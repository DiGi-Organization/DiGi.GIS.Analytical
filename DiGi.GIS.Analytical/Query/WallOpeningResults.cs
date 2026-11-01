using DiGi.Analytical.Building.Classes;
using DiGi.Analytical.Building.Enums;
using DiGi.Analytical.Building.Interfaces;
using DiGi.Core.Classes;
using DiGi.Core.Parameter.Classes;
using DiGi.Geometry.Spatial.Classes;
using DiGi.GIS.Analytical.Enums;
using DiGi.GIS.Classes;
using DiGi.GIS.Enums;
using System;
using System.Collections.Generic;
using PlanarEdge = (double X1, double Y1, double X2, double Y2);
using NeighbourWall = (double X1, double Y1, double X2, double Y2, double MidX, double MidY, double Nx, double Ny, System.Guid Wall);
using PlanarSegment = (bool Ok, double X1, double Y1, double X2, double Y2, double MidX, double MidY, double Nx, double Ny, double Start, double End, double Offset, double Dx, double Dy);
using ObstructionSource = (System.Collections.Generic.List<(double X1, double Y1, double X2, double Y2)> Edges, double Top, bool Self);

namespace DiGi.GIS.Analytical
{
    public static partial class Query
    {
        /// <summary>
        /// Gets, for every external wall of a building model, why it may carry no openings under the neighbour rules of the opening generation, and the distances measured behind that decision: § 271 fire separation and § 13 daylight obstruction (DiGi-Organization/DiGi.GIS.Analytical#9).
        /// <para><b>§ 271 fire separation.</b> Each external wall that is not a party wall (a fire-separation wall is excluded by ust. 1) is compared with every wall of a neighbour model within reach. A pair counts when the walls mutually face each other, judged at their midpoints, and the angle between the wall planes on the side of the gap is read from their outward normals: parallel facing walls give 0 deg and the full distance, 60 deg to less than 120 deg halves it (ust. 11), at 120 deg and above the rule does not apply (ust. 12 pkt 2). The required distance is the larger value of the § 271 table for the two <see cref="FireClass"/> kinds, taken through the local <c>FireSeparationBase</c> and multiplied by the spread factors of ust. 2, the no-openings factor of ust. 9 when both facing walls carry openings-free walls and neither building spreads fire, and the half-strip factor. The wall fails when the measured distance falls short, and it then gets no openings at all. Not modelled, as the stock data carries none of it: the E-class surface precondition of ust. 1, explosion-hazard rooms (ust. 3), the E-class coverage factors of ust. 4-5 and the sprinkler reductions of ust. 6-7; see also <see cref="OpeningGenerationOptions.FireSeparationNoOpeningsFactor"/> for what of ust. 9 is reached.</para>
        /// <para><b>§ 13 daylight obstruction.</b> On each window axis - both ends of the usable wall length, its midpoint, and the axis of each neighbour's point nearest the wall - a horizontal sector of <see cref="OpeningGenerationOptions.ObstructionSectorAngle"/> opens from the wall line, bisected by the outward normal. Every part of a neighbour's solid, and every other part of the same building, that falls inside the sector must be at least its height of shading away: the obstructing top minus the lowest window sill, taken as the ground elevation plus <see cref="OpeningGenerationOptions.SillHeight"/>, capped at <see cref="OpeningGenerationOptions.ObstructionMaxDistance"/>; a slender object of <see cref="OpeningGenerationOptions.ObstructionSlenderWidth"/> or less measured parallel to the wall instead answers to <see cref="OpeningGenerationOptions.ObstructionSlenderDistance"/> (§ 13 ust. 3), and <see cref="OpeningGenerationOptions.ObstructionInnerCityFactor"/> reduces the result. The wall fails when any axis violates the requirement, and it then gets no windows of rooms for people, doors and the staircase window staying allowed. Distances are measured from the wall plane: a wall with thickness moves the inner face of the statute inward, which only widens the measured distance, so the stricter value is taken here.</para>
        /// <para>Neighbours with the identifier of the model are skipped, so the model may be passed in its own neighbour list, and only those whose bounding box comes within <c>max(<see cref="OpeningGenerationOptions.ObstructionMaxDistance"/>, the largest § 271 distance times the both-sides factor)</c> are measured. The models themselves are not changed. The overload taking 2D buildings derives each neighbour's height from its storey count at <see cref="Constants.StoreyHeight.Default"/>, and its kind from its function; a model-only neighbour has no function, so with a fuel load stated it takes the row that load describes.</para>
        /// </summary>
        /// <param name="buildingModel">The building model examined. This value can be null.</param>
        /// <param name="buildingModels_Neighbour">The building models of the adjacent buildings, which get no results themselves. A model with the identifier of the examined one is skipped. This value can be null.</param>
        /// <param name="options">The rules to apply, or null for the defaults of <see cref="OpeningGenerationOptions"/>.</param>
        /// <param name="buildingGeneralFunction">The general function of the examined building, giving its <see cref="FireClass"/>, or null when unknown.</param>
        /// <param name="tolerance">The distance tolerance.</param>
        /// <returns>One result per external wall that is not a party wall, in envelope order; an empty list when the model has none; or null when the model is null.</returns>
        public static List<WallOpeningResult>? WallOpeningResults(this BuildingModel? buildingModel, IEnumerable<BuildingModel?>? buildingModels_Neighbour, OpeningGenerationOptions? options, BuildingGeneralFunction? buildingGeneralFunction = null, double tolerance = Core.Constants.Tolerance.Distance)
        {
            if (buildingModel is null)
            {
                return null;
            }

            OpeningGenerationOptions openingGenerationOptions = options ?? new OpeningGenerationOptions();

            List<WallOpeningResult> result = [];

            List<DiGi.Analytical.Classes.Face>? faces = buildingModel.GetExternalShell(Geometry.Core.Enums.Side.External, tolerance: tolerance)?.PolygonalFaces;
            if (faces is null || faces.Count == 0)
            {
                return result;
            }

            BoundingBox3D? boundingBox3D = buildingModel.GetBoundingBox();
            double groundZ = boundingBox3D?.Min?.Z ?? 0;

            // ---- helpers: planar geometry, the angle sector, and the rule values ----

            static double Cross(double x1, double y1, double x2, double y2)
            {
                return (x1 * y2) - (y1 * x2);
            }

            static double PointSegmentDistance(double pointX, double pointY, double startX, double startY, double endX, double endY)
            {
                double edgeX = endX - startX;
                double edgeY = endY - startY;
                double lengthSquared = (edgeX * edgeX) + (edgeY * edgeY);
                if (lengthSquared <= 0)
                {
                    return Math.Sqrt(((pointX - startX) * (pointX - startX)) + ((pointY - startY) * (pointY - startY)));
                }

                double t = (((pointX - startX) * edgeX) + ((pointY - startY) * edgeY)) / lengthSquared;
                if (t < 0)
                {
                    t = 0;
                }
                else if (t > 1)
                {
                    t = 1;
                }

                double differenceX = pointX - (startX + (t * edgeX));
                double differenceY = pointY - (startY + (t * edgeY));
                return Math.Sqrt((differenceX * differenceX) + (differenceY * differenceY));
            }

            static double SegmentDistance(double aX1, double aY1, double aX2, double aY2, double bX1, double bY1, double bX2, double bY2)
            {
                double d1 = Cross(bX2 - bX1, bY2 - bY1, aX1 - bX1, aY1 - bY1);
                double d2 = Cross(bX2 - bX1, bY2 - bY1, aX2 - bX1, aY2 - bY1);
                double d3 = Cross(aX2 - aX1, aY2 - aY1, bX1 - aX1, bY1 - aY1);
                double d4 = Cross(aX2 - aX1, aY2 - aY1, bX2 - aX1, bY2 - aY1);
                if (((d1 > 0 && d2 < 0) || (d1 < 0 && d2 > 0)) && ((d3 > 0 && d4 < 0) || (d3 < 0 && d4 > 0)))
                {
                    return 0;
                }

                return Math.Min(
                    Math.Min(PointSegmentDistance(aX1, aY1, bX1, bY1, bX2, bY2), PointSegmentDistance(aX2, aY2, bX1, bY1, bX2, bY2)),
                    Math.Min(PointSegmentDistance(bX1, bY1, aX1, aY1, aX2, aY2), PointSegmentDistance(bX2, bY2, aX1, aY1, aX2, aY2)));
            }

            // Keeps the part of the parameter range where the linear functional c + m * t stays at or below zero.
            static bool ClipHalf(double c, double m, ref double low, ref double high)
            {
                if (m > 0)
                {
                    double t = -c / m;
                    if (t < high)
                    {
                        high = t;
                    }
                }
                else if (m < 0)
                {
                    double t = -c / m;
                    if (t > low)
                    {
                        low = t;
                    }
                }
                else if (c > 0)
                {
                    return false;
                }

                return low <= high;
            }

            // Clips the segment to the sector between dir1 and dir2 (both counter-clockwise around the opening, arms inclusive).
            static bool ClipWedge(double x1, double y1, double x2, double y2, double vertexX, double vertexY, double dir1X, double dir1Y, double dir2X, double dir2Y, out double low, out double high)
            {
                low = 0;
                high = 1;

                double c1 = (dir1X * (y1 - vertexY)) - (dir1Y * (x1 - vertexX));
                double m1 = (dir1X * (y2 - y1)) - (dir1Y * (x2 - x1));
                if (!ClipHalf(c1, m1, ref low, ref high))
                {
                    return false;
                }

                double c2 = ((x1 - vertexX) * dir2Y) - ((y1 - vertexY) * dir2X);
                double m2 = ((x2 - x1) * dir2Y) - ((y2 - y1) * dir2X);
                return ClipHalf(c2, m2, ref low, ref high);
            }

            // The distance from the vertex to the clipped part of the edge.
            static double ClippedDistance(double startX, double startY, double edgeX, double edgeY, double low, double high, double vertexX, double vertexY)
            {
                double lengthSquared = (edgeX * edgeX) + (edgeY * edgeY);
                double t = lengthSquared > 0 ? (((vertexX - startX) * edgeX) + ((vertexY - startY) * edgeY)) / lengthSquared : 0;
                if (t < low)
                {
                    t = low;
                }
                else if (t > high)
                {
                    t = high;
                }

                double differenceX = vertexX - (startX + (t * edgeX));
                double differenceY = vertexY - (startY + (t * edgeY));
                return Math.Sqrt((differenceX * differenceX) + (differenceY * differenceY));
            }

            // Projects a wall face onto the plan: the line it stands on, oriented by the outward normal of the face.
            PlanarSegment PlanSegment(List<Point3D>? point3Ds, Vector3D? normal)
            {
                PlanarSegment planarSegment = (false, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
                if (point3Ds is null || point3Ds.Count < 3 || normal is null)
                {
                    return planarSegment;
                }

                double length = Math.Sqrt((normal.X * normal.X) + (normal.Y * normal.Y));
                if (length < 1e-9)
                {
                    return planarSegment;
                }

                double nx = normal.X / length;
                double ny = normal.Y / length;
                double dx = -ny;
                double dy = nx;

                double start = double.MaxValue;
                double end = double.MinValue;
                double offset = 0;
                foreach (Point3D point3D in point3Ds)
                {
                    double s = (point3D.X * dx) + (point3D.Y * dy);
                    start = Math.Min(start, s);
                    end = Math.Max(end, s);
                    offset += (point3D.X * nx) + (point3D.Y * ny);
                }

                offset /= point3Ds.Count;
                if (end - start <= tolerance)
                {
                    return planarSegment;
                }

                double middle = (start + end) / 2;
                return (
                    true,
                    (dx * start) + (nx * offset), (dy * start) + (ny * offset),
                    (dx * end) + (nx * offset), (dy * end) + (ny * offset),
                    (dx * middle) + (nx * offset), (dy * middle) + (ny * offset),
                    nx, ny,
                    start, end, offset, dx, dy);
            }

            // The ring of a face projected onto the plan, degenerate pairs dropped.
            List<PlanarEdge> Edges(List<Point3D>? point3Ds)
            {
                List<PlanarEdge> result_Edges = [];
                if (point3Ds is null || point3Ds.Count < 2)
                {
                    return result_Edges;
                }

                for (int i = 0; i < point3Ds.Count; i++)
                {
                    Point3D point3D_Start = point3Ds[i];
                    Point3D point3D_End = point3Ds[(i + 1) % point3Ds.Count];
                    if (Math.Sqrt(((point3D_End.X - point3D_Start.X) * (point3D_End.X - point3D_Start.X)) + ((point3D_End.Y - point3D_Start.Y) * (point3D_End.Y - point3D_Start.Y))) > tolerance)
                    {
                        result_Edges.Add((point3D_Start.X, point3D_Start.Y, point3D_End.X, point3D_End.Y));
                    }
                }

                return result_Edges;
            }

            static bool IsPartyWall(IWall? wall)
            {
                return wall is Component component && component.TryGetValue(new EnumParameterDefinition(ComponentParameter.PartyWall), out Guid _);
            }

            static bool Spreads(BuildingModel? buildingModel_Temp)
            {
                return buildingModel_Temp is not null && buildingModel_Temp.TryGetValue(new EnumParameterDefinition(BuildingModelParameter.FireSpreading), out bool value) && value;
            }

            static bool HasOpenings(BuildingModel? buildingModel_Temp, IWall? wall)
            {
                return buildingModel_Temp is not null && wall is not null && buildingModel_Temp.GetOpenings<IOpening>(wall) is List<IOpening> openings && openings.Count > 0;
            }

            // The distance of the § 271 table for one kind of building: the Q row for PM and for an unknown kind, the class row for ZL and IN; NaN switches the rule off.
            double FireSeparationBase(Enums.FireClass? fireClass)
            {
                Dictionary<Enums.FireClass, double>? distances = openingGenerationOptions.FireSeparationDistances;
                if (distances is null || distances.Count == 0)
                {
                    return double.NaN;
                }

                if (fireClass != Enums.FireClass.ZL && fireClass != Enums.FireClass.IN && openingGenerationOptions.FireSeparationHeatRelease is double heatRelease)
                {
                    if (heatRelease > 4000)
                    {
                        return openingGenerationOptions.FireSeparationDistancePMHigh;
                    }

                    if (heatRelease > 1000)
                    {
                        return openingGenerationOptions.FireSeparationDistancePMMid;
                    }
                }

                if (fireClass is Enums.FireClass fireClass_Value && distances.TryGetValue(fireClass_Value, out double value))
                {
                    return value;
                }

                // A kind missing from an edited table, or a building of unknown kind with no fuel load stated: the largest value present.
                double result_Value = double.MinValue;
                foreach (KeyValuePair<Enums.FireClass, double> keyValuePair in distances)
                {
                    if (!double.IsNaN(keyValuePair.Value) && keyValuePair.Value > result_Value)
                    {
                        result_Value = keyValuePair.Value;
                    }
                }

                return result_Value == double.MinValue ? double.NaN : result_Value;
            }

            // How far a neighbour may be and still be measured by either rule.
            double MaxDistance()
            {
                double result_MaxDistance = openingGenerationOptions.ObstructionMaxDistance;
                Dictionary<Enums.FireClass, double>? distances = openingGenerationOptions.FireSeparationDistances;
                if (distances is null || distances.Count == 0)
                {
                    // § 271 is off, so only the § 13 cap decides.
                    return result_MaxDistance;
                }

                double maxFire = double.MinValue;
                foreach (KeyValuePair<Enums.FireClass, double> keyValuePair in distances)
                {
                    if (!double.IsNaN(keyValuePair.Value) && keyValuePair.Value > maxFire)
                    {
                        maxFire = keyValuePair.Value;
                    }
                }

                if (openingGenerationOptions.FireSeparationDistancePMMid > maxFire && !double.IsNaN(openingGenerationOptions.FireSeparationDistancePMMid))
                {
                    maxFire = openingGenerationOptions.FireSeparationDistancePMMid;
                }

                if (openingGenerationOptions.FireSeparationDistancePMHigh > maxFire && !double.IsNaN(openingGenerationOptions.FireSeparationDistancePMHigh))
                {
                    maxFire = openingGenerationOptions.FireSeparationDistancePMHigh;
                }

                if (maxFire == double.MinValue)
                {
                    return result_MaxDistance;
                }

                return Math.Max(result_MaxDistance, maxFire * openingGenerationOptions.FireSeparationSpreadFactor_BothSides);
            }

            // ---- subject walls ----

            Dictionary<Guid, IWall> dictionary_Wall = [];
            foreach (IWall wall_Temp in buildingModel.GetComponents<IWall>() ?? [])
            {
                dictionary_Wall[wall_Temp.Guid] = wall_Temp;
            }

            Enums.FireClass? fireClass_Subject = buildingGeneralFunction.FireClass();

            // The subject's own other faces are obstructions too (§ 13 covers a part of the same building);
            // the host line itself is dropped per axis below, where its distance to the vertex is zero.
            List<ObstructionSource> obstructionSources = [];
            foreach (DiGi.Analytical.Classes.Face face_Temp in faces)
            {
                List<Point3D>? point3Ds_Temp = face_Temp.ExternalEdge?.GetPoints();
                List<PlanarEdge> edges_Temp = Edges(point3Ds_Temp);
                if (edges_Temp.Count == 0)
                {
                    continue;
                }

                double top_Temp = double.MinValue;
                foreach (Point3D point3D_Temp in point3Ds_Temp!)
                {
                    top_Temp = Math.Max(top_Temp, point3D_Temp.Z);
                }

                obstructionSources.Add((edges_Temp, top_Temp, true));
            }

            // ---- neighbours in reach ----

            double maxDistance_Candidate = MaxDistance();
            List<BuildingModel> buildingModels = [];
            HashSet<Guid> guids = [buildingModel.Guid];
            if (buildingModels_Neighbour is not null && boundingBox3D is not null)
            {
                foreach (BuildingModel? buildingModel_Neighbour in buildingModels_Neighbour)
                {
                    if (buildingModel_Neighbour is not null && guids.Add(buildingModel_Neighbour.Guid) && buildingModel_Neighbour.GetBoundingBox() is BoundingBox3D boundingBox3D_Neighbour && boundingBox3D.InRange(boundingBox3D_Neighbour, maxDistance_Candidate))
                    {
                        buildingModels.Add(buildingModel_Neighbour);
                    }
                }
            }

            int count = buildingModels.Count;
            List<List<NeighbourWall>> neighbourWalls = [];
            List<List<PlanarEdge>> neighbourEdges = [];
            List<Dictionary<Guid, IWall>> neighbourWallComponents = [];
            List<bool> neighbourSpreads = [];

            for (int i = 0; i < count; i++)
            {
                BuildingModel buildingModel_Neighbour = buildingModels[i];
                List<NeighbourWall> walls_Neighbour = [];
                Dictionary<Guid, IWall> dictionary_Wall_Neighbour = [];
                foreach (IWall wall_Temp in buildingModel_Neighbour.GetComponents<IWall>() ?? [])
                {
                    dictionary_Wall_Neighbour[wall_Temp.Guid] = wall_Temp;
                }

                double top_Neighbour = buildingModel_Neighbour.GetBoundingBox()?.Max?.Z ?? 0;
                List<PlanarEdge> edges_Neighbour = [];

                List<DiGi.Analytical.Classes.Face>? faces_Neighbour = buildingModel_Neighbour.GetExternalShell(Geometry.Core.Enums.Side.External, tolerance: tolerance)?.PolygonalFaces;
                if (faces_Neighbour is not null)
                {
                    foreach (DiGi.Analytical.Classes.Face face_Neighbour in faces_Neighbour)
                    {
                        List<Point3D>? point3Ds_Neighbour = face_Neighbour.ExternalEdge?.GetPoints();
                        if (point3Ds_Neighbour is null || point3Ds_Neighbour.Count < 3)
                        {
                            continue;
                        }

                        foreach (Point3D point3D_Neighbour in point3Ds_Neighbour)
                        {
                            top_Neighbour = Math.Max(top_Neighbour, point3D_Neighbour.Z);
                        }

                        edges_Neighbour.AddRange(Edges(point3Ds_Neighbour));

                        PlanarSegment planarSegment_Neighbour = PlanSegment(point3Ds_Neighbour, face_Neighbour.Plane?.Normal);
                        if (!planarSegment_Neighbour.Ok || face_Neighbour.UniqueReference is not GuidReference guidReference_Neighbour)
                        {
                            continue;
                        }

                        if (dictionary_Wall_Neighbour.TryGetValue(guidReference_Neighbour.Guid, out IWall? wall_Neighbour) && !IsPartyWall(wall_Neighbour))
                        {
                            walls_Neighbour.Add((planarSegment_Neighbour.X1, planarSegment_Neighbour.Y1, planarSegment_Neighbour.X2, planarSegment_Neighbour.Y2, planarSegment_Neighbour.MidX, planarSegment_Neighbour.MidY, planarSegment_Neighbour.Nx, planarSegment_Neighbour.Ny, guidReference_Neighbour.Guid));
                        }
                    }
                }

                if (edges_Neighbour.Count == 0 && buildingModel_Neighbour.GetBoundingBox() is BoundingBox3D boundingBox3D_Neighbour)
                {
                    // No envelope to read: the bounding box still stands in for the mass.
                    edges_Neighbour.Add((boundingBox3D_Neighbour.Min!.X, boundingBox3D_Neighbour.Min.Y, boundingBox3D_Neighbour.Max!.X, boundingBox3D_Neighbour.Min.Y));
                    edges_Neighbour.Add((boundingBox3D_Neighbour.Max.X, boundingBox3D_Neighbour.Min.Y, boundingBox3D_Neighbour.Max.X, boundingBox3D_Neighbour.Max.Y));
                    edges_Neighbour.Add((boundingBox3D_Neighbour.Max.X, boundingBox3D_Neighbour.Max.Y, boundingBox3D_Neighbour.Min.X, boundingBox3D_Neighbour.Max.Y));
                    edges_Neighbour.Add((boundingBox3D_Neighbour.Min.X, boundingBox3D_Neighbour.Max.Y, boundingBox3D_Neighbour.Min.X, boundingBox3D_Neighbour.Min.Y));
                }

                neighbourWalls.Add(walls_Neighbour);
                neighbourEdges.Add(edges_Neighbour);
                neighbourWallComponents.Add(dictionary_Wall_Neighbour);
                neighbourSpreads.Add(Spreads(buildingModel_Neighbour));
                obstructionSources.Add((edges_Neighbour, top_Neighbour, false));
            }

            // ---- one result per external wall ----

            HashSet<Guid> guids_Wall = [];
            foreach (DiGi.Analytical.Classes.Face face in faces)
            {
                if (face.UniqueReference is not GuidReference guidReference || !dictionary_Wall.TryGetValue(guidReference.Guid, out IWall? wall) || !guids_Wall.Add(wall.Guid) || IsPartyWall(wall))
                {
                    continue;
                }

                PlanarSegment planarSegment = PlanSegment(face.ExternalEdge?.GetPoints(), face.Plane?.Normal);
                if (!planarSegment.Ok)
                {
                    continue;
                }

                bool hasOpenings = HasOpenings(buildingModel, wall);

                // § 271: the nearest mutually facing wall of a neighbour decides.
                bool fireApplicable = false;
                bool fireExempt = false;
                double fireDeficit = double.MinValue;
                double fireDistance = double.NaN;
                double fireRequired = double.NaN;
                double exemptDistance = double.PositiveInfinity;

                for (int i = 0; i < count; i++)
                {
                    bool spreads_Neighbour = neighbourSpreads[i];
                    foreach (NeighbourWall neighbourWall in neighbourWalls[i])
                    {
                        double towardsX = neighbourWall.MidX - planarSegment.MidX;
                        double towardsY = neighbourWall.MidY - planarSegment.MidY;
                        if (((planarSegment.Nx * towardsX) + (planarSegment.Ny * towardsY)) <= 0 || ((neighbourWall.Nx * -towardsX) + (neighbourWall.Ny * -towardsY)) <= 0)
                        {
                            continue;
                        }

                        double distance = SegmentDistance(planarSegment.X1, planarSegment.Y1, planarSegment.X2, planarSegment.Y2, neighbourWall.X1, neighbourWall.Y1, neighbourWall.X2, neighbourWall.Y2);
                        double dot = (planarSegment.Nx * neighbourWall.Nx) + (planarSegment.Ny * neighbourWall.Ny);
                        double angle = Math.Acos(Math.Max(-1, Math.Min(1, dot))) * (180 / Math.PI);
                        double theta = 180 - angle;

                        if (theta >= openingGenerationOptions.FireSeparationNoApplyAngle)
                        {
                            if (distance < exemptDistance)
                            {
                                exemptDistance = distance;
                            }

                            fireExempt = true;
                            continue;
                        }

                        double required = Math.Max(FireSeparationBase(fireClass_Subject), FireSeparationBase(null));
                        if (double.IsNaN(required))
                        {
                            continue;
                        }

                        int spreadCount = (Spreads(buildingModel) ? 1 : 0) + (spreads_Neighbour ? 1 : 0);
                        if (spreadCount == 1)
                        {
                            required *= openingGenerationOptions.FireSeparationSpreadFactor_OneSide;
                        }
                        else if (spreadCount >= 2)
                        {
                            required *= openingGenerationOptions.FireSeparationSpreadFactor_BothSides;
                        }

                        if (!hasOpenings && spreadCount == 0 && neighbourWallComponents[i].TryGetValue(neighbourWall.Wall, out IWall? wall_Neighbour) && !HasOpenings(buildingModels[i], wall_Neighbour))
                        {
                            required *= openingGenerationOptions.FireSeparationNoOpeningsFactor;
                        }

                        if (theta >= openingGenerationOptions.FireSeparationHalfStripAngle)
                        {
                            required *= 0.5;
                        }

                        double deficit = required - distance;
                        if (!fireApplicable || deficit > fireDeficit)
                        {
                            fireApplicable = true;
                            fireDeficit = deficit;
                            fireDistance = distance;
                            fireRequired = required;
                        }
                    }
                }

                // § 13: the sector on each window axis, over the neighbours and the rest of the same building.
                double usableStart = planarSegment.Start + openingGenerationOptions.CornerMargin;
                double usableEnd = planarSegment.End - openingGenerationOptions.CornerMargin;
                List<double> axisParameters = [];
                if (usableEnd - usableStart < tolerance)
                {
                    axisParameters.Add((planarSegment.Start + planarSegment.End) / 2);
                }
                else
                {
                    axisParameters.Add(usableStart);
                    axisParameters.Add((planarSegment.Start + planarSegment.End) / 2);
                    axisParameters.Add(usableEnd);
                }

                for (int i = 0; i < count; i++)
                {
                    // The axis of the neighbour's point nearest the wall line, clamped to the usable length.
                    double bestPerpendicular = double.MaxValue;
                    double bestParameter = double.NaN;
                    foreach (PlanarEdge edge in neighbourEdges[i])
                    {
                        ConsiderPoint(edge.X1, edge.Y1);
                        ConsiderPoint(edge.X2, edge.Y2);
                    }

                    void ConsiderPoint(double pointX, double pointY)
                    {
                        double perpendicular = Math.Abs(((pointX * planarSegment.Nx) + (pointY * planarSegment.Ny)) - planarSegment.Offset);
                        if (perpendicular < bestPerpendicular)
                        {
                            bestPerpendicular = perpendicular;
                            bestParameter = (pointX * planarSegment.Dx) + (pointY * planarSegment.Dy);
                        }
                    }

                    if (!double.IsNaN(bestParameter))
                    {
                        axisParameters.Add(Math.Max(Math.Min(bestParameter, usableEnd), usableStart));
                    }
                }

                bool obstructionFound = false;
                double obstructionDeficit = double.MinValue;
                double obstructionDistance = double.NaN;
                double obstructionRequired = double.NaN;

                double halfAngle = (openingGenerationOptions.ObstructionSectorAngle / 2) * (Math.PI / 180);
                double cosine = Math.Cos(halfAngle);
                double sine = Math.Sin(halfAngle);
                double dir1X = (planarSegment.Nx * cosine) - (planarSegment.Ny * sine);
                double dir1Y = (planarSegment.Nx * sine) + (planarSegment.Ny * cosine);
                double dir2X = (planarSegment.Nx * cosine) + (planarSegment.Ny * sine);
                double dir2Y = (-(planarSegment.Nx * sine)) + (planarSegment.Ny * cosine);

                foreach (double axisParameter in axisParameters)
                {
                    double vertexX = (planarSegment.Dx * axisParameter) + (planarSegment.Nx * planarSegment.Offset);
                    double vertexY = (planarSegment.Dy * axisParameter) + (planarSegment.Ny * planarSegment.Offset);

                    foreach (ObstructionSource obstructionSource in obstructionSources)
                    {
                        double heightShading = obstructionSource.Top - (groundZ + openingGenerationOptions.SillHeight);
                        if (heightShading <= 0)
                        {
                            continue;
                        }

                        double minimum = double.PositiveInfinity;
                        double minimumParameter = double.MaxValue;
                        double maximumParameter = double.MinValue;
                        bool found = false;
                        foreach (PlanarEdge edge in obstructionSource.Edges)
                        {
                            if (obstructionSource.Self && PointSegmentDistance(vertexX, vertexY, edge.X1, edge.Y1, edge.X2, edge.Y2) < tolerance)
                            {
                                // The host wall line itself, and its continuation, are not obstructions of the window they hold.
                                continue;
                            }

                            if (!ClipWedge(edge.X1, edge.Y1, edge.X2, edge.Y2, vertexX, vertexY, dir1X, dir1Y, dir2X, dir2Y, out double low, out double high))
                            {
                                continue;
                            }

                            double edgeX = edge.X2 - edge.X1;
                            double edgeY = edge.Y2 - edge.Y1;
                            minimum = Math.Min(minimum, ClippedDistance(edge.X1, edge.Y1, edgeX, edgeY, low, high, vertexX, vertexY));
                            found = true;

                            double parameter1 = (edge.X1 * planarSegment.Dx) + (edge.Y1 * planarSegment.Dy);
                            double parameter2 = (edge.X2 * planarSegment.Dx) + (edge.Y2 * planarSegment.Dy);
                            double lowParameter = parameter1 + ((parameter2 - parameter1) * low);
                            double highParameter = parameter1 + ((parameter2 - parameter1) * high);
                            minimumParameter = Math.Min(minimumParameter, Math.Min(lowParameter, highParameter));
                            maximumParameter = Math.Max(maximumParameter, Math.Max(lowParameter, highParameter));
                        }

                        if (!found)
                        {
                            continue;
                        }

                        double required = Math.Min(heightShading, openingGenerationOptions.ObstructionMaxDistance);
                        if ((maximumParameter - minimumParameter) <= (openingGenerationOptions.ObstructionSlenderWidth + tolerance))
                        {
                            required = Math.Min(required, openingGenerationOptions.ObstructionSlenderDistance);
                        }

                        if (openingGenerationOptions.ObstructionInnerCityFactor is double factor)
                        {
                            required *= factor;
                        }

                        double deficit = required - minimum;
                        if (!obstructionFound || deficit > obstructionDeficit)
                        {
                            obstructionFound = true;
                            obstructionDeficit = deficit;
                            obstructionDistance = minimum;
                            obstructionRequired = required;
                        }
                    }
                }

                WallOpeningRestriction wallOpeningRestriction = WallOpeningRestriction.None;
                double? fireDistance_Result = null;
                double? fireRequired_Result = null;
                double? obstructionDistance_Result = null;
                double? obstructionRequired_Result = null;

                if (fireApplicable)
                {
                    fireDistance_Result = fireDistance;
                    fireRequired_Result = fireRequired;
                    if (fireDeficit > tolerance)
                    {
                        wallOpeningRestriction = WallOpeningRestriction.FireSeparation;
                    }
                }
                else if (fireExempt)
                {
                    // Measured, but § 271 does not apply between walls at this angle.
                    fireDistance_Result = exemptDistance;
                }

                if (obstructionFound)
                {
                    obstructionDistance_Result = obstructionDistance;
                    obstructionRequired_Result = obstructionRequired;
                    if (obstructionDeficit > tolerance && wallOpeningRestriction == WallOpeningRestriction.None)
                    {
                        wallOpeningRestriction = WallOpeningRestriction.Obstruction;
                    }
                }

                result.Add(new WallOpeningResult(new GuidReference(wall), wallOpeningRestriction, fireDistance_Result, fireRequired_Result, obstructionDistance_Result, obstructionRequired_Result));
            }

            return result;
        }

        /// <summary>
        /// Gets the same per-wall neighbour results when only the 2D buildings of the neighbours are known (DiGi-Organization/DiGi.GIS.Analytical#9).
        /// <para>Each neighbour is extruded from its footprint at the ground elevation of the examined model to <see cref="Constants.StoreyHeight.Default"/> times its <see cref="Building2D.Storeys"/> storeys, so its height comes from the 2D building, and its <see cref="FireClass"/> from its general function. The results are those of <see cref="WallOpeningResults(BuildingModel, IEnumerable{BuildingModel?}?, OpeningGenerationOptions, BuildingGeneralFunction?, double)"/>.</para>
        /// </summary>
        /// <param name="buildingModel">The building model examined. This value can be null.</param>
        /// <param name="building2Ds_Neighbour">The 2D buildings of the adjacent buildings, extruded for the measurement. This value can be null.</param>
        /// <param name="options">The rules to apply, or null for the defaults of <see cref="OpeningGenerationOptions"/>.</param>
        /// <param name="buildingGeneralFunction">The general function of the examined building, giving its <see cref="FireClass"/>, or null when unknown.</param>
        /// <param name="tolerance">The distance tolerance.</param>
        /// <returns>One result per external wall that is not a party wall, in envelope order; an empty list when the model has none; or null when the model is null.</returns>
        public static List<WallOpeningResult>? WallOpeningResults(this BuildingModel? buildingModel, IEnumerable<Building2D?>? building2Ds_Neighbour, OpeningGenerationOptions? options, BuildingGeneralFunction? buildingGeneralFunction = null, double tolerance = Core.Constants.Tolerance.Distance)
        {
            if (buildingModel is null)
            {
                return null;
            }

            List<BuildingModel> buildingModels = [];
            if (building2Ds_Neighbour is not null)
            {
                double elevation = buildingModel.GetBoundingBox()?.Min?.Z ?? 0;
                foreach (Building2D? building2D in building2Ds_Neighbour)
                {
                    if (building2D is not null && Create.BuildingModel(building2D, elevation, Constants.StoreyHeight.Default, tolerance) is BuildingModel buildingModel_Neighbour)
                    {
                        buildingModels.Add(buildingModel_Neighbour);
                    }
                }
            }

            return buildingModel.WallOpeningResults(buildingModels, options, buildingGeneralFunction, tolerance);
        }
    }
}
