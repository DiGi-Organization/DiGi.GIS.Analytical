namespace DiGi.GIS.Analytical.Solar.Constants
{
    /// <summary>
    /// Defaults of the solar radiation solve that define stored results: the reference year the shading factors are indexed by, the radius key and the solver version. Request ceilings are host policy and are not held here.
    /// </summary>
    public static class Default
    {
        /// <summary>
        /// The angular tolerance, in radians, below which the solar radiation solve groups sun directions into one shading solve (<c>ShadingSolverOptions.AngleTolerance</c>); 2°, twice the solver default.
        /// <para>Measured over a full EPW year (DiGi-Organization/DiGi.Solar#7, comment 5831808537): it halves the direction groups (615 → 295) and the solve time, and changes the annual per-surface irradiation by at most 2.06 %. It is part of <see cref="SolarSolverVersion"/>.</para>
        /// </summary>
        public const double SolarAngleTolerance = Core.Constants.Tolerance.Angle;

        /// <summary>
        /// The precision, in decimal places, to which the neighbour radius is rounded before it is solved, looked up and stored: one, so 0.1 m. The radius is part of the stored key and compared exactly, so it is rounded once (<see cref="Query.SolarRadiusKey(double)"/>) and every layer then uses the same value.
        /// </summary>
        public const int SolarRadiusDecimals = 1;

        /// <summary>
        /// The neighbour radius, in m, a solve of the building alone is stored under: no surrounding building casts shade, while the building still shades and blocks the view of its own surfaces.
        /// <para>The isolated building is the reference of the urban-context effect (DiGi-Organization/DiGi.GIS.PostgreSQL#107). It is not the open-sky <c>IrradiationUnshaded</c> of a surface, which ignores the building itself and matches the isolated solve only for a convex building.</para>
        /// </summary>
        public const double SolarRadiusIsolated = 0.0;

        /// <summary>
        /// The number of hours of the solar reference year (<see cref="SolarReferenceYear"/>, 365 days): the length of every surface's stored shading factors, index = hour of the year.
        /// </summary>
        public const int SolarReferenceHourCount = 8760;

        /// <summary>
        /// The year every weather record is mapped into before the sun is positioned for it (<see cref="Query.SolarReferenceDateTime(System.DateTime)"/>).
        /// <para>A non-leap year, so the 8 760 hours of an EPW year map one to one; a 29 February record is skipped.</para>
        /// </summary>
        public const int SolarReferenceYear = 2025;

        /// <summary>
        /// The version of the solar radiation solve - the shading solver, <see cref="Create.SolarShadingSolverOptions"/> and the hourly aggregation - that stored results are keyed by. Bump it whenever any of them changes: every result stored under an older version is then a miss and is solved again (DiGi.GIS.WebAPI.UI#73).
        /// </summary>
        public const int SolarSolverVersion = 1;
    }
}
