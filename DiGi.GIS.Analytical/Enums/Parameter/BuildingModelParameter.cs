using DiGi.Analytical.Building.Classes;
using DiGi.Core.Parameter.Classes;
using System.ComponentModel;

namespace DiGi.GIS.Analytical.Enums
{
    /// <summary>
    /// Defines the available parameters for a building model.
    /// </summary>
    [AssociatedTypes(typeof(BuildingModel)), Description("Building Model Parameters")]
    public enum BuildingModelParameter
    {
        /// <summary>
        /// Gets the data source information associated with the building model.
        /// </summary>
        [ParameterProperties("8286ccdc-1731-4d66-b8a2-de6f52c00a24", "Source", "Source", Core.Parameter.Enums.AccessType.Read), StringParameterValue()] Source,

        /// <summary>
        /// Gets the reference identifier associated with the building model.
        /// </summary>
        [ParameterProperties("59029eab-aa99-4caa-9ae6-10613421ef1d", "Reference", "Reference", Core.Parameter.Enums.AccessType.Read), StringParameterValue(false)] Reference,

        /// <summary>
        /// Gets the administrative area code associated with the building model.
        /// </summary>
        [ParameterProperties("47495ce2-6884-4eb0-92f1-217e79c6a7de", "Code", "Code", Core.Parameter.Enums.AccessType.Read), StringParameterValue()] Code,

        /// <summary>
        /// Gets whether an external wall facing the neighbouring building, or the roof covering, spreads fire (DiGi-Organization/DiGi.GIS.Analytical#9). A building carrying this flag raises the § 271 distance by the one-side or both-sides factor of <c>OpeningGenerationOptions</c> and loses the § 271 ust. 9 no-openings reduction. Not derivable from the stock data, so the flag is absent - the wall and roof do not spread fire - until a caller or the database sets it.
        /// </summary>
        [ParameterProperties("917498af-9784-4f62-86c9-7b85834f326a", "FireSpreading", "Spreads fire", Core.Parameter.Enums.AccessType.Read), BooleanParameterValue()] FireSpreading,
    }
}