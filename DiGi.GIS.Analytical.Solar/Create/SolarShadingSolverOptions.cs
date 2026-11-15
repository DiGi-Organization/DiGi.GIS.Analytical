using DiGi.Solar.Classes;

namespace DiGi.GIS.Analytical.Solar
{
    public static partial class Create
    {
        /// <summary>
        /// Creates the shading solver options every solar radiation solve runs with: the solver defaults with the angle tolerance <see cref="Constants.Default.SolarAngleTolerance"/>.
        /// <para>Part of <see cref="Constants.Default.SolarSolverVersion"/>: a solve with other options must not be stored under the same version.</para>
        /// </summary>
        /// <returns>New options.</returns>
        public static ShadingSolverOptions SolarShadingSolverOptions()
        {
            return new ShadingSolverOptions()
            {
                AngleTolerance = Constants.Default.SolarAngleTolerance,
            };
        }
    }
}
