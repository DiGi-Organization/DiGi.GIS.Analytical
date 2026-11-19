using DiGi.GIS.Classes;
using DiGi.GIS.Enums;

namespace DiGi.GIS.Analytical
{
    public static partial class Query
    {
        /// <summary>
        /// Returns the year built a calculation models a building as, and its source (DiGi-Organization/DiGi.GIS.Analytical#16).
        /// <para>A predicted year equal to <see cref="GIS.Constants.YearBuiltPrediction.FirstYear"/> only bounds the year: the predictor answers the first year it sees a building, so a building already standing then is predicted as that year. Such a year is replaced by <see cref="OpeningGenerationOptions.FallbackYearBuilt"/> with <see cref="YearBuiltSource.Fallback"/>. An earlier predicted year cannot come from that predictor; it is an estimate of the retired regressor and is kept. Any other year and source, a user year of 2008 included, is returned as given, so the substitution applies once.</para>
        /// <para>Every reader of a year built for the heat-demand calculation applies it before the year selects a regime or a construction set: <see cref="Modify.GenerateOpenings"/> and the production solve task of DiGi.GIS.PostgreSQL.Energy.</para>
        /// </summary>
        /// <param name="yearBuilt">The year built, or null when unknown.</param>
        /// <param name="yearBuiltSource">Where <paramref name="yearBuilt"/> comes from, or null when no year is known.</param>
        /// <param name="openingGenerationOptions">The options giving the fallback year, or null for the default.</param>
        /// <returns>The year built and its source to calculate with.</returns>
        public static (short? YearBuilt, YearBuiltSource? YearBuiltSource) CalculationYearBuilt(short? yearBuilt, YearBuiltSource? yearBuiltSource, OpeningGenerationOptions? openingGenerationOptions = null)
        {
            if (yearBuiltSource == YearBuiltSource.Prediction && yearBuilt == GIS.Constants.YearBuiltPrediction.FirstYear)
            {
                return ((openingGenerationOptions ?? new OpeningGenerationOptions()).FallbackYearBuilt, YearBuiltSource.Fallback);
            }

            return (yearBuilt, yearBuiltSource);
        }
    }
}
