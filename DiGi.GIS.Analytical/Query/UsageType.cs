using DiGi.GIS.Classes;
using DiGi.GIS.Enums;
using System.Collections.Generic;
using HVAC = DiGi.Analytical.Building.HVAC;

namespace DiGi.GIS.Analytical
{
    public static partial class Query
    {
        /// <summary>
        /// Gets the usage type of the Polish energy-certificate methodology (Dz.U. 2015 poz. 376, Annex 1, Tables 23-27) a BDOT10k building is used as, which selects its usage profile (DiGi-Organization/DiGi.Analytical#9).
        /// <para><b>Specific functions first.</b> Each specific function that names a usage maps to one, and when several do, the first in the order MultiFamily, SingleFamily, CollectiveResidence, Healthcare, Education, Sport, Gastronomy, Retail, Office, Production, Storage wins - people living in a building outweigh what else it is used for:</para>
        /// <list type="bullet">
        /// <item><description>SingleFamily: <c>single_family_building</c>; MultiFamily: <c>multi_family_building</c> (a building with both is multi-family), the same specific functions as <c>GIS.Query.IsResidential</c>.</description></item>
        /// <item><description>CollectiveResidence: dormitories, boarding schools, social-care, children's and juvenile homes, homeless and tourist shelters, monasteries, retreat and parish houses, hotels, motels, workers' hotels, guesthouses, barracks, prisons and correctional facilities.</description></item>
        /// <item><description>Healthcare: hospitals, healthcare facilities, hospices, emergency medical units, blood donation and sanitary-epidemiological stations, sobering-up stations.</description></item>
        /// <item><description>Education: nurseries, kindergartens, primary and secondary schools, universities, other educational and care-educational facilities, research facilities, observatories.</description></item>
        /// <item><description>Sport: sports halls, gyms, swimming pools, ice rinks, arenas, tennis courts, riding halls, bowling alleys, go-kart tracks, sports clubs.</description></item>
        /// <item><description>Gastronomy: restaurants, inns, clubs and discos, wedding houses.</description></item>
        /// <item><description>Retail: shopping centres, department stores, hypermarkets, market halls, commercial and service buildings, pharmacies, banks.</description></item>
        /// <item><description>Office: ministries, voivodeship, marshal's, county, municipal and city offices, courts, prosecutors, other public administration, company headquarters, postal and diplomatic offices.</description></item>
        /// <item><description>Production: production and livestock buildings, repair workshops, refineries, mills, greenhouses.</description></item>
        /// <item><description>Storage: warehouses, cold stores, archives, silos, grain elevators.</description></item>
        /// </list>
        /// <para><b>Then the general function:</b> office → Office, commercial and service → Retail, education, science, culture and sport → Education, hospital and healthcare → Healthcare, agricultural production and industrial → Production, tanks, silos and storage → Storage. Residential buildings without a single- or multi-family specific function, transport and communication, other non-residential buildings and an unknown function give <see cref="HVAC.Enums.UsageType.Undefined"/>, which the caller resolves by a fallback (<see cref="Modify.AssignInternalConditions"/>).</para>
        /// </summary>
        /// <param name="building2D">The building.</param>
        /// <returns>The usage type, or <see cref="HVAC.Enums.UsageType.Undefined"/> when the functions name none or <paramref name="building2D"/> is null.</returns>
        public static HVAC.Enums.UsageType UsageType(this Building2D? building2D)
        {
            if (building2D is null)
            {
                return HVAC.Enums.UsageType.Undefined;
            }

            static HVAC.Enums.UsageType UsageType_Specific(BuildingSpecificFunction buildingSpecificFunction)
            {
                switch (buildingSpecificFunction)
                {
                    case BuildingSpecificFunction.single_family_building:
                        return HVAC.Enums.UsageType.SingleFamily;

                    case BuildingSpecificFunction.multi_family_building:
                        return HVAC.Enums.UsageType.MultiFamily;

                    case BuildingSpecificFunction.student_dormitory:
                    case BuildingSpecificFunction.boarding_school_dormitory:
                    case BuildingSpecificFunction.social_care_home:
                    case BuildingSpecificFunction.childrens_home:
                    case BuildingSpecificFunction.juvenile_shelter:
                    case BuildingSpecificFunction.homeless_shelter:
                    case BuildingSpecificFunction.tourist_shelter:
                    case BuildingSpecificFunction.monastery:
                    case BuildingSpecificFunction.monastery_house:
                    case BuildingSpecificFunction.retreat_house:
                    case BuildingSpecificFunction.parish_house:
                    case BuildingSpecificFunction.hotel:
                    case BuildingSpecificFunction.motel:
                    case BuildingSpecificFunction.workers_hotel:
                    case BuildingSpecificFunction.guesthouse:
                    case BuildingSpecificFunction.barracks:
                    case BuildingSpecificFunction.prison:
                    case BuildingSpecificFunction.prison_or_correctional_facility:
                    case BuildingSpecificFunction.correctional_facility:
                    case BuildingSpecificFunction.remand_prison:
                        return HVAC.Enums.UsageType.CollectiveResidence;

                    case BuildingSpecificFunction.hospital:
                    case BuildingSpecificFunction.healthcare_facility:
                    case BuildingSpecificFunction.hospice:
                    case BuildingSpecificFunction.emergency_medical_service_unit:
                    case BuildingSpecificFunction.blood_donation_station:
                    case BuildingSpecificFunction.sanitary_epidemiological_station:
                    case BuildingSpecificFunction.sobering_up_station:
                        return HVAC.Enums.UsageType.Healthcare;

                    case BuildingSpecificFunction.nursery:
                    case BuildingSpecificFunction.kindergarten:
                    case BuildingSpecificFunction.primary_school:
                    case BuildingSpecificFunction.secondary_school:
                    case BuildingSpecificFunction.higher_education_institution_or_university:
                    case BuildingSpecificFunction.other_educational_facility:
                    case BuildingSpecificFunction.care_educational_facility:
                    case BuildingSpecificFunction.research_facility:
                    case BuildingSpecificFunction.observatory_or_planetarium:
                        return HVAC.Enums.UsageType.Education;

                    case BuildingSpecificFunction.sports_hall:
                    case BuildingSpecificFunction.gym:
                    case BuildingSpecificFunction.swimming_pool:
                    case BuildingSpecificFunction.ice_rink:
                    case BuildingSpecificFunction.arena:
                    case BuildingSpecificFunction.tennis_courts:
                    case BuildingSpecificFunction.riding_hall:
                    case BuildingSpecificFunction.bowling_alley:
                    case BuildingSpecificFunction.indoor_go_kart_track:
                    case BuildingSpecificFunction.sports_club:
                        return HVAC.Enums.UsageType.Sport;

                    case BuildingSpecificFunction.restaurant:
                    case BuildingSpecificFunction.inn:
                    case BuildingSpecificFunction.club_disco:
                    case BuildingSpecificFunction.wedding_house:
                        return HVAC.Enums.UsageType.Gastronomy;

                    case BuildingSpecificFunction.shopping_center:
                    case BuildingSpecificFunction.department_store:
                    case BuildingSpecificFunction.hypermarket_or_supermarket:
                    case BuildingSpecificFunction.market_hall:
                    case BuildingSpecificFunction.commercial_service_building:
                    case BuildingSpecificFunction.pharmacy:
                    case BuildingSpecificFunction.bank:
                        return HVAC.Enums.UsageType.Retail;

                    case BuildingSpecificFunction.ministry_building:
                    case BuildingSpecificFunction.voivodeship_office:
                    case BuildingSpecificFunction.marshals_office:
                    case BuildingSpecificFunction.county_office:
                    case BuildingSpecificFunction.municipal_office:
                    case BuildingSpecificFunction.city_hall:
                    case BuildingSpecificFunction.city_and_municipality_office:
                    case BuildingSpecificFunction.court_building:
                    case BuildingSpecificFunction.prosecutors_office:
                    case BuildingSpecificFunction.other_public_administration_office:
                    case BuildingSpecificFunction.company_headquarters:
                    case BuildingSpecificFunction.postal_operators_office:
                    case BuildingSpecificFunction.diplomatic_or_consular_office:
                        return HVAC.Enums.UsageType.Office;

                    case BuildingSpecificFunction.production_building:
                    case BuildingSpecificFunction.livestock_production_building:
                    case BuildingSpecificFunction.repair_workshop:
                    case BuildingSpecificFunction.refinery:
                    case BuildingSpecificFunction.mill:
                    case BuildingSpecificFunction.greenhouse_or_hothouse:
                        return HVAC.Enums.UsageType.Production;

                    case BuildingSpecificFunction.warehouse:
                    case BuildingSpecificFunction.cold_storage:
                    case BuildingSpecificFunction.archive:
                    case BuildingSpecificFunction.silo:
                    case BuildingSpecificFunction.grain_elevator:
                        return HVAC.Enums.UsageType.Storage;

                    default:
                        return HVAC.Enums.UsageType.Undefined;
                }
            }

            HashSet<BuildingSpecificFunction>? buildingSpecificFunctions = building2D.BuildingSpecificFunctions;
            if (buildingSpecificFunctions is not null && buildingSpecificFunctions.Count != 0)
            {
                HashSet<HVAC.Enums.UsageType> usageTypes = [];
                foreach (BuildingSpecificFunction buildingSpecificFunction in buildingSpecificFunctions)
                {
                    usageTypes.Add(UsageType_Specific(buildingSpecificFunction));
                }

                // A building with both is multi-family, so MultiFamily is checked before SingleFamily.
                HVAC.Enums.UsageType[] usageTypes_Priority =
                [
                    HVAC.Enums.UsageType.MultiFamily,
                    HVAC.Enums.UsageType.SingleFamily,
                    HVAC.Enums.UsageType.CollectiveResidence,
                    HVAC.Enums.UsageType.Healthcare,
                    HVAC.Enums.UsageType.Education,
                    HVAC.Enums.UsageType.Sport,
                    HVAC.Enums.UsageType.Gastronomy,
                    HVAC.Enums.UsageType.Retail,
                    HVAC.Enums.UsageType.Office,
                    HVAC.Enums.UsageType.Production,
                    HVAC.Enums.UsageType.Storage,
                ];

                foreach (HVAC.Enums.UsageType usageType in usageTypes_Priority)
                {
                    if (usageTypes.Contains(usageType))
                    {
                        return usageType;
                    }
                }
            }

            return building2D.BuildingGeneralFunction switch
            {
                BuildingGeneralFunction.office_buildings => HVAC.Enums.UsageType.Office,
                BuildingGeneralFunction.commercial_service_buildings => HVAC.Enums.UsageType.Retail,
                BuildingGeneralFunction.buildings_for_education_science_culture_and_sports => HVAC.Enums.UsageType.Education,
                BuildingGeneralFunction.hospital_and_healthcare_buildings => HVAC.Enums.UsageType.Healthcare,
                BuildingGeneralFunction.agricultural_production_service_utility_buildings => HVAC.Enums.UsageType.Production,
                BuildingGeneralFunction.industrial_buildings => HVAC.Enums.UsageType.Production,
                BuildingGeneralFunction.tanks_silos_and_storage_buildings => HVAC.Enums.UsageType.Storage,
                _ => HVAC.Enums.UsageType.Undefined,
            };
        }
    }
}
