using DiGi.GIS.Analytical.Enums;
using DiGi.GIS.Enums;

namespace DiGi.GIS.Analytical
{
    public static partial class Query
    {
        /// <summary>
        /// Gets the kind of building of § 271 for the general function of a 2D building (DiGi-Organization/DiGi.GIS.Analytical#9).
        /// <para>§ 209 ust. 1 of the technical conditions of 2002 (Dz.U. 2022 poz. 1225), read in ISAP on 2026-11-01, divides buildings into ZL (residential, collective-residence and public-utility), PM (production and storage) and IN (livestock): residential, office, commercial, education/science/culture/sports, hospital/healthcare, transport, other non-residential and unknown functions take ZL, agricultural production for agriculture and industrial, tanks/silos/storage take PM. The kind decides the row of the § 271 table together with the fuel-load density Q of <c>OpeningGenerationOptions.FireSeparationHeatRelease</c>; with Q unknown the ZL, IN and PM rows of Q &lt;= 1000 MJ/m2 all give the same distance.</para>
        /// </summary>
        /// <param name="buildingGeneralFunction">The general function of the building, or null when unknown.</param>
        /// <returns>The kind of building, or null when the function is null.</returns>
        public static FireClass? FireClass(this BuildingGeneralFunction? buildingGeneralFunction)
        {
            if (buildingGeneralFunction is not BuildingGeneralFunction buildingGeneralFunction_Value)
            {
                return null;
            }

            // The enum is qualified: the method of this class carries the same name, and an unqualified
            // FireClass in expression position would bind to the method (CS0119).
            return buildingGeneralFunction_Value switch
            {
                BuildingGeneralFunction.agricultural_production_service_utility_buildings => Enums.FireClass.PM,
                BuildingGeneralFunction.industrial_buildings => Enums.FireClass.PM,
                BuildingGeneralFunction.tanks_silos_and_storage_buildings => Enums.FireClass.PM,
                BuildingGeneralFunction.office_buildings => Enums.FireClass.ZL,
                BuildingGeneralFunction.commercial_service_buildings => Enums.FireClass.ZL,
                BuildingGeneralFunction.residential_buildings => Enums.FireClass.ZL,
                BuildingGeneralFunction.buildings_for_education_science_culture_and_sports => Enums.FireClass.ZL,
                BuildingGeneralFunction.hospital_and_healthcare_buildings => Enums.FireClass.ZL,
                BuildingGeneralFunction.transport_and_communication_buildings => Enums.FireClass.ZL,
                BuildingGeneralFunction.other_non_residential_buildings => Enums.FireClass.ZL,
                _ => Enums.FireClass.ZL,
            };
        }
    }
}
