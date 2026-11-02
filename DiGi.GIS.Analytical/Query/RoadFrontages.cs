using DiGi.Analytical.Building.Classes;
using DiGi.Analytical.Building.Interfaces;
using DiGi.Core.Classes;
using DiGi.Geometry.Planar.Classes;
using DiGi.Geometry.Spatial.Classes;
using DiGi.GIS.Classes;
using System;
using System.Collections.Generic;

namespace DiGi.GIS.Analytical
{
    public static partial class Query
    {
        /// <summary>
        /// Finds the walls of a building model that front a road: the external walls whose facing strip of <c>OpeningGenerationOptions.RoadFrontageDistance</c> a road polyline reaches (DiGi-Organization/DiGi.GIS.Analytical#10).
        /// <para>The strip stands in for the neighbouring plot of § 12 ust. 10 of the technical conditions of 2002 (Dz.U. 2002 nr 75 poz. 690), in the wording added by Dz.U. 2023 poz. 2442: the distances of ust. 1-9 are not required when the neighbouring plot is a road plot or a publicly accessible square. A road polyline counts only when it comes within the distance of the wall face on the outward side and between the wall's ends, so a road behind the building or past its corner does not mark the wall. The models are not changed.</para>
        /// </summary>
        /// <param name="buildingModel">The building model whose walls are probed.</param>
        /// <param name="polyline2Ds_Road">The road polylines, in the order the caller gives them; the index is kept on the result. This value can be null.</param>
        /// <param name="options">The rules to apply, or null for the defaults.</param>
        /// <param name="tolerance">The distance tolerance.</param>
        /// <returns>The road frontage of every external wall that reaches a road, keyed by the wall identifier, walls ordered by their identifier; null when the model is null or there is no road context.</returns>
        public static Dictionary<Guid, RoadFrontage>? RoadFrontages(this BuildingModel? buildingModel, IEnumerable<Polyline2D>? polyline2Ds_Road, OpeningGenerationOptions? options = null, double tolerance = Core.Constants.Tolerance.Distance)
        {
            if (buildingModel is null || polyline2Ds_Road is null)
            {
                return null;
            }

            List<Polyline2D> polyline2Ds = [];
            foreach (Polyline2D polyline2D in polyline2Ds_Road)
            {
                if (polyline2D is not null)
                {
                    polyline2Ds.Add(polyline2D);
                }
            }

            if (polyline2Ds.Count == 0)
            {
                return null;
            }

            // The roads flattened into segments, each carrying the index of its polyline, built once for every wall.
            List<(int RoadIndex, Segment2D Segment2D)> segments_Road = [];
            for (int i = 0; i < polyline2Ds.Count; i++)
            {
                List<Segment2D>? segment2Ds = polyline2Ds[i].GetSegments();
                if (segment2Ds is null)
                {
                    continue;
                }

                foreach (Segment2D segment2D in segment2Ds)
                {
                    if (segment2D.Start is not null && segment2D.End is not null)
                    {
                        segments_Road.Add((i, segment2D));
                    }
                }
            }

            if (segments_Road.Count == 0)
            {
                return null;
            }

            double distance = (options ?? new OpeningGenerationOptions()).RoadFrontageDistance;

            Dictionary<Guid, DiGi.Analytical.Classes.Face> faces = [];
            List<DiGi.Analytical.Classes.Face>? faces_Shell = buildingModel.GetExternalShell(Geometry.Core.Enums.Side.External, tolerance: tolerance)?.PolygonalFaces;
            if (faces_Shell is not null)
            {
                foreach (DiGi.Analytical.Classes.Face face in faces_Shell)
                {
                    if (face.UniqueReference is GuidReference guidReference && !faces.ContainsKey(guidReference.Guid))
                    {
                        faces[guidReference.Guid] = face;
                    }
                }
            }

            if (faces.Count == 0)
            {
                return [];
            }

            List<IWall> walls = buildingModel.GetComponents<IWall>() ?? [];
            walls.Sort((x, y) => x.Guid.CompareTo(y.Guid));

            Dictionary<Guid, RoadFrontage> result = [];
            foreach (IWall wall in walls)
            {
                if (!faces.TryGetValue(wall.Guid, out DiGi.Analytical.Classes.Face? face) || face.Plane?.Normal?.Unit is not Vector3D vector3D_Normal || face.ExternalEdge?.GetPoints() is not List<Point3D> point3Ds || point3Ds.Count < 3)
                {
                    continue;
                }

                Vector3D? vector3D_Horizontal = new Vector3D(vector3D_Normal.X, vector3D_Normal.Y, 0).Unit;
                if (vector3D_Horizontal is null)
                {
                    continue;
                }

                // The wall's footprint line: the first projected point and the point farthest from it.
                Point2D point2D_Start = new(point3Ds[0].X, point3Ds[0].Y);
                Point2D point2D_End = point2D_Start;
                double lengthSquared = 0;
                foreach (Point3D point3D in point3Ds)
                {
                    double x = point3D.X - point2D_Start.X;
                    double y = point3D.Y - point2D_Start.Y;
                    double lengthSquared_Temp = (x * x) + (y * y);
                    if (lengthSquared_Temp > lengthSquared)
                    {
                        lengthSquared = lengthSquared_Temp;
                        point2D_End = new Point2D(point3D.X, point3D.Y);
                    }
                }

                if (lengthSquared <= (tolerance * tolerance))
                {
                    continue;
                }

                double length = Math.Sqrt(lengthSquared);
                double directionX = (point2D_End.X - point2D_Start.X) / length;
                double directionY = (point2D_End.Y - point2D_Start.Y) / length;
                double normalX = vector3D_Horizontal.X;
                double normalY = vector3D_Horizontal.Y;

                Segment2D segment2D = new(point2D_Start, point2D_End);

                int index_Road = -1;
                double setback = double.NaN;
                for (int i = 0; i < segments_Road.Count; i++)
                {
                    (int RoadIndex, Segment2D Segment2D) segment_Road = segments_Road[i];
                    double distance_Road = Geometry.Planar.Query.Distance(segment2D, segment_Road.Segment2D, out Point2D? point2D_Wall, out Point2D? point2D_Road, tolerance);
                    if (double.IsNaN(distance_Road) || point2D_Wall is null || point2D_Road is null || distance_Road > distance + tolerance)
                    {
                        continue;
                    }

                    // The road must reach the strip: on the outward side of the wall face, between the wall's ends.
                    if ((((point2D_Road.X - point2D_Wall.X) * normalX) + ((point2D_Road.Y - point2D_Wall.Y) * normalY)) < -tolerance)
                    {
                        continue;
                    }

                    double parameter = (((point2D_Road.X - point2D_Start.X) * directionX) + ((point2D_Road.Y - point2D_Start.Y) * directionY));
                    if (parameter < -tolerance || parameter > length + tolerance)
                    {
                        continue;
                    }

                    if (index_Road == -1 || distance_Road < setback)
                    {
                        index_Road = segment_Road.RoadIndex;
                        setback = distance_Road;
                    }
                }

                if (index_Road != -1)
                {
                    result[wall.Guid] = new RoadFrontage(index_Road, setback, segment2D, new Vector2D(normalX, normalY));
                }
            }

            return result;
        }
    }
}
