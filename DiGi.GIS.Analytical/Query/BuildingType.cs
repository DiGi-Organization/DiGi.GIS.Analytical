using DiGi.GIS.Classes;
using DiGi.GIS.Enums;
using System.Collections.Generic;
using Regulation = DiGi.Analytical.Building.Regulation;

namespace DiGi.GIS.Analytical
{
    public static partial class Query
    {
        /// <summary>
        /// The number of storeys from which a multi-family building is taken as an apartment block, a default: the TABULA Polish apartment blocks have 5 to 11 storeys, and no threshold is published.
        /// </summary>
        public const ushort ApartmentBlockStoreys = 5;

        /// <summary>
        /// Gets the TABULA residential building type of a BDOT10k building, the key of the construction library and of the opening size library (DiGi-Organization/DiGi.GIS.Analytical#6).
        /// <para>A single-family building (specific function <c>single_family_building</c>) is <see cref="Regulation.Enums.BuildingType.SingleFamily"/>, or <see cref="Regulation.Enums.BuildingType.Terraced"/> when it has party walls (<c>Analytical.Building.Query.PartyWalls</c>, DiGi-Organization/DiGi.GIS.Analytical#4). A multi-family building (<c>multi_family_building</c>, which wins when both are given) is <see cref="Regulation.Enums.BuildingType.ApartmentBlock"/> from <see cref="ApartmentBlockStoreys"/> storeys and <see cref="Regulation.Enums.BuildingType.MultiFamily"/> below. Any other building is <see cref="Regulation.Enums.BuildingType.Undefined"/>.</para>
        /// </summary>
        /// <param name="building2D">The building.</param>
        /// <param name="partyWalls">True when the building has party walls with a neighbour.</param>
        /// <returns>The building type.</returns>
        public static Regulation.Enums.BuildingType BuildingType(this Building2D? building2D, bool partyWalls = false)
        {
            HashSet<BuildingSpecificFunction>? buildingSpecificFunctions = building2D?.BuildingSpecificFunctions;
            if (building2D is null || buildingSpecificFunctions is null)
            {
                return Regulation.Enums.BuildingType.Undefined;
            }

            if (buildingSpecificFunctions.Contains(BuildingSpecificFunction.multi_family_building))
            {
                return building2D.Storeys >= ApartmentBlockStoreys ? Regulation.Enums.BuildingType.ApartmentBlock : Regulation.Enums.BuildingType.MultiFamily;
            }

            if (buildingSpecificFunctions.Contains(BuildingSpecificFunction.single_family_building))
            {
                return partyWalls ? Regulation.Enums.BuildingType.Terraced : Regulation.Enums.BuildingType.SingleFamily;
            }

            return Regulation.Enums.BuildingType.Undefined;
        }
    }
}
