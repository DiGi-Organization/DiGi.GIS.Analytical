using DiGi.Analytical.Building.Energy.Classes;
using DiGi.Analytical.Building.Regulation.Classes;
using DiGi.GIS.Classes;

namespace DiGi.GIS.Analytical.Energy.Classes
{
    /// <summary>
    /// Holds the inputs of the heat-demand assembly shared by every building of a batch, read or created once per batch (DiGi-Organization/DiGi.GIS.Analytical#14): the construction library, the opening-size library, the climate-zone map and the heat-demand options.
    /// <para>Not serializable: the libraries are large and versioned on their own, and the batch records their versions in each result instead.</para>
    /// </summary>
    public class HeatDemandContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HeatDemandContext"/> class.
        /// </summary>
        /// <param name="constructionLibrary">The construction library, or null for <c>Regulation.Query.EmbeddedConstructionLibrary_PL()</c> read per call.</param>
        /// <param name="openingSizeLibrary">The opening-size library, or null for <c>Regulation.Create.OpeningSizeLibrary_PL()</c> created per call.</param>
        /// <param name="climateZoneMap">The climate-zone map, or null for the embedded map read per call.</param>
        /// <param name="heatDemandOptions">The heat-demand options, or null for the defaults.</param>
        public HeatDemandContext(ConstructionLibrary? constructionLibrary, OpeningSizeLibrary? openingSizeLibrary, ClimateZoneMap? climateZoneMap, HeatDemandOptions? heatDemandOptions)
        {
            ConstructionLibrary = constructionLibrary;
            OpeningSizeLibrary = openingSizeLibrary;
            ClimateZoneMap = climateZoneMap;
            HeatDemandOptions = heatDemandOptions;
        }

        /// <summary>
        /// Gets the climate-zone map.
        /// </summary>
        public ClimateZoneMap? ClimateZoneMap { get; }

        /// <summary>
        /// Gets the construction library.
        /// </summary>
        public ConstructionLibrary? ConstructionLibrary { get; }

        /// <summary>
        /// Gets the heat-demand options.
        /// </summary>
        public HeatDemandOptions? HeatDemandOptions { get; }

        /// <summary>
        /// Gets the opening-size library.
        /// </summary>
        public OpeningSizeLibrary? OpeningSizeLibrary { get; }
    }
}
