using DiGi.GIS.Classes;
using DiGi.GIS.Enums;

namespace DiGi.GIS.Analytical
{
    public static partial class Query
    {
        /// <summary>
        /// Returns the year built a calculation models a building as, and its source (DiGi-Organization/DiGi.GIS.Analytical#16, #17).
        /// <para>A predicted year equal to <see cref="GIS.Constants.YearBuiltPrediction.FirstYear"/> only bounds the year: the predictor answers the first year it sees a building, so a building already standing then is predicted as that year. Such a year is replaced by <paramref name="censusYearBuilt"/>, the census year built of the building's area (<c>GIS.Query.CensusYearBuilt</c>), with <see cref="YearBuiltSource.Census"/>; when that is null or not in 1..<see cref="GIS.Constants.YearBuiltPrediction.FirstYear"/>, by <see cref="OpeningGenerationOptions.FallbackYearBuilt"/> with <see cref="YearBuiltSource.Fallback"/>. The rule does not look at the building's function: a non-residential building takes the census year too (decided on #17).</para>
        /// <para>An earlier predicted year cannot come from that predictor; it is an estimate of the retired regressor and is kept. Any other year and source, a user year of 2008, a census year and a fallback included, is returned as given, so the substitution applies once and applying the rule to its own result changes nothing.</para>
        /// <para>Every reader of a year built for the heat-demand calculation applies it before the year selects a regime or a construction set: <see cref="Modify.GenerateOpenings"/> (without a census year) and the production solve task of DiGi.GIS.PostgreSQL.Energy (with the census year stored for the building).</para>
        /// </summary>
        /// <param name="yearBuilt">The year built, or null when unknown.</param>
        /// <param name="yearBuiltSource">Where <paramref name="yearBuilt"/> comes from, or null when no year is known.</param>
        /// <param name="censusYearBuilt">The census year built of the building's area, or null when the area has no census data.</param>
        /// <param name="openingGenerationOptions">The options giving the fallback year, or null for the default.</param>
        /// <returns>The year built and its source to calculate with.</returns>
        public static (short? YearBuilt, YearBuiltSource? YearBuiltSource) CalculationYearBuilt(short? yearBuilt, YearBuiltSource? yearBuiltSource, short? censusYearBuilt, OpeningGenerationOptions? openingGenerationOptions = null)
        {
            if (yearBuiltSource != YearBuiltSource.Prediction || yearBuilt != GIS.Constants.YearBuiltPrediction.FirstYear)
            {
                return (yearBuilt, yearBuiltSource);
            }

            if (censusYearBuilt > 0 && censusYearBuilt <= GIS.Constants.YearBuiltPrediction.FirstYear)
            {
                return (censusYearBuilt, YearBuiltSource.Census);
            }

            return ((openingGenerationOptions ?? new OpeningGenerationOptions()).FallbackYearBuilt, YearBuiltSource.Fallback);
        }

        /// <summary>
        /// Returns the year built a calculation models a building as, and its source, when no census year built is known: a prediction that only bounds the year takes <see cref="OpeningGenerationOptions.FallbackYearBuilt"/> (DiGi-Organization/DiGi.GIS.Analytical#16).
        /// <para>The same rule as <see cref="CalculationYearBuilt(short?, YearBuiltSource?, short?, OpeningGenerationOptions?)"/> with no census year.</para>
        /// </summary>
        /// <param name="yearBuilt">The year built, or null when unknown.</param>
        /// <param name="yearBuiltSource">Where <paramref name="yearBuilt"/> comes from, or null when no year is known.</param>
        /// <param name="openingGenerationOptions">The options giving the fallback year, or null for the default.</param>
        /// <returns>The year built and its source to calculate with.</returns>
        public static (short? YearBuilt, YearBuiltSource? YearBuiltSource) CalculationYearBuilt(short? yearBuilt, YearBuiltSource? yearBuiltSource, OpeningGenerationOptions? openingGenerationOptions = null)
        {
            return CalculationYearBuilt(yearBuilt, yearBuiltSource, censusYearBuilt: null, openingGenerationOptions);
        }
    }
}
