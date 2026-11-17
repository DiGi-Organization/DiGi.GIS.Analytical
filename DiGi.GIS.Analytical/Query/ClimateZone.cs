using DiGi.Geometry.Planar.Classes;
using DiGi.GIS.Classes;
using System.Collections.Generic;
using Regulation = DiGi.Analytical.Building.Regulation;

namespace DiGi.GIS.Analytical
{
    public static partial class Query
    {
        /// <summary>
        /// Gets the PN-82/B-02403 climate zone of a point in EPSG:2180 (DiGi-Organization/DiGi.GIS.Analytical#7).
        /// <para><b>Boundaries.</b> A point inside an area, or within <paramref name="tolerance"/> of its boundary, lies in that area's zone. A point on the boundary between two zones gets the colder one (the higher zone number), because that is the safer side of a design limit.</para>
        /// <para><b>Outside the map.</b> A point outside every area gets <see cref="Regulation.Enums.ClimateZone.Undefined"/>. The embedded Polish map covers the country's outline buffered by 250 m, so a point within that distance outside the border still gets a zone.</para>
        /// <para>The zone boundaries are accurate only to the map's <see cref="ClimateZoneMap.PositionalAccuracy"/> (about 10 km for the embedded map). Near a boundary the answer is the map's answer, not the climate's.</para>
        /// </summary>
        /// <param name="point2D">The point in EPSG:2180, easting first.</param>
        /// <param name="climateZoneMap">The map, or null for <see cref="EmbeddedClimateZoneMap_PL"/>. A caller classifying many points passes it, so the map is read only once.</param>
        /// <param name="tolerance">The distance tolerance in metres.</param>
        /// <returns>The climate zone of the point, or <see cref="Regulation.Enums.ClimateZone.Undefined"/> when the point is null, lies outside every area, or no map can be read.</returns>
        public static Regulation.Enums.ClimateZone ClimateZone(this Point2D? point2D, ClimateZoneMap? climateZoneMap = null, double tolerance = Core.Constants.Tolerance.Distance)
        {
            if (point2D is null)
            {
                return Regulation.Enums.ClimateZone.Undefined;
            }

            climateZoneMap ??= EmbeddedClimateZoneMap_PL();

            List<ClimateZoneArea>? climateZoneAreas = climateZoneMap?.ClimateZoneAreas;
            if (climateZoneAreas is null)
            {
                return Regulation.Enums.ClimateZone.Undefined;
            }

            // The zones are numbered from the mildest (I) to the coldest (V), so the larger value is the colder zone.
            Regulation.Enums.ClimateZone result = Regulation.Enums.ClimateZone.Undefined;
            foreach (ClimateZoneArea climateZoneArea in climateZoneAreas)
            {
                if (climateZoneArea.ClimateZone <= result)
                {
                    continue;
                }

                PolygonalFace2D? polygonalFace2D = climateZoneArea.PolygonalFace2D;
                if (polygonalFace2D is not null && polygonalFace2D.InRange(point2D, tolerance))
                {
                    result = climateZoneArea.ClimateZone;
                }
            }

            return result;
        }

        /// <summary>
        /// Gets the PN-82/B-02403 climate zone of a building from an internal point of its footprint (DiGi-Organization/DiGi.GIS.Analytical#7).
        /// <para>An internal point is used rather than the centroid, because the centroid of an L-shaped or courtyard footprint can lie outside the building. At the scale of the zone map the two give the same answer.</para>
        /// </summary>
        /// <param name="building2D">The building, with its footprint in EPSG:2180.</param>
        /// <param name="climateZoneMap">The map, or null for <see cref="EmbeddedClimateZoneMap_PL"/>. A caller classifying many buildings passes it, so the map is read only once.</param>
        /// <param name="tolerance">The distance tolerance in metres.</param>
        /// <returns>The climate zone of the building, or <see cref="Regulation.Enums.ClimateZone.Undefined"/> when the building or its footprint is null, or the footprint lies outside every area.</returns>
        public static Regulation.Enums.ClimateZone ClimateZone(this Building2D? building2D, ClimateZoneMap? climateZoneMap = null, double tolerance = Core.Constants.Tolerance.Distance)
        {
            return ClimateZone(building2D?.PolygonalFace2D?.GetInternalPoint(tolerance), climateZoneMap, tolerance);
        }
    }
}
