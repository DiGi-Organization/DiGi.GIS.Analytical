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

            // The roads flattened into segments, each carrying the index of its polyline.
            List<(int RoadIndex, double X1, double Y1, double X2, double Y2)> segments_Road = [];
            for (int i = 0; i < polyline2Ds.Count; i++)
            {
                List<Segment2D>? segment2Ds = polyline2Ds[i].GetSegments();
                if (segment2Ds is null)
                {
                    continue;
                }

                foreach (Segment2D segment2D in segment2Ds)
                {
                    if (segment2D.Start is Point2D point2D_Start_Road && segment2D.End is Point2D point2D_End_Road)
                    {
                        segments_Road.Add((i, point2D_Start_Road.X, point2D_Start_Road.Y, point2D_End_Road.X, point2D_End_Road.Y));
                    }
                }
            }

            if (segments_Road.Count == 0)
            {
                return null;
            }

            // TODO [ParallelSegmentDistance]: remove this local helper and call Geometry.Planar.Query.Distance(segment2D, polyline2D, out point2D_Wall, out point2D_Road, tolerance) once DiGi-Organization/DiGi.Geometry#11 ships a segment distance that returns the closest points for parallel segments instead of NaN.
            static void ClosestPoints(
                double startX_1,
                double startY_1,
                double endX_1,
                double endY_1,
                double startX_2,
                double startY_2,
                double endX_2,
                double endY_2,
                out double closestX_1,
                out double closestY_1,
                out double closestX_2,
                out double closestY_2)
            {
                static void ClosestOnSegment(double pointX, double pointY, double startX, double startY, double endX, double endY, out double closestX, out double closestY)
                {
                    double vectorX = endX - startX;
                    double vectorY = endY - startY;
                    double lengthSquared = (vectorX * vectorX) + (vectorY * vectorY);
                    double parameter = lengthSquared <= 0 ? 0 : ((((pointX - startX) * vectorX) + ((pointY - startY) * vectorY)) / lengthSquared);
                    if (parameter < 0)
                    {
                        parameter = 0;
                    }
                    else if (parameter > 1)
                    {
                        parameter = 1;
                    }

                    closestX = startX + (parameter * vectorX);
                    closestY = startY + (parameter * vectorY);
                }

                double vectorX_1 = endX_1 - startX_1;
                double vectorY_1 = endY_1 - startY_1;
                double vectorX_2 = endX_2 - startX_2;
                double vectorY_2 = endY_2 - startY_2;

                double cross_1 = (vectorX_1 * (startY_2 - startY_1)) - (vectorY_1 * (startX_2 - startX_1));
                double cross_2 = (vectorX_1 * (endY_2 - startY_1)) - (vectorY_1 * (endX_2 - startX_1));
                double cross_3 = (vectorX_2 * (startY_1 - startY_2)) - (vectorY_2 * (startX_1 - startX_2));
                double cross_4 = (vectorX_2 * (endY_1 - startY_2)) - (vectorY_2 * (endX_1 - startX_2));

                if (((cross_1 > 0 && cross_2 < 0) || (cross_1 < 0 && cross_2 > 0)) && ((cross_3 > 0 && cross_4 < 0) || (cross_3 < 0 && cross_4 > 0)))
                {
                    // The segments cross: the intersection is the closest pair.
                    double denominator = (vectorX_1 * vectorY_2) - (vectorY_1 * vectorX_2);
                    double parameter = (((startX_2 - startX_1) * vectorY_2) - ((startY_2 - startY_1) * vectorX_2)) / denominator;
                    closestX_1 = startX_1 + (parameter * vectorX_1);
                    closestY_1 = startY_1 + (parameter * vectorY_1);
                    closestX_2 = closestX_1;
                    closestY_2 = closestY_1;
                    return;
                }

                // No crossing: the closest pair of two segments has at least one endpoint in it,
                // so the four endpoint-to-segment projections cover the parallel case as well.
                double bestSquared = double.MaxValue;
                double bestX_1 = startX_1;
                double bestY_1 = startY_1;
                double bestX_2 = startX_1;
                double bestY_2 = startY_1;

                void Consider(bool pointOnFirst, double pointX, double pointY, double startX, double startY, double endX, double endY)
                {
                    ClosestOnSegment(pointX, pointY, startX, startY, endX, endY, out double closestX, out double closestY);
                    double distanceSquared = ((closestX - pointX) * (closestX - pointX)) + ((closestY - pointY) * (closestY - pointY));
                    if (distanceSquared < bestSquared)
                    {
                        bestSquared = distanceSquared;
                        if (pointOnFirst)
                        {
                            bestX_1 = pointX;
                            bestY_1 = pointY;
                            bestX_2 = closestX;
                            bestY_2 = closestY;
                        }
                        else
                        {
                            bestX_1 = closestX;
                            bestY_1 = closestY;
                            bestX_2 = pointX;
                            bestY_2 = pointY;
                        }
                    }
                }

                Consider(true, startX_1, startY_1, startX_2, startY_2, endX_2, endY_2);
                Consider(true, endX_1, endY_1, startX_2, startY_2, endX_2, endY_2);
                Consider(false, startX_2, startY_2, startX_1, startY_1, endX_1, endY_1);
                Consider(false, endX_2, endY_2, startX_1, startY_1, endX_1, endY_1);

                closestX_1 = bestX_1;
                closestY_1 = bestY_1;
                closestX_2 = bestX_2;
                closestY_2 = bestY_2;
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
                    (int RoadIndex, double X1, double Y1, double X2, double Y2) segment_Road = segments_Road[i];
                    ClosestPoints(point2D_Start.X, point2D_Start.Y, point2D_End.X, point2D_End.Y, segment_Road.X1, segment_Road.Y1, segment_Road.X2, segment_Road.Y2, out double wallX, out double wallY, out double roadX, out double roadY);

                    double distance_Road = Math.Sqrt(((roadX - wallX) * (roadX - wallX)) + ((roadY - wallY) * (roadY - wallY)));
                    if (double.IsNaN(distance_Road) || distance_Road > distance + tolerance)
                    {
                        continue;
                    }

                    // The road must reach the strip: on the outward side of the wall face, between the wall's ends.
                    if ((((roadX - wallX) * normalX) + ((roadY - wallY) * normalY)) < -tolerance)
                    {
                        continue;
                    }

                    double parameter = (((roadX - point2D_Start.X) * directionX) + ((roadY - point2D_Start.Y) * directionY));
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
