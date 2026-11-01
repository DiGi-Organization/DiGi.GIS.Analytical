using DiGi.Analytical.Building.Regulation.Enums;
using DiGi.Core.Classes;
using DiGi.GIS.Analytical.Enums;
using DiGi.GIS.Interfaces;
using System.Collections.Generic;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace DiGi.GIS.Classes
{
    /// <summary>
    /// Holds every numeric rule <c>Modify.GenerateOpenings</c> applies, so nothing is hard-coded in the generator (DiGi-Organization/DiGi.GIS.Analytical#2).
    /// <para><c>Create.OpeningGenerationOptions(BuildingRegulation)</c> fills them per regime, and the wiki page Opening Generation lists each value with its source and status. Values with no cited source are decided defaults to be calibrated.</para>
    /// </summary>
    public class OpeningGenerationOptions : SerializableOptions, IGISSerializableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OpeningGenerationOptions"/> class with the values of the current regime.
        /// </summary>
        public OpeningGenerationOptions()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OpeningGenerationOptions"/> class by copying another instance.
        /// </summary>
        /// <param name="openingGenerationOptions">The options to copy. This value can be null.</param>
        public OpeningGenerationOptions(OpeningGenerationOptions? openingGenerationOptions)
            : base(openingGenerationOptions)
        {
            if (openingGenerationOptions is not null)
            {
                SillHeight = openingGenerationOptions.SillHeight;
                HighSillHeight = openingGenerationOptions.HighSillHeight;
                HighSillElevation = openingGenerationOptions.HighSillElevation;
                InterstoreyStrip = openingGenerationOptions.InterstoreyStrip;
                CornerMargin = openingGenerationOptions.CornerMargin;
                MinimumPier = openingGenerationOptions.MinimumPier;
                HeadClearance = openingGenerationOptions.HeadClearance;
                DaylightRatio = openingGenerationOptions.DaylightRatio;
                HabitableFloorFractions = openingGenerationOptions.HabitableFloorFractions is null ? null : new Dictionary<BuildingType, double>(openingGenerationOptions.HabitableFloorFractions);
                MaximumGlazedAreaThermalTransmittance = openingGenerationOptions.MaximumGlazedAreaThermalTransmittance;
                MaximumGlazedAreaSingleFamilyOnly = openingGenerationOptions.MaximumGlazedAreaSingleFamilyOnly;
                StreetFacadeWeights = openingGenerationOptions.StreetFacadeWeights is null ? null : new Dictionary<BuildingType, double>(openingGenerationOptions.StreetFacadeWeights);
                DoorMinimumWidth = openingGenerationOptions.DoorMinimumWidth;
                DoorMinimumHeight = openingGenerationOptions.DoorMinimumHeight;
                FireSeparationDistances = openingGenerationOptions.FireSeparationDistances is null ? null : new Dictionary<FireClass, double>(openingGenerationOptions.FireSeparationDistances);
                FireSeparationDistancePMMid = openingGenerationOptions.FireSeparationDistancePMMid;
                FireSeparationDistancePMHigh = openingGenerationOptions.FireSeparationDistancePMHigh;
                FireSeparationHeatRelease = openingGenerationOptions.FireSeparationHeatRelease;
                FireSeparationSpreadFactor_OneSide = openingGenerationOptions.FireSeparationSpreadFactor_OneSide;
                FireSeparationSpreadFactor_BothSides = openingGenerationOptions.FireSeparationSpreadFactor_BothSides;
                FireSeparationNoOpeningsFactor = openingGenerationOptions.FireSeparationNoOpeningsFactor;
                FireSeparationHalfStripAngle = openingGenerationOptions.FireSeparationHalfStripAngle;
                FireSeparationNoApplyAngle = openingGenerationOptions.FireSeparationNoApplyAngle;
                FrontageLineMinimumFronts = openingGenerationOptions.FrontageLineMinimumFronts;
                FrontageLineSetbackTolerance = openingGenerationOptions.FrontageLineSetbackTolerance;
                RoadFrontageDistance = openingGenerationOptions.RoadFrontageDistance;
                ObstructionSectorAngle = openingGenerationOptions.ObstructionSectorAngle;
                ObstructionMaxDistance = openingGenerationOptions.ObstructionMaxDistance;
                ObstructionSlenderWidth = openingGenerationOptions.ObstructionSlenderWidth;
                ObstructionSlenderDistance = openingGenerationOptions.ObstructionSlenderDistance;
                ObstructionInnerCityFactor = openingGenerationOptions.ObstructionInnerCityFactor;
                StaircaseSpacing = openingGenerationOptions.StaircaseSpacing;
                DesignLag = openingGenerationOptions.DesignLag;
                ConstructionFlavour = openingGenerationOptions.ConstructionFlavour;
                MinimumStoreyHeight = openingGenerationOptions.MinimumStoreyHeight;
                MaximumStoreyHeightFactor = openingGenerationOptions.MaximumStoreyHeightFactor;

                if (openingGenerationOptions.RoomMixes is not null)
                {
                    RoomMixes = [];
                    foreach (KeyValuePair<BuildingType, Dictionary<RoomUse, double>> keyValuePair in openingGenerationOptions.RoomMixes)
                    {
                        RoomMixes[keyValuePair.Key] = keyValuePair.Value is null ? [] : new Dictionary<RoomUse, double>(keyValuePair.Value);
                    }
                }
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OpeningGenerationOptions"/> class from a JSON object.
        /// </summary>
        /// <param name="jsonObject">The JSON object containing the data. This value can be null.</param>
        public OpeningGenerationOptions(JsonObject? jsonObject)
            : base(jsonObject)
        {
        }

        /// <summary>
        /// Gets or sets the construction flavour the thermal values of window and door constructions are copied from: <see cref="ConstructionFlavour.TypicalAsBuilt"/> (TABULA, looked up by year built) for stock modelling, or <see cref="ConstructionFlavour.Regulation"/> (U(max) of the stage, looked up by design date). A role the chosen flavour lacks falls back to TypicalAsBuilt.
        /// </summary>
        [JsonInclude, JsonPropertyName(nameof(ConstructionFlavour))]
        public ConstructionFlavour ConstructionFlavour { get; set; } = ConstructionFlavour.TypicalAsBuilt;

        /// <summary>
        /// Gets or sets the minimum ratio of glazed area, in the clear of the frames, to floor area of rooms for people [-].
        /// <para>1:8 in § 57 ust. 2 of the technical conditions of 2002 (Dz.U. 2022 poz. 1225) and of 1994 (Dz.U. 1995 nr 10 poz. 46), both read in ISAP on 2026-11-01. 1:10 ("one tenth of the floor area of the dwelling") in the 1928 regulation (Dz.U. 1928 nr 23 poz. 202), read on the same date. A decided 1:8 for the 1961 and 1980 regimes, whose texts give no ratio.</para>
        /// </summary>
        [JsonInclude, JsonPropertyName(nameof(DaylightRatio))]
        public double DaylightRatio { get; set; } = 0.125;

        /// <summary>
        /// Gets or sets the number of years between design and completion: the regime is selected for the year built minus this lag.
        /// </summary>
        [JsonInclude, JsonPropertyName(nameof(DesignLag))]
        public int DesignLag { get; set; } = 2;

        /// <summary>
        /// Gets or sets the minimum clear height of an entrance door [m]: § 62 ust. 1 of the technical conditions of 2002, read in ISAP on 2026-11-01. A door below it is reported, not resized.
        /// </summary>
        [JsonInclude, JsonPropertyName(nameof(DoorMinimumHeight))]
        public double DoorMinimumHeight { get; set; } = 2.0;

        /// <summary>
        /// Gets or sets the minimum clear width of an entrance door, or of the main leaf of a two-leaf door [m]: § 62 ust. 1 of the technical conditions of 2002, read in ISAP on 2026-11-01.
        /// </summary>
        [JsonInclude, JsonPropertyName(nameof(DoorMinimumWidth))]
        public double DoorMinimumWidth { get; set; } = 0.9;

        /// <summary>
        /// Gets or sets the fire-separation distance per kind of building when the fuel-load density Q of both fire compartments is at most 1000 MJ/m2 [m]; a kind missing from the dictionary falls back to the largest value present, an empty dictionary switches § 271 off (DiGi-Organization/DiGi.GIS.Analytical#9).
        /// <para>§ 271 ust. 1 table of the technical conditions of 2002 (Dz.U. 2022 poz. 1225), read in ISAP on 2026-11-01: the required distance between two buildings is the larger of their row values, so ZL, IN and PM at Q &lt;= 1000 all give 8 m against each other and the ZL row already carries the 15 m and 20 m the PM rows of higher fuel loads demand. The kinds are <see cref="FireClass"/>.</para>
        /// </summary>
        [JsonInclude, JsonPropertyName(nameof(FireSeparationDistances))]
        public Dictionary<FireClass, double>? FireSeparationDistances { get; set; } = new()
        {
            [FireClass.ZL] = 8,
            [FireClass.IN] = 8,
            [FireClass.PM] = 8,
        };

        /// <summary>
        /// Gets or sets the fire-separation distance when a building of kind PM has a fuel-load density Q above 1000 and at most 4000 MJ/m2 [m] (DiGi-Organization/DiGi.GIS.Analytical#9).
        /// <para>§ 271 ust. 1 table of the technical conditions of 2002 (Dz.U. 2022 poz. 1225), read in ISAP on 2026-11-01.</para>
        /// </summary>
        [JsonInclude, JsonPropertyName(nameof(FireSeparationDistancePMMid))]
        public double FireSeparationDistancePMMid { get; set; } = 15;

        /// <summary>
        /// Gets or sets the fire-separation distance when a building of kind PM has a fuel-load density Q above 4000 MJ/m2 [m] (DiGi-Organization/DiGi.GIS.Analytical#9).
        /// <para>§ 271 ust. 1 table of the technical conditions of 2002 (Dz.U. 2022 poz. 1225), read in ISAP on 2026-11-01.</para>
        /// </summary>
        [JsonInclude, JsonPropertyName(nameof(FireSeparationDistancePMHigh))]
        public double FireSeparationDistancePMHigh { get; set; } = 20;

        /// <summary>
        /// Gets or sets the maximum fuel-load density Q of the fire compartment [MJ/m2], or null when unknown (DiGi-Organization/DiGi.GIS.Analytical#9).
        /// <para>§ 271 ust. 1 of the technical conditions of 2002 (Dz.U. 2022 poz. 1225), read in ISAP on 2026-11-01: a building of kind PM takes its row of the table by Q, so with Q null a PM building stays at Q &lt;= 1000 MJ/m2. A building whose function does not say whether it is PM takes the row of a stated Q as well, since the table works by the larger requirement of the two buildings.</para>
        /// </summary>
        [JsonInclude, JsonPropertyName(nameof(FireSeparationHeatRelease))]
        public double? FireSeparationHeatRelease { get; set; } = null;

        /// <summary>
        /// Gets or sets the factor applied to the § 271 distance when one of the two buildings - its external wall facing the neighbour or its roof covering - spreads fire [-] (DiGi-Organization/DiGi.GIS.Analytical#9).
        /// <para>§ 271 ust. 2 of the technical conditions of 2002 (Dz.U. 2022 poz. 1225), read in ISAP on 2026-11-01: an increase of 50 %. Whether a building spreads fire comes from <see cref="BuildingModelParameter.FireSpreading"/>, as no construction data reaches the library.</para>
        /// </summary>
        [JsonInclude, JsonPropertyName(nameof(FireSeparationSpreadFactor_OneSide))]
        public double FireSeparationSpreadFactor_OneSide { get; set; } = 1.5;

        /// <summary>
        /// Gets or sets the factor applied to the § 271 distance when both buildings - their external walls facing each other or their roof coverings - spread fire [-] (DiGi-Organization/DiGi.GIS.Analytical#9).
        /// <para>§ 271 ust. 2 of the technical conditions of 2002 (Dz.U. 2022 poz. 1225), read in ISAP on 2026-11-01: an increase of 100 %.</para>
        /// </summary>
        [JsonInclude, JsonPropertyName(nameof(FireSeparationSpreadFactor_BothSides))]
        public double FireSeparationSpreadFactor_BothSides { get; set; } = 2.0;

        /// <summary>
        /// Gets or sets the factor applied to the § 271 distance when the two facing walls carry no openings and neither building spreads fire [-] (DiGi-Organization/DiGi.GIS.Analytical#9).
        /// <para>§ 271 ust. 9 of the technical conditions of 2002 (Dz.U. 2022 poz. 1225), read in ISAP on 2026-11-01: a reduction of 25 %. The further conditions of that clause - buildings listed in § 213 (which include single-family, farm and individual-recreation buildings of up to three storeys), roofs with non-spreading coverings and no explosion-hazard room - are only partly reachable from the stock data: the roof condition rides on <see cref="BuildingModelParameter.FireSpreading"/>, while § 213 membership and explosion-hazard rooms are not modelled and the clause is taken to hold when the walls are opening-free. The walls are read as they are given, before the subject's own openings are placed.</para>
        /// </summary>
        [JsonInclude, JsonPropertyName(nameof(FireSeparationNoOpeningsFactor))]
        public double FireSeparationNoOpeningsFactor { get; set; } = 0.75;

        /// <summary>
        /// Gets or sets the smallest angle between two external walls [deg] from which the strip of § 271 is taken at half the distance (DiGi-Organization/DiGi.GIS.Analytical#9).
        /// <para>§ 271 ust. 11 of the technical conditions of 2002 (Dz.U. 2022 poz. 1225), read in ISAP on 2026-11-01: for walls forming an angle of 60 deg or more but less than 120 deg the strip is reduced by 50 %. The angle is measured between the wall planes on the side of the gap between the two buildings, so parallel facing walls give 0 deg and take the full strip; since no fire-resistance data exists to evaluate the strip requirement of ust. 10 itself, the clause is applied to the distance here as specified by DiGi-Organization/DiGi.GIS.Analytical#9.</para>
        /// </summary>
        [JsonInclude, JsonPropertyName(nameof(FireSeparationHalfStripAngle))]
        public double FireSeparationHalfStripAngle { get; set; } = 60;

        /// <summary>
        /// Gets or sets the angle between two external walls [deg] from which § 271 does not apply between them (DiGi-Organization/DiGi.GIS.Analytical#9).
        /// <para>§ 271 ust. 12 pkt 2 of the technical conditions of 2002 (Dz.U. 2022 poz. 1225), read in ISAP on 2026-11-01: the requirement does not concern buildings whose external walls form an angle of at least 120 deg, measured as in <see cref="FireSeparationHalfStripAngle"/>.</para>
        /// </summary>
        [JsonInclude, JsonPropertyName(nameof(FireSeparationNoApplyAngle))]
        public double FireSeparationNoApplyAngle { get; set; } = 120;

        /// <summary>
        /// Gets or sets the number of building fronts that must align along one road before their walls are reported as a frontage line (pierzeja); the walls of the storeys of one building count as its single front (DiGi-Organization/DiGi.GIS.Analytical#10).
        /// <para>A decided default: three fronts - the subject building plus at least two aligned neighbours. Reported only; a frontage line does not change placement.</para>
        /// </summary>
        [JsonInclude, JsonPropertyName(nameof(FrontageLineMinimumFronts))]
        public int FrontageLineMinimumFronts { get; set; } = 3;

        /// <summary>
        /// Gets or sets the largest difference in the setback of two aligned fronts from the same road at which they are still reported as one frontage line [m] (DiGi-Organization/DiGi.GIS.Analytical#10).
        /// <para>A decided default.</para>
        /// </summary>
        [JsonInclude, JsonPropertyName(nameof(FrontageLineSetbackTolerance))]
        public double FrontageLineSetbackTolerance { get; set; } = 1.0;

        /// <summary>
        /// Gets or sets the share of floor area in rooms that need daylight, per building type [-]; a type missing from the dictionary takes 0.6. A decided default: single-family 0.60, multi-family 0.65, non-residential (<see cref="BuildingType.Undefined"/>) 0.50.
        /// </summary>
        [JsonInclude, JsonPropertyName(nameof(HabitableFloorFractions))]
        public Dictionary<BuildingType, double>? HabitableFloorFractions { get; set; } = new()
        {
            [BuildingType.SingleFamily] = 0.6,
            [BuildingType.Terraced] = 0.6,
            [BuildingType.MultiFamily] = 0.65,
            [BuildingType.ApartmentBlock] = 0.65,
            [BuildingType.Undefined] = 0.5,
        };

        /// <summary>
        /// Gets or sets the smallest distance between a window head and the top of its storey band [m]. A decided default.
        /// </summary>
        [JsonInclude, JsonPropertyName(nameof(HeadClearance))]
        public double HeadClearance { get; set; } = 0.3;

        /// <summary>
        /// Gets or sets the height above the ground storey from which <see cref="HighSillHeight"/> applies [m]: § 301 of the technical conditions of 2002 (25 m), read in ISAP on 2026-11-01.
        /// </summary>
        [JsonInclude, JsonPropertyName(nameof(HighSillElevation))]
        public double HighSillElevation { get; set; } = 25.0;

        /// <summary>
        /// Gets or sets the minimum sill height on storeys more than <see cref="HighSillElevation"/> above the ground [m]: § 301 ust. 2 of the technical conditions of 2002 (1.1 m), read in ISAP on 2026-11-01; the 1980 conditions (§ 64, Dz.U. 1980 nr 17 poz. 62) asked for a guard to 1.1 m.
        /// </summary>
        [JsonInclude, JsonPropertyName(nameof(HighSillHeight))]
        public double HighSillHeight { get; set; } = 1.1;

        /// <summary>
        /// Gets or sets the minimum distance between the head of a window and the sill of the window above it [m]: § 223 ust. 1 of the technical conditions of 2002 (0.8 m), read in ISAP on 2026-11-01; assumed for earlier regimes.
        /// </summary>
        [JsonInclude, JsonPropertyName(nameof(InterstoreyStrip))]
        public double InterstoreyStrip { get; set; } = 0.8;

        /// <summary>
        /// Gets or sets a value indicating whether the maximum glazed area applies to single-family buildings only: so in the original technical conditions of 2002 (annex 2 pt 2.1.1), read in ISAP on 2026-11-01.
        /// </summary>
        [JsonInclude, JsonPropertyName(nameof(MaximumGlazedAreaSingleFamilyOnly))]
        public bool MaximumGlazedAreaSingleFamilyOnly { get; set; } = false;

        /// <summary>
        /// Gets or sets the window U-value from which the maximum glazed area A0max = 0.15 · Az + 0.03 · Aw applies [W/(m2K)], or null when the regime has no such limit.
        /// <para>Annex 2 pt 2.1.1 of the technical conditions, read in ISAP on 2026-11-01: 2.0 from 2002 for single-family buildings (Dz.U. 2002 nr 75 poz. 690); 1.5 from 2009 for residential buildings (Dz.U. 2008 nr 201 poz. 1238); 0.9 from 2014 (Dz.U. 2013 poz. 926). The annex that replaced it from 1 January 2018 (Dz.U. 2017 poz. 2285) has no such limit.</para>
        /// </summary>
        [JsonInclude, JsonPropertyName(nameof(MaximumGlazedAreaThermalTransmittance))]
        public double? MaximumGlazedAreaThermalTransmittance { get; set; } = null;

        /// <summary>
        /// Gets or sets the multiple of the stock's typical storey height above which a storey band is reported as a height mismatch [-]. A decided default.
        /// </summary>
        [JsonInclude, JsonPropertyName(nameof(MaximumStoreyHeightFactor))]
        public double MaximumStoreyHeightFactor { get; set; } = 1.5;

        /// <summary>
        /// Gets or sets the smallest wall between two windows [m]. A decided default.
        /// </summary>
        [JsonInclude, JsonPropertyName(nameof(MinimumPier))]
        public double MinimumPier { get; set; } = 0.5;

        /// <summary>
        /// Gets or sets the storey band height below which a band is reported as a height mismatch [m]. A decided default.
        /// </summary>
        [JsonInclude, JsonPropertyName(nameof(MinimumStoreyHeight))]
        public double MinimumStoreyHeight { get; set; } = 2.2;

        /// <summary>
        /// Gets or sets the angle of the horizontal daylight sector measured at the inner wall face on the window axis [deg] (DiGi-Organization/DiGi.GIS.Analytical#9).
        /// <para>§ 13 ust. 1 pkt 1 of the technical conditions of 2002 (Dz.U. 2022 poz. 1225), read in ISAP on 2026-11-01: no obstructing part of the same building or other obstructing object may lie between the arms of a 60 degree angle closer than its height of shading.</para>
        /// </summary>
        [JsonInclude, JsonPropertyName(nameof(ObstructionSectorAngle))]
        public double ObstructionSectorAngle { get; set; } = 60;

        /// <summary>
        /// Gets or sets the largest height of shading an obstructing object may demand [m]; above it the required distance stops growing (DiGi-Organization/DiGi.GIS.Analytical#9).
        /// <para>§ 13 ust. 1 pkt 1 of the technical conditions of 2002 (Dz.U. 2022 poz. 1225), read in ISAP on 2026-11-01: 35 m for obstructing objects taller than 35 m. This value also caps which neighbours are looked at, the § 271 distances never exceeding it once their factors are read with <see cref="FireSeparationSpreadFactor_BothSides"/>.</para>
        /// </summary>
        [JsonInclude, JsonPropertyName(nameof(ObstructionMaxDistance))]
        public double ObstructionMaxDistance { get; set; } = 35;

        /// <summary>
        /// Gets or sets the largest obstructing width of an object measured parallel to the window plane at which § 13 ust. 3 gives it the fixed distance of <see cref="ObstructionSlenderDistance"/> instead of its height [m] (DiGi-Organization/DiGi.GIS.Analytical#9).
        /// <para>§ 13 ust. 3 of the technical conditions of 2002 (Dz.U. 2022 poz. 1225), read in ISAP on 2026-11-01: a mast, chimney, tower or other building object of obstructing width not greater than 3 m.</para>
        /// </summary>
        [JsonInclude, JsonPropertyName(nameof(ObstructionSlenderWidth))]
        public double ObstructionSlenderWidth { get; set; } = 3;

        /// <summary>
        /// Gets or sets the distance at which a slender obstructing object of <see cref="ObstructionSlenderWidth"/> or less is permitted regardless of its height [m] (DiGi-Organization/DiGi.GIS.Analytical#9).
        /// <para>§ 13 ust. 3 of the technical conditions of 2002 (Dz.U. 2022 poz. 1225), read in ISAP on 2026-11-01: not less than 10 m from the window, without limit on the object's height. A slender object shorter than this distance still answers to the height of shading, so its required distance is the smaller of the two.</para>
        /// </summary>
        [JsonInclude, JsonPropertyName(nameof(ObstructionSlenderDistance))]
        public double ObstructionSlenderDistance { get; set; } = 10;

        /// <summary>
        /// Gets or sets the factor the § 13 distances are multiplied by in inner-city development, or null when the building stands outside it [-] (DiGi-Organization/DiGi.GIS.Analytical#9).
        /// <para>§ 13 ust. 4 of the technical conditions of 2002 (Dz.U. 2022 poz. 1225), read in ISAP on 2026-11-01: the distances may be reduced by no more than half in zabudowa srodmiejska as defined in § 3 pkt 1, so 0.5 is the largest reduction. Whether the building stands in such development is decided by the caller, from the local plan; a null value applies no factor.</para>
        /// </summary>
        [JsonInclude, JsonPropertyName(nameof(ObstructionInnerCityFactor))]
        public double? ObstructionInnerCityFactor { get; set; } = null;

        /// <summary>
        /// Gets or sets the smallest distance from a wall end to a window or door [m]. A decided default.
        /// </summary>
        [JsonInclude, JsonPropertyName(nameof(CornerMargin))]
        public double CornerMargin { get; set; } = 0.5;

        /// <summary>
        /// Gets or sets the depth of the strip facing a wall within which a road polyline marks the wall as road frontage [m] (DiGi-Organization/DiGi.GIS.Analytical#10).
        /// <para>§ 12 ust. 1 pkt 1 and ust. 10 of the technical conditions of 2002 (Dz.U. 2002 nr 75 poz. 690, t.j. Dz.U. 2022 poz. 1225), ust. 10 in the wording added by the amendment of 27 October 2023 (Dz.U. 2023 poz. 2442), read on 2026-11-01 in the Dziennik Ustaw text (ISAP directs machine access to eli.gov.pl): the distances of ust. 1-9 are not required when the neighbouring plot is a road plot or a publicly accessible square, and 4 m is the distance of ust. 1 pkt 1 for a wall turned towards that boundary with windows or doors. The road polyline standing in for the neighbouring plot is a proxy: no parcel data reaches the generator.</para>
        /// </summary>
        [JsonInclude, JsonPropertyName(nameof(RoadFrontageDistance))]
        public double RoadFrontageDistance { get; set; } = 4.0;

        /// <summary>
        /// Gets or sets the shares of a storey's glazing target by room use, per building type [-]; a type missing from the dictionary takes the multi-family shares. A decided default (the model has one space per storey and no rooms): single-family living 0.60, kitchen 0.25, bathroom 0.15; multi-family living 0.65, kitchen 0.25, bathroom 0.10.
        /// </summary>
        [JsonInclude, JsonPropertyName(nameof(RoomMixes))]
        public Dictionary<BuildingType, Dictionary<RoomUse, double>>? RoomMixes { get; set; } = new()
        {
            [BuildingType.SingleFamily] = new() { [RoomUse.LivingRoom] = 0.6, [RoomUse.Kitchen] = 0.25, [RoomUse.Bathroom] = 0.15 },
            [BuildingType.Terraced] = new() { [RoomUse.LivingRoom] = 0.6, [RoomUse.Kitchen] = 0.25, [RoomUse.Bathroom] = 0.15 },
            [BuildingType.MultiFamily] = new() { [RoomUse.LivingRoom] = 0.65, [RoomUse.Kitchen] = 0.25, [RoomUse.Bathroom] = 0.1 },
            [BuildingType.ApartmentBlock] = new() { [RoomUse.LivingRoom] = 0.65, [RoomUse.Kitchen] = 0.25, [RoomUse.Bathroom] = 0.1 },
        };

        /// <summary>
        /// Gets or sets the minimum sill height above the floor of storeys other than the ground storey [m]: § 301 ust. 1 of the technical conditions of 2002 (0.85 m, the ground storey exempt) and the conditions of 1994 and 1980 (§ 63), read in ISAP on 2026-11-01; assumed for earlier regimes.
        /// </summary>
        [JsonInclude, JsonPropertyName(nameof(SillHeight))]
        public double SillHeight { get; set; } = 0.85;

        /// <summary>
        /// Gets or sets the façade length per staircase of a multi-family building [m], which sets the number of staircase entrance doors. A decided default.
        /// </summary>
        [JsonInclude, JsonPropertyName(nameof(StaircaseSpacing))]
        public double StaircaseSpacing { get; set; } = 15.0;

        /// <summary>
        /// Gets or sets the weight of the front wall when windows are distributed over the walls, per building type [-]; a type missing from the dictionary takes 1.0. A decided default, set per regime by <c>Create.OpeningGenerationOptions</c>.
        /// </summary>
        [JsonInclude, JsonPropertyName(nameof(StreetFacadeWeights))]
        public Dictionary<BuildingType, double>? StreetFacadeWeights { get; set; } = null;
    }
}
