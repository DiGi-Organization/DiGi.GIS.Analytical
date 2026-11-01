using System.ComponentModel;

namespace DiGi.GIS.Analytical.Enums
{
    /// <summary>
    /// Specifies why a wall received no openings from <c>Modify.GenerateOpenings</c> (DiGi-Organization/DiGi.GIS.Analytical#2).
    /// </summary>
    [Description("Wall opening restriction")]
    public enum WallOpeningRestriction
    {
        /// <summary>
        /// The wall may carry openings.
        /// </summary>
        [Description("None")] None,

        /// <summary>
        /// The wall is shared with an adjacent building (<c>ComponentParameter.PartyWall</c>), so it carries no openings.
        /// </summary>
        [Description("Party wall")] PartyWall,

        /// <summary>
        /// The wall is too short to hold the narrowest window between its corner margins.
        /// </summary>
        [Description("Too short")] TooShort,

        /// <summary>
        /// The wall is not part of the external envelope of the model.
        /// </summary>
        [Description("Not external")] NotExternal,
    }
}
