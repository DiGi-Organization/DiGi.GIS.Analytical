using DiGi.Analytical.Building.Energy.Classes;
using DiGi.Analytical.Building.Regulation.Enums;
using DiGi.Core.Classes;
using DiGi.GIS.Analytical.Energy.Enums;
using DiGi.GIS.Enums;
using DiGi.GIS.Interfaces;
using System;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace DiGi.GIS.Analytical.Energy.Classes
{
    /// <summary>
    /// Represents the monthly heat demand of a stored GIS building with the provenance of its inputs (DiGi-Organization/DiGi.GIS.Analytical#14, for DiGi-Organization/DiGi.Analytical#10): what the model, the climate and the constructions were taken from, and the nested <see cref="DiGi.Analytical.Building.Energy.Classes.HeatDemandResult"/>.
    /// <para>Created by <c>Create.BuildingHeatDemandResult</c>; stored by DiGi.GIS.PostgreSQL in <c>building_heat_demand</c>. The constructor only assigns and clones.</para>
    /// </summary>
    public class BuildingHeatDemandResult : SerializableResult, IGISSerializableObject
    {
        [JsonInclude, JsonPropertyName(nameof(BuildingModelId))]
        private readonly long buildingModelId;

        [JsonInclude, JsonPropertyName(nameof(BuildingType))]
        private readonly BuildingType buildingType;

        [JsonInclude, JsonPropertyName(nameof(ConstructionFlavour))]
        private readonly ConstructionFlavour constructionFlavour;

        [JsonInclude, JsonPropertyName(nameof(ConstructionLibraryVersion))]
        private readonly string? constructionLibraryVersion;

        [JsonInclude, JsonPropertyName(nameof(ConstructionSetSource))]
        private readonly string? constructionSetSource;

        [JsonInclude, JsonPropertyName(nameof(CountyId))]
        private readonly int countyId;

        [JsonInclude, JsonPropertyName(nameof(CreatedAt))]
        private readonly DateTimeOffset? createdAt;

        [JsonInclude, JsonPropertyName(nameof(HeatDemandResult))]
        private readonly HeatDemandResult? heatDemandResult;

        [JsonInclude, JsonPropertyName(nameof(MatchedSurfaceCount))]
        private readonly int matchedSurfaceCount;

        [JsonInclude, JsonPropertyName(nameof(Reference))]
        private readonly string? reference;

        [JsonInclude, JsonPropertyName(nameof(SolarRadius))]
        private readonly double? solarRadius;

        [JsonInclude, JsonPropertyName(nameof(SolarSolverVersion))]
        private readonly int? solarSolverVersion;

        [JsonInclude, JsonPropertyName(nameof(SolarSource))]
        private readonly HeatDemandSolarSource solarSource = HeatDemandSolarSource.Undefined;

        [JsonInclude, JsonPropertyName(nameof(UnshadedSurfaceCount))]
        private readonly int unshadedSurfaceCount;

        [JsonInclude, JsonPropertyName(nameof(UsageSource))]
        private readonly string? usageSource;

        [JsonInclude, JsonPropertyName(nameof(WeatherSourceId))]
        private readonly string? weatherSourceId;

        [JsonInclude, JsonPropertyName(nameof(WeatherSourceType))]
        private readonly WeatherSourceType weatherSourceType = WeatherSourceType.Undefined;

        [JsonInclude, JsonPropertyName(nameof(YearBuilt))]
        private readonly short? yearBuilt;

        [JsonInclude, JsonPropertyName(nameof(YearBuiltSource))]
        private readonly YearBuiltSource? yearBuiltSource;

        /// <summary>
        /// Initializes a new instance of the <see cref="BuildingHeatDemandResult"/> class.
        /// <para>The values are assigned and the heat-demand result cloned; <c>Create.BuildingHeatDemandResult</c> computes them.</para>
        /// </summary>
        /// <param name="reference">The <c>building_2d</c> reference of the building. This value can be null.</param>
        /// <param name="countyId">The id of the county part the building is filed under.</param>
        /// <param name="buildingModelId">The id of the stored building model the result was calculated from.</param>
        /// <param name="weatherSourceType">The kind of the weather source of the temperatures and irradiation.</param>
        /// <param name="weatherSourceId">The id of the weather source (the <c>epw_file</c> id of an EPW source). This value can be null.</param>
        /// <param name="solarSource">Where the irradiation of the external surfaces comes from.</param>
        /// <param name="solarSolverVersion">The solver version of the stored solar result, or null when none was used.</param>
        /// <param name="solarRadius">The neighbour radius of the stored solar result [m], or null when none was used.</param>
        /// <param name="matchedSurfaceCount">The number of external surfaces created by the party-wall split and matched to the stored solar surface of the wall they were split from.</param>
        /// <param name="unshadedSurfaceCount">The number of external surfaces that took the unshaded irradiation of their orientation and tilt, having no stored solar surface.</param>
        /// <param name="constructionFlavour">The construction flavour of the envelope and the openings.</param>
        /// <param name="constructionLibraryVersion">The version of the construction library. This value can be null.</param>
        /// <param name="constructionSetSource">The source text of the construction set used. This value can be null.</param>
        /// <param name="buildingType">The building type the constructions and openings were looked up for.</param>
        /// <param name="yearBuilt">The year built, or null when unknown.</param>
        /// <param name="yearBuiltSource">Where the year built comes from, or null when unknown.</param>
        /// <param name="usageSource">The source of the usage profile of the internal conditions, a fallback rule included. This value can be null.</param>
        /// <param name="createdAt">When the result was calculated.</param>
        /// <param name="heatDemandResult">The monthly heat demand of the building. This value can be null.</param>
        public BuildingHeatDemandResult(
            string? reference,
            int countyId,
            long buildingModelId,
            WeatherSourceType weatherSourceType,
            string? weatherSourceId,
            HeatDemandSolarSource solarSource,
            int? solarSolverVersion,
            double? solarRadius,
            int matchedSurfaceCount,
            int unshadedSurfaceCount,
            ConstructionFlavour constructionFlavour,
            string? constructionLibraryVersion,
            string? constructionSetSource,
            BuildingType buildingType,
            short? yearBuilt,
            YearBuiltSource? yearBuiltSource,
            string? usageSource,
            DateTimeOffset? createdAt,
            HeatDemandResult? heatDemandResult)
            : base()
        {
            this.reference = reference;
            this.countyId = countyId;
            this.buildingModelId = buildingModelId;
            this.weatherSourceType = weatherSourceType;
            this.weatherSourceId = weatherSourceId;
            this.solarSource = solarSource;
            this.solarSolverVersion = solarSolverVersion;
            this.solarRadius = solarRadius;
            this.matchedSurfaceCount = matchedSurfaceCount;
            this.unshadedSurfaceCount = unshadedSurfaceCount;
            this.constructionFlavour = constructionFlavour;
            this.constructionLibraryVersion = constructionLibraryVersion;
            this.constructionSetSource = constructionSetSource;
            this.buildingType = buildingType;
            this.yearBuilt = yearBuilt;
            this.yearBuiltSource = yearBuiltSource;
            this.usageSource = usageSource;
            this.createdAt = createdAt;
            this.heatDemandResult = Core.Query.Clone(heatDemandResult);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BuildingHeatDemandResult"/> class by copying an existing instance.
        /// </summary>
        /// <param name="buildingHeatDemandResult">The <see cref="BuildingHeatDemandResult"/> to copy. This value can be null.</param>
        public BuildingHeatDemandResult(BuildingHeatDemandResult? buildingHeatDemandResult)
            : base(buildingHeatDemandResult)
        {
            if (buildingHeatDemandResult is not null)
            {
                reference = buildingHeatDemandResult.reference;
                countyId = buildingHeatDemandResult.countyId;
                buildingModelId = buildingHeatDemandResult.buildingModelId;
                weatherSourceType = buildingHeatDemandResult.weatherSourceType;
                weatherSourceId = buildingHeatDemandResult.weatherSourceId;
                solarSource = buildingHeatDemandResult.solarSource;
                solarSolverVersion = buildingHeatDemandResult.solarSolverVersion;
                solarRadius = buildingHeatDemandResult.solarRadius;
                matchedSurfaceCount = buildingHeatDemandResult.matchedSurfaceCount;
                unshadedSurfaceCount = buildingHeatDemandResult.unshadedSurfaceCount;
                constructionFlavour = buildingHeatDemandResult.constructionFlavour;
                constructionLibraryVersion = buildingHeatDemandResult.constructionLibraryVersion;
                constructionSetSource = buildingHeatDemandResult.constructionSetSource;
                buildingType = buildingHeatDemandResult.buildingType;
                yearBuilt = buildingHeatDemandResult.yearBuilt;
                yearBuiltSource = buildingHeatDemandResult.yearBuiltSource;
                usageSource = buildingHeatDemandResult.usageSource;
                createdAt = buildingHeatDemandResult.createdAt;
                heatDemandResult = Core.Query.Clone(buildingHeatDemandResult.heatDemandResult);
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BuildingHeatDemandResult"/> class from a JSON object.
        /// </summary>
        /// <param name="jsonObject">The JSON object containing the data. This value can be null.</param>
        public BuildingHeatDemandResult(JsonObject? jsonObject)
            : base(jsonObject)
        {
        }

        /// <summary>
        /// Gets the id of the stored building model the result was calculated from.
        /// </summary>
        [JsonIgnore]
        public long BuildingModelId
        {
            get
            {
                return buildingModelId;
            }
        }

        /// <summary>
        /// Gets the building type the constructions and openings were looked up for.
        /// </summary>
        [JsonIgnore]
        public BuildingType BuildingType
        {
            get
            {
                return buildingType;
            }
        }

        /// <summary>
        /// Gets the construction flavour of the envelope and the openings.
        /// </summary>
        [JsonIgnore]
        public ConstructionFlavour ConstructionFlavour
        {
            get
            {
                return constructionFlavour;
            }
        }

        /// <summary>
        /// Gets the version of the construction library.
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
        /// Gets the source text of the construction set used.
        /// </summary>
        [JsonIgnore]
        public string? ConstructionSetSource
        {
            get
            {
                return constructionSetSource;
            }
        }

        /// <summary>
        /// Gets the id of the county part the building is filed under.
        /// </summary>
        [JsonIgnore]
        public int CountyId
        {
            get
            {
                return countyId;
            }
        }

        /// <summary>
        /// Gets when the result was calculated.
        /// </summary>
        [JsonIgnore]
        public DateTimeOffset? CreatedAt
        {
            get
            {
                return createdAt;
            }
        }

        /// <summary>
        /// Gets a clone of the monthly heat demand of the building.
        /// </summary>
        [JsonIgnore]
        public HeatDemandResult? HeatDemandResult
        {
            get
            {
                return Core.Query.Clone(heatDemandResult);
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
        /// Gets the <c>building_2d</c> reference of the building.
        /// </summary>
        [JsonIgnore]
        public string? Reference
        {
            get
            {
                return reference;
            }
        }

        /// <summary>
        /// Gets the neighbour radius of the stored solar result [m], or null when none was used.
        /// </summary>
        [JsonIgnore]
        public double? SolarRadius
        {
            get
            {
                return solarRadius;
            }
        }

        /// <summary>
        /// Gets the solver version of the stored solar result, or null when none was used.
        /// </summary>
        [JsonIgnore]
        public int? SolarSolverVersion
        {
            get
            {
                return solarSolverVersion;
            }
        }

        /// <summary>
        /// Gets where the irradiation of the external surfaces comes from.
        /// </summary>
        [JsonIgnore]
        public HeatDemandSolarSource SolarSource
        {
            get
            {
                return solarSource;
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

        /// <summary>
        /// Gets the id of the weather source (the <c>epw_file</c> id of an EPW source).
        /// </summary>
        [JsonIgnore]
        public string? WeatherSourceId
        {
            get
            {
                return weatherSourceId;
            }
        }

        /// <summary>
        /// Gets the kind of the weather source of the temperatures and irradiation.
        /// </summary>
        [JsonIgnore]
        public WeatherSourceType WeatherSourceType
        {
            get
            {
                return weatherSourceType;
            }
        }

        /// <summary>
        /// Gets the year built, or null when unknown.
        /// </summary>
        [JsonIgnore]
        public short? YearBuilt
        {
            get
            {
                return yearBuilt;
            }
        }

        /// <summary>
        /// Gets where the year built comes from, or null when unknown.
        /// </summary>
        [JsonIgnore]
        public YearBuiltSource? YearBuiltSource
        {
            get
            {
                return yearBuiltSource;
            }
        }
    }
}
