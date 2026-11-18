using System.ComponentModel;

namespace DiGi.GIS.Analytical.Energy.Enums
{
    /// <summary>
    /// Specifies where the monthly irradiation of a building's external surfaces comes from in its heat demand (DiGi-Organization/DiGi.GIS.Analytical#14).
    /// </summary>
    [Description("Heat demand solar source")]
    public enum HeatDemandSolarSource
    {
        /// <summary>The source is not known.</summary>
        [Description("Undefined")] Undefined,

        /// <summary>The stored solar result of the building: its shading factors and view factors, neighbours included. Surfaces without a stored surface still take the unshaded irradiation; their number is recorded.</summary>
        [Description("Shaded")] Shaded,

        /// <summary>No solar result: every surface takes the irradiation of its orientation and tilt under an open sky, from the same weather.</summary>
        [Description("Unshaded")] Unshaded,
    }
}
