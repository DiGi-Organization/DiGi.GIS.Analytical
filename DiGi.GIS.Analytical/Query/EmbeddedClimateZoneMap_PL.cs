using DiGi.Geometry.Planar.Classes;
using DiGi.GIS.Classes;
using System.IO;

namespace DiGi.GIS.Analytical
{
    public static partial class Query
    {
        /// <summary>
        /// The manifest name of the Polish climate zone map read by <see cref="EmbeddedClimateZoneMap_PL"/>.
        /// </summary>
        public const string EmbeddedClimateZoneMap_PL_ResourceName = "DiGi.GIS.Analytical.Resources.ClimateZoneMap_PL.geojson";

        /// <summary>
        /// Reads the map of the Polish climate zones I-V embedded in this assembly (DiGi-Organization/DiGi.GIS.Analytical#7).
        /// <para>The embedded file is a GeoJSON FeatureCollection in EPSG:2180. It is the PN-82/B-02403 zone map as reproduced in the Purmo guide to PN-EN 12831 (Strzeszewski, Wereszczyński), digitised from the vector figure and cut against the national outline. Its <see cref="ClimateZoneMap.Source"/> holds the full citation and the digitising method, and its <see cref="ClimateZoneMap.PositionalAccuracy"/> holds the accuracy of the boundaries. The method is described on the wiki page Climate Zones.</para>
        /// <para>Each call reads and converts the file, so a caller classifying many points reads the map once and passes it to <see cref="ClimateZone(Point2D, ClimateZoneMap, double)"/>.</para>
        /// </summary>
        /// <returns>A new <see cref="ClimateZoneMap"/> read from the embedded file, or null when the file is missing or cannot be read.</returns>
        public static ClimateZoneMap? EmbeddedClimateZoneMap_PL()
        {
            using Stream? stream = typeof(Query).Assembly.GetManifestResourceStream(EmbeddedClimateZoneMap_PL_ResourceName);
            if (stream is null)
            {
                return null;
            }

            using StreamReader streamReader = new(stream);
            return Convert.ToDiGi_ClimateZoneMap(streamReader.ReadToEnd());
        }
    }
}
