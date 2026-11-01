using DiGi.Analytical.Building.Regulation.Enums;
using System.Collections.Generic;

namespace DiGi.GIS.Analytical
{
    public static partial class Create
    {
        /// <summary>
        /// Creates the rules <c>Modify.GenerateOpenings</c> applies to a building designed under the specified regime (DiGi-Organization/DiGi.GIS.Analytical#2).
        /// <para>Every value read in the Dz.U. text (ISAP, 2026-11-01) cites its paragraph in the documentation of its option:</para>
        /// <list type="bullet">
        /// <item><description><b>Daylight ratio:</b> 1:10 before 1961 (the 1928 regulation, also taken for buildings before 1928); 1:8 from the 1994 conditions on (§ 57); a decided 1:8 for the 1961 and 1980 regimes, whose texts give no ratio.</description></item>
        /// <item><description><b>Maximum glazed area A0max:</b> single-family buildings only, for windows of U ≥ 2.0, under the original conditions of 2002; residential buildings, U ≥ 1.5, from 2009; U ≥ 0.9 from 2014. None from the 2017 stage on: the annex was replaced from 1 January 2018 without it, a year into that stage.</description></item>
        /// <item><description><b>Sills, interstorey strip, entrance door:</b> the same values for every regime (§ 301, § 223, § 62), read for 2002 and, for the sill, 1994 and 1980; assumed before that.</description></item>
        /// <item><description><b>Street façade weight</b> (a decided default): 1.5 for multi-family buildings and apartment blocks before 1961, the frontage blocks; 1.3 for single-family and terraced buildings from the 1994 regime on; 1.0 otherwise, including the 1961-1993 panel blocks.</description></item>
        /// </list>
        /// </summary>
        /// <param name="buildingRegulation">The regime the building was designed under; <see cref="BuildingRegulation.Undefined"/> takes the values of the current regime.</param>
        /// <returns>The options of the regime.</returns>
        public static GIS.Classes.OpeningGenerationOptions OpeningGenerationOptions(BuildingRegulation buildingRegulation)
        {
            GIS.Classes.OpeningGenerationOptions result = new();

            switch (buildingRegulation)
            {
                case BuildingRegulation.PL_Before1928:
                case BuildingRegulation.PL_1928:
                    result.DaylightRatio = 0.1;
                    result.StreetFacadeWeights = new Dictionary<BuildingType, double>() { [BuildingType.MultiFamily] = 1.5, [BuildingType.ApartmentBlock] = 1.5 };
                    break;

                case BuildingRegulation.PL_1961:
                case BuildingRegulation.PL_1980:
                    break;

                case BuildingRegulation.PL_WT2002:
                    result.MaximumGlazedAreaThermalTransmittance = 2.0;
                    result.MaximumGlazedAreaSingleFamilyOnly = true;
                    break;

                case BuildingRegulation.PL_WT2009:
                    result.MaximumGlazedAreaThermalTransmittance = 1.5;
                    break;

                case BuildingRegulation.PL_WT2014:
                    result.MaximumGlazedAreaThermalTransmittance = 0.9;
                    break;
            }

            if (buildingRegulation is BuildingRegulation.PL_1994 or BuildingRegulation.PL_WT2002 or BuildingRegulation.PL_WT2009 or BuildingRegulation.PL_WT2014 or BuildingRegulation.PL_WT2017 or BuildingRegulation.PL_WT2021 or BuildingRegulation.Undefined)
            {
                result.StreetFacadeWeights = new Dictionary<BuildingType, double>() { [BuildingType.SingleFamily] = 1.3, [BuildingType.Terraced] = 1.3 };
            }

            return result;
        }
    }
}
