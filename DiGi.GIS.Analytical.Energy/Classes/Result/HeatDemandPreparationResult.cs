using DiGi.Analytical.Building.Classes;
using DiGi.Analytical.Building.Energy.Classes;
using DiGi.Analytical.Building.Regulation.Enums;
using DiGi.Core.Classes;
using DiGi.GIS.Classes;
using DiGi.GIS.Interfaces;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace DiGi.GIS.Analytical.Energy.Classes
{
    /// <summary>
    /// Represents what the heat-demand engine is calculated on, exactly as it was prepared (DiGi-Organization/DiGi.GIS.Analytical#15, for DiGi-Organization/DiGi.Analytical#10): the model with its party walls split, its openings and envelope constructions placed and its internal conditions assigned, the <see cref="OpeningGenerationResult"/> carrying <see cref="OpeningGenerationResult.TypologyData"/>, the <see cref="MonthlyClimate"/> the engine was given, and their provenance.
    /// <para>Created by <c>Create.HeatDemandPreparationResult</c>; stored by nothing - the EnergyPlus cross-check (DiGi-Organization/DiGi.EnergyPlus#1) exports this model rather than rebuilding the preparation, so it cannot drift from the engine. <c>Create.BuildingHeatDemandResult</c> is this preparation plus <c>DiGi.Analytical.Building.Energy.Create.HeatDemandResult</c>. The constructor only assigns and clones, and every property hands out a copy.</para>
    /// </summary>
    public class HeatDemandPreparationResult : SerializableResult, IGISSerializableObject
    {
        [JsonInclude, JsonPropertyName(nameof(BuildingModel))]
        private readonly BuildingModel? buildingModel;

        [JsonInclude, JsonPropertyName(nameof(ClimateZone))]
        private readonly ClimateZone climateZone = ClimateZone.Undefined;

        [JsonInclude, JsonPropertyName(nameof(ConstructionLibraryVersion))]
        private readonly string? constructionLibraryVersion;

        [JsonInclude, JsonPropertyName(nameof(MatchedSurfaceCount))]
        private readonly int matchedSurfaceCount;

        [JsonInclude, JsonPropertyName(nameof(MonthlyClimate))]
        private readonly MonthlyClimate? monthlyClimate;

        [JsonInclude, JsonPropertyName(nameof(OpeningGenerationResult))]
        private readonly OpeningGenerationResult? openingGenerationResult;

        [JsonInclude, JsonPropertyName(nameof(UnshadedSurfaceCount))]
        private readonly int unshadedSurfaceCount;

        [JsonInclude, JsonPropertyName(nameof(UsageSource))]
        private readonly string? usageSource;

        /// <summary>
        /// Initializes a new instance of the <see cref="HeatDemandPreparationResult"/> class.
        /// <para>The model and the nested results are cloned; <c>Create.HeatDemandPreparationResult</c> computes the values.</para>
        /// </summary>
        /// <param name="buildingModel">The prepared building model: party walls split against the neighbours, openings and envelope constructions placed, internal conditions assigned. This value can be null.</param>
        /// <param name="openingGenerationResult">What <c>Modify.GenerateOpenings</c> did and could not do, <see cref="OpeningGenerationResult.TypologyData"/> included - the set the engine takes its F_w, ΔU_tb, F_f, floor boundary, R_add and b from. This value can be null.</param>
        /// <param name="monthlyClimate">The monthly climate the engine was calculated with, or null when the weather holds no record (DiGi-Organization/DiGi.GIS.Analytical#15).</param>
        /// <param name="climateZone">The climate zone the monthly climate was built for: the input's when it names one, else the zone of the footprint.</param>
        /// <param name="constructionLibraryVersion">The version of the construction library the openings and the envelope constructions were taken from - the context's library, or the embedded one. This value can be null.</param>
        /// <param name="matchedSurfaceCount">The number of external surfaces created by the party-wall split and matched to the stored solar surface of the wall they were split from.</param>
        /// <param name="unshadedSurfaceCount">The number of external surfaces that took the unshaded irradiation of their orientation and tilt, having no stored solar surface.</param>
        /// <param name="usageSource">The source of the usage profile of the internal conditions, a fallback rule included. This value can be null.</param>
        public HeatDemandPreparationResult(
            BuildingModel? buildingModel,
            OpeningGenerationResult? openingGenerationResult,
            MonthlyClimate? monthlyClimate,
            ClimateZone climateZone,
            string? constructionLibraryVersion,
            int matchedSurfaceCount,
            int unshadedSurfaceCount,
            string? usageSource)
            : base()
        {
            // The copy constructor, not Core.Query.Clone: ParametrizedObject.Clone is a
            // MemberwiseClone, so a cloned model shares its relations with the original
            // (DiGi-Organization/DiGi.Core#14), and what this result hands out must stay isolated
            // from it - the same rule the preparation follows for its working copy.
            this.buildingModel = buildingModel is null ? null : new BuildingModel(buildingModel);
            this.openingGenerationResult = Core.Query.Clone(openingGenerationResult);
            this.monthlyClimate = Core.Query.Clone(monthlyClimate);
            this.climateZone = climateZone;
            this.constructionLibraryVersion = constructionLibraryVersion;
            this.matchedSurfaceCount = matchedSurfaceCount;
            this.unshadedSurfaceCount = unshadedSurfaceCount;
            this.usageSource = usageSource;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HeatDemandPreparationResult"/> class by copying an existing instance.
        /// </summary>
        /// <param name="heatDemandPreparationResult">The <see cref="HeatDemandPreparationResult"/> to copy. This value can be null.</param>
        public HeatDemandPreparationResult(HeatDemandPreparationResult? heatDemandPreparationResult)
            : base(heatDemandPreparationResult)
        {
            if (heatDemandPreparationResult is not null)
            {
                buildingModel = heatDemandPreparationResult.buildingModel is null ? null : new BuildingModel(heatDemandPreparationResult.buildingModel);
                openingGenerationResult = Core.Query.Clone(heatDemandPreparationResult.openingGenerationResult);
                monthlyClimate = Core.Query.Clone(heatDemandPreparationResult.monthlyClimate);
                climateZone = heatDemandPreparationResult.climateZone;
                constructionLibraryVersion = heatDemandPreparationResult.constructionLibraryVersion;
                matchedSurfaceCount = heatDemandPreparationResult.matchedSurfaceCount;
                unshadedSurfaceCount = heatDemandPreparationResult.unshadedSurfaceCount;
                usageSource = heatDemandPreparationResult.usageSource;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HeatDemandPreparationResult"/> class from a JSON object.
        /// </summary>
        /// <param name="jsonObject">The JSON object containing the data. This value can be null.</param>
        public HeatDemandPreparationResult(JsonObject? jsonObject)
            : base(jsonObject)
        {
        }

        /// <summary>
        /// Gets a copy of the prepared building model: party walls split against the neighbours, openings and envelope constructions placed, internal conditions assigned.
        /// </summary>
        [JsonIgnore]
        public BuildingModel? BuildingModel
        {
            get
            {
                return buildingModel is null ? null : new BuildingModel(buildingModel);
            }
        }

        /// <summary>
        /// Gets the climate zone the monthly climate was built for: the input's when it names one, else the zone of the footprint.
        /// </summary>
        [JsonIgnore]
        public ClimateZone ClimateZone
        {
            get
            {
                return climateZone;
            }
        }

        /// <summary>
        /// Gets the version of the construction library the openings and the envelope constructions were taken from.
        /// </summary>
        [JsonIgnore]
        public string? ConstructionLibraryVersion
        {
            get
            {
                return constructionLibraryVersion;
            }
        }

        /// <summary>
        /// Gets the number of external surfaces created by the party-wall split and matched to the stored solar surface of the wall they were split from.
        /// </summary>
        [JsonIgnore]
        public int MatchedSurfaceCount
        {
            get
            {
                return matchedSurfaceCount;
            }
        }

        /// <summary>
        /// Gets a clone of the monthly climate the engine was calculated with, or null when the weather holds no record (DiGi-Organization/DiGi.GIS.Analytical#15).
        /// </summary>
        [JsonIgnore]
        public MonthlyClimate? MonthlyClimate
        {
            get
            {
                return Core.Query.Clone(monthlyClimate);
            }
        }

        /// <summary>
        /// Gets a clone of what <c>Modify.GenerateOpenings</c> did and could not do: the keys it looked the sizes and constructions up by, the placed openings, the envelope roles, and <see cref="OpeningGenerationResult.TypologyData"/> of the set the engine reads. This value can be null.
        /// </summary>
        [JsonIgnore]
        public OpeningGenerationResult? OpeningGenerationResult
        {
            get
            {
                return Core.Query.Clone(openingGenerationResult);
            }
        }

        /// <summary>
        /// Gets the number of external surfaces that took the unshaded irradiation of their orientation and tilt, having no stored solar surface.
        /// </summary>
        [JsonIgnore]
        public int UnshadedSurfaceCount
        {
            get
            {
                return unshadedSurfaceCount;
            }
        }

        /// <summary>
        /// Gets the source of the usage profile of the internal conditions, a fallback rule included.
        /// </summary>
        [JsonIgnore]
        public string? UsageSource
        {
            get
            {
                return usageSource;
            }
        }
    }
}
