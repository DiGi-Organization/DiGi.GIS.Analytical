#### [DiGi\.GIS\.Analytical\.Energy](DiGi.GIS.Analytical.Energy.Overview.md 'DiGi\.GIS\.Analytical\.Energy\.Overview')

## DiGi\.GIS\.Analytical\.Energy\.Enums Namespace
### Enums

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