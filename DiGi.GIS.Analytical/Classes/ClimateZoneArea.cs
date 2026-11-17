using DiGi.Analytical.Building.Regulation.Enums;
using DiGi.Core.Classes;
using DiGi.Geometry.Planar.Classes;
using DiGi.GIS.Interfaces;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace DiGi.GIS.Classes
{
    /// <summary>
    /// One area of a climate zone map: a polygonal face in EPSG:2180 and the PN-82/B-02403 climate zone it lies in (DiGi-Organization/DiGi.GIS.Analytical#7).
    /// <para>A zone may consist of several areas. Zone V, for example, covers the north-east and the Tatra mountains.</para>
    /// </summary>
    public class ClimateZoneArea : SerializableObject, IGISSerializableObject
    {
        [JsonInclude, JsonPropertyName(nameof(ClimateZone))]
        private readonly ClimateZone climateZone;

        [JsonInclude, JsonPropertyName(nameof(PolygonalFace2D))]
        private readonly PolygonalFace2D? polygonalFace2D;

        /// <summary>
        /// Initializes a new instance of the <see cref="ClimateZoneArea"/> class.
        /// </summary>
        /// <param name="climateZone">The climate zone of the area.</param>
        /// <param name="polygonalFace2D">The outline of the area in EPSG:2180. It is cloned.</param>
        public ClimateZoneArea(ClimateZone climateZone, PolygonalFace2D? polygonalFace2D)
        {
            this.climateZone = climateZone;
            this.polygonalFace2D = Core.Query.Clone(polygonalFace2D);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ClimateZoneArea"/> class by copying another instance.
        /// </summary>
        /// <param name="climateZoneArea">The area to copy. This value can be null.</param>
        public ClimateZoneArea(ClimateZoneArea? climateZoneArea)
            : base(climateZoneArea)
        {
            if (climateZoneArea is not null)
            {
                climateZone = climateZoneArea.climateZone;
                polygonalFace2D = Core.Query.Clone(climateZoneArea.polygonalFace2D);
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ClimateZoneArea"/> class from a JSON object.
        /// </summary>
        /// <param name="jsonObject">The JSON object containing the data. This value can be null.</param>
        public ClimateZoneArea(JsonObject? jsonObject)
            : base(jsonObject)
        {
        }

        /// <summary>
        /// Gets the climate zone of the area.
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
        /// Gets a CLONE of the outline of the area in EPSG:2180, or null.
        /// </summary>
        [JsonIgnore]
        public PolygonalFace2D? PolygonalFace2D
        {
            get
            {
                return Core.Query.Clone(polygonalFace2D);
            }
        }
    }
}
