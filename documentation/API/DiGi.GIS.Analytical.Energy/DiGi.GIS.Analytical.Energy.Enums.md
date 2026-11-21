#### [DiGi\.GIS\.Analytical\.Energy](DiGi.GIS.Analytical.Energy.Overview.md 'DiGi\.GIS\.Analytical\.Energy\.Overview')

## DiGi\.GIS\.Analytical\.Energy\.Enums Namespace
### Enums

<a name='DiGi.GIS.Analytical.Energy.Enums.HeatDemandInputVariant'></a>

## HeatDemandInputVariant Enum

Specifies how the building model and the inputs of a heat demand were assembled before the calculation \(DiGi\-Organization/DiGi\.GIS\.Analytical\#20, Heat Demand Method Identity DiGi\-Organization/DiGi\.GIS\.Analytical\#19\)\.

The second axis of a result's identity beside the calculation method (`DiGi.Analytical.Building.Energy.Enums.HeatDemandMethod` and its version): two methods are compared on the same input variant, two input variants under the same method. The integer values are stored and sent as integers and never change; surveyed openings, a retrofit state or metered calibration would each be a new member.

```csharp
public enum HeatDemandInputVariant
```
### Fields

<a name='DiGi.GIS.Analytical.Energy.Enums.HeatDemandInputVariant.Undefined'></a>

`Undefined` 0

The input variant is not known; never stored\.

<a name='DiGi.GIS.Analytical.Energy.Enums.HeatDemandInputVariant.Generated'></a>

`Generated` 1

The inputs `Create.HeatDemandPreparationResult` generates from GIS data and rules: party walls split against the neighbours, openings and envelope constructions placed by `Modify.GenerateOpenings` from the opening\-size and construction sets of the year built, internal conditions assigned by `Modify.AssignInternalConditions` from the standard\-use profile scaled to the occupancy estimate, and the monthly climate of the climate zone with the stored solar result\. Nothing is measured or surveyed\.

<a name='DiGi.GIS.Analytical.Energy.Enums.HeatDemandSolarSource'></a>

## HeatDemandSolarSource Enum

Specifies where the monthly irradiation of a building's external surfaces comes from in its heat demand \(DiGi\-Organization/DiGi\.GIS\.Analytical\#14\)\.

```csharp
public enum HeatDemandSolarSource
```
### Fields

<a name='DiGi.GIS.Analytical.Energy.Enums.HeatDemandSolarSource.Undefined'></a>

`Undefined` 0

The source is not known\.

<a name='DiGi.GIS.Analytical.Energy.Enums.HeatDemandSolarSource.Shaded'></a>

`Shaded` 1

The stored solar result of the building: its shading factors and view factors, neighbours included\. Surfaces without a stored surface still take the unshaded irradiation; their number is recorded\.

<a name='DiGi.GIS.Analytical.Energy.Enums.HeatDemandSolarSource.Unshaded'></a>

`Unshaded` 2

No solar result: every surface takes the irradiation of its orientation and tilt under an open sky, from the same weather\.