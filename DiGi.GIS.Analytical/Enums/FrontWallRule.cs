using System.ComponentModel;

namespace DiGi.GIS.Analytical.Enums
{
    /// <summary>
    /// Specifies how the front wall of a building, which holds the entrance door, was chosen (DiGi-Organization/DiGi.GIS.Analytical#2).
    /// </summary>
    [Description("Front wall rule")]
    public enum FrontWallRule
    {
        /// <summary>
        /// No front wall was chosen.
        /// </summary>
        [Description("Undefined")] Undefined,

        /// <summary>
        /// The external wall nearest the address point of the building.
        /// </summary>
        [Description("Address point")] AddressPoint,

        /// <summary>
        /// The longest unrestricted external wall of the ground storey, used when no address point is given.
        /// </summary>
        [Description("Longest edge")] LongestEdge,
    }
}
