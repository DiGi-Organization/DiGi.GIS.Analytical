using DiGi.Analytical.Building.Classes;
using DiGi.Core.Parameter.Classes;
using DiGi.GIS.Classes;
using HVAC = DiGi.Analytical.Building.HVAC;

namespace DiGi.GIS.Analytical
{
    public static partial class Modify
    {
        /// <summary>
        /// Assigns the standard-use internal condition of a BDOT10k building to every space of its model: the usage type from <see cref="Query.UsageType(Building2D?)"/>, its usage profile and the internal condition built from it (DiGi-Organization/DiGi.Analytical#9).
        /// <para><b>Fallback.</b> When the functions name no usage type, a residential or occupied building (<c>GIS.Query.IsResidential</c>, <c>GIS.Query.IsOccupied</c>) is treated as multi-family and any other as an office, and <see cref="HVAC.Enums.InternalConditionParameter.UsageSource"/> starts with <c>fallback</c> naming the rule, so every space has a condition and the guess stays visible.</para>
        /// <para><b>Occupancy.</b> The persons are <see cref="OccupancyData.Occupancy"/> and the floor area they share is <see cref="OccupancyData.OccupancyArea"/>, else the footprint area times the storeys - the area the occupancy estimate is made for. Without persons the per-area values of the methodology apply unscaled.</para>
        /// </summary>
        /// <param name="buildingModel">The building model of <paramref name="building2D"/>.</param>
        /// <param name="building2D">The BDOT10k building.</param>
        /// <param name="occupancyData">The occupancy estimate of the building (<c>occupancy_data_building_2d</c>). This value can be null.</param>
        /// <param name="yearBuilt">The year the building was erected, which selects the infiltration; null when unknown.</param>
        /// <param name="occupancySource">Where <paramref name="occupancyData"/> comes from, recorded on the condition. This value can be null.</param>
        /// <returns>True when every space of the model was assigned; otherwise, false.</returns>
        public static bool AssignInternalConditions(this BuildingModel? buildingModel, Building2D? building2D, OccupancyData? occupancyData = null, short? yearBuilt = null, string? occupancySource = null)
        {
            if (buildingModel is null || building2D is null)
            {
                return false;
            }

            HVAC.Enums.UsageType usageType = Query.UsageType(building2D);

            string? fallback = null;
            if (usageType == HVAC.Enums.UsageType.Undefined)
            {
                if (GIS.Query.IsResidential(building2D) || GIS.Query.IsOccupied(building2D))
                {
                    usageType = HVAC.Enums.UsageType.MultiFamily;
                    fallback = "fallback: no usage type in the functions, residential or occupied building taken as multi-family";
                }
                else
                {
                    usageType = HVAC.Enums.UsageType.Office;
                    fallback = "fallback: no usage type in the functions, non-residential building taken as office";
                }
            }

            HVAC.Classes.UsageProfile? usageProfile = HVAC.Create.UsageProfile(usageType);
            if (usageProfile is null)
            {
                return false;
            }

            double? floorArea = occupancyData?.OccupancyArea;
            if (floorArea is not > 0 && building2D.PolygonalFace2D?.GetArea() is double area && area > 0)
            {
                floorArea = area * (building2D.Storeys is > 0 ? building2D.Storeys : 1);
            }

            double? occupancy = occupancyData?.Occupancy is uint persons ? persons : null;

            InternalCondition? internalCondition = HVAC.Create.InternalCondition(usageProfile, yearBuilt, occupancy, floorArea, occupancySource);
            if (internalCondition is null)
            {
                return false;
            }

            if (fallback is not null)
            {
                internalCondition.TryGetValue(new EnumParameterDefinition(HVAC.Enums.InternalConditionParameter.UsageSource), out string? usageSource, new GetValueSettings(true, false));
                internalCondition.SetValue(HVAC.Enums.InternalConditionParameter.UsageSource, fallback + "; " + usageSource);
            }

            return HVAC.Modify.AssignInternalCondition(buildingModel, internalCondition);
        }
    }
}
