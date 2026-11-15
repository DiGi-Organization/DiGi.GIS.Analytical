#### [DiGi\.GIS\.Analytical\.Solar](DiGi.GIS.Analytical.Solar.Overview.md 'DiGi\.GIS\.Analytical\.Solar\.Overview')

## DiGi\.GIS\.Analytical\.Solar\.Classes Namespace
### Classes

<a name='DiGi.GIS.Analytical.Solar.Classes.SolarHourSeries'></a>

## SolarHourSeries Class

Holds the hourly weather and sun of one site, shared by every receiving surface of a building: one element per weather hour, in weather order\.

Both the solve and the rebuild of a stored result aggregate through it ([SurfaceSolarRadiation\(this SolarHourSeries, string, double, Vector3D, double, double, IList&lt;double&gt;\)](DiGi.GIS.Analytical.Solar.md#DiGi.GIS.Analytical.Solar.Create.SurfaceSolarRadiation(thisDiGi.GIS.Analytical.Solar.Classes.SolarHourSeries,string,double,DiGi.Geometry.Spatial.Classes.Vector3D,double,double,System.Collections.Generic.IList_double_) 'DiGi\.GIS\.Analytical\.Solar\.Create\.SurfaceSolarRadiation\(this DiGi\.GIS\.Analytical\.Solar\.Classes\.SolarHourSeries, string, double, DiGi\.Geometry\.Spatial\.Classes\.Vector3D, double, double, System\.Collections\.Generic\.IList\<double\>\)')), so the two read every hour identically. Built by [SolarHourSeries\(this Weather, Coordinates, UTC\)](DiGi.GIS.Analytical.Solar.md#DiGi.GIS.Analytical.Solar.Create.SolarHourSeries(thisDiGi.Weather.Classes.Weather,DiGi.Core.Classes.Coordinates,DiGi.Core.Enums.UTC) 'DiGi\.GIS\.Analytical\.Solar\.Create\.SolarHourSeries\(this DiGi\.Weather\.Classes\.Weather, DiGi\.Core\.Classes\.Coordinates, DiGi\.Core\.Enums\.UTC\)').

```csharp
public class SolarHourSeries
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → SolarHourSeries
### Constructors

<a name='DiGi.GIS.Analytical.Solar.Classes.SolarHourSeries.SolarHourSeries(System.DateTime[],DiGi.Geometry.Spatial.Classes.Vector3D[],bool[],double[],double[],double[],double[])'></a>

## SolarHourSeries\(DateTime\[\], Vector3D\[\], bool\[\], double\[\], double\[\], double\[\], double\[\]\) Constructor

Initializes a new instance of the [SolarHourSeries](DiGi.GIS.Analytical.Solar.Classes.md#DiGi.GIS.Analytical.Solar.Classes.SolarHourSeries 'DiGi\.GIS\.Analytical\.Solar\.Classes\.SolarHourSeries') class\. The arrays are kept, not copied, and must have one common length\.

```csharp
public SolarHourSeries(System.DateTime[] dateTimes, DiGi.Geometry.Spatial.Classes.Vector3D?[] sunDirections, bool[] sunUps, double[] globalHorizontalRadiations, double[] directNormalRadiations, double[] diffuseHorizontalRadiations, double[] albedos);
```
#### Parameters

<a name='DiGi.GIS.Analytical.Solar.Classes.SolarHourSeries.SolarHourSeries(System.DateTime[],DiGi.Geometry.Spatial.Classes.Vector3D[],bool[],double[],double[],double[],double[]).dateTimes'></a>

`dateTimes` [System\.DateTime](https://learn.microsoft.com/en-us/dotnet/api/system.datetime 'System\.DateTime')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

The mid\-hour reference time of each hour\.

<a name='DiGi.GIS.Analytical.Solar.Classes.SolarHourSeries.SolarHourSeries(System.DateTime[],DiGi.Geometry.Spatial.Classes.Vector3D[],bool[],double[],double[],double[],double[]).sunDirections'></a>

`sunDirections` [DiGi\.Geometry\.Spatial\.Classes\.Vector3D](https://learn.microsoft.com/en-us/dotnet/api/digi.geometry.spatial.classes.vector3d 'DiGi\.Geometry\.Spatial\.Classes\.Vector3D')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

The sun direction of each hour, night included\.

<a name='DiGi.GIS.Analytical.Solar.Classes.SolarHourSeries.SolarHourSeries(System.DateTime[],DiGi.Geometry.Spatial.Classes.Vector3D[],bool[],double[],double[],double[],double[]).sunUps'></a>

`sunUps` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Whether the sun is up in each hour\.

<a name='DiGi.GIS.Analytical.Solar.Classes.SolarHourSeries.SolarHourSeries(System.DateTime[],DiGi.Geometry.Spatial.Classes.Vector3D[],bool[],double[],double[],double[],double[]).globalHorizontalRadiations'></a>

`globalHorizontalRadiations` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

The global horizontal radiation of each hour, in Wh/m²\.

<a name='DiGi.GIS.Analytical.Solar.Classes.SolarHourSeries.SolarHourSeries(System.DateTime[],DiGi.Geometry.Spatial.Classes.Vector3D[],bool[],double[],double[],double[],double[]).directNormalRadiations'></a>

`directNormalRadiations` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

The direct normal radiation of each hour, in Wh/m²\.

<a name='DiGi.GIS.Analytical.Solar.Classes.SolarHourSeries.SolarHourSeries(System.DateTime[],DiGi.Geometry.Spatial.Classes.Vector3D[],bool[],double[],double[],double[],double[]).diffuseHorizontalRadiations'></a>

`diffuseHorizontalRadiations` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

The diffuse horizontal radiation of each hour, in Wh/m²\.

<a name='DiGi.GIS.Analytical.Solar.Classes.SolarHourSeries.SolarHourSeries(System.DateTime[],DiGi.Geometry.Spatial.Classes.Vector3D[],bool[],double[],double[],double[],double[]).albedos'></a>

`albedos` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

The albedo of each hour, the default substituted for a missing reading\.
### Properties

<a name='DiGi.GIS.Analytical.Solar.Classes.SolarHourSeries.Albedos'></a>

## SolarHourSeries\.Albedos Property

Gets the albedo of each hour\.

```csharp
public double[] Albedos { get; }
```

#### Property Value
[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

<a name='DiGi.GIS.Analytical.Solar.Classes.SolarHourSeries.Count'></a>

## SolarHourSeries\.Count Property

Gets the number of hours\.

```csharp
public int Count { get; }
```

#### Property Value
[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

<a name='DiGi.GIS.Analytical.Solar.Classes.SolarHourSeries.DateTimes'></a>

## SolarHourSeries\.DateTimes Property

Gets the mid\-hour reference time of each hour\.

```csharp
public System.DateTime[] DateTimes { get; }
```

#### Property Value
[System\.DateTime](https://learn.microsoft.com/en-us/dotnet/api/system.datetime 'System\.DateTime')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

<a name='DiGi.GIS.Analytical.Solar.Classes.SolarHourSeries.DiffuseHorizontalRadiations'></a>

## SolarHourSeries\.DiffuseHorizontalRadiations Property

Gets the diffuse horizontal radiation of each hour, in Wh/m²\.

```csharp
public double[] DiffuseHorizontalRadiations { get; }
```

#### Property Value
[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

<a name='DiGi.GIS.Analytical.Solar.Classes.SolarHourSeries.DirectNormalRadiations'></a>

## SolarHourSeries\.DirectNormalRadiations Property

Gets the direct normal radiation of each hour, in Wh/m²\.

```csharp
public double[] DirectNormalRadiations { get; }
```

#### Property Value
[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

<a name='DiGi.GIS.Analytical.Solar.Classes.SolarHourSeries.GlobalHorizontalRadiations'></a>

## SolarHourSeries\.GlobalHorizontalRadiations Property

Gets the global horizontal radiation of each hour, in Wh/m²\.

```csharp
public double[] GlobalHorizontalRadiations { get; }
```

#### Property Value
[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

<a name='DiGi.GIS.Analytical.Solar.Classes.SolarHourSeries.SunDirections'></a>

## SolarHourSeries\.SunDirections Property

Gets the sun direction of each hour, night included: a night hour still needs one for its irradiance, whose beam is zeroed by passing no direct radiation\.

```csharp
public DiGi.Geometry.Spatial.Classes.Vector3D?[] SunDirections { get; }
```

#### Property Value
[DiGi\.Geometry\.Spatial\.Classes\.Vector3D](https://learn.microsoft.com/en-us/dotnet/api/digi.geometry.spatial.classes.vector3d 'DiGi\.Geometry\.Spatial\.Classes\.Vector3D')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

<a name='DiGi.GIS.Analytical.Solar.Classes.SolarHourSeries.SunUps'></a>

## SolarHourSeries\.SunUps Property

Gets whether the sun is up in each hour\.

```csharp
public bool[] SunUps { get; }
```

#### Property Value
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')