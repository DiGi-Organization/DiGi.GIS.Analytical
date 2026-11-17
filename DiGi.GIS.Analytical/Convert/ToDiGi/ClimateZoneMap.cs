using DiGi.Analytical.Building.Regulation.Enums;
using DiGi.Geometry.Planar.Classes;
using DiGi.GIS.Classes;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace DiGi.GIS.Analytical
{
    public static partial class Convert
    {
        /// <summary>
        /// Converts a GeoJSON FeatureCollection of climate zones to a <see cref="ClimateZoneMap"/> (DiGi-Organization/DiGi.GIS.Analytical#7).
        /// <para><b>Expected layout.</b> Every feature carries a <c>ClimateZone</c> property (<c>"I"</c> to <c>"V"</c>) and a <c>Polygon</c> or <c>MultiPolygon</c> geometry. Each polygon becomes one <see cref="ClimateZoneArea"/>, its first ring the outline and the others holes. The coordinates are read as given, easting first. They are not reprojected, so the collection is expected in EPSG:2180, as its <c>crs</c> member states, even though RFC 7946 assumes WGS 84. The top-level members <c>Version</c>, <c>Source</c> and <c>PositionalAccuracy</c> (metres) become the map's own values.</para>
        /// <para>A feature with an unknown zone or an unreadable geometry is skipped, so check the number of areas after converting a new file.</para>
        /// </summary>
        /// <param name="geoJson">The GeoJSON text.</param>
        /// <returns>The map, or null when the text is null, is not JSON or is not a FeatureCollection.</returns>
        public static ClimateZoneMap? ToDiGi_ClimateZoneMap(this string? geoJson)
        {
            if (string.IsNullOrWhiteSpace(geoJson))
            {
                return null;
            }

            JsonObject? jsonObject;
            try
            {
                jsonObject = JsonNode.Parse(geoJson!) as JsonObject;
            }
            catch (JsonException)
            {
                return null;
            }

            if (jsonObject is null || (jsonObject["type"] as JsonValue)?.ToString() != "FeatureCollection")
            {
                return null;
            }

            double positionalAccuracy = jsonObject["PositionalAccuracy"] is JsonValue jsonValue_PositionalAccuracy && jsonValue_PositionalAccuracy.TryGetValue(out double value) ? value : double.NaN;

            List<ClimateZoneArea> climateZoneAreas = [];
            if (jsonObject["features"] is JsonArray jsonArray_Features)
            {
                foreach (JsonNode? jsonNode_Feature in jsonArray_Features)
                {
                    if (jsonNode_Feature is not JsonObject jsonObject_Feature)
                    {
                        continue;
                    }

                    string? zone = (jsonObject_Feature["properties"]?["ClimateZone"] as JsonValue)?.ToString();
                    if (zone is null || !Enum.TryParse(zone, false, out ClimateZone climateZone) || climateZone == ClimateZone.Undefined || !Enum.IsDefined(typeof(ClimateZone), climateZone))
                    {
                        continue;
                    }

                    if (jsonObject_Feature["geometry"] is not JsonObject jsonObject_Geometry || jsonObject_Geometry["coordinates"] is not JsonArray jsonArray_Coordinates)
                    {
                        continue;
                    }

                    string? geometryType = (jsonObject_Geometry["type"] as JsonValue)?.ToString();
                    List<JsonArray> jsonArrays_Polygon = [];
                    if (geometryType == "Polygon")
                    {
                        jsonArrays_Polygon.Add(jsonArray_Coordinates);
                    }
                    else if (geometryType == "MultiPolygon")
                    {
                        foreach (JsonNode? jsonNode_Polygon in jsonArray_Coordinates)
                        {
                            if (jsonNode_Polygon is JsonArray jsonArray_Polygon)
                            {
                                jsonArrays_Polygon.Add(jsonArray_Polygon);
                            }
                        }
                    }

                    foreach (JsonArray jsonArray_Polygon in jsonArrays_Polygon)
                    {
                        List<Polygon2D> polygon2Ds = [];
                        foreach (JsonNode? jsonNode_Ring in jsonArray_Polygon)
                        {
                            if (jsonNode_Ring is not JsonArray jsonArray_Ring)
                            {
                                continue;
                            }

                            List<Point2D?> point2Ds = [];
                            foreach (JsonNode? jsonNode_Position in jsonArray_Ring)
                            {
                                if (jsonNode_Position is JsonArray jsonArray_Position && jsonArray_Position.Count >= 2 && jsonArray_Position[0] is JsonValue jsonValue_X && jsonValue_X.TryGetValue(out double x) && jsonArray_Position[1] is JsonValue jsonValue_Y && jsonValue_Y.TryGetValue(out double y))
                                {
                                    point2Ds.Add(new Point2D(x, y));
                                }
                            }

                            // A GeoJSON ring repeats its first position as its last; the factory drops the repeat.
                            if (DiGi.Geometry.Planar.Create.Polygon2D(point2Ds) is Polygon2D polygon2D)
                            {
                                polygon2Ds.Add(polygon2D);
                            }
                        }

                        if (polygon2Ds.Count == 0)
                        {
                            continue;
                        }

                        PolygonalFace2D? polygonalFace2D = DiGi.Geometry.Planar.Create.PolygonalFace2D(polygon2Ds[0], polygon2Ds.GetRange(1, polygon2Ds.Count - 1));
                        if (polygonalFace2D is not null)
                        {
                            climateZoneAreas.Add(new ClimateZoneArea(climateZone, polygonalFace2D));
                        }
                    }
                }
            }

            return new ClimateZoneMap((jsonObject["Version"] as JsonValue)?.ToString(), (jsonObject["Source"] as JsonValue)?.ToString(), positionalAccuracy, climateZoneAreas);
        }
    }
}
