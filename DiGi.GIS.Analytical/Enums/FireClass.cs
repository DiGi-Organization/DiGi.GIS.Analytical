using System.ComponentModel;

namespace DiGi.GIS.Analytical.Enums
{
    /// <summary>
    /// Specifies the kind of building for the fire-separation distances of § 271 (DiGi-Organization/DiGi.GIS.Analytical#9).
    /// </summary>
    [Description("Fire class")]
    public enum FireClass
    {
        /// <summary>
        /// Residential, collective-residence and public-utility buildings, characterised by the human-hazard category (§ 209 ust. 1 pkt 1 of the technical conditions of 2002, Dz.U. 2022 poz. 1225, read in ISAP on 2026-11-01).
        /// </summary>
        [Description("ZL")] ZL,

        /// <summary>
        /// Livestock buildings (§ 209 ust. 1 pkt 3 of the technical conditions of 2002, Dz.U. 2022 poz. 1225, read in ISAP on 2026-11-01).
        /// </summary>
        [Description("IN")] IN,

        /// <summary>
        /// Production and storage buildings (§ 209 ust. 1 pkt 2 of the technical conditions of 2002, Dz.U. 2022 poz. 1225, read in ISAP on 2026-11-01). The row of the § 271 table this class takes depends on the fuel-load density Q of its fire compartment.
        /// </summary>
        [Description("PM")] PM,
    }
}
