using DiGi.Core.Classes;
using DiGi.GIS.Analytical.Enums;
using DiGi.GIS.Interfaces;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace DiGi.GIS.Classes
{
    /// <summary>
    /// Holds what <c>Query.WallOpeningResults</c> measured for one external wall of a building model: why it is restricted, if at all, and the distances behind that decision (DiGi-Organization/DiGi.GIS.Analytical#9).
    /// <para>Created by <c>Query.WallOpeningResults</c>, which does the measuring; the constructor only assigns and clones. A wall that passes both rules keeps <see cref="WallOpeningRestriction.None"/> and still reports the distances that decided it; a distance with no applicable rule is null.</para>
    /// </summary>
    public class WallOpeningResult : SerializableResult, IGISSerializableObject
    {
        [JsonInclude, JsonPropertyName(nameof(FireSeparationDistance))]
        private readonly double? fireSeparationDistance = null;

        [JsonInclude, JsonPropertyName(nameof(FireSeparationRequired))]
        private readonly double? fireSeparationRequired = null;

        [JsonInclude, JsonPropertyName(nameof(ObstructionDistance))]
        private readonly double? obstructionDistance = null;

        [JsonInclude, JsonPropertyName(nameof(ObstructionRequired))]
        private readonly double? obstructionRequired = null;

        [JsonInclude, JsonPropertyName(nameof(Restriction))]
        private readonly WallOpeningRestriction wallOpeningRestriction = WallOpeningRestriction.None;

        [JsonInclude, JsonPropertyName(nameof(Wall))]
        private readonly GuidReference? wall;

        /// <summary>
        /// Initializes a new instance of the <see cref="WallOpeningResult"/> class.
        /// <para>The values are assigned and the wall reference cloned; the distances are taken as given. <c>Query.WallOpeningResults</c> computes them.</para>
        /// </summary>
        /// <param name="wall">The reference of the external wall this result describes. This value can be null.</param>
        /// <param name="wallOpeningRestriction">Why the wall may carry no openings: <see cref="WallOpeningRestriction.None"/> when neither rule failed, otherwise the governing rule, <see cref="WallOpeningRestriction.FireSeparation"/> winning over <see cref="WallOpeningRestriction.Obstruction"/>.</param>
        /// <param name="fireSeparationDistance">The smallest measured horizontal distance to a facing wall of a neighbour [m], or null when no wall faced it or § 271 does not apply between them.</param>
        /// <param name="fireSeparationRequired">The distance § 271 required at that measurement [m] after the class table, fuel load, spread, no-openings and wall-angle factors, or null when no applicable rule was measured.</param>
        /// <param name="obstructionDistance">The smallest measured distance from a window axis inside the 60 degree sector of § 13 to the obstructing object [m], or null when no object lay in the sector.</param>
        /// <param name="obstructionRequired">The distance § 13 required at that measurement [m], the height of shading capped at 35 m and reduced by the inner-city factor, or null when no object lay in the sector.</param>
        public WallOpeningResult(GuidReference? wall, WallOpeningRestriction wallOpeningRestriction, double? fireSeparationDistance, double? fireSeparationRequired, double? obstructionDistance, double? obstructionRequired)
            : base()
        {
            this.wall = Core.Query.Clone(wall);
            this.wallOpeningRestriction = wallOpeningRestriction;
            this.fireSeparationDistance = fireSeparationDistance;
            this.fireSeparationRequired = fireSeparationRequired;
            this.obstructionDistance = obstructionDistance;
            this.obstructionRequired = obstructionRequired;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WallOpeningResult"/> class by copying another instance.
        /// </summary>
        /// <param name="wallOpeningResult">The result to copy. This value can be null.</param>
        public WallOpeningResult(WallOpeningResult? wallOpeningResult)
            : base(wallOpeningResult)
        {
            if (wallOpeningResult is not null)
            {
                wall = Core.Query.Clone(wallOpeningResult.wall);
                wallOpeningRestriction = wallOpeningResult.wallOpeningRestriction;
                fireSeparationDistance = wallOpeningResult.fireSeparationDistance;
                fireSeparationRequired = wallOpeningResult.fireSeparationRequired;
                obstructionDistance = wallOpeningResult.obstructionDistance;
                obstructionRequired = wallOpeningResult.obstructionRequired;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WallOpeningResult"/> class from a JSON object.
        /// </summary>
        /// <param name="jsonObject">The JSON object containing the result data. This value can be null.</param>
        public WallOpeningResult(JsonObject? jsonObject)
            : base(jsonObject)
        {
        }

        /// <summary>
        /// Gets the smallest measured horizontal distance to a facing wall of a neighbour [m], or null when no wall faced it or § 271 does not apply between them.
        /// </summary>
        [JsonIgnore]
        public double? FireSeparationDistance
        {
            get
            {
                return fireSeparationDistance;
            }
        }

        /// <summary>
        /// Gets the distance § 271 required at the reported measurement [m], or null when no applicable rule was measured.
        /// </summary>
        [JsonIgnore]
        public double? FireSeparationRequired
        {
            get
            {
                return fireSeparationRequired;
            }
        }

        /// <summary>
        /// Gets the smallest measured distance from a window axis inside the 60 degree sector of § 13 to the obstructing object [m], or null when no object lay in the sector.
        /// </summary>
        [JsonIgnore]
        public double? ObstructionDistance
        {
            get
            {
                return obstructionDistance;
            }
        }

        /// <summary>
        /// Gets the distance § 13 required at the reported measurement [m], or null when no object lay in the sector.
        /// </summary>
        [JsonIgnore]
        public double? ObstructionRequired
        {
            get
            {
                return obstructionRequired;
            }
        }

        /// <summary>
        /// Gets why the wall may carry no openings: <see cref="WallOpeningRestriction.None"/> when neither rule failed, otherwise the governing rule.
        /// </summary>
        [JsonIgnore]
        public WallOpeningRestriction Restriction
        {
            get
            {
                return wallOpeningRestriction;
            }
        }

        /// <summary>
        /// Gets a clone of the reference of the external wall this result describes, or null.
        /// </summary>
        [JsonIgnore]
        public GuidReference? Wall
        {
            get
            {
                return Core.Query.Clone(wall);
            }
        }
    }
}
