using DiGi.Core.Classes;
using DiGi.GIS.Classes;
using DiGi.GIS.Enums;
using DiGi.GIS.Interfaces;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace DiGi.GIS.Analytical.Energy.Classes
{
    /// <summary>
    /// Represents the per-building inputs of the heat-demand assembly of a stored GIS building (DiGi-Organization/DiGi.GIS.Analytical#14): what the opening generation, the internal conditions and the provenance need beyond the model, its 2D building and its solar result.
    /// <para>The construction flavour is <c>OpeningGenerationInput.OpeningGenerationOptions.ConstructionFlavour</c>; it is not held twice. The weather source is used only when the building has no solar result: with one, the climate comes from the weather the result was calculated from.</para>
    /// </summary>
    public class HeatDemandInput : SerializableObject, IGISSerializableObject
    {
        [JsonInclude, JsonPropertyName(nameof(CountyId))]
        private readonly int countyId;

        [JsonInclude, JsonPropertyName(nameof(OccupancyData))]
        private readonly OccupancyData? occupancyData;

        [JsonInclude, JsonPropertyName(nameof(OccupancySource))]
        private readonly string? occupancySource;

        [JsonInclude, JsonPropertyName(nameof(OpeningGenerationInput))]
        private readonly OpeningGenerationInput? openingGenerationInput;

        [JsonInclude, JsonPropertyName(nameof(WeatherSourceId))]
        private readonly string? weatherSourceId;

        [JsonInclude, JsonPropertyName(nameof(WeatherSourceType))]
        private readonly WeatherSourceType weatherSourceType = WeatherSourceType.Undefined;

        /// <summary>
        /// Initializes a new instance of the <see cref="HeatDemandInput"/> class.
        /// <para>The values are assigned and the objects cloned; nothing is validated here.</para>
        /// </summary>
        /// <param name="openingGenerationInput">The input of the opening generation: the year built and its source, the address point, the climate zone, the panel system, the options (the construction flavour among them) and the roads. This value can be null.</param>
        /// <param name="occupancyData">The occupancy estimate of the building, which scales the internal gains and hot water of the usage profile. This value can be null.</param>
        /// <param name="occupancySource">Where the occupancy estimate comes from. This value can be null.</param>
        /// <param name="countyId">The id of the county part the building is filed under.</param>
        /// <param name="weatherSourceType">The kind of the weather source the climate is taken from, when the building has no solar result.</param>
        /// <param name="weatherSourceId">The id of the weather source (the <c>epw_file</c> id of an EPW source), when the building has no solar result. This value can be null.</param>
        public HeatDemandInput(OpeningGenerationInput? openingGenerationInput, OccupancyData? occupancyData, string? occupancySource, int countyId, WeatherSourceType weatherSourceType, string? weatherSourceId)
            : base()
        {
            this.openingGenerationInput = Core.Query.Clone(openingGenerationInput);
            this.occupancyData = Core.Query.Clone(occupancyData);
            this.occupancySource = occupancySource;
            this.countyId = countyId;
            this.weatherSourceType = weatherSourceType;
            this.weatherSourceId = weatherSourceId;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HeatDemandInput"/> class by copying an existing instance.
        /// </summary>
        /// <param name="heatDemandInput">The <see cref="HeatDemandInput"/> to copy. This value can be null.</param>
        public HeatDemandInput(HeatDemandInput? heatDemandInput)
            : base(heatDemandInput)
        {
            if (heatDemandInput is not null)
            {
                openingGenerationInput = Core.Query.Clone(heatDemandInput.openingGenerationInput);
                occupancyData = Core.Query.Clone(heatDemandInput.occupancyData);
                occupancySource = heatDemandInput.occupancySource;
                countyId = heatDemandInput.countyId;
                weatherSourceType = heatDemandInput.weatherSourceType;
                weatherSourceId = heatDemandInput.weatherSourceId;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HeatDemandInput"/> class from a JSON object.
        /// </summary>
        /// <param name="jsonObject">The JSON object containing the data. This value can be null.</param>
        public HeatDemandInput(JsonObject? jsonObject)
            : base(jsonObject)
        {
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
        /// Gets a clone of the occupancy estimate of the building, which scales the internal gains and hot water of the usage profile.
        /// </summary>
        [JsonIgnore]
        public OccupancyData? OccupancyData
        {
            get
            {
                return Core.Query.Clone(occupancyData);
            }
        }

        /// <summary>
        /// Gets where the occupancy estimate comes from.
        /// </summary>
        [JsonIgnore]
        public string? OccupancySource
        {
            get
            {
                return occupancySource;
            }
        }

        /// <summary>
        /// Gets a clone of the input of the opening generation: the year built and its source, the address point, the climate zone, the panel system, the options (the construction flavour among them) and the roads.
        /// </summary>
        [JsonIgnore]
        public OpeningGenerationInput? OpeningGenerationInput
        {
            get
            {
                return Core.Query.Clone(openingGenerationInput);
            }
        }

        /// <summary>
        /// Gets the id of the weather source (the <c>epw_file</c> id of an EPW source), when the building has no solar result.
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
        /// Gets the kind of the weather source the climate is taken from, when the building has no solar result.
        /// </summary>
        [JsonIgnore]
        public WeatherSourceType WeatherSourceType
        {
            get
            {
                return weatherSourceType;
            }
        }
    }
}
