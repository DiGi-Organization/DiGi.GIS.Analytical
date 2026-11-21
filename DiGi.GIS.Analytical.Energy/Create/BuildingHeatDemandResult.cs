using DiGi.Analytical.Building.Classes;
using DiGi.GIS.Analytical.Energy.Classes;
using DiGi.GIS.Analytical.Energy.Enums;
using DiGi.GIS.Analytical.Solar;
using DiGi.GIS.Classes;
using DiGi.GIS.Enums;
using System.Collections.Generic;

namespace DiGi.GIS.Analytical.Energy
{
    public static partial class Create
    {
        /// <summary>
        /// Calculates the monthly heat demand of a stored GIS building with the provenance of its inputs (DiGi-Organization/DiGi.GIS.Analytical#14, for DiGi-Organization/DiGi.Analytical#10).
        /// <para><c>Create.HeatDemandPreparationResult</c> first prepares a copy of <paramref name="buildingModel"/> (DiGi-Organization/DiGi.GIS.Analytical#15): the party walls against <paramref name="buildingModels_Neighbour"/> (<c>DiGi.Analytical.Building.Query.PartyWalls</c>) split off (<c>Modify.SplitPartyWalls</c>), so they are adiabatic; the openings and envelope constructions placed by <see cref="Modify.GenerateOpenings"/> from <see cref="HeatDemandInput.OpeningGenerationInput"/> and the libraries of <paramref name="heatDemandContext"/>; the internal conditions assigned by <see cref="Modify.AssignInternalConditions"/>, scaled to <see cref="HeatDemandInput.OccupancyData"/>; the climate zone picked - the input's when it names one, else the zone of the footprint; and the <see cref="MonthlyClimate"/> built from <paramref name="weather"/>, the stored solar result and that zone.</para>
        /// <para><c>DiGi.Analytical.Building.Energy.Create.HeatDemandResult</c> then calculates the demand on that preparation with the <see cref="OpeningGenerationResult.TypologyData"/> of the TypicalAsBuilt set of the year built, and every construction, climate and usage provenance member below is read back from the preparation.</para>
        /// <para>The construction library is read once, in the preparation, when the context gives none, so the generator and the recorded <see cref="BuildingHeatDemandResult.ConstructionLibraryVersion"/> use the same one. <see cref="BuildingHeatDemandResult.CreatedAt"/> is left null for the writer to stamp, as for a solar result.</para>
        /// </summary>
        /// <param name="buildingModel">The stored building model. This value can be null.</param>
        /// <param name="building2D">The 2D building of the model, giving its function, storeys, footprint and reference. This value can be null.</param>
        /// <param name="buildingInformation">The building's information after <c>GIS.Analytical.Modify.UpdateBuildingInformation</c>: its coordinates and UTC offset. This value can be null.</param>
        /// <param name="heatDemandInput">The per-building inputs. This value can be null.</param>
        /// <param name="buildingModels_Neighbour">The building models of the adjacent buildings, for the party walls and the opening rules. This value can be null.</param>
        /// <param name="buildingSolarRadiationResult">The stored solar result of the building, read with its shading factors, or null when it has none.</param>
        /// <param name="weather">The weather of the solar result, or of the building's site when it has none. This value can be null.</param>
        /// <param name="heatDemandContext">The libraries, the climate-zone map and the options shared by the batch. This value can be null.</param>
        /// <param name="tolerance">The distance tolerance.</param>
        /// <returns>The result, of the preparation's input variant (<see cref="Enums.HeatDemandInputVariant.Generated"/>) and the engine's method and version, or null when the model, the 2D building or the weather is null, no opening-size set matches the building, or the heat demand cannot be calculated (no heated space, no heat-loss element, a month without a valid temperature).</returns>
        public static BuildingHeatDemandResult? BuildingHeatDemandResult(
            this BuildingModel? buildingModel,
            Building2D? building2D,
            DiGi.Analytical.Building.Classes.BuildingInformation? buildingInformation,
            HeatDemandInput? heatDemandInput,
            IEnumerable<BuildingModel?>? buildingModels_Neighbour,
            BuildingSolarRadiationResult? buildingSolarRadiationResult,
            Weather.Classes.Weather? weather,
            HeatDemandContext? heatDemandContext,
            double tolerance = Core.Constants.Tolerance.Distance)
        {
            HeatDemandPreparationResult? heatDemandPreparationResult = buildingModel.HeatDemandPreparationResult(
                building2D,
                buildingInformation,
                heatDemandInput,
                buildingModels_Neighbour,
                buildingSolarRadiationResult,
                weather,
                heatDemandContext,
                tolerance);
            if (heatDemandPreparationResult is null)
            {
                return null;
            }

            // The preparation returns null instead of a result without one, so this guard repeats the
            // no-opening-size-set case of the original method and keeps the provenance below non-null.
            OpeningGenerationResult? openingGenerationResult = heatDemandPreparationResult.OpeningGenerationResult;
            if (openingGenerationResult is null)
            {
                return null;
            }

            DiGi.Analytical.Building.Energy.Classes.HeatDemandResult? heatDemandResult = DiGi.Analytical.Building.Energy.Create.HeatDemandResult(
                heatDemandPreparationResult.BuildingModel,
                heatDemandPreparationResult.MonthlyClimate,
                openingGenerationResult.TypologyData,
                heatDemandContext?.HeatDemandOptions,
                tolerance);
            if (heatDemandResult is null)
            {
                return null;
            }

            return new BuildingHeatDemandResult(
                building2D?.Reference,
                heatDemandInput?.CountyId ?? buildingSolarRadiationResult?.CountyId ?? 0,
                buildingModel.SolarBuildingModelId() ?? 0,
                buildingSolarRadiationResult?.WeatherSourceType ?? heatDemandInput?.WeatherSourceType ?? WeatherSourceType.Undefined,
                buildingSolarRadiationResult?.WeatherSourceId ?? heatDemandInput?.WeatherSourceId,
                buildingSolarRadiationResult is null ? HeatDemandSolarSource.Unshaded : HeatDemandSolarSource.Shaded,
                buildingSolarRadiationResult?.SolverVersion,
                buildingSolarRadiationResult?.Radius,
                heatDemandPreparationResult.MatchedSurfaceCount,
                heatDemandPreparationResult.UnshadedSurfaceCount,
                openingGenerationResult.ConstructionFlavour,
                heatDemandPreparationResult.ConstructionLibraryVersion,
                openingGenerationResult.ConstructionSetSource,
                openingGenerationResult.BuildingType,
                openingGenerationResult.YearBuilt,
                openingGenerationResult.YearBuiltSource,
                heatDemandPreparationResult.UsageSource,
                heatDemandPreparationResult.HeatDemandInputVariant,
                null,
                heatDemandResult);
        }
    }
}
