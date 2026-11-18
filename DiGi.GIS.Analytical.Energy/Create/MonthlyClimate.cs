using DiGi.Analytical.Building.Classes;
using DiGi.Analytical.Building.Enums;
using DiGi.Analytical.Building.Interfaces;
using DiGi.Analytical.Building.Regulation.Enums;
using DiGi.Core.Classes;
using DiGi.Core.Interfaces;
using DiGi.Core.Parameter.Classes;
using DiGi.Geometry.Spatial.Classes;
using DiGi.Geometry.Spatial.Interfaces;
using DiGi.GIS.Analytical.Solar;
using DiGi.GIS.Analytical.Solar.Classes;
using DiGi.GIS.Classes;
using DiGi.Weather;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace DiGi.GIS.Analytical.Energy
{
    public static partial class Create
    {
        /// <summary>
        /// Builds the monthly climate of a building for its heat demand (DiGi-Organization/DiGi.GIS.Analytical#14, for DiGi-Organization/DiGi.Analytical#10): the monthly mean external temperatures, the design and mean annual temperatures of its climate zone, and the monthly irradiation of each external wall and roof.
        /// <para><b>Temperatures.</b> <c>Weather.Query.MonthlyMeanDryBulbTemperatures</c> of <paramref name="weather"/> - the weather the solar result was calculated from, so temperature and irradiation describe the same year. The design and mean annual temperatures are <c>Regulation.Query.DesignOutdoorTemperature</c> and <c>AnnualMeanOutdoorTemperature</c> of <paramref name="climateZone"/>.</para>
        /// <para><b>Irradiation.</b> Every wall and roof of the external shell of <paramref name="buildingModel"/> (outward normals), party walls excepted, gets 12 monthly values keyed by its identifier in the "D" format:</para>
        /// <para>- the stored surface of the same component - the same identifier, whatever type its reference names - in <paramref name="buildingSolarRadiationResult"/> (<see cref="Solar.Query.MonthlyIrradiations(SolarHourSeries?, SurfaceSolarRadiation?)"/>);</para>
        /// <para>- for a wall the party-wall split created (<c>DiGi.Analytical.Building.Modify.SplitPartyWalls</c> gives a new identifier to every external piece after the first), the stored surface of the wall of <paramref name="buildingModel_Solar"/> it was split from: a wall whose face contains the piece's internal point within <see cref="Core.Constants.Tolerance.MacroDistance"/> and whose plane is parallel within <see cref="Core.Constants.Tolerance.Angle"/>. The piece takes that wall's mean irradiation per m², which includes the part its neighbour now covers, so it slightly underestimates the piece; it is counted in <paramref name="matchedSurfaceCount"/>;</para>
        /// <para>- otherwise, or with no solar result, the irradiation of its orientation and tilt under an open sky from the same weather (no shading, visibilities 1), counted in <paramref name="unshadedSurfaceCount"/>.</para>
        /// <para>Without <paramref name="buildingInformation"/> the sun cannot be positioned, so no surface gets irradiation; the heat-demand calculation then counts every surface as missing.</para>
        /// </summary>
        /// <param name="buildingModel">The building model the heat demand is calculated for, after its party walls were split. This value can be null.</param>
        /// <param name="buildingModel_Solar">The stored building model the solar result was calculated for, before the split. This value can be null.</param>
        /// <param name="buildingInformation">The building's information after <c>GIS.Analytical.Modify.UpdateBuildingInformation</c>: its coordinates and UTC offset. This value can be null.</param>
        /// <param name="buildingSolarRadiationResult">The stored solar result of the building, read with its shading factors, or null when it has none.</param>
        /// <param name="weather">The weather of the solar result, or of the building's site when it has none. This value can be null.</param>
        /// <param name="climateZone">The climate zone of the building.</param>
        /// <param name="matchedSurfaceCount">The number of split pieces matched to the stored surface of their wall.</param>
        /// <param name="unshadedSurfaceCount">The number of surfaces that took the unshaded irradiation.</param>
        /// <param name="tolerance">The distance tolerance of the external shell.</param>
        /// <returns>The monthly climate, or null when the model or the weather is null or the weather holds no record.</returns>
        public static DiGi.Analytical.Building.Energy.Classes.MonthlyClimate? MonthlyClimate(
            this BuildingModel? buildingModel,
            BuildingModel? buildingModel_Solar,
            DiGi.Analytical.Building.Classes.BuildingInformation? buildingInformation,
            BuildingSolarRadiationResult? buildingSolarRadiationResult,
            Weather.Classes.Weather? weather,
            ClimateZone climateZone,
            out int matchedSurfaceCount,
            out int unshadedSurfaceCount,
            double tolerance = Core.Constants.Tolerance.Distance)
        {
            matchedSurfaceCount = 0;
            unshadedSurfaceCount = 0;

            if (buildingModel is null)
            {
                return null;
            }

            double[]? externalTemperatures = weather.MonthlyMeanDryBulbTemperatures();
            if (externalTemperatures is null)
            {
                return null;
            }

            SolarHourSeries? solarHourSeries = buildingInformation is null ? null : weather.SolarHourSeries(buildingInformation.Coordinates, buildingInformation.UTC);

            // The stored surfaces by the identifier of their component. The reference a solve writes names the component's type as well,
            // and the shell updater of the party-wall split rebuilds a CurveWall as a SurfaceWall under the same identifier, so only the identifier is compared.
            Dictionary<Guid, SurfaceSolarRadiation> surfaceSolarRadiations = [];
            List<SurfaceSolarRadiation>? surfaceSolarRadiations_Stored = buildingSolarRadiationResult?.SurfaceSolarRadiations;
            if (surfaceSolarRadiations_Stored is not null)
            {
                foreach (SurfaceSolarRadiation surfaceSolarRadiation in surfaceSolarRadiations_Stored)
                {
                    if (Core.Query.TryParse(surfaceSolarRadiation?.Reference, out IReference? reference) && reference is GuidReference guidReference && !surfaceSolarRadiations.ContainsKey(guidReference.Guid))
                    {
                        surfaceSolarRadiations[guidReference.Guid] = surfaceSolarRadiation!;
                    }
                }
            }

            // The walls of the solar model as faces, for the pieces the split created.
            List<(IPolygonalFace3D Face, Vector3D Normal, Guid Guid)> faces_Solar = [];
            List<IWall>? walls_Solar = surfaceSolarRadiations.Count == 0 ? null : buildingModel_Solar?.GetComponents<IWall>();
            if (walls_Solar is not null)
            {
                foreach (IWall wall in walls_Solar)
                {
                    if (DiGi.Analytical.Building.Query.Surface3D(wall) is IPolygonalFace3D polygonalFace3D && polygonalFace3D.Plane?.Normal?.Unit is Vector3D vector3D_Normal && surfaceSolarRadiations.ContainsKey(wall.Guid))
                    {
                        faces_Solar.Add((polygonalFace3D, vector3D_Normal, wall.Guid));
                    }
                }
            }

            double cosine_Parallel = Math.Cos(Core.Constants.Tolerance.Angle);

            Dictionary<string, List<double>> surfaceIrradiations = [];
            List<DiGi.Analytical.Classes.Face>? faces = null;
            try
            {
                faces = buildingModel.GetExternalShell(Geometry.Core.Enums.Side.External, tolerance: tolerance)?.PolygonalFaces;
            }
            catch (NotImplementedException)
            {
                // Query.Geometry3D does not support a component carrying more than one geometry.
                faces = null;
            }

            if (faces is not null && solarHourSeries is not null)
            {
                Dictionary<Guid, IComponent> components = [];
                foreach (IComponent component in buildingModel.GetComponents<IComponent>() ?? [])
                {
                    if (component is IWall || component is IRoof)
                    {
                        components[component.Guid] = component;
                    }
                }

                foreach (DiGi.Analytical.Classes.Face face in faces)
                {
                    IUniqueReference? uniqueReference = face.UniqueReference;
                    if (uniqueReference is not GuidReference guidReference || !components.TryGetValue(guidReference.Guid, out IComponent? component))
                    {
                        continue;
                    }

                    string key = component.Guid.ToString("D");
                    if (surfaceIrradiations.ContainsKey(key) || (component is Component component_Party && component_Party.TryGetValue(new EnumParameterDefinition(ComponentParameter.PartyWall), out Guid _)))
                    {
                        continue;
                    }

                    if (face.Plane?.Normal?.Unit is not Vector3D vector3D_Normal)
                    {
                        continue;
                    }

                    double[]? irradiations = null;
                    if (surfaceSolarRadiations.TryGetValue(component.Guid, out SurfaceSolarRadiation? surfaceSolarRadiation))
                    {
                        irradiations = solarHourSeries.MonthlyIrradiations(surfaceSolarRadiation);
                    }
                    else if (component is IWall && face.GetInternalPoint(tolerance) is Point3D point3D_Internal)
                    {
                        foreach ((IPolygonalFace3D face_Solar, Vector3D vector3D_Normal_Solar, Guid guid_Solar) in faces_Solar)
                        {
                            if (Math.Abs(vector3D_Normal.DotProduct(vector3D_Normal_Solar)) >= cosine_Parallel && face_Solar.InRange(point3D_Internal, Core.Constants.Tolerance.MacroDistance))
                            {
                                irradiations = solarHourSeries.MonthlyIrradiations(surfaceSolarRadiations[guid_Solar]);
                                if (irradiations is not null)
                                {
                                    matchedSurfaceCount++;
                                }

                                break;
                            }
                        }
                    }

                    if (irradiations is null)
                    {
                        irradiations = solarHourSeries.MonthlyIrradiations(1.0, vector3D_Normal, 1.0, 1.0, null);
                        if (irradiations is not null)
                        {
                            unshadedSurfaceCount++;
                        }
                    }

                    if (irradiations is not null)
                    {
                        surfaceIrradiations[key] = [.. irradiations];
                    }
                }
            }

            string source = string.Format(
                CultureInfo.InvariantCulture,
                "Temperatures: monthly means of the dry bulb temperature of the weather ({0} records). Design and mean annual temperatures: climate zone {1}. Irradiation: {2}; {3} split pieces matched to the surface of their wall, {4} surfaces unshaded.",
                weather!.WeatherRecords?.Count ?? 0,
                climateZone,
                buildingSolarRadiationResult is null ? "no solar result, every surface unshaded" : string.Format(CultureInfo.InvariantCulture, "stored solar result (radius {0} m, solver version {1})", buildingSolarRadiationResult.Radius, buildingSolarRadiationResult.SolverVersion),
                matchedSurfaceCount,
                unshadedSurfaceCount);

            return new DiGi.Analytical.Building.Energy.Classes.MonthlyClimate(
                externalTemperatures,
                DiGi.Analytical.Building.Regulation.Query.DesignOutdoorTemperature(climateZone),
                DiGi.Analytical.Building.Regulation.Query.AnnualMeanOutdoorTemperature(climateZone),
                surfaceIrradiations,
                source);
        }
    }
}
