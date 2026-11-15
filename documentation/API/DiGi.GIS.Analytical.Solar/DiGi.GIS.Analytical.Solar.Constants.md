#### [DiGi\.GIS\.Analytical\.Solar](DiGi.GIS.Analytical.Solar.Overview.md 'DiGi\.GIS\.Analytical\.Solar\.Overview')

## DiGi\.GIS\.Analytical\.Solar\.Constants Namespace
### Classes

<a name='DiGi.GIS.Analytical.Solar.Constants.Default'></a>

## Default Class

Defaults of the solar radiation solve that define stored results: the reference year the shading factors are indexed by, the radius key and the solver version\. Request ceilings are host policy and are not held here\.

```csharp
public static class Default
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → Default
### Fields

<a name='DiGi.GIS.Analytical.Solar.Constants.Default.SolarAngleTolerance'></a>

## Default\.SolarAngleTolerance Field

The angular tolerance, in radians, below which the solar radiation solve groups sun directions into one shading solve \(`ShadingSolverOptions.AngleTolerance`\); 2°, twice the solver default\.

Measured over a full EPW year (DiGi-Organization/DiGi.Solar#7, comment 5831808537): it halves the direction groups (615 → 295) and the solve time, and changes the annual per-surface irradiation by at most 2.06 %. It is part of [SolarSolverVersion](DiGi.GIS.Analytical.Solar.Constants.md#DiGi.GIS.Analytical.Solar.Constants.Default.SolarSolverVersion 'DiGi\.GIS\.Analytical\.Solar\.Constants\.Default\.SolarSolverVersion').

```csharp
public const double SolarAngleTolerance = 0.0349066;
```

#### Field Value
[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

<a name='DiGi.GIS.Analytical.Solar.Constants.Default.SolarRadiusDecimals'></a>

## Default\.SolarRadiusDecimals Field

The precision, in decimal places, to which the neighbour radius is rounded before it is solved, looked up and stored: one, so 0\.1 m\. The radius is part of the stored key and compared exactly, so it is rounded once \([SolarRadiusKey\(double\)](DiGi.GIS.Analytical.Solar.md#DiGi.GIS.Analytical.Solar.Query.SolarRadiusKey(double) 'DiGi\.GIS\.Analytical\.Solar\.Query\.SolarRadiusKey\(double\)')\) and every layer then uses the same value\.

```csharp
public const int SolarRadiusDecimals = 1;
```

#### Field Value
[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

<a name='DiGi.GIS.Analytical.Solar.Constants.Default.SolarRadiusIsolated'></a>

## Default\.SolarRadiusIsolated Field

The neighbour radius, in m, a solve of the building alone is stored under: no surrounding building casts shade, while the building still shades and blocks the view of its own surfaces\.

The isolated building is the reference of the urban-context effect (DiGi-Organization/DiGi.GIS.PostgreSQL#107). It is not the open-sky `IrradiationUnshaded` of a surface, which ignores the building itself and matches the isolated solve only for a convex building.

```csharp
public const double SolarRadiusIsolated = 0;
```

#### Field Value
[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

<a name='DiGi.GIS.Analytical.Solar.Constants.Default.SolarReferenceHourCount'></a>

## Default\.SolarReferenceHourCount Field

The number of hours of the solar reference year \([SolarReferenceYear](DiGi.GIS.Analytical.Solar.Constants.md#DiGi.GIS.Analytical.Solar.Constants.Default.SolarReferenceYear 'DiGi\.GIS\.Analytical\.Solar\.Constants\.Default\.SolarReferenceYear'), 365 days\): the length of every surface's stored shading factors, index = hour of the year\.

```csharp
public const int SolarReferenceHourCount = 8760;
```

#### Field Value
[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

<a name='DiGi.GIS.Analytical.Solar.Constants.Default.SolarReferenceYear'></a>

## Default\.SolarReferenceYear Field

The year every weather record is mapped into before the sun is positioned for it \([SolarReferenceDateTime\(this DateTime\)](DiGi.GIS.Analytical.Solar.md#DiGi.GIS.Analytical.Solar.Query.SolarReferenceDateTime(thisSystem.DateTime) 'DiGi\.GIS\.Analytical\.Solar\.Query\.SolarReferenceDateTime\(this System\.DateTime\)')\)\.

A non-leap year, so the 8 760 hours of an EPW year map one to one; a 29 February record is skipped.

```csharp
public const int SolarReferenceYear = 2025;
```

#### Field Value
[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

<a name='DiGi.GIS.Analytical.Solar.Constants.Default.SolarSolverVersion'></a>

## Default\.SolarSolverVersion Field

The version of the solar radiation solve \- the shading solver, [SolarShadingSolverOptions\(\)](DiGi.GIS.Analytical.Solar.md#DiGi.GIS.Analytical.Solar.Create.SolarShadingSolverOptions() 'DiGi\.GIS\.Analytical\.Solar\.Create\.SolarShadingSolverOptions\(\)') and the hourly aggregation \- that stored results are keyed by\. Bump it whenever any of them changes: every result stored under an older version is then a miss and is solved again \(DiGi\.GIS\.WebAPI\.UI\#73\)\.

```csharp
public const int SolarSolverVersion = 1;
```

#### Field Value
[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')