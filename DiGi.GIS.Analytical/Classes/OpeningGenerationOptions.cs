using DiGi.Analytical.Building.Regulation.Enums;
using DiGi.Core.Classes;
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
        /// Gets or sets the smallest distance from a wall end to a window or door [m]. A decided default.
        /// </summary>
        [JsonInclude, JsonPropertyName(nameof(CornerMargin))]
        public double CornerMargin { get; set; } = 0.5;

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
