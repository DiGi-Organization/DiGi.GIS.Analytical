using DiGi.Core.Classes;
using DiGi.GIS.Interfaces;
using System.Collections.Generic;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace DiGi.GIS.Classes
{
    /// <summary>
    /// A map of the PN-82/B-02403 climate zones I-V in EPSG:2180, with its source and positional accuracy (DiGi-Organization/DiGi.GIS.Analytical#7).
    /// <para>The Polish map is read with <c>Query.EmbeddedClimateZoneMap_PL</c>, and a point is classified with <c>Query.ClimateZone</c>.</para>
    /// </summary>
    public class ClimateZoneMap : SerializableObject, IGISSerializableObject
    {
        [JsonInclude, JsonPropertyName(nameof(ClimateZoneAreas))]
        private readonly List<ClimateZoneArea>? climateZoneAreas;

        [JsonInclude, JsonPropertyName(nameof(PositionalAccuracy))]
        private readonly double positionalAccuracy;

        [JsonInclude, JsonPropertyName(nameof(Source))]
        private readonly string? source;

        [JsonInclude, JsonPropertyName(nameof(Version))]
        private readonly string? version;

        /// <summary>
        /// Initializes a new instance of the <see cref="ClimateZoneMap"/> class.
        /// </summary>
        /// <param name="version">The version of the map, raised whenever its areas change.</param>
        /// <param name="source">The source tag: the map reproduced, where it was reproduced and how it was digitised.</param>
        /// <param name="positionalAccuracy">The positional accuracy of the zone boundaries in metres.</param>
        /// <param name="climateZoneAreas">The areas of the map. Each one is cloned.</param>
        public ClimateZoneMap(string? version, string? source, double positionalAccuracy, IEnumerable<ClimateZoneArea>? climateZoneAreas)
        {
            this.version = version;
            this.source = source;
            this.positionalAccuracy = positionalAccuracy;
            if (climateZoneAreas is not null)
            {
                this.climateZoneAreas = [];
                foreach (ClimateZoneArea climateZoneArea in climateZoneAreas)
                {
                    if (Core.Query.Clone(climateZoneArea) is ClimateZoneArea climateZoneArea_Temp)
                    {
                        this.climateZoneAreas.Add(climateZoneArea_Temp);
                    }
                }
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ClimateZoneMap"/> class by copying another instance.
        /// </summary>
        /// <param name="climateZoneMap">The map to copy. This value can be null.</param>
        public ClimateZoneMap(ClimateZoneMap? climateZoneMap)
            : base(climateZoneMap)
        {
            if (climateZoneMap is not null)
            {
                version = climateZoneMap.version;
                source = climateZoneMap.source;
                positionalAccuracy = climateZoneMap.positionalAccuracy;
                if (climateZoneMap.climateZoneAreas is not null)
                {
                    climateZoneAreas = [];
                    foreach (ClimateZoneArea climateZoneArea in climateZoneMap.climateZoneAreas)
                    {
                        if (Core.Query.Clone(climateZoneArea) is ClimateZoneArea climateZoneArea_Temp)
                        {
                            climateZoneAreas.Add(climateZoneArea_Temp);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ClimateZoneMap"/> class from a JSON object.
        /// </summary>
        /// <param name="jsonObject">The JSON object containing the data. This value can be null.</param>
        public ClimateZoneMap(JsonObject? jsonObject)
            : base(jsonObject)
        {
        }

        /// <summary>
        /// Gets CLONES of the areas of the map, or null.
        /// </summary>
        [JsonIgnore]
        public List<ClimateZoneArea>? ClimateZoneAreas
        {
            get
            {
                if (climateZoneAreas is null)
                {
                    return null;
                }

                List<ClimateZoneArea> result = [];
                foreach (ClimateZoneArea climateZoneArea in climateZoneAreas)
                {
                    if (Core.Query.Clone(climateZoneArea) is ClimateZoneArea climateZoneArea_Temp)
                    {
                        result.Add(climateZoneArea_Temp);
                    }
                }

                return result;
            }
        }

        /// <summary>
        /// Gets the positional accuracy of the zone boundaries in metres.
        /// </summary>
        [JsonIgnore]
        public double PositionalAccuracy
        {
            get
            {
                return positionalAccuracy;
            }
        }

        /// <summary>
        /// Gets the source tag: the map reproduced, where it was reproduced and how it was digitised.
        /// </summary>
        [JsonIgnore]
        public string? Source
        {
            get
            {
                return source;
            }
        }

        /// <summary>
        /// Gets the version of the map, raised whenever its areas change.
        /// </summary>
        [JsonIgnore]
        public string? Version
        {
            get
            {
                return version;
            }
        }
    }
}
