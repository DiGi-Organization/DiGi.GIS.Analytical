using System.ComponentModel;

namespace DiGi.GIS.Analytical.Enums
{
    /// <summary>
    /// Specifies where the storey bands openings are placed in come from (DiGi-Organization/DiGi.GIS.Analytical#2).
    /// </summary>
    [Description("Storey source")]
    public enum StoreySource
    {
        /// <summary>
        /// No storey band could be derived.
        /// </summary>
        [Description("Undefined")] Undefined,

        /// <summary>
        /// The model holds two or more storey spaces, and each band is the extent of one of them.
        /// </summary>
        [Description("Spaces")] Spaces,

        /// <summary>
        /// The model holds one space, and its height is divided into the storey count of the 2D building.
        /// </summary>
        [Description("Building2D")] Building2D,

        /// <summary>
        /// The model holds one space and no storey count is known, so the count is estimated from the height of its walls and the typical storey height of its stock.
        /// </summary>
        [Description("Estimated")] Estimated,

        /// <summary>
        /// No height could be read, so the whole wall is one band.
        /// </summary>
        [Description("Single")] Single,
    }
}
