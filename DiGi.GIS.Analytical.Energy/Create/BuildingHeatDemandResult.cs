using DiGi.Analytical.Building.Classes;
using DiGi.Analytical.Building.Interfaces;
using DiGi.Analytical.Building.Regulation.Classes;
using DiGi.Analytical.Building.Regulation.Enums;
using DiGi.Core.Parameter.Classes;
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
        /// <para>On a clone of <paramref name="buildingModel"/>, in order:</para>
        /// <para>1. the party walls against <paramref name="buildingModels_Neighbour"/> (<c>DiGi.Analytical.Building.Query.PartyWalls</c>) are split off (<c>Modify.SplitPartyWalls</c>), so they are adiabatic;</para>
        /// <para>2. <see cref="Modify.GenerateOpenings"/> places the openings and gives the envelope its constructions, from <see cref="HeatDemandInput.OpeningGenerationInput"/> and the libraries of <paramref name="heatDemandContext"/>;</para>
        /// <para>3. <see cref="Modify.AssignInternalConditions"/> gives every space the standard-use condition of the building, scaled to <see cref="HeatDemandInput.OccupancyData"/>;</para>
        /// <para>4. <see cref="MonthlyClimate"/> builds the climate from <paramref name="weather"/>, the stored solar result and the building's climate zone - the input's when it names one, else the zone of the footprint;</para>
        /// <para>5. <c>DiGi.Analytical.Building.Energy.Create.HeatDemandResult</c> calculates the demand with the <see cref="OpeningGenerationResult.TypologyData"/> of the TypicalAsBuilt set of the year built.</para>
        /// <para>The construction library is read once here when the context gives none, so the generator and the recorded <see cref="BuildingHeatDemandResult.ConstructionLibraryVersion"/> use the same one. <see cref="BuildingHeatDemandResult.CreatedAt"/> is left null for the writer to stamp, as for a solar result.</para>
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
        /// <returns>The result, or null when the model, the 2D building or the weather is null, no opening-size set matches the building, or the heat demand cannot be calculated (no heated space, no heat-loss element, a month without a valid temperature).</returns>
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
            if (buildingModel is null || building2D is null || weather is null)
            {
                return null;
            }

            // The copy constructor, not Core.Query.Clone: a model from Core.Query.Clone shares its relations with the original, so the split below would also split the stored model.
            BuildingModel buildingModel_Temp = new(buildingModel);

            List<BuildingModel?> buildingModels_Neighbour_Temp = buildingModels_Neighbour is null ? [] : [.. buildingModels_Neighbour];
            if (buildingModels_Neighbour_Temp.Count > 0)
            {
                List<PartyWallResult>? partyWallResults = DiGi.Analytical.Building.Query.PartyWalls(buildingModel_Temp, buildingModels_Neighbour_Temp, tolerance: tolerance);
                if (partyWallResults is not null && partyWallResults.Count > 0)
                {
                    DiGi.Analytical.Building.Modify.SplitPartyWalls(buildingModel_Temp, partyWallResults, tolerance);
                }
            }

            ConstructionLibrary? constructionLibrary = heatDemandContext?.ConstructionLibrary ?? DiGi.Analytical.Building.Regulation.Query.EmbeddedConstructionLibrary_PL();

            OpeningGenerationInput? openingGenerationInput = heatDemandInput?.OpeningGenerationInput;
            OpeningGenerationResult? openingGenerationResult = buildingModel_Temp.GenerateOpenings(building2D, openingGenerationInput, buildingModels_Neighbour_Temp, constructionLibrary, heatDemandContext?.OpeningSizeLibrary, tolerance);
            if (openingGenerationResult is null)
            {
                return null;
            }

            buildingModel_Temp.AssignInternalConditions(building2D, heatDemandInput?.OccupancyData, openingGenerationResult.YearBuilt, heatDemandInput?.OccupancySource);

            ClimateZone climateZone = openingGenerationInput?.ClimateZone ?? ClimateZone.Undefined;
            if (climateZone == ClimateZone.Undefined)
            {
                climateZone = building2D.ClimateZone(heatDemandContext?.ClimateZoneMap, tolerance);
            }

            DiGi.Analytical.Building.Energy.Classes.MonthlyClimate? monthlyClimate = buildingModel_Temp.MonthlyClimate(buildingModel, buildingInformation, buildingSolarRadiationResult, weather, climateZone, out int matchedSurfaceCount, out int unshadedSurfaceCount, tolerance);

            DiGi.Analytical.Building.Energy.Classes.HeatDemandResult? heatDemandResult = DiGi.Analytical.Building.Energy.Create.HeatDemandResult(buildingModel_Temp, monthlyClimate, openingGenerationResult.TypologyData, heatDemandContext?.HeatDemandOptions, tolerance);
            if (heatDemandResult is null)
            {
                return null;
            }

            // The usage source of the first space that has one: every space of a building gets the same condition.
            string? usageSource = null;
            foreach (ISpace space in buildingModel_Temp.GetSpaces<ISpace>() ?? [])
            {
                List<SpaceInternalCondition>? spaceInternalConditions = buildingModel_Temp.GetSpaceInternalConditions(space);
                if (spaceInternalConditions is null)
                {
                    continue;
                }

                foreach (SpaceInternalCondition spaceInternalCondition in spaceInternalConditions)
                {
                    if (spaceInternalCondition?.InternalCondition is IInternalCondition internalCondition && internalCondition.TryGetValue(new EnumParameterDefinition(DiGi.Analytical.Building.HVAC.Enums.InternalConditionParameter.UsageSource), out string? usageSource_Temp) && usageSource_Temp is not null)
                    {
                        usageSource = usageSource_Temp;
                        break;
                    }
                }

                if (usageSource is not null)
                {
                    break;
                }
            }

            return new BuildingHeatDemandResult(
                building2D.Reference,
                heatDemandInput?.CountyId ?? buildingSolarRadiationResult?.CountyId ?? 0,
                buildingModel.SolarBuildingModelId() ?? 0,
                buildingSolarRadiationResult?.WeatherSourceType ?? heatDemandInput?.WeatherSourceType ?? WeatherSourceType.Undefined,
                buildingSolarRadiationResult?.WeatherSourceId ?? heatDemandInput?.WeatherSourceId,
                buildingSolarRadiationResult is null ? HeatDemandSolarSource.Unshaded : HeatDemandSolarSource.Shaded,
                buildingSolarRadiationResult?.SolverVersion,
                buildingSolarRadiationResult?.Radius,
                matchedSurfaceCount,
                unshadedSurfaceCount,
                openingGenerationResult.ConstructionFlavour,
                constructionLibrary?.Version,
                openingGenerationResult.ConstructionSetSource,
                openingGenerationResult.BuildingType,
                openingGenerationResult.YearBuilt,
                openingGenerationResult.YearBuiltSource,
                usageSource,
                null,
                heatDemandResult);
        }
    }
}
