using DiGi.Analytical.Building.Classes;
using DiGi.Analytical.Building.Enums;
using DiGi.Analytical.Building.Interfaces;
using DiGi.Analytical.Building.Regulation.Classes;
using DiGi.Analytical.Building.Regulation.Enums;
using DiGi.Core.Classes;
using DiGi.Core.Parameter.Classes;
using DiGi.Geometry.Planar.Classes;
using DiGi.Geometry.Spatial.Classes;
using DiGi.Geometry.Spatial.Interfaces;
using DiGi.GIS.Analytical.Enums;
using DiGi.GIS.Classes;
using DiGi.GIS.Enums;
using System;
using System.Collections.Generic;
using System.Globalization;
using Regulation = DiGi.Analytical.Building.Regulation;

namespace DiGi.GIS.Analytical
{
    public static partial class Modify
    {
        /// <summary>
        /// The text <see cref="OpeningParameter.GeneratedBy"/> carries on every opening <see cref="GenerateOpenings"/> places.
        /// </summary>
        public const string GenerateOpenings_GeneratedBy = "DiGi.GIS.Analytical.Modify.GenerateOpenings";

        /// <summary>
        /// Places windows and doors on the external walls of a building model, following the Polish rules of the building's period (DiGi-Organization/DiGi.GIS.Analytical#2, phase A).
        /// <para><b>Keys.</b> The regime is <c>Regulation.Query.BuildingRegulation(yearBuilt, DesignLag)</c>. The building type is <see cref="Query.BuildingType(Building2D, bool)"/>, terraced when any wall carries <see cref="ComponentParameter.PartyWall"/>; a non-residential building takes the multi-family sets. The sizes come from the opening-size set of the year built, type and panel system, and the thermal values from the construction set of the chosen flavour, a role it lacks falling back to TypicalAsBuilt. With no year built, the latest sets are used.</para>
        /// <para><b>Storeys.</b> Openings are placed per storey band (<see cref="Query.StoreyBands"/>), never assuming that one space is one storey, so an unsplit 3D model and a building with no storey count get windows on every storey. Every band uses the same positions along a wall where its allowed walls are the same, so windows stack.</para>
        /// <para><b>Windows.</b> The target of a band is the daylight ratio times the habitable floor fraction times the footprint area, as glazed area in the clear of the frames. It is split over the living-room, kitchen and bathroom sizes by the room mix of the building type (a use the set lists as windowless gives its share to the living room) and interleaved by largest remainder. Where the regime has a maximum glazed area A0max and the window U-value reaches its threshold, the windows are cut to it. The windows are distributed over the allowed walls in proportion to their usable length, the front wall weighted by the street façade weight; spaced evenly, keeping the corner margin and the minimum pier, and snapped to the façade module of a large-panel set where it fits. The sill is the size's own, raised on upper storeys to the option sill (or the high sill above 25 m) and to keep the interstorey strip above the openings below; a window whose head would not clear the band top less the head clearance falls back to the tallest narrower size that fits. What does not fit is the band's shortfall, reported, not an error.</para>
        /// <para><b>Walls.</b> A wall carrying <see cref="ComponentParameter.PartyWall"/> (split beforehand by <c>DiGi.Analytical.Building.Modify.SplitPartyWalls</c>) or too short for the narrowest window gets nothing, and the result records why.</para>
        /// <para><b>Doors.</b> The front wall is the external ground-storey wall nearest the address point, else the longest unrestricted one. A single-family or terraced building gets one entrance door centred on it; any other building one staircase entrance door per staircase spacing, each with a staircase window above it on every upper storey, outside the daylight target. A door below the § 62 clear size is reported, not resized.</para>
        /// <para><b>Constructions.</b> Each distinct size gets one construction (<c>Regulation.Create.WindowConstruction</c> or <c>DoorConstruction</c>), named after its kind and size, carrying the declared U-value, g and τv of the library construction of its role. Identifiers are derived from stable keys, so the same model and input give the same openings.</para>
        /// <para><b>Neighbours.</b> When neighbours are given, every external wall is measured against them first, by <see cref="Query.WallOpeningResults(BuildingModel, IEnumerable{BuildingModel?}?, OpeningGenerationOptions, BuildingGeneralFunction?, double)"/>: a wall closer to a facing neighbour than § 271 allows gets no openings at all (<see cref="WallOpeningRestriction.FireSeparation"/>), and a wall with an obstructing object inside the 60 degree sector of § 13 gets no windows of rooms for people, while its entrance door and staircase window stay allowed (<see cref="WallOpeningRestriction.Obstruction"/>). Both reasons are reported in <see cref="OpeningGenerationResult.WallOpeningRestrictions"/>.</para>
        /// <para>Every opening carries <see cref="OpeningParameter"/> values. The rules, defaults, constraints and limits are documented on the wiki page Opening Generation.</para>
        /// </summary>
        /// <param name="buildingModel">The building model to place the openings on.</param>
        /// <param name="building2D">The 2D building of the model, giving its function and storey count. This value can be null.</param>
        /// <param name="openingGenerationInput">The year built, address point, climate zone, panel system and options. This value can be null.</param>
        /// <param name="buildingModels_Neighbour">The building models of the adjacent buildings, measured against before placement under § 271 and § 13; null skips the neighbour rules. This value can be null.</param>
        /// <param name="constructionLibrary">The construction library, or null for <c>Regulation.Query.EmbeddedConstructionLibrary_PL()</c>. A batch caller passes it to read it once.</param>
        /// <param name="openingSizeLibrary">The opening-size library, or null for <c>Regulation.Create.OpeningSizeLibrary_PL()</c>. A batch caller passes it to create it once.</param>
        /// <param name="tolerance">The distance tolerance.</param>
        /// <returns>What was placed and what could not be, or null when the model is null or no opening-size set matches the building.</returns>
        public static OpeningGenerationResult? GenerateOpenings(this BuildingModel? buildingModel, Building2D? building2D, OpeningGenerationInput? openingGenerationInput, IEnumerable<BuildingModel?>? buildingModels_Neighbour = null, ConstructionLibrary? constructionLibrary = null, OpeningSizeLibrary? openingSizeLibrary = null, double tolerance = Core.Constants.Tolerance.Distance)
        {
            if (buildingModel is null)
            {
                return null;
            }

            short? yearBuilt = openingGenerationInput?.YearBuilt;
            YearBuiltSource? yearBuiltSource = openingGenerationInput?.YearBuiltSource;
            ClimateZone climateZone = openingGenerationInput?.ClimateZone ?? ClimateZone.Undefined;

            OpeningGenerationOptions? openingGenerationOptions_Input = openingGenerationInput?.OpeningGenerationOptions;
            BuildingRegulation buildingRegulation = Regulation.Query.BuildingRegulation(yearBuilt, openingGenerationOptions_Input?.DesignLag ?? new OpeningGenerationOptions().DesignLag);
            OpeningGenerationOptions openingGenerationOptions = openingGenerationOptions_Input ?? Create.OpeningGenerationOptions(buildingRegulation);

            constructionLibrary ??= Regulation.Query.EmbeddedConstructionLibrary_PL();
            openingSizeLibrary ??= Regulation.Create.OpeningSizeLibrary_PL();

            static bool IsPartyWall(IWall? wall)
            {
                return wall is Component component && component.TryGetValue(new EnumParameterDefinition(ComponentParameter.PartyWall), out Guid _);
            }

            List<IWall> walls = buildingModel.GetComponents<IWall>() ?? [];
            walls.Sort((x, y) => x.Guid.CompareTo(y.Guid));

            bool partyWalls = walls.Exists(IsPartyWall);

            // The neighbour rules, measured before anything is placed: § 271 fire separation and § 13 daylight obstruction.
            Dictionary<Guid, WallOpeningResult> dictionary_WallOpeningResult = [];
            if (buildingModels_Neighbour is not null)
            {
                List<BuildingModel> buildingModels_Neighbour_Temp = [];
                foreach (BuildingModel? buildingModel_Neighbour in buildingModels_Neighbour)
                {
                    if (buildingModel_Neighbour is not null)
                    {
                        buildingModels_Neighbour_Temp.Add(buildingModel_Neighbour);
                    }
                }

                if (buildingModels_Neighbour_Temp.Count > 0 && buildingModel.WallOpeningResults(buildingModels_Neighbour_Temp, openingGenerationOptions, building2D?.BuildingGeneralFunction, tolerance) is List<WallOpeningResult> wallOpeningResults)
                {
                    foreach (WallOpeningResult wallOpeningResult in wallOpeningResults)
                    {
                        if (wallOpeningResult.Wall?.Guid is Guid guid)
                        {
                            dictionary_WallOpeningResult[guid] = wallOpeningResult;
                        }
                    }
                }
            }
            BuildingType buildingType = building2D.BuildingType(partyWalls);
            BuildingType buildingType_Lookup = buildingType == BuildingType.Undefined ? BuildingType.MultiFamily : buildingType;
            bool singleFamily = buildingType_Lookup is BuildingType.SingleFamily or BuildingType.Terraced;

            static DateTimeOffset January(int year)
            {
                return new DateTimeOffset(year, 1, 1, 0, 0, 0, TimeSpan.Zero);
            }

            DateTimeOffset dateTimeOffset_Built = yearBuilt is short year_Built ? January(year_Built) : January(9999);
            DateTimeOffset dateTimeOffset_Design = yearBuilt is short year_Design ? January(year_Design - openingGenerationOptions.DesignLag) : dateTimeOffset_Built;

            OpeningSizeSet? openingSizeSet = openingSizeLibrary?.GetOpeningSizeSet(dateTimeOffset_Built, buildingType_Lookup, openingGenerationInput?.PanelSystem);
            if (openingSizeSet is null)
            {
                return null;
            }

            ConstructionSet? constructionSet_TypicalAsBuilt = constructionLibrary?.GetConstructionSet(dateTimeOffset_Built, buildingType_Lookup, climateZone, ConstructionFlavour.TypicalAsBuilt);
            ConstructionSet? constructionSet = openingGenerationOptions.ConstructionFlavour == ConstructionFlavour.Regulation ? constructionLibrary?.GetConstructionSet(dateTimeOffset_Design, buildingType_Lookup, climateZone, ConstructionFlavour.Regulation) : constructionSet_TypicalAsBuilt;

            IOpeningConstruction? LibraryConstruction(OpeningKind openingKind)
            {
                ConstructionRole constructionRole = Regulation.Query.OpeningConstructionRole(openingKind);
                return (constructionLibrary?.GetConstruction(constructionSet, constructionRole) ?? constructionLibrary?.GetConstruction(constructionSet_TypicalAsBuilt, constructionRole)) as IOpeningConstruction;
            }

            static double Value(IOpeningConstruction? openingConstruction, OpeningConstructionParameter openingConstructionParameter)
            {
                return openingConstruction is not null && openingConstruction.TryGetValue(new EnumParameterDefinition(openingConstructionParameter), out double value) ? value : double.NaN;
            }

            static double PaneArea(OpeningSize openingSize)
            {
                double result_PaneArea = 0;
                List<Polygon2D>? polygon2Ds = Regulation.Query.Panes(openingSize);
                if (polygon2Ds is not null)
                {
                    foreach (Polygon2D polygon2D in polygon2Ds)
                    {
                        result_PaneArea += polygon2D.GetArea();
                    }
                }

                return result_PaneArea;
            }

            List<OpeningSize> openingSizes_Window = openingSizeSet.GetOpeningSizes().FindAll(x => x.OpeningKind == OpeningKind.Window);
            openingSizes_Window.Sort((x, y) => y.Height != x.Height ? y.Height.CompareTo(x.Height) : y.Width.CompareTo(x.Width));
            double width_Narrowest = double.NaN;
            foreach (OpeningSize openingSize in openingSizes_Window)
            {
                width_Narrowest = double.IsNaN(width_Narrowest) ? openingSize.Width : Math.Min(width_Narrowest, openingSize.Width);
            }

            // Storey bands, and the footprint area every band is given for the daylight target.
            List<Range<double>> bands = buildingModel.StoreyBands(building2D?.Storeys ?? 0, openingSizeSet.StoreyHeight, out StoreySource storeySource, tolerance) ?? [];

            double area_Footprint = 0;
            double area_Inner = 0;
            List<PolygonalFace2D>? polygonalFace2Ds_Footprint = DiGi.Analytical.Building.Query.Footprints(buildingModel, tolerance);
            if (polygonalFace2Ds_Footprint is not null)
            {
                foreach (PolygonalFace2D polygonalFace2D in polygonalFace2Ds_Footprint)
                {
                    area_Footprint += polygonalFace2D.GetArea();
                    List<PolygonalFace2D>? polygonalFace2Ds_Inner = Geometry.Planar.Query.Offset(polygonalFace2D, -5.0);
                    if (polygonalFace2Ds_Inner is not null)
                    {
                        foreach (PolygonalFace2D polygonalFace2D_Inner in polygonalFace2Ds_Inner)
                        {
                            area_Inner += polygonalFace2D_Inner.GetArea();
                        }
                    }
                }
            }

            // Facade segments: the external walls grouped by the horizontal line they stand on, so the walls of one edge in every storey share their window positions.
            Dictionary<Guid, WallOpeningRestriction> wallOpeningRestrictions = [];

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

            Vector3D vector3D_Up = new(0, 0, 1);
            SortedDictionary<(long, long, long, long, long), (Vector3D Direction, Vector3D Normal, double Offset, double Start, double End, List<(IWall Wall, double Bottom, double Top, bool Restricted, bool WindowsRestricted)> Walls)> segments = [];

            static long Round(double value, double precision)
            {
                return (long)Math.Round(value / precision, MidpointRounding.AwayFromZero);
            }

            foreach (IWall wall in walls)
            {
                if (!faces.TryGetValue(wall.Guid, out DiGi.Analytical.Classes.Face? face) || face.Plane?.Normal?.Unit is not Vector3D vector3D_Normal || vector3D_Up.CrossProduct(vector3D_Normal)?.Unit is not Vector3D vector3D_Direction || face.ExternalEdge?.GetPoints() is not List<Point3D> point3Ds || point3Ds.Count < 3)
                {
                    wallOpeningRestrictions[wall.Guid] = WallOpeningRestriction.NotExternal;
                    continue;
                }

                Vector3D? vector3D_Horizontal = new Vector3D(vector3D_Normal.X, vector3D_Normal.Y, 0).Unit;
                if (vector3D_Horizontal is null)
                {
                    wallOpeningRestrictions[wall.Guid] = WallOpeningRestriction.NotExternal;
                    continue;
                }

                double start = double.MaxValue;
                double end = double.MinValue;
                double bottom = double.MaxValue;
                double top = double.MinValue;
                double offset = 0;
                foreach (Point3D point3D in point3Ds)
                {
                    double s = (point3D.X * vector3D_Direction.X) + (point3D.Y * vector3D_Direction.Y);
                    start = Math.Min(start, s);
                    end = Math.Max(end, s);
                    bottom = Math.Min(bottom, point3D.Z);
                    top = Math.Max(top, point3D.Z);
                    offset += (point3D.X * vector3D_Horizontal.X) + (point3D.Y * vector3D_Horizontal.Y);
                }

                offset /= point3Ds.Count;

                WallOpeningRestriction wallOpeningRestriction;
                if (IsPartyWall(wall))
                {
                    wallOpeningRestriction = WallOpeningRestriction.PartyWall;
                }
                else if (double.IsNaN(width_Narrowest) || end - start - (2 * openingGenerationOptions.CornerMargin) < width_Narrowest)
                {
                    wallOpeningRestriction = WallOpeningRestriction.TooShort;
                }
                else
                {
                    wallOpeningRestriction = WallOpeningRestriction.None;
                }

                // The neighbour rules override the phase A reason: fire separation blocks every opening, an
                // obstruction only the windows of rooms for people, and a structural reason already stands.
                if (dictionary_WallOpeningResult.TryGetValue(wall.Guid, out WallOpeningResult? wallOpeningResult))
                {
                    if (wallOpeningResult.Restriction == WallOpeningRestriction.FireSeparation)
                    {
                        wallOpeningRestriction = WallOpeningRestriction.FireSeparation;
                    }
                    else if (wallOpeningResult.Restriction == WallOpeningRestriction.Obstruction && wallOpeningRestriction == WallOpeningRestriction.None)
                    {
                        wallOpeningRestriction = WallOpeningRestriction.Obstruction;
                    }
                }

                wallOpeningRestrictions[wall.Guid] = wallOpeningRestriction;

                bool restricted = wallOpeningRestriction is WallOpeningRestriction.PartyWall or WallOpeningRestriction.TooShort or WallOpeningRestriction.FireSeparation;
                bool windowsRestricted = wallOpeningRestriction == WallOpeningRestriction.Obstruction;

                (long, long, long, long, long) key = (Round(vector3D_Direction.X, 0.001), Round(vector3D_Direction.Y, 0.001), Round(offset, 0.01), Round(start, 0.01), Round(end, 0.01));
                if (!segments.TryGetValue(key, out (Vector3D Direction, Vector3D Normal, double Offset, double Start, double End, List<(IWall Wall, double Bottom, double Top, bool Restricted, bool WindowsRestricted)> Walls) segment))
                {
                    segment = (vector3D_Direction, vector3D_Horizontal, offset, start, end, []);
                    segments[key] = segment;
                }

                segment.Walls.Add((wall, bottom, top, restricted, windowsRestricted));
            }

            List<(Vector3D Direction, Vector3D Normal, double Offset, double Start, double End, List<(IWall Wall, double Bottom, double Top, bool Restricted, bool WindowsRestricted)> Walls)> segments_Ordered = [.. segments.Values];

            // The wall of a segment in a band: the one covering more than half of the band.
            (IWall Wall, bool Restricted, bool WindowsRestricted)? SegmentWall(int index_Segment, Range<double> band)
            {
                foreach ((IWall Wall, double Bottom, double Top, bool Restricted, bool WindowsRestricted) tuple in segments_Ordered[index_Segment].Walls)
                {
                    double overlap = Math.Min(tuple.Top, band.Max) - Math.Max(tuple.Bottom, band.Min);
                    if (overlap > 0.5 * (band.Max - band.Min))
                    {
                        return (tuple.Wall, tuple.Restricted, tuple.WindowsRestricted);
                    }
                }

                return null;
            }

            Point3D Point(int index_Segment, double s, double z)
            {
                (Vector3D Direction, Vector3D Normal, double Offset, double Start, double End, List<(IWall Wall, double Bottom, double Top, bool Restricted, bool WindowsRestricted)> Walls) segment = segments_Ordered[index_Segment];
                return new Point3D((segment.Direction.X * s) + (segment.Normal.X * segment.Offset), (segment.Direction.Y * s) + (segment.Normal.Y * segment.Offset), z);
            }

            // Constructions: one per distinct size, carrying the declared values of the library construction of its role.
            Dictionary<string, IOpeningConstruction> openingConstructions = [];
            IOpeningConstruction? OpeningConstruction(OpeningSize openingSize)
            {
                string? name = Regulation.Query.ConstructionName(openingSize);
                if (name is null)
                {
                    return null;
                }

                if (openingConstructions.TryGetValue(name, out IOpeningConstruction? openingConstruction_Existing))
                {
                    return openingConstruction_Existing;
                }

                IOpeningConstruction? openingConstruction_Library = LibraryConstruction(openingSize.OpeningKind);
                Guid guid = Core.Create.Guid(string.Concat(GenerateOpenings_GeneratedBy, ".", name, ".", openingConstruction_Library?.Guid.ToString() ?? string.Empty));
                string description = string.Format(CultureInfo.InvariantCulture, "Generated by {0}: size and pane layout from the opening-size set ({1}); thermal values of the library construction {2}.", GenerateOpenings_GeneratedBy, openingSize.Source, openingConstruction_Library?.Name);

                IOpeningConstruction? openingConstruction;
                if (openingSize.OpeningKind is OpeningKind.EntranceDoor or OpeningKind.StaircaseEntranceDoor or OpeningKind.DoorToUnheatedSpace or OpeningKind.GarageDoor)
                {
                    DoorConstruction? doorConstruction = Regulation.Create.DoorConstruction(openingSize, name, tolerance);
                    openingConstruction = doorConstruction is null ? null : new DoorConstruction(guid, doorConstruction) { Description = description };
                }
                else
                {
                    WindowConstruction? windowConstruction = Regulation.Create.WindowConstruction(openingSize, name, tolerance);
                    openingConstruction = windowConstruction is null ? null : new WindowConstruction(guid, windowConstruction) { Description = description };
                }

                if (openingConstruction is not OpeningConstruction openingConstruction_Value)
                {
                    return null;
                }

                foreach (OpeningConstructionParameter openingConstructionParameter in new[] { OpeningConstructionParameter.ThermalTransmittance, OpeningConstructionParameter.TotalSolarEnergyTransmittance, OpeningConstructionParameter.LightTransmittance })
                {
                    double value = Value(openingConstruction_Library, openingConstructionParameter);
                    if (!double.IsNaN(value))
                    {
                        openingConstruction_Value.SetValue(openingConstructionParameter, value);
                    }
                }

                openingConstructions[name] = openingConstruction;
                return openingConstruction;
            }

            // The parameters are read-only to users, so the access type is not checked here.
            SetValueSettings setValueSettings = new(true, false);
            void Trace(OpeningSize openingSize, RoomUse roomUse, ParametrizedGuidObject opening)
            {
                opening.SetValue(OpeningParameter.BuildingRegulation, buildingRegulation.ToString(), setValueSettings);
                opening.SetValue(OpeningParameter.YearBuiltSource, yearBuiltSource?.ToString() ?? "None", setValueSettings);
                opening.SetValue(OpeningParameter.ConstructionFlavour, openingGenerationOptions.ConstructionFlavour.ToString(), setValueSettings);
                opening.SetValue(OpeningParameter.OpeningKind, openingSize.OpeningKind.ToString(), setValueSettings);
                opening.SetValue(OpeningParameter.RoomUse, roomUse.ToString(), setValueSettings);
                opening.SetValue(OpeningParameter.GeneratedBy, GenerateOpenings_GeneratedBy, setValueSettings);
            }

            int droppedOpeningCount = 0;

            // Hosts one opening; its identifier is derived from the model, the segment, the band and the position.
            bool Place(OpeningSize openingSize, RoomUse roomUse, int index_Segment, int index_Band, IWall wall, double s, double z)
            {
                if (OpeningConstruction(openingSize) is not IOpeningConstruction openingConstruction)
                {
                    droppedOpeningCount++;
                    return false;
                }

                Plane plane = new(Point(index_Segment, s, z), segments_Ordered[index_Segment].Direction, vector3D_Up);
                Guid guid = Core.Create.Guid(string.Format(CultureInfo.InvariantCulture, "{0}.{1}.{2}.{3}.{4}", GenerateOpenings_GeneratedBy, buildingModel.Guid, index_Segment, index_Band, Round(s, 0.001)));

                bool placed;
                if (openingConstruction is IDoorConstruction doorConstruction)
                {
                    Door door = new(guid, plane);
                    Trace(openingSize, roomUse, door);
                    placed = buildingModel.Assign(wall, door, doorConstruction, tolerance);
                }
                else if (openingConstruction is IWindowConstruction windowConstruction)
                {
                    Window window = new(guid, plane);
                    Trace(openingSize, roomUse, window);
                    placed = buildingModel.Assign(wall, window, windowConstruction, tolerance);
                }
                else
                {
                    placed = false;
                }

                if (!placed)
                {
                    droppedOpeningCount++;
                }

                return placed;
            }

            // The front wall: the unrestricted ground-storey segment nearest the address point, else the longest one.
            Range<double>? band_Ground = bands.Count > 0 ? bands[0] : null;
            int index_Front = -1;
            FrontWallRule frontWallRule = FrontWallRule.Undefined;
            Point2D? point2D_Address = openingGenerationInput?.AddressPoint;
            if (band_Ground is not null)
            {
                double best = double.NaN;
                for (int i = 0; i < segments_Ordered.Count; i++)
                {
                    if (SegmentWall(i, band_Ground) is not (IWall, bool, bool) tuple_Wall || tuple_Wall.Restricted)
                    {
                        continue;
                    }

                    Point3D point3D_Start = Point(i, segments_Ordered[i].Start, 0);
                    Point3D point3D_End = Point(i, segments_Ordered[i].End, 0);
                    if (point2D_Address is not null)
                    {
                        double distance = new Segment2D(new Point2D(point3D_Start.X, point3D_Start.Y), new Point2D(point3D_End.X, point3D_End.Y)).Distance(point2D_Address);
                        if (double.IsNaN(best) || distance < best - tolerance)
                        {
                            best = distance;
                            index_Front = i;
                        }
                    }
                    else
                    {
                        double length = segments_Ordered[i].End - segments_Ordered[i].Start;
                        if (double.IsNaN(best) || length > best + tolerance)
                        {
                            best = length;
                            index_Front = i;
                        }
                    }
                }

                if (index_Front != -1)
                {
                    frontWallRule = point2D_Address is not null ? FrontWallRule.AddressPoint : FrontWallRule.LongestEdge;
                }
            }

            // Doors on the ground storey of the front wall, and the intervals they keep free on that wall in every band.
            int doorCount = 0;
            int doorsBelowMinimumCount = 0;
            List<(double Start, double End)> intervals_Reserved = [];
            List<double> centres_Door = [];
            double head_Door = double.NaN;
            if (index_Front != -1 && band_Ground is not null && SegmentWall(index_Front, band_Ground) is (IWall, bool, bool) tuple_Front)
            {
                OpeningKind openingKind_Door = singleFamily ? OpeningKind.EntranceDoor : OpeningKind.StaircaseEntranceDoor;
                OpeningSize? openingSize_Door = openingSizeSet.GetOpeningSize(openingKind_Door, singleFamily ? RoomUse.Other : RoomUse.Staircase);
                double start_Front = segments_Ordered[index_Front].Start;
                double end_Front = segments_Ordered[index_Front].End;
                double length_Front = end_Front - start_Front;
                if (openingSize_Door is not null && length_Front - (2 * openingGenerationOptions.CornerMargin) >= openingSize_Door.Width)
                {
                    int count_Door = singleFamily ? 1 : Math.Max(1, (int)Math.Ceiling(length_Front / openingGenerationOptions.StaircaseSpacing));
                    for (int i = 0; i < count_Door; i++)
                    {
                        double centre = start_Front + (length_Front * (i + 0.5) / count_Door);
                        double left = Math.Min(Math.Max(centre - (openingSize_Door.Width / 2), start_Front + openingGenerationOptions.CornerMargin), end_Front - openingGenerationOptions.CornerMargin - openingSize_Door.Width);
                        if (intervals_Reserved.Count > 0 && left < intervals_Reserved[intervals_Reserved.Count - 1].End)
                        {
                            continue;
                        }

                        if (Place(openingSize_Door, singleFamily ? RoomUse.Other : RoomUse.Staircase, index_Front, 0, tuple_Front.Wall, left, band_Ground.Min))
                        {
                            doorCount++;
                            intervals_Reserved.Add((left - openingGenerationOptions.MinimumPier, left + openingSize_Door.Width + openingGenerationOptions.MinimumPier));
                            centres_Door.Add(left + (openingSize_Door.Width / 2));
                            head_Door = band_Ground.Min + openingSize_Door.Height;

                            double width_Clear = openingSize_Door.Width - (2 * openingSize_Door.FrameWidth);
                            if (openingSize_Door.Columns > 1)
                            {
                                width_Clear = (width_Clear - ((openingSize_Door.Columns - 1) * openingSize_Door.DividerWidth)) / openingSize_Door.Columns;
                            }

                            if (width_Clear < openingGenerationOptions.DoorMinimumWidth - tolerance || openingSize_Door.Height - openingSize_Door.FrameWidth < openingGenerationOptions.DoorMinimumHeight - tolerance)
                            {
                                doorsBelowMinimumCount++;
                            }
                        }
                    }
                }
            }

            // The window sequence of a band: the room mix of the target, interleaved by largest remainder.
            Dictionary<RoomUse, double>? shares = null;
            if (openingGenerationOptions.RoomMixes is Dictionary<BuildingType, Dictionary<RoomUse, double>> roomMixes)
            {
                if (!roomMixes.TryGetValue(buildingType_Lookup, out shares))
                {
                    roomMixes.TryGetValue(BuildingType.MultiFamily, out shares);
                }
            }

            shares ??= new Dictionary<RoomUse, double>() { [RoomUse.LivingRoom] = 1.0 };

            double fraction_Habitable = 0.6;
            if (openingGenerationOptions.HabitableFloorFractions is Dictionary<BuildingType, double> habitableFloorFractions && habitableFloorFractions.TryGetValue(buildingType, out double fraction))
            {
                fraction_Habitable = fraction;
            }

            double area_Target = openingGenerationOptions.DaylightRatio * fraction_Habitable * area_Footprint;

            List<RoomUse> roomUses = [RoomUse.LivingRoom, RoomUse.Kitchen, RoomUse.Bathroom];
            Dictionary<RoomUse, (OpeningSize OpeningSize, double Share)> sizes = [];
            double share_Living = 0;
            foreach (RoomUse roomUse in roomUses)
            {
                double share = shares.TryGetValue(roomUse, out double share_Value) ? share_Value : 0;
                if (share <= 0)
                {
                    continue;
                }

                OpeningSize? openingSize = openingSizeSet.GetOpeningSize(OpeningKind.Window, roomUse);
                if (openingSize is null || roomUse == RoomUse.LivingRoom)
                {
                    share_Living += share;
                    continue;
                }

                sizes[roomUse] = (openingSize, share);
            }

            if (share_Living > 0 && openingSizeSet.GetOpeningSize(OpeningKind.Window, RoomUse.LivingRoom) is OpeningSize openingSize_Living)
            {
                sizes[RoomUse.LivingRoom] = (openingSize_Living, share_Living);
            }

            List<(RoomUse RoomUse, int Count)> counts = [];
            int count_Total = 0;
            foreach (RoomUse roomUse in roomUses)
            {
                if (!sizes.TryGetValue(roomUse, out (OpeningSize OpeningSize, double Share) tuple_Size))
                {
                    continue;
                }

                double area_Pane = PaneArea(tuple_Size.OpeningSize);
                int count = area_Pane > 0 && area_Target > 0 ? (int)Math.Ceiling((area_Target * tuple_Size.Share / area_Pane) - 1e-9) : 0;
                counts.Add((roomUse, count));
                count_Total += count;
            }

            List<(OpeningSize OpeningSize, RoomUse RoomUse)> sequence = [];
            int[] placed_Use = new int[counts.Count];
            for (int i = 0; i < count_Total; i++)
            {
                int index_Best = -1;
                double remainder_Best = double.MinValue;
                for (int j = 0; j < counts.Count; j++)
                {
                    if (placed_Use[j] >= counts[j].Count)
                    {
                        continue;
                    }

                    double remainder = ((double)counts[j].Count * (i + 1) / count_Total) - placed_Use[j];
                    if (remainder > remainder_Best + 1e-12)
                    {
                        remainder_Best = remainder;
                        index_Best = j;
                    }
                }

                if (index_Best == -1)
                {
                    break;
                }

                placed_Use[index_Best]++;
                sequence.Add((sizes[counts[index_Best].RoomUse].OpeningSize, counts[index_Best].RoomUse));
            }

            // The maximum glazed area, where the regime has one and the window U-value reaches its threshold.
            double maximumGlazedArea = double.NaN;
            if (openingGenerationOptions.MaximumGlazedAreaThermalTransmittance is double thermalTransmittance_Limit && buildingType != BuildingType.Undefined && (!openingGenerationOptions.MaximumGlazedAreaSingleFamilyOnly || singleFamily) && bands.Count > 0)
            {
                double thermalTransmittance = Value(LibraryConstruction(OpeningKind.Window), OpeningConstructionParameter.ThermalTransmittance);
                if (!double.IsNaN(thermalTransmittance) && thermalTransmittance >= thermalTransmittance_Limit - 1e-9)
                {
                    maximumGlazedArea = bands.Count * ((0.15 * (area_Footprint - area_Inner)) + (0.03 * area_Inner));

                    double area_Modular = 0;
                    int count_Allowed = 0;
                    foreach ((OpeningSize OpeningSize, RoomUse RoomUse) tuple in sequence)
                    {
                        double area = tuple.OpeningSize.Width * tuple.OpeningSize.Height;
                        if (bands.Count * (area_Modular + area) > maximumGlazedArea + 1e-9)
                        {
                            break;
                        }

                        area_Modular += area;
                        count_Allowed++;
                    }

                    sequence.RemoveRange(count_Allowed, sequence.Count - count_Allowed);
                }
            }

            double frontWeight = 1.0;
            if (openingGenerationOptions.StreetFacadeWeights is Dictionary<BuildingType, double> streetFacadeWeights && streetFacadeWeights.TryGetValue(buildingType_Lookup, out double weight_Front))
            {
                frontWeight = weight_Front;
            }

            // The free intervals of a segment, between its corner margins and outside the door intervals of the front wall.
            List<(double Start, double End)> Intervals(int index_Segment)
            {
                List<(double Start, double End)> result_Intervals = [(segments_Ordered[index_Segment].Start + openingGenerationOptions.CornerMargin, segments_Ordered[index_Segment].End - openingGenerationOptions.CornerMargin)];
                if (index_Segment == index_Front)
                {
                    foreach ((double Start, double End) interval_Reserved in intervals_Reserved)
                    {
                        List<(double Start, double End)> intervals_New = [];
                        foreach ((double Start, double End) interval in result_Intervals)
                        {
                            if (interval_Reserved.End <= interval.Start || interval_Reserved.Start >= interval.End)
                            {
                                intervals_New.Add(interval);
                                continue;
                            }

                            if (interval_Reserved.Start > interval.Start)
                            {
                                intervals_New.Add((interval.Start, interval_Reserved.Start));
                            }

                            if (interval_Reserved.End < interval.End)
                            {
                                intervals_New.Add((interval_Reserved.End, interval.End));
                            }
                        }

                        result_Intervals = intervals_New;
                    }
                }

                result_Intervals.RemoveAll(x => double.IsNaN(width_Narrowest) || x.End - x.Start < width_Narrowest - tolerance);
                return result_Intervals;
            }

            // Packs windows into intervals in order; returns the left edge of each, or null when they do not all fit.
            List<double>? Pack(List<(double Start, double End)> intervals, List<(OpeningSize OpeningSize, RoomUse RoomUse)> windows)
            {
                List<double> result_Pack = [];
                int index_Window = 0;
                double pier = openingGenerationOptions.MinimumPier;
                foreach ((double Start, double End) interval in intervals)
                {
                    int index_First = index_Window;
                    double width = 0;
                    while (index_Window < windows.Count)
                    {
                        double width_New = width + windows[index_Window].OpeningSize.Width;
                        if (width_New + ((index_Window - index_First) * pier) > interval.End - interval.Start + tolerance)
                        {
                            break;
                        }

                        width = width_New;
                        index_Window++;
                    }

                    int count = index_Window - index_First;
                    if (count == 0)
                    {
                        continue;
                    }

                    double length = interval.End - interval.Start;
                    double gap = (length - width) / (count + 1);
                    double x;
                    if (gap < pier)
                    {
                        gap = pier;
                        x = interval.Start + ((length - width - ((count - 1) * pier)) / 2);
                    }
                    else
                    {
                        x = interval.Start + gap;
                    }

                    for (int i = index_First; i < index_Window; i++)
                    {
                        result_Pack.Add(x);
                        x += windows[i].OpeningSize.Width + gap;
                    }
                }

                return index_Window == windows.Count ? result_Pack : null;
            }

            // Bands from the ground up: distribute the sequence over the allowed segments, then place each window.
            List<OpeningGenerationStorey> openingGenerationStoreys = [];
            double head_Previous = double.NaN;
            double? facadeModule = openingSizeSet.FacadeModule;
            const double fittingGap = 0.035;

            for (int index_Band = 0; index_Band < bands.Count; index_Band++)
            {
                Range<double> band = bands[index_Band];
                double height_Band = band.Max - band.Min;
                bool heightMismatch = height_Band < openingGenerationOptions.MinimumStoreyHeight - tolerance || height_Band > (openingGenerationOptions.MaximumStoreyHeightFactor * openingSizeSet.StoreyHeight) + tolerance;

                List<int> indexes_Allowed = [];
                List<List<(double Start, double End)>> intervals_Allowed = [];
                List<double> weights = [];
                for (int i = 0; i < segments_Ordered.Count; i++)
                {
                    if (SegmentWall(i, band) is not (IWall, bool, bool) tuple_Wall || tuple_Wall.Restricted || tuple_Wall.WindowsRestricted)
                    {
                        continue;
                    }

                    List<(double Start, double End)> intervals = Intervals(i);
                    double length = 0;
                    foreach ((double Start, double End) interval in intervals)
                    {
                        length += interval.End - interval.Start;
                    }

                    if (length <= 0)
                    {
                        continue;
                    }

                    indexes_Allowed.Add(i);
                    intervals_Allowed.Add(intervals);
                    weights.Add(length * (i == index_Front ? frontWeight : 1.0));
                }

                // Quotas by largest remainder, then the sequence handed out in order.
                int[] quotas = new int[indexes_Allowed.Count];
                double weight_Total = 0;
                foreach (double weight in weights)
                {
                    weight_Total += weight;
                }

                if (weight_Total > 0)
                {
                    int assigned = 0;
                    List<(int Index, double Remainder)> remainders = [];
                    for (int i = 0; i < quotas.Length; i++)
                    {
                        double exact = sequence.Count * weights[i] / weight_Total;
                        quotas[i] = (int)Math.Floor(exact);
                        assigned += quotas[i];
                        remainders.Add((i, exact - quotas[i]));
                    }

                    remainders.Sort((x, y) => y.Remainder != x.Remainder ? y.Remainder.CompareTo(x.Remainder) : x.Index.CompareTo(y.Index));
                    for (int i = 0; assigned < sequence.Count && i < remainders.Count; i++, assigned++)
                    {
                        quotas[remainders[i].Index]++;
                    }
                }

                List<List<(OpeningSize OpeningSize, RoomUse RoomUse)>> windows_Segment = [];
                List<List<double>> lefts_Segment = [];
                List<(OpeningSize OpeningSize, RoomUse RoomUse)> overflow = [];
                int index_Sequence = 0;
                for (int i = 0; i < quotas.Length; i++)
                {
                    List<(OpeningSize OpeningSize, RoomUse RoomUse)> windows = [];
                    for (int j = 0; j < quotas[i] && index_Sequence < sequence.Count; j++, index_Sequence++)
                    {
                        windows.Add(sequence[index_Sequence]);
                    }

                    List<double>? lefts = Pack(intervals_Allowed[i], windows);
                    while (lefts is null && windows.Count > 0)
                    {
                        overflow.Add(windows[windows.Count - 1]);
                        windows.RemoveAt(windows.Count - 1);
                        lefts = Pack(intervals_Allowed[i], windows);
                    }

                    windows_Segment.Add(windows);
                    lefts_Segment.Add(lefts ?? []);
                }

                // Overflow goes to the segments with spare room, the heaviest first.
                List<int> order = [];
                for (int i = 0; i < quotas.Length; i++)
                {
                    order.Add(i);
                }

                order.Sort((x, y) => weights[y] != weights[x] ? weights[y].CompareTo(weights[x]) : x.CompareTo(y));
                foreach ((OpeningSize OpeningSize, RoomUse RoomUse) tuple in overflow)
                {
                    foreach (int i in order)
                    {
                        windows_Segment[i].Add(tuple);
                        if (Pack(intervals_Allowed[i], windows_Segment[i]) is List<double> lefts)
                        {
                            lefts_Segment[i] = lefts;
                            break;
                        }

                        windows_Segment[i].RemoveAt(windows_Segment[i].Count - 1);
                    }
                }

                // Vertical placement: sill, strip and head; the façade module of a panel set.
                double sill_Minimum = index_Band == 0 ? 0 : (band.Min - bands[0].Min > openingGenerationOptions.HighSillElevation ? openingGenerationOptions.HighSillHeight : openingGenerationOptions.SillHeight);
                if (index_Band > 0 && !double.IsNaN(head_Previous))
                {
                    sill_Minimum = Math.Max(sill_Minimum, head_Previous - band.Min + openingGenerationOptions.InterstoreyStrip);
                }

                double limit_Head = height_Band - openingGenerationOptions.HeadClearance;
                double head_Band = double.NaN;
                double area_Achieved = 0;
                int windowCount = 0;

                for (int i = 0; i < indexes_Allowed.Count; i++)
                {
                    int index_Segment = indexes_Allowed[i];
                    if (SegmentWall(index_Segment, band) is not (IWall, bool, bool) tuple_Wall)
                    {
                        continue;
                    }

                    double right_Previous = double.NaN;
                    for (int j = 0; j < windows_Segment[i].Count; j++)
                    {
                        OpeningSize openingSize = windows_Segment[i][j].OpeningSize;
                        double left = lefts_Segment[i][j];
                        double sill = Math.Max(openingSize.SillHeight ?? openingGenerationOptions.SillHeight, sill_Minimum);
                        if (sill + openingSize.Height > limit_Head + tolerance)
                        {
                            OpeningSize? openingSize_Fallback = openingSizes_Window.Find(x => x.Width <= openingSize.Width + tolerance && Math.Max(x.SillHeight ?? openingGenerationOptions.SillHeight, sill_Minimum) + x.Height <= limit_Head + tolerance);
                            if (openingSize_Fallback is null)
                            {
                                continue;
                            }

                            left += (openingSize.Width - openingSize_Fallback.Width) / 2;
                            openingSize = openingSize_Fallback;
                            sill = Math.Max(openingSize.SillHeight ?? openingGenerationOptions.SillHeight, sill_Minimum);
                        }

                        if (facadeModule is double module && module > 0)
                        {
                            // The nearest grid line first, then the one on the other side.
                            double start = segments_Ordered[index_Segment].Start;
                            double grid = (left - start - (fittingGap / 2)) / module;
                            double right_Next = j + 1 < windows_Segment[i].Count ? lefts_Segment[i][j + 1] : double.MaxValue;
                            foreach (double index_Grid in new[] { Math.Round(grid, MidpointRounding.AwayFromZero), Math.Floor(grid), Math.Ceiling(grid) })
                            {
                                double left_Snapped = start + (index_Grid * module) + (fittingGap / 2);
                                bool inside = intervals_Allowed[i].Exists(x => left_Snapped >= x.Start - tolerance && left_Snapped + openingSize.Width <= x.End + tolerance);
                                bool clear = (double.IsNaN(right_Previous) || left_Snapped >= right_Previous + openingGenerationOptions.MinimumPier - tolerance) && left_Snapped + openingSize.Width + openingGenerationOptions.MinimumPier <= right_Next + tolerance;
                                if (inside && clear)
                                {
                                    left = left_Snapped;
                                    break;
                                }
                            }
                        }

                        if (Place(openingSize, windows_Segment[i][j].RoomUse, index_Segment, index_Band, tuple_Wall.Wall, left, band.Min + sill))
                        {
                            area_Achieved += PaneArea(openingSize);
                            windowCount++;
                            head_Band = double.IsNaN(head_Band) ? band.Min + sill + openingSize.Height : Math.Max(head_Band, band.Min + sill + openingSize.Height);
                            right_Previous = left + openingSize.Width;
                        }
                    }
                }

                // Staircase windows above the staircase doors, outside the daylight target.
                if (index_Band > 0 && !singleFamily && index_Front != -1 && SegmentWall(index_Front, band) is (IWall, bool, bool) tuple_Staircase && !tuple_Staircase.Restricted && openingSizeSet.GetOpeningSize(OpeningKind.StaircaseWindow, RoomUse.Staircase) is OpeningSize openingSize_Staircase)
                {
                    double sill = Math.Max(openingSize_Staircase.SillHeight ?? openingGenerationOptions.SillHeight, sill_Minimum);
                    if (sill + openingSize_Staircase.Height <= limit_Head + tolerance)
                    {
                        foreach (double centre in centres_Door)
                        {
                            if (Place(openingSize_Staircase, RoomUse.Staircase, index_Front, index_Band, tuple_Staircase.Wall, centre - (openingSize_Staircase.Width / 2), band.Min + sill))
                            {
                                head_Band = double.IsNaN(head_Band) ? band.Min + sill + openingSize_Staircase.Height : Math.Max(head_Band, band.Min + sill + openingSize_Staircase.Height);
                            }
                        }
                    }
                }

                if (index_Band == 0 && !double.IsNaN(head_Door))
                {
                    head_Band = double.IsNaN(head_Band) ? head_Door : Math.Max(head_Band, head_Door);
                }

                head_Previous = head_Band;
                openingGenerationStoreys.Add(new OpeningGenerationStorey(index_Band, band.Min, band.Max, heightMismatch, area_Target, area_Achieved, windowCount));
            }

            Guid? guid_Front = null;
            if (index_Front != -1 && band_Ground is not null && SegmentWall(index_Front, band_Ground) is (IWall, bool, bool) tuple_Front_Wall)
            {
                guid_Front = tuple_Front_Wall.Wall.Guid;
            }

            return new OpeningGenerationResult(
                building2D?.Reference,
                buildingRegulation,
                yearBuilt,
                yearBuiltSource,
                openingGenerationOptions.ConstructionFlavour,
                buildingType,
                openingSizeSet.Source,
                constructionSet?.Source ?? constructionSet_TypicalAsBuilt?.Source,
                storeySource,
                maximumGlazedArea,
                guid_Front,
                frontWallRule,
                openingGenerationStoreys,
                wallOpeningRestrictions,
                doorCount,
                doorsBelowMinimumCount,
                droppedOpeningCount);
        }
    }
}
