using System;

namespace DiGi.GIS.Analytical.Solar
{
    public static partial class Query
    {
        /// <summary>
        /// Rounds a neighbour radius to <see cref="Constants.Default.SolarRadiusDecimals"/> decimal places (0.1 m), the value a solar radiation request is solved with and its stored result is keyed by.
        /// <para>The stored key compares the radius exactly, so it is rounded once, here, and the same value is then solved, looked up and stored; no layer below rounds again. <see cref="Constants.Default.SolarRadiusIsolated"/> (0) is its own key.</para>
        /// </summary>
        /// <param name="radius">The requested radius, in m.</param>
        /// <returns>The radius rounded to 0.1 m, midpoints away from zero.</returns>
        public static double SolarRadiusKey(double radius)
        {
            return Math.Round(radius, Constants.Default.SolarRadiusDecimals, MidpointRounding.AwayFromZero);
        }
    }
}
