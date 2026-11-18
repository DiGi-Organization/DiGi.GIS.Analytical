using DiGi.Geometry.Spatial.Classes;
using DiGi.GIS.Analytical.Solar.Classes;
using DiGi.Solar.Classes;
using System;
using System.Collections.Generic;

namespace DiGi.GIS.Analytical.Solar
{
    public static partial class Query
    {
        /// <summary>
        /// Gets the monthly solar irradiation of one receiving surface, the I_m of the monthly heat balance (DiGi-Organization/DiGi.GIS.Analytical#14, for DiGi-Organization/DiGi.Analytical#10).
        /// <para>The hourly math is that of <see cref="Create.SurfaceSolarRadiation(SolarHourSeries?, string?, double, Vector3D?, double, double, IList{double}?)"/> - the beam on the unshaded area, the diffuse and ground-reflected components on the unblocked share of the sky and ground, a sun-up hour without a factor skipped - summed per calendar month instead of over the series, so the 12 values add up to the surface's <c>Irradiation</c> for the same weather and factors. A null <paramref name="shadingFactors"/> means unshaded (every factor 0); with visibilities of 1 the months then add up to <c>IrradiationUnshaded</c>.</para>
        /// <para>The month of an hour is the month of its <see cref="SolarHourSeries.DateTimes"/>, the mid-hour instant of <see cref="SolarReferenceDateTime(DateTime)"/>: the last hour of a month, stamped 00:00 of the next one in an EPW file, stays in its month, as in <c>DiGi.Weather.Query.MonthlyMeanDryBulbTemperatures</c>. A 29 February hour is not in the series.</para>
        /// </summary>
        /// <param name="solarHourSeries">The hourly weather and sun of the site. This value can be null.</param>
        /// <param name="area">The area of the surface, in m².</param>
        /// <param name="normal">The outward unit normal of the surface. This value can be null.</param>
        /// <param name="skyVisibility">The unblocked share of the sky, 0..1.</param>
        /// <param name="groundVisibility">The unblocked share of the ground, 0..1.</param>
        /// <param name="shadingFactors">The shading factor of every hour of the solar reference year (<see cref="Constants.Default.SolarReferenceHourCount"/> values), 0 unshaded to 1 shaded, or null for an unshaded surface.</param>
        /// <returns>The 12 monthly irradiations, January first [kWh/m²], or null when an input is missing, the area is not a positive number or the factors do not cover the reference year.</returns>
        public static double[]? MonthlyIrradiations(this SolarHourSeries? solarHourSeries, double area, Vector3D? normal, double skyVisibility, double groundVisibility, IList<double>? shadingFactors)
        {
            if (solarHourSeries is null || normal is null || double.IsNaN(area) || double.IsInfinity(area) || area <= 0 || (shadingFactors is not null && shadingFactors.Count != Constants.Default.SolarReferenceHourCount))
            {
                return null;
            }

            // Energies in Wh per month: each weather value is a mean power over one hour.
            double[] energies = new double[12];
            for (int i = 0; i < solarHourSeries.Count; i++)
            {
                bool sunUp = solarHourSeries.SunUps[i];

                double shadingFactor = 0;
                if (sunUp && shadingFactors is not null)
                {
                    double shadingFactor_Hour = shadingFactors[solarHourSeries.DateTimes[i].SolarReferenceHourIndex()!.Value];
                    if (double.IsNaN(shadingFactor_Hour))
                    {
                        continue;
                    }

                    // A fully shaded receiver can read 1 plus a few ulps. Math.Clamp is not available on netstandard2.0.
                    shadingFactor = Math.Min(Math.Max(shadingFactor_Hour, 0), 1);
                }

                IrradianceResult? irradianceResult = DiGi.Solar.Create.IrradianceResult(normal, solarHourSeries.SunDirections[i], solarHourSeries.GlobalHorizontalRadiations[i], sunUp ? solarHourSeries.DirectNormalRadiations[i] : 0, solarHourSeries.DiffuseHorizontalRadiations[i], solarHourSeries.Albedos[i]);
                if (irradianceResult is null)
                {
                    continue;
                }

                SolarPowerResult? solarPowerResult = DiGi.Solar.Create.SolarPowerResult_ByShadingFactor(irradianceResult, area, shadingFactor);
                if (solarPowerResult is null)
                {
                    continue;
                }

                energies[solarHourSeries.DateTimes[i].Month - 1] += (solarPowerResult.UnshadedArea * irradianceResult.Beam) + (solarPowerResult.TotalArea * irradianceResult.Diffuse * skyVisibility) + (solarPowerResult.TotalArea * irradianceResult.Ground * groundVisibility);
            }

            double[] result = new double[12];
            for (int i = 0; i < 12; i++)
            {
                result[i] = energies[i] / 1000 / area;
            }

            return result;
        }

        /// <summary>
        /// Gets the monthly solar irradiation of a stored receiving surface from its stored shading factors, normal and visibilities (DiGi-Organization/DiGi.GIS.Analytical#14).
        /// <para>The factors are decoded from their stored bytes (<c>GIS.Convert.ToSystem_Doubles</c>), so the months add up to the <c>Irradiation</c> a rebuild from the stored factors gives (<see cref="Create.SurfaceSolarRadiations(GIS.Classes.BuildingSolarRadiationResult?, DiGi.Analytical.Building.Classes.BuildingInformation?, Weather.Classes.Weather?)"/>), and to the stored <c>Irradiation</c> within the quantization of the factors (at most 0.5/255 per hour). A surface without stored factors is unshaded.</para>
        /// </summary>
        /// <param name="solarHourSeries">The hourly weather and sun of the site, for the weather the result is wanted for. This value can be null.</param>
        /// <param name="surfaceSolarRadiation">The stored surface. This value can be null.</param>
        /// <returns>The 12 monthly irradiations, January first [kWh/m²], or null when an input is missing or the surface has no normal or area.</returns>
        public static double[]? MonthlyIrradiations(this SolarHourSeries? solarHourSeries, GIS.Classes.SurfaceSolarRadiation? surfaceSolarRadiation)
        {
            if (surfaceSolarRadiation is null)
            {
                return null;
            }

            return solarHourSeries.MonthlyIrradiations(surfaceSolarRadiation.Area, surfaceSolarRadiation.Normal, surfaceSolarRadiation.SkyVisibility, surfaceSolarRadiation.GroundVisibility, GIS.Convert.ToSystem_Doubles(surfaceSolarRadiation.ShadingFactors));
        }
    }
}
