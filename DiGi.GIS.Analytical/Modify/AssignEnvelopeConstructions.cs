using DiGi.Analytical.Building.Classes;
using DiGi.Analytical.Building.Enums;
using DiGi.Analytical.Building.Interfaces;
using DiGi.Analytical.Building.Regulation.Classes;
using DiGi.Analytical.Building.Regulation.Enums;
using DiGi.Core.Parameter.Classes;
using DiGi.Geometry.Spatial.Classes;
using System;
using System.Collections.Generic;

namespace DiGi.GIS.Analytical
{
    public static partial class Modify
    {
        /// <summary>
        /// Gives the envelope components of a model the constructions of the construction set the openings were looked up by (DiGi-Organization/DiGi.GIS.Analytical#11, phase D), and reports the roles the library has no construction for.
        /// <para>A wall carrying <see cref="ComponentParameter.PartyWall"/> takes <see cref="ConstructionRole.PartyWall"/>, a wall of the external shell takes <see cref="ConstructionRole.ExternalWall"/> and any other wall <see cref="ConstructionRole.InternalWall"/>. A roof whose shell face stands less than 5 degrees off the world up axis - the flat threshold of <c>DiGi.GIS.PostgreSQL.Modify.Update_ExternalComponentsArea</c> - takes <see cref="ConstructionRole.FlatRoof"/>, any other roof <see cref="ConstructionRole.Roof"/>, and a roof the external shell does not carry is left alone: it has no outward normal to read a tilt from. The lowest floor takes <see cref="ConstructionRole.FloorOverUnheated"/> when the run's floor boundary is <see cref="FloorBoundary.Cellar"/>, otherwise <see cref="ConstructionRole.GroundFloor"/>, and every other floor <see cref="ConstructionRole.IntermediateFloor"/>.</para>
        /// <para>Each role is resolved in the chosen construction set and falls back to the <c>TypicalAsBuilt</c> set of the same run for a role it lacks - a <c>Regulation</c> set describes no typology, so the floor boundary comes from the <c>TypicalAsBuilt</c> set as well - so the envelope and the openings come from one regime. Each distinct construction is imported once with <c>BuildingModel.Update(ConstructionRelationCluster, IConstruction)</c>, its layers and materials with it, before it is assigned. A component whose role resolves to no construction, to a construction of another kind, or to an import or assignment that fails is left untouched and listed under its role.</para>
        /// </summary>
        /// <param name="buildingModel">The building model whose envelope is to be given constructions.</param>
        /// <param name="constructionLibrary">The construction library holding the sets, their constructions, layers and materials.</param>
        /// <param name="constructionSet">The construction set chosen for the run, or null when none applies.</param>
        /// <param name="constructionSet_Fallback">The <c>TypicalAsBuilt</c> construction set of the run, used for roles the chosen set lacks and for the floor boundary, or null. This value can be null.</param>
        /// <param name="walls">The walls of the model, in a deterministic order.</param>
        /// <param name="faces_Shell">The faces of the external shell, keyed by the identifier of the component each was built from.</param>
        /// <returns>The envelope components whose role had no construction, keyed by the component's identifier with the role; empty when every role was filled.</returns>
        private static Dictionary<Guid, ConstructionRole> AssignEnvelopeConstructions(BuildingModel buildingModel, ConstructionLibrary constructionLibrary, ConstructionSet? constructionSet, ConstructionSet? constructionSet_Fallback, List<IWall> walls, Dictionary<Guid, DiGi.Analytical.Classes.Face> faces_Shell)
        {
            const double flatRoofTiltDegrees = 5.0;

            static bool IsPartyWall(IWall wall)
            {
                return wall is Component component && component.TryGetValue(new EnumParameterDefinition(ComponentParameter.PartyWall), out Guid _);
            }

            FloorBoundary floorBoundary = constructionSet?.TypologyData?.FloorBoundary ?? constructionSet_Fallback?.TypologyData?.FloorBoundary ?? FloorBoundary.Undefined;

            Dictionary<Guid, ConstructionRole> result = [];

            // One lookup and one import per distinct role and construction, so a run of many walls resolves the library once.
            Dictionary<ConstructionRole, IConstruction?> dictionary_Construction = [];
            IConstruction? Construction(ConstructionRole constructionRole)
            {
                if (dictionary_Construction.TryGetValue(constructionRole, out IConstruction? construction))
                {
                    return construction;
                }

                construction = constructionLibrary.GetConstruction(constructionSet, constructionRole) ?? constructionLibrary.GetConstruction(constructionSet_Fallback, constructionRole);
                dictionary_Construction[constructionRole] = construction;
                return construction;
            }

            HashSet<Guid> hashSet_Imported = [];
            bool Import(IConstruction construction)
            {
                if (hashSet_Imported.Contains(construction.Guid))
                {
                    return true;
                }

                if (!buildingModel.Update(constructionLibrary.ConstructionRelationCluster, construction))
                {
                    return false;
                }

                hashSet_Imported.Add(construction.Guid);
                return true;
            }

            // Resolves the role, imports the construction once and assigns it; anything unresolved leaves the component untouched and is reported.
            void Assign(IComponent component, ConstructionRole constructionRole)
            {
                IConstruction? construction = Construction(constructionRole);

                bool assigned;
                if (component is IWall wall && construction is IWallConstruction wallConstruction && Import(construction))
                {
                    assigned = buildingModel.Assign(wall, wallConstruction);
                }
                else if (component is IRoof roof && construction is IRoofConstruction roofConstruction && Import(construction))
                {
                    assigned = buildingModel.Assign(roof, roofConstruction);
                }
                else if (component is IFloor floor && construction is IFloorConstruction floorConstruction && Import(construction))
                {
                    assigned = buildingModel.Assign(floor, floorConstruction);
                }
                else
                {
                    assigned = false;
                }

                if (!assigned)
                {
                    result[component.Guid] = constructionRole;
                }
            }

            foreach (IWall wall in walls)
            {
                if (IsPartyWall(wall))
                {
                    Assign(wall, ConstructionRole.PartyWall);
                }
                else if (faces_Shell.ContainsKey(wall.Guid))
                {
                    Assign(wall, ConstructionRole.ExternalWall);
                }
                else
                {
                    Assign(wall, ConstructionRole.InternalWall);
                }
            }

            List<IRoof> roofs = buildingModel.GetComponents<IRoof>() ?? [];
            roofs.Sort((x, y) => x.Guid.CompareTo(y.Guid));

            foreach (IRoof roof in roofs)
            {
                // The shell normal is the roof's upward direction, as in DiGi.GIS.PostgreSQL.Modify.Update_ExternalComponentsArea; no flip is applied.
                if (!faces_Shell.TryGetValue(roof.Guid, out DiGi.Analytical.Classes.Face? face) || face.Plane?.Normal?.Unit is not Vector3D vector3D_Normal)
                {
                    continue;
                }

                double tilt = vector3D_Normal.Angle(Geometry.Spatial.Constants.Vector3D.WorldZ) * 180.0 / Math.PI;
                Assign(roof, tilt < flatRoofTiltDegrees ? ConstructionRole.FlatRoof : ConstructionRole.Roof);
            }

            List<IFloor> floors = buildingModel.GetComponents<IFloor>() ?? [];
            floors.Sort((x, y) => x.Guid.CompareTo(y.Guid));

            // The lowest floor stands lowest; its elevation comes off its own geometry, so a floor the shell does not
            // carry - an intermediate floor bounds two spaces - is classified too.
            int index_Lowest = -1;
            double elevation_Lowest = double.MaxValue;
            for (int i = 0; i < floors.Count; i++)
            {
                if (floors[i].GetBoundingBox()?.Min?.Z is double elevation && (index_Lowest == -1 || elevation < elevation_Lowest))
                {
                    index_Lowest = i;
                    elevation_Lowest = elevation;
                }
            }

            for (int i = 0; i < floors.Count; i++)
            {
                if (i == index_Lowest)
                {
                    Assign(floors[i], floorBoundary == FloorBoundary.Cellar ? ConstructionRole.FloorOverUnheated : ConstructionRole.GroundFloor);
                }
                else
                {
                    Assign(floors[i], ConstructionRole.IntermediateFloor);
                }
            }

            return result;
        }
    }
}
