using System.ComponentModel;

namespace DiGi.GIS.Analytical.Energy.Enums
{
    /// <summary>
    /// Specifies how the building model and the inputs of a heat demand were assembled before the calculation (DiGi-Organization/DiGi.GIS.Analytical#20, Heat Demand Method Identity DiGi-Organization/DiGi.GIS.Analytical#19).
    /// <para>The second axis of a result's identity beside the calculation method (<c>DiGi.Analytical.Building.Energy.Enums.HeatDemandMethod</c> and its version): two methods are compared on the same input variant, two input variants under the same method. The integer values are stored and sent as integers and never change; surveyed openings, a retrofit state or metered calibration would each be a new member.</para>
    /// </summary>
    [Description("Heat demand input variant")]
    public enum HeatDemandInputVariant
    {
        /// <summary>The input variant is not known; never stored.</summary>
        [Description("Undefined")] Undefined = 0,

        /// <summary>The inputs <c>Create.HeatDemandPreparationResult</c> generates from GIS data and rules: party walls split against the neighbours, openings and envelope constructions placed by <c>Modify.GenerateOpenings</c> from the opening-size and construction sets of the year built, internal conditions assigned by <c>Modify.AssignInternalConditions</c> from the standard-use profile scaled to the occupancy estimate, and the monthly climate of the climate zone with the stored solar result. Nothing is measured or surveyed.</summary>
        [Description("Generated: rule-based openings, typology constructions, standard-use profiles")] Generated = 1,
    }
}
