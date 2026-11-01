using DiGi.Analytical.Building.Regulation.Enums;
using DiGi.Core.Classes;
using DiGi.Geometry.Planar.Classes;
using DiGi.GIS.Enums;
using DiGi.GIS.Interfaces;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace DiGi.GIS.Classes
{
    /// <summary>
    /// Holds the building-specific inputs of <c>Modify.GenerateOpenings</c> that the model and its 2D building do not carry (DiGi-Organization/DiGi.GIS.Analytical#2).
    /// </summary>
    public class OpeningGenerationInput : SerializableObject, IGISSerializableObject
    {
        [JsonInclude, JsonPropertyName(nameof(AddressPoint))]
        private readonly Point2D? addressPoint;

        [JsonInclude, JsonPropertyName(nameof(ClimateZone))]
        private readonly ClimateZone climateZone;

        [JsonInclude, JsonPropertyName(nameof(OpeningGenerationOptions))]
        private readonly OpeningGenerationOptions? openingGenerationOptions;

        [JsonInclude, JsonPropertyName(nameof(PanelSystem))]
        private readonly string? panelSystem;

        [JsonInclude, JsonPropertyName(nameof(YearBuilt))]
        private readonly short? yearBuilt;

        [JsonInclude, JsonPropertyName(nameof(YearBuiltSource))]
        private readonly YearBuiltSource? yearBuiltSource;

        /// <summary>
        /// Initializes a new instance of the <see cref="OpeningGenerationInput"/> class.
        /// </summary>
        /// <param name="yearBuilt">The year the building was completed, or null when unknown.</param>
        /// <param name="yearBuiltSource">Where <paramref name="yearBuilt"/> comes from, or null when no year is known.</param>
        /// <param name="addressPoint">The location of the building's address point in the coordinate system of the model, or null; the entrance goes on the external wall nearest it.</param>
        /// <param name="climateZone">The climatic zone of the building; <see cref="ClimateZone.Undefined"/> takes the zone I-III window limits.</param>
        /// <param name="panelSystem">The large-panel system of a 1967-1985 apartment block ("W-70", "OWT-67", ...), or null for the default W-70.</param>
        /// <param name="openingGenerationOptions">The rules to apply, or null for those of the building's regime.</param>
        public OpeningGenerationInput(short? yearBuilt, YearBuiltSource? yearBuiltSource, Point2D? addressPoint, ClimateZone climateZone, string? panelSystem, OpeningGenerationOptions? openingGenerationOptions)
        {
            this.yearBuilt = yearBuilt;
            this.yearBuiltSource = yearBuiltSource;
            this.addressPoint = Core.Query.Clone(addressPoint);
            this.climateZone = climateZone;
            this.panelSystem = panelSystem;
            this.openingGenerationOptions = Core.Query.Clone(openingGenerationOptions);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OpeningGenerationInput"/> class by copying another instance.
        /// </summary>
        /// <param name="openingGenerationInput">The input to copy. This value can be null.</param>
        public OpeningGenerationInput(OpeningGenerationInput? openingGenerationInput)
            : base(openingGenerationInput)
        {
            if (openingGenerationInput is not null)
            {
                yearBuilt = openingGenerationInput.yearBuilt;
                yearBuiltSource = openingGenerationInput.yearBuiltSource;
                addressPoint = Core.Query.Clone(openingGenerationInput.addressPoint);
                climateZone = openingGenerationInput.climateZone;
                panelSystem = openingGenerationInput.panelSystem;
                openingGenerationOptions = Core.Query.Clone(openingGenerationInput.openingGenerationOptions);
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OpeningGenerationInput"/> class from a JSON object.
        /// </summary>
        /// <param name="jsonObject">The JSON object containing the data. This value can be null.</param>
        public OpeningGenerationInput(JsonObject? jsonObject)
            : base(jsonObject)
        {
        }

        /// <summary>
        /// Gets a CLONE of the location of the building's address point, or null.
        /// </summary>
        [JsonIgnore]
        public Point2D? AddressPoint
        {
            get
            {
                return Core.Query.Clone(addressPoint);
            }
        }

        /// <summary>
        /// Gets the climatic zone of the building.
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
        /// Gets a CLONE of the rules to apply, or null for those of the building's regime.
        /// </summary>
        [JsonIgnore]
        public OpeningGenerationOptions? OpeningGenerationOptions
        {
            get
            {
                return Core.Query.Clone(openingGenerationOptions);
            }
        }

        /// <summary>
        /// Gets the large-panel system of a 1967-1985 apartment block, or null for the default W-70.
        /// </summary>
        [JsonIgnore]
        public string? PanelSystem
        {
            get
            {
                return panelSystem;
            }
        }

        /// <summary>
        /// Gets the year the building was completed, or null when unknown.
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
        /// Gets where the year built comes from, or null when no year is known.
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
