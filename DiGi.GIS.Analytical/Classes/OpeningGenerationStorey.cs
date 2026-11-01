using DiGi.Core.Classes;
using DiGi.GIS.Interfaces;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace DiGi.GIS.Classes
{
    /// <summary>
    /// Holds what <c>Modify.GenerateOpenings</c> achieved in one storey band of a building (DiGi-Organization/DiGi.GIS.Analytical#2).
    /// </summary>
    public class OpeningGenerationStorey : SerializableObject, IGISSerializableObject
    {
        [JsonInclude, JsonPropertyName(nameof(AchievedGlazedArea))]
        private readonly double achievedGlazedArea;

        [JsonInclude, JsonPropertyName(nameof(Bottom))]
        private readonly double bottom;

        [JsonInclude, JsonPropertyName(nameof(HeightMismatch))]
        private readonly bool heightMismatch;

        [JsonInclude, JsonPropertyName(nameof(Index))]
        private readonly int index;

        [JsonInclude, JsonPropertyName(nameof(TargetGlazedArea))]
        private readonly double targetGlazedArea;

        [JsonInclude, JsonPropertyName(nameof(Top))]
        private readonly double top;

        [JsonInclude, JsonPropertyName(nameof(WindowCount))]
        private readonly int windowCount;

        /// <summary>
        /// Initializes a new instance of the <see cref="OpeningGenerationStorey"/> class.
        /// </summary>
        /// <param name="index">The index of the band, 0 for the ground band.</param>
        /// <param name="bottom">The elevation of the bottom of the band [m].</param>
        /// <param name="top">The elevation of the top of the band [m].</param>
        /// <param name="heightMismatch">True when the band height is below the minimum storey height or above the multiple of the stock's typical storey height in the options.</param>
        /// <param name="targetGlazedArea">The glazed area the daylight ratio asks for, in the clear of the frames [m2].</param>
        /// <param name="achievedGlazedArea">The glazed area of the windows placed for rooms, in the clear of the frames [m2]; staircase windows are not counted.</param>
        /// <param name="windowCount">The number of windows placed for rooms.</param>
        public OpeningGenerationStorey(int index, double bottom, double top, bool heightMismatch, double targetGlazedArea, double achievedGlazedArea, int windowCount)
        {
            this.index = index;
            this.bottom = bottom;
            this.top = top;
            this.heightMismatch = heightMismatch;
            this.targetGlazedArea = targetGlazedArea;
            this.achievedGlazedArea = achievedGlazedArea;
            this.windowCount = windowCount;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OpeningGenerationStorey"/> class by copying another instance.
        /// </summary>
        /// <param name="openingGenerationStorey">The instance to copy. This value can be null.</param>
        public OpeningGenerationStorey(OpeningGenerationStorey? openingGenerationStorey)
            : base(openingGenerationStorey)
        {
            if (openingGenerationStorey is not null)
            {
                index = openingGenerationStorey.index;
                bottom = openingGenerationStorey.bottom;
                top = openingGenerationStorey.top;
                heightMismatch = openingGenerationStorey.heightMismatch;
                targetGlazedArea = openingGenerationStorey.targetGlazedArea;
                achievedGlazedArea = openingGenerationStorey.achievedGlazedArea;
                windowCount = openingGenerationStorey.windowCount;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OpeningGenerationStorey"/> class from a JSON object.
        /// </summary>
        /// <param name="jsonObject">The JSON object containing the data. This value can be null.</param>
        public OpeningGenerationStorey(JsonObject? jsonObject)
            : base(jsonObject)
        {
        }

        /// <summary>
        /// Gets the glazed area of the windows placed for rooms, in the clear of the frames [m2].
        /// </summary>
        [JsonIgnore]
        public double AchievedGlazedArea
        {
            get
            {
                return achievedGlazedArea;
            }
        }

        /// <summary>
        /// Gets the elevation of the bottom of the band [m].
        /// </summary>
        [JsonIgnore]
        public double Bottom
        {
            get
            {
                return bottom;
            }
        }

        /// <summary>
        /// Gets a value indicating whether the band height is outside the range the options accept.
        /// </summary>
        [JsonIgnore]
        public bool HeightMismatch
        {
            get
            {
                return heightMismatch;
            }
        }

        /// <summary>
        /// Gets the index of the band, 0 for the ground band.
        /// </summary>
        [JsonIgnore]
        public int Index
        {
            get
            {
                return index;
            }
        }

        /// <summary>
        /// Gets the glazed area the daylight target asks for and the windows placed do not reach [m2]; 0 when the target is met. A shortfall is a finding, not an error.
        /// </summary>
        [JsonIgnore]
        public double Shortfall
        {
            get
            {
                return achievedGlazedArea >= targetGlazedArea ? 0.0 : targetGlazedArea - achievedGlazedArea;
            }
        }

        /// <summary>
        /// Gets the glazed area the daylight ratio asks for, in the clear of the frames [m2].
        /// </summary>
        [JsonIgnore]
        public double TargetGlazedArea
        {
            get
            {
                return targetGlazedArea;
            }
        }

        /// <summary>
        /// Gets the elevation of the top of the band [m].
        /// </summary>
        [JsonIgnore]
        public double Top
        {
            get
            {
                return top;
            }
        }

        /// <summary>
        /// Gets the number of windows placed for rooms.
        /// </summary>
        [JsonIgnore]
        public int WindowCount
        {
            get
            {
                return windowCount;
            }
        }
    }
}
