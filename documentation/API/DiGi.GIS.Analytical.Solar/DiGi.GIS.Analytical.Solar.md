#### [DiGi\.GIS\.Analytical\.Solar](DiGi.GIS.Analytical.Solar.Overview.md 'DiGi\.GIS\.Analytical\.Solar\.Overview')

## DiGi\.GIS\.Analytical\.Solar Namespace
### Classes

<a name='DiGi.GIS.Analytical.Solar.Create'></a>

## Create Class

```csharp
public static class Create
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → Create
### Methods

<a name='DiGi.GIS.Analytical.Solar.Create.BuildingSolarRadiationResult(thisDiGi.Analytical.Building.Classes.BuildingModel,int,double,int,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.SurfaceSolarRadiation_)'></a>

## Create\.BuildingSolarRadiationResult\(this BuildingModel, int, double, int, IEnumerable\<SurfaceSolarRadiation\>\) Method

Builds the stored form of a building's solar radiation: keyed by county part, building model id \([SolarBuildingModelId\(this BuildingModel\)](DiGi.GIS.Analytical.Solar.md#DiGi.GIS.Analytical.Solar.Query.SolarBuildingModelId(thisDiGi.Analytical.Building.Classes.BuildingModel) 'DiGi\.GIS\.Analytical\.Solar\.Query\.SolarBuildingModelId\(this DiGi\.Analytical\.Building\.Classes\.BuildingModel\)')\), radius and [SolarSolverVersion](DiGi.GIS.Analytical.Solar.Constants.md#DiGi.GIS.Analytical.Solar.Constants.Default.SolarSolverVersion 'DiGi\.GIS\.Analytical\.Solar\.Constants\.Default\.SolarSolverVersion'), with an EPW weather source\.

The user email and the creation time are left null: the writer stamps both (the `gis/buildingsolarradiation/setsolarradiation` route from the token and its clock). The weather period is null, a typical year.

```csharp
public static DiGi.GIS.Classes.BuildingSolarRadiationResult? BuildingSolarRadiationResult(this DiGi.Analytical.Building.Classes.BuildingModel? buildingModel, int countyId, double radius, int ePWFileId, System.Collections.Generic.IEnumerable<DiGi.GIS.Classes.SurfaceSolarRadiation>? surfaceSolarRadiations);
```
#### Parameters

<a name='DiGi.GIS.Analytical.Solar.Create.BuildingSolarRadiationResult(thisDiGi.Analytical.Building.Classes.BuildingModel,int,double,int,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.SurfaceSolarRadiation_).buildingModel'></a>

`buildingModel` [DiGi\.Analytical\.Building\.Classes\.BuildingModel](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.classes.buildingmodel 'DiGi\.Analytical\.Building\.Classes\.BuildingModel')

The solved building model; it supplies the `building_2d` reference \(`BuildingModelParameter.Reference`\) and the model id\.

<a name='DiGi.GIS.Analytical.Solar.Create.BuildingSolarRadiationResult(thisDiGi.Analytical.Building.Classes.BuildingModel,int,double,int,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.SurfaceSolarRadiation_).countyId'></a>

`countyId` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The county part the building is filed under; a server write resolves the actual part\.

<a name='DiGi.GIS.Analytical.Solar.Create.BuildingSolarRadiationResult(thisDiGi.Analytical.Building.Classes.BuildingModel,int,double,int,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.SurfaceSolarRadiation_).radius'></a>

`radius` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The neighbour radius, already rounded \([SolarRadiusKey\(double\)](DiGi.GIS.Analytical.Solar.md#DiGi.GIS.Analytical.Solar.Query.SolarRadiusKey(double) 'DiGi\.GIS\.Analytical\.Solar\.Query\.SolarRadiusKey\(double\)')\); [SolarRadiusIsolated](DiGi.GIS.Analytical.Solar.Constants.md#DiGi.GIS.Analytical.Solar.Constants.Default.SolarRadiusIsolated 'DiGi\.GIS\.Analytical\.Solar\.Constants\.Default\.SolarRadiusIsolated') for the building alone\.

<a name='DiGi.GIS.Analytical.Solar.Create.BuildingSolarRadiationResult(thisDiGi.Analytical.Building.Classes.BuildingModel,int,double,int,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.SurfaceSolarRadiation_).ePWFileId'></a>

`ePWFileId` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The id of the `epw_file` row the summary was calculated from\.

<a name='DiGi.GIS.Analytical.Solar.Create.BuildingSolarRadiationResult(thisDiGi.Analytical.Building.Classes.BuildingModel,int,double,int,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.SurfaceSolarRadiation_).surfaceSolarRadiations'></a>

`surfaceSolarRadiations` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[DiGi\.GIS\.Classes\.SurfaceSolarRadiation](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.classes.surfacesolarradiation 'DiGi\.GIS\.Classes\.SurfaceSolarRadiation')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The surfaces in their stored form\.

#### Returns
[DiGi\.GIS\.Classes\.BuildingSolarRadiationResult](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.classes.buildingsolarradiationresult 'DiGi\.GIS\.Classes\.BuildingSolarRadiationResult')  
The result, or null when the model carries no reference, no surface is given, or a surface has no stored shading factors of a whole reference year \- such a result cannot be stored\.

<a name='DiGi.GIS.Analytical.Solar.Create.SolarHourSeries(thisDiGi.Weather.Classes.Weather,DiGi.Core.Classes.Coordinates,DiGi.Core.Enums.UTC)'></a>

## Create\.SolarHourSeries\(this Weather, Coordinates, UTC\) Method

Builds the hourly weather and sun of a site from a weather series: one hour per weather record that carries all three radiation readings, mapped to the solar reference year \([SolarReferenceDateTime\(this DateTime\)](DiGi.GIS.Analytical.Solar.md#DiGi.GIS.Analytical.Solar.Query.SolarReferenceDateTime(thisSystem.DateTime) 'DiGi\.GIS\.Analytical\.Solar\.Query\.SolarReferenceDateTime\(this System\.DateTime\)')\), the first record of each reference hour kept\.

Readings are taken through the DiGi.Weather missing-value helpers (`GlobalHorizontalRadiationValue`, `DirectNormalRadiationValue`, `DiffuseHorizontalRadiationValue`, `AlbedoValue`): a record missing a radiation reading is skipped, and a missing albedo takes the default of `Solar.Query.Albedo`. An EPW file is a [DiGi\.Weather\.Classes\.Weather](https://learn.microsoft.com/en-us/dotnet/api/digi.weather.classes.weather 'DiGi\.Weather\.Classes\.Weather') and is passed as is.

```csharp
public static DiGi.GIS.Analytical.Solar.Classes.SolarHourSeries? SolarHourSeries(this DiGi.Weather.Classes.Weather? weather, DiGi.Core.Classes.Coordinates? coordinates, DiGi.Core.Enums.UTC uTC);
```
#### Parameters

<a name='DiGi.GIS.Analytical.Solar.Create.SolarHourSeries(thisDiGi.Weather.Classes.Weather,DiGi.Core.Classes.Coordinates,DiGi.Core.Enums.UTC).weather'></a>

`weather` [DiGi\.Weather\.Classes\.Weather](https://learn.microsoft.com/en-us/dotnet/api/digi.weather.classes.weather 'DiGi\.Weather\.Classes\.Weather')

The weather series\.

<a name='DiGi.GIS.Analytical.Solar.Create.SolarHourSeries(thisDiGi.Weather.Classes.Weather,DiGi.Core.Classes.Coordinates,DiGi.Core.Enums.UTC).coordinates'></a>

`coordinates` [DiGi\.Core\.Classes\.Coordinates](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.coordinates 'DiGi\.Core\.Classes\.Coordinates')

The location of the site\.

<a name='DiGi.GIS.Analytical.Solar.Create.SolarHourSeries(thisDiGi.Weather.Classes.Weather,DiGi.Core.Classes.Coordinates,DiGi.Core.Enums.UTC).uTC'></a>

`uTC` [DiGi\.Core\.Enums\.UTC](https://learn.microsoft.com/en-us/dotnet/api/digi.core.enums.utc 'DiGi\.Core\.Enums\.UTC')

The fixed UTC offset the sun is positioned with \- the shading model's, so that the solve and a rebuild of its stored result see the same sun\.

#### Returns
[SolarHourSeries](DiGi.GIS.Analytical.Solar.Classes.md#DiGi.GIS.Analytical.Solar.Classes.SolarHourSeries 'DiGi\.GIS\.Analytical\.Solar\.Classes\.SolarHourSeries')  
The series, or null when an input is missing, the coordinates are the unstamped \(0, 0\), or no record is usable\.

<a name='DiGi.GIS.Analytical.Solar.Create.SolarShadingSolverOptions()'></a>

## Create\.SolarShadingSolverOptions\(\) Method

Creates the shading solver options every solar radiation solve runs with: the solver defaults with the angle tolerance [SolarAngleTolerance](DiGi.GIS.Analytical.Solar.Constants.md#DiGi.GIS.Analytical.Solar.Constants.Default.SolarAngleTolerance 'DiGi\.GIS\.Analytical\.Solar\.Constants\.Default\.SolarAngleTolerance')\.

Part of [SolarSolverVersion](DiGi.GIS.Analytical.Solar.Constants.md#DiGi.GIS.Analytical.Solar.Constants.Default.SolarSolverVersion 'DiGi\.GIS\.Analytical\.Solar\.Constants\.Default\.SolarSolverVersion'): a solve with other options must not be stored under the same version.

```csharp
public static DiGi.Solar.Classes.ShadingSolverOptions SolarShadingSolverOptions();
```

#### Returns
[DiGi\.Solar\.Classes\.ShadingSolverOptions](https://learn.microsoft.com/en-us/dotnet/api/digi.solar.classes.shadingsolveroptions 'DiGi\.Solar\.Classes\.ShadingSolverOptions')  
New options\.

<a name='DiGi.GIS.Analytical.Solar.Create.SurfaceSolarRadiation(thisDiGi.GIS.Analytical.Solar.Classes.SolarHourSeries,string,double,DiGi.Geometry.Spatial.Classes.Vector3D,double,double,System.Collections.Generic.IList_double_)'></a>

## Create\.SurfaceSolarRadiation\(this SolarHourSeries, string, double, Vector3D, double, double, IList\<double\>\) Method

Aggregates the hourly radiation of one receiving surface over a weather series into its stored form: the summary values and the quantized shading factors\.

The one aggregation behind both a solve and a rebuild from stored factors, so the two read every hour identically. Per hour: the beam reaches the unshaded area only (`UnshadedArea · I_beam`), the diffuse and ground-reflected components the unblocked share of the sky and ground (`A · I_diff · SkyVisibility`, `A · I_ground · GroundVisibility`); a blocked share contributes 0, as reflections off neighbours are ignored (DiGi-Organization/DiGi.Solar#15). A night hour has a factor of 0 and no direct radiation.

A sun-up hour whose factor is [System\.Double\.NaN](https://learn.microsoft.com/en-us/dotnet/api/system.double.nan 'System\.Double\.NaN') - the solver produced none - is skipped, and the surface is then given no stored factors ([DiGi\.GIS\.Classes\.SurfaceSolarRadiation\.ShadingFactors](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.classes.surfacesolarradiation.shadingfactors 'DiGi\.GIS\.Classes\.SurfaceSolarRadiation\.ShadingFactors') null), so it cannot be stored: a stored byte cannot say "missing", and reading it as 0 would count the hour as unshaded on a rebuild.

```csharp
public static DiGi.GIS.Classes.SurfaceSolarRadiation? SurfaceSolarRadiation(this DiGi.GIS.Analytical.Solar.Classes.SolarHourSeries? solarHourSeries, string? reference, double area, DiGi.Geometry.Spatial.Classes.Vector3D? normal, double skyVisibility, double groundVisibility, System.Collections.Generic.IList<double>? shadingFactors);
```
#### Parameters

<a name='DiGi.GIS.Analytical.Solar.Create.SurfaceSolarRadiation(thisDiGi.GIS.Analytical.Solar.Classes.SolarHourSeries,string,double,DiGi.Geometry.Spatial.Classes.Vector3D,double,double,System.Collections.Generic.IList_double_).solarHourSeries'></a>

`solarHourSeries` [SolarHourSeries](DiGi.GIS.Analytical.Solar.Classes.md#DiGi.GIS.Analytical.Solar.Classes.SolarHourSeries 'DiGi\.GIS\.Analytical\.Solar\.Classes\.SolarHourSeries')

The hourly weather and sun of the site\.

<a name='DiGi.GIS.Analytical.Solar.Create.SurfaceSolarRadiation(thisDiGi.GIS.Analytical.Solar.Classes.SolarHourSeries,string,double,DiGi.Geometry.Spatial.Classes.Vector3D,double,double,System.Collections.Generic.IList_double_).reference'></a>

`reference` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The `GuidReference` string of the surface's component\.

<a name='DiGi.GIS.Analytical.Solar.Create.SurfaceSolarRadiation(thisDiGi.GIS.Analytical.Solar.Classes.SolarHourSeries,string,double,DiGi.Geometry.Spatial.Classes.Vector3D,double,double,System.Collections.Generic.IList_double_).area'></a>

`area` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The area of the surface, in m²\.

<a name='DiGi.GIS.Analytical.Solar.Create.SurfaceSolarRadiation(thisDiGi.GIS.Analytical.Solar.Classes.SolarHourSeries,string,double,DiGi.Geometry.Spatial.Classes.Vector3D,double,double,System.Collections.Generic.IList_double_).normal'></a>

`normal` [DiGi\.Geometry\.Spatial\.Classes\.Vector3D](https://learn.microsoft.com/en-us/dotnet/api/digi.geometry.spatial.classes.vector3d 'DiGi\.Geometry\.Spatial\.Classes\.Vector3D')

The outward unit normal of the surface\.

<a name='DiGi.GIS.Analytical.Solar.Create.SurfaceSolarRadiation(thisDiGi.GIS.Analytical.Solar.Classes.SolarHourSeries,string,double,DiGi.Geometry.Spatial.Classes.Vector3D,double,double,System.Collections.Generic.IList_double_).skyVisibility'></a>

`skyVisibility` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The unblocked share of the sky, 0\.\.1\.

<a name='DiGi.GIS.Analytical.Solar.Create.SurfaceSolarRadiation(thisDiGi.GIS.Analytical.Solar.Classes.SolarHourSeries,string,double,DiGi.Geometry.Spatial.Classes.Vector3D,double,double,System.Collections.Generic.IList_double_).groundVisibility'></a>

`groundVisibility` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The unblocked share of the ground, 0\.\.1\.

<a name='DiGi.GIS.Analytical.Solar.Create.SurfaceSolarRadiation(thisDiGi.GIS.Analytical.Solar.Classes.SolarHourSeries,string,double,DiGi.Geometry.Spatial.Classes.Vector3D,double,double,System.Collections.Generic.IList_double_).shadingFactors'></a>

`shadingFactors` [System\.Collections\.Generic\.IList&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ilist-1 'System\.Collections\.Generic\.IList\`1')[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ilist-1 'System\.Collections\.Generic\.IList\`1')

The shading factor of every hour of the solar reference year \([SolarReferenceHourCount](DiGi.GIS.Analytical.Solar.Constants.md#DiGi.GIS.Analytical.Solar.Constants.Default.SolarReferenceHourCount 'DiGi\.GIS\.Analytical\.Solar\.Constants\.Default\.SolarReferenceHourCount') values, index = [SolarReferenceHourIndex\(this DateTime\)](DiGi.GIS.Analytical.Solar.md#DiGi.GIS.Analytical.Solar.Query.SolarReferenceHourIndex(thisSystem.DateTime) 'DiGi\.GIS\.Analytical\.Solar\.Query\.SolarReferenceHourIndex\(this System\.DateTime\)')\), 0 unshaded to 1 shaded; NaN for a sun\-up hour without one\.

#### Returns
[DiGi\.GIS\.Classes\.SurfaceSolarRadiation](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.classes.surfacesolarradiation 'DiGi\.GIS\.Classes\.SurfaceSolarRadiation')  
The surface, or null when an input is missing, the area is not a positive number or the factors do not cover the reference year\.

<a name='DiGi.GIS.Analytical.Solar.Create.SurfaceSolarRadiations(thisDiGi.GIS.Classes.BuildingSolarRadiationResult,DiGi.Analytical.Building.Classes.BuildingInformation,DiGi.Weather.Classes.Weather)'></a>

## Create\.SurfaceSolarRadiations\(this BuildingSolarRadiationResult, BuildingInformation, Weather\) Method

Rebuilds the summary values of a stored solar radiation result for another weather series, from its stored shading factors, normals and visibilities: no neighbours, no shading model, no solve\.

The factors depend on the sun position only, so they hold for any weather. The weather is read hour by hour through the same aggregation as a solve ([SurfaceSolarRadiation\(this SolarHourSeries, string, double, Vector3D, double, double, IList&lt;double&gt;\)](DiGi.GIS.Analytical.Solar.md#DiGi.GIS.Analytical.Solar.Create.SurfaceSolarRadiation(thisDiGi.GIS.Analytical.Solar.Classes.SolarHourSeries,string,double,DiGi.Geometry.Spatial.Classes.Vector3D,double,double,System.Collections.Generic.IList_double_) 'DiGi\.GIS\.Analytical\.Solar\.Create\.SurfaceSolarRadiation\(this DiGi\.GIS\.Analytical\.Solar\.Classes\.SolarHourSeries, string, double, DiGi\.Geometry\.Spatial\.Classes\.Vector3D, double, double, System\.Collections\.Generic\.IList\<double\>\)')) and the sun is positioned from the building's location and UTC offset - the ones its shading model was solved with - so the rebuild differs from a solve only by the quantization of the factors (at most 0.5/255 per hour).

```csharp
public static System.Collections.Generic.List<DiGi.GIS.Classes.SurfaceSolarRadiation>? SurfaceSolarRadiations(this DiGi.GIS.Classes.BuildingSolarRadiationResult? buildingSolarRadiationResult, DiGi.Analytical.Building.Classes.BuildingInformation? buildingInformation, DiGi.Weather.Classes.Weather? weather);
```
#### Parameters

<a name='DiGi.GIS.Analytical.Solar.Create.SurfaceSolarRadiations(thisDiGi.GIS.Classes.BuildingSolarRadiationResult,DiGi.Analytical.Building.Classes.BuildingInformation,DiGi.Weather.Classes.Weather).buildingSolarRadiationResult'></a>

`buildingSolarRadiationResult` [DiGi\.GIS\.Classes\.BuildingSolarRadiationResult](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.classes.buildingsolarradiationresult 'DiGi\.GIS\.Classes\.BuildingSolarRadiationResult')

The stored result, read with its shading factors\.

<a name='DiGi.GIS.Analytical.Solar.Create.SurfaceSolarRadiations(thisDiGi.GIS.Classes.BuildingSolarRadiationResult,DiGi.Analytical.Building.Classes.BuildingInformation,DiGi.Weather.Classes.Weather).buildingInformation'></a>

`buildingInformation` [DiGi\.Analytical\.Building\.Classes\.BuildingInformation](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.classes.buildinginformation 'DiGi\.Analytical\.Building\.Classes\.BuildingInformation')

The building's information after `GIS.Analytical.Modify.UpdateBuildingInformation`: its coordinates and UTC offset\.

<a name='DiGi.GIS.Analytical.Solar.Create.SurfaceSolarRadiations(thisDiGi.GIS.Classes.BuildingSolarRadiationResult,DiGi.Analytical.Building.Classes.BuildingInformation,DiGi.Weather.Classes.Weather).weather'></a>

`weather` [DiGi\.Weather\.Classes\.Weather](https://learn.microsoft.com/en-us/dotnet/api/digi.weather.classes.weather 'DiGi\.Weather\.Classes\.Weather')

The weather series to rebuild for; an EPW file is passed as is\.

#### Returns
[System\.Collections\.Generic\.List&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[DiGi\.GIS\.Classes\.SurfaceSolarRadiation](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.classes.surfacesolarradiation 'DiGi\.GIS\.Classes\.SurfaceSolarRadiation')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')  
One surface per stored surface, carrying the stored factors, or null when an input is missing, the weather holds no usable hour, or a stored surface has no normal or no factors\.

<a name='DiGi.GIS.Analytical.Solar.Create.SurfaceSolarRadiations(thisDiGi.Solar.Classes.ShadingModel,System.Collections.Generic.IDictionary_string,DiGi.Geometry.Spatial.Classes.Vector3D_,DiGi.Weather.Classes.Weather,DiGi.Solar.Classes.ShadingSolverOptions,System.Action_string_)'></a>

## Create\.SurfaceSolarRadiations\(this ShadingModel, IDictionary\<string,Vector3D\>, Weather, ShadingSolverOptions, Action\<string\>\) Method

Solves the solar radiation of every receiving surface of a shading model over a weather series, in the stored form: the summary values over the weather and the quantized shading factor of every hour of the solar reference year\.

The shading solver samples all [SolarReferenceHourCount](DiGi.GIS.Analytical.Solar.Constants.md#DiGi.GIS.Analytical.Solar.Constants.Default.SolarReferenceHourCount 'DiGi\.GIS\.Analytical\.Solar\.Constants\.Default\.SolarReferenceHourCount') reference hours ([SolarReferenceDateTimes\(\)](DiGi.GIS.Analytical.Solar.md#DiGi.GIS.Analytical.Solar.Query.SolarReferenceDateTimes() 'DiGi\.GIS\.Analytical\.Solar\.Query\.SolarReferenceDateTimes\(\)')), not the hours the weather happens to hold: a factor depends on the sun position only, so the stored factors are valid for any weather source (DiGi.GIS.WebAPI.UI#73). The summary values are aggregated from the exact factors ([SurfaceSolarRadiation\(this SolarHourSeries, string, double, Vector3D, double, double, IList&lt;double&gt;\)](DiGi.GIS.Analytical.Solar.md#DiGi.GIS.Analytical.Solar.Create.SurfaceSolarRadiation(thisDiGi.GIS.Analytical.Solar.Classes.SolarHourSeries,string,double,DiGi.Geometry.Spatial.Classes.Vector3D,double,double,System.Collections.Generic.IList_double_) 'DiGi\.GIS\.Analytical\.Solar\.Create\.SurfaceSolarRadiation\(this DiGi\.GIS\.Analytical\.Solar\.Classes\.SolarHourSeries, string, double, DiGi\.Geometry\.Spatial\.Classes\.Vector3D, double, double, System\.Collections\.Generic\.IList\<double\>\)')); only the stored bytes are quantized.

A surface with a sun-up hour the solver left without a factor carries no stored factors (and is logged), so its building can be shown but not stored.

For the building alone ([SolarRadiusIsolated](DiGi.GIS.Analytical.Solar.Constants.md#DiGi.GIS.Analytical.Solar.Constants.Default.SolarRadiusIsolated 'DiGi\.GIS\.Analytical\.Solar\.Constants\.Default\.SolarRadiusIsolated')) build the shading model with no surrounding buildings; the building still shades and blocks the view of its own surfaces.

```csharp
public static System.Collections.Generic.List<DiGi.GIS.Classes.SurfaceSolarRadiation>? SurfaceSolarRadiations(this DiGi.Solar.Classes.ShadingModel? shadingModel, System.Collections.Generic.IDictionary<string,DiGi.Geometry.Spatial.Classes.Vector3D>? normals, DiGi.Weather.Classes.Weather? weather, DiGi.Solar.Classes.ShadingSolverOptions? shadingSolverOptions, System.Action<string>? log=null);
```
#### Parameters

<a name='DiGi.GIS.Analytical.Solar.Create.SurfaceSolarRadiations(thisDiGi.Solar.Classes.ShadingModel,System.Collections.Generic.IDictionary_string,DiGi.Geometry.Spatial.Classes.Vector3D_,DiGi.Weather.Classes.Weather,DiGi.Solar.Classes.ShadingSolverOptions,System.Action_string_).shadingModel'></a>

`shadingModel` [DiGi\.Solar\.Classes\.ShadingModel](https://learn.microsoft.com/en-us/dotnet/api/digi.solar.classes.shadingmodel 'DiGi\.Solar\.Classes\.ShadingModel')

The shading model, stamped with its coordinates and UTC offset\.

<a name='DiGi.GIS.Analytical.Solar.Create.SurfaceSolarRadiations(thisDiGi.Solar.Classes.ShadingModel,System.Collections.Generic.IDictionary_string,DiGi.Geometry.Spatial.Classes.Vector3D_,DiGi.Weather.Classes.Weather,DiGi.Solar.Classes.ShadingSolverOptions,System.Action_string_).normals'></a>

`normals` [System\.Collections\.Generic\.IDictionary&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.idictionary-2 'System\.Collections\.Generic\.IDictionary\`2')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[,](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.idictionary-2 'System\.Collections\.Generic\.IDictionary\`2')[DiGi\.Geometry\.Spatial\.Classes\.Vector3D](https://learn.microsoft.com/en-us/dotnet/api/digi.geometry.spatial.classes.vector3d 'DiGi\.Geometry\.Spatial\.Classes\.Vector3D')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.idictionary-2 'System\.Collections\.Generic\.IDictionary\`2')

The outward unit normal of each receiving surface, by the `GuidReference` string of its component \([SolarReceiverNormals\(this BuildingModel\)](DiGi.GIS.Analytical.Solar.md#DiGi.GIS.Analytical.Solar.Query.SolarReceiverNormals(thisDiGi.Analytical.Building.Classes.BuildingModel) 'DiGi\.GIS\.Analytical\.Solar\.Query\.SolarReceiverNormals\(this DiGi\.Analytical\.Building\.Classes\.BuildingModel\)')\)\.

<a name='DiGi.GIS.Analytical.Solar.Create.SurfaceSolarRadiations(thisDiGi.Solar.Classes.ShadingModel,System.Collections.Generic.IDictionary_string,DiGi.Geometry.Spatial.Classes.Vector3D_,DiGi.Weather.Classes.Weather,DiGi.Solar.Classes.ShadingSolverOptions,System.Action_string_).weather'></a>

`weather` [DiGi\.Weather\.Classes\.Weather](https://learn.microsoft.com/en-us/dotnet/api/digi.weather.classes.weather 'DiGi\.Weather\.Classes\.Weather')

The weather series; an EPW file is passed as is\.

<a name='DiGi.GIS.Analytical.Solar.Create.SurfaceSolarRadiations(thisDiGi.Solar.Classes.ShadingModel,System.Collections.Generic.IDictionary_string,DiGi.Geometry.Spatial.Classes.Vector3D_,DiGi.Weather.Classes.Weather,DiGi.Solar.Classes.ShadingSolverOptions,System.Action_string_).shadingSolverOptions'></a>

`shadingSolverOptions` [DiGi\.Solar\.Classes\.ShadingSolverOptions](https://learn.microsoft.com/en-us/dotnet/api/digi.solar.classes.shadingsolveroptions 'DiGi\.Solar\.Classes\.ShadingSolverOptions')

The solver options \([SolarShadingSolverOptions\(\)](DiGi.GIS.Analytical.Solar.md#DiGi.GIS.Analytical.Solar.Create.SolarShadingSolverOptions() 'DiGi\.GIS\.Analytical\.Solar\.Create\.SolarShadingSolverOptions\(\)')\); their time series is replaced by the reference hours\.

<a name='DiGi.GIS.Analytical.Solar.Create.SurfaceSolarRadiations(thisDiGi.Solar.Classes.ShadingModel,System.Collections.Generic.IDictionary_string,DiGi.Geometry.Spatial.Classes.Vector3D_,DiGi.Weather.Classes.Weather,DiGi.Solar.Classes.ShadingSolverOptions,System.Action_string_).log'></a>

`log` [System\.Action&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.action-1 'System\.Action\`1')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.action-1 'System\.Action\`1')

Receives one line of timings, or null\.

#### Returns
[System\.Collections\.Generic\.List&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[DiGi\.GIS\.Classes\.SurfaceSolarRadiation](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.classes.surfacesolarradiation 'DiGi\.GIS\.Classes\.SurfaceSolarRadiation')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')  
One surface per receiving surface the model holds, or null when an input is missing, the model is unstamped, the weather holds no usable hour or the solve fails\.

<a name='DiGi.GIS.Analytical.Solar.Query'></a>

## Query Class

```csharp
public static class Query
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → Query
### Methods

<a name='DiGi.GIS.Analytical.Solar.Query.CasterTriangleCount(thisDiGi.Solar.Classes.ShadingModel,double)'></a>

## Query\.CasterTriangleCount\(this ShadingModel, double\) Method

Counts the triangles of the shading\-only elements of a shading model \- the neighbours and the analysed building's own non\-receiving components \- which every receiver is solved against\.

The elements are triangulated exactly as [DiGi\.Solar\.Classes\.ShadingSolver\.Solve](https://learn.microsoft.com/en-us/dotnet/api/digi.solar.classes.shadingsolver.solve 'DiGi\.Solar\.Classes\.ShadingSolver\.Solve') triangulates its casters, so the count is the quantity the caster ceilings of a solve were measured on (DiGi-Organization/DiGi.Solar#7): `SolarCasterTriangleCountMax` and `SolarJobCasterTriangleCountMax` of DiGi.GIS.WebAPI.UI, and the ceiling of a batch solve (DiGi-Organization/DiGi.GIS.PostgreSQL#136). The receivers' own triangles are not counted.

```csharp
public static int CasterTriangleCount(this DiGi.Solar.Classes.ShadingModel? shadingModel, double tolerance=1E-06);
```
#### Parameters

<a name='DiGi.GIS.Analytical.Solar.Query.CasterTriangleCount(thisDiGi.Solar.Classes.ShadingModel,double).shadingModel'></a>

`shadingModel` [DiGi\.Solar\.Classes\.ShadingModel](https://learn.microsoft.com/en-us/dotnet/api/digi.solar.classes.shadingmodel 'DiGi\.Solar\.Classes\.ShadingModel')

The shading model\. This value can be null\.

<a name='DiGi.GIS.Analytical.Solar.Query.CasterTriangleCount(thisDiGi.Solar.Classes.ShadingModel,double).tolerance'></a>

`tolerance` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The distance tolerance used by the triangulation\.

#### Returns
[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')  
The number of triangles, or 0 when the model is null or has no shading\-only element\.

<a name='DiGi.GIS.Analytical.Solar.Query.SolarBuildingModelId(thisDiGi.Analytical.Building.Classes.BuildingModel)'></a>

## Query\.SolarBuildingModelId\(this BuildingModel\) Method

Derives the building model id a stored solar radiation result is keyed by, from the building model's [DiGi\.Core\.Classes\.GuidObject\.Guid](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.guidobject.guid 'DiGi\.Core\.Classes\.GuidObject\.Guid')\.

The UI never sees the `building_model` row id: `gis/buildingmodel/itemsbyreferences` answers the bare models, and the `id` of the solar routes is the `building_2d` id, which survives a regeneration of the model. The model's Guid does not - a regenerated model is a new object with a new Guid (`GuidObject` draws [System\.Guid\.NewGuid](https://learn.microsoft.com/en-us/dotnet/api/system.guid.newguid 'System\.Guid\.NewGuid')) - so a stored result of the old model becomes a miss, which is what the key is for (DiGi.GIS.WebAPI.UI#73).

The value is the first eight bytes of the Guid read little-endian, with the sign bit cleared and 0 mapped to 1, so it is positive, as the read and write endpoints require, and identical on every platform. Two models colliding in 63 bits within one county part is not a practical concern.

```csharp
public static System.Nullable<long> SolarBuildingModelId(this DiGi.Analytical.Building.Classes.BuildingModel? buildingModel);
```
#### Parameters

<a name='DiGi.GIS.Analytical.Solar.Query.SolarBuildingModelId(thisDiGi.Analytical.Building.Classes.BuildingModel).buildingModel'></a>

`buildingModel` [DiGi\.Analytical\.Building\.Classes\.BuildingModel](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.classes.buildingmodel 'DiGi\.Analytical\.Building\.Classes\.BuildingModel')

The building model\.

#### Returns
[System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Int64](https://learn.microsoft.com/en-us/dotnet/api/system.int64 'System\.Int64')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')  
The positive id, or null when [buildingModel](DiGi.GIS.Analytical.Solar.md#DiGi.GIS.Analytical.Solar.Query.SolarBuildingModelId(thisDiGi.Analytical.Building.Classes.BuildingModel).buildingModel 'DiGi\.GIS\.Analytical\.Solar\.Query\.SolarBuildingModelId\(this DiGi\.Analytical\.Building\.Classes\.BuildingModel\)\.buildingModel') is null or its Guid is empty\.

<a name='DiGi.GIS.Analytical.Solar.Query.SolarNeighbourCircle(thisDiGi.Analytical.Building.Classes.BuildingModel,double)'></a>

## Query\.SolarNeighbourCircle\(this BuildingModel, double\) Method

Gets the circle a solar radiation solve takes a building's neighbours from: centred on the centre of the building's bounding box, reaching [radius](DiGi.GIS.Analytical.Solar.md#DiGi.GIS.Analytical.Solar.Query.SolarNeighbourCircle(thisDiGi.Analytical.Building.Classes.BuildingModel,double).radius 'DiGi\.GIS\.Analytical\.Solar\.Query\.SolarNeighbourCircle\(this DiGi\.Analytical\.Building\.Classes\.BuildingModel, double\)\.radius') beyond its farthest corner\.

Every building whose footprint bounding box lies within or intersects the circle casts shade (`gis/buildingmodel/itemsbycircle`). The centre is also the point the weather station is chosen for. The viewer (`SolarController`) and a batch solve (DiGi-Organization/DiGi.GIS.PostgreSQL#136) both take the circle from here, so a stored result does not depend on which of them solved it.

```csharp
public static DiGi.Geometry.Planar.Classes.Circle2D? SolarNeighbourCircle(this DiGi.Analytical.Building.Classes.BuildingModel? buildingModel, double radius);
```
#### Parameters

<a name='DiGi.GIS.Analytical.Solar.Query.SolarNeighbourCircle(thisDiGi.Analytical.Building.Classes.BuildingModel,double).buildingModel'></a>

`buildingModel` [DiGi\.Analytical\.Building\.Classes\.BuildingModel](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.classes.buildingmodel 'DiGi\.Analytical\.Building\.Classes\.BuildingModel')

The building model\. This value can be null\.

<a name='DiGi.GIS.Analytical.Solar.Query.SolarNeighbourCircle(thisDiGi.Analytical.Building.Classes.BuildingModel,double).radius'></a>

`radius` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The neighbour radius, in m, measured from the farthest corner of the bounding box\.

#### Returns
[DiGi\.Geometry\.Planar\.Classes\.Circle2D](https://learn.microsoft.com/en-us/dotnet/api/digi.geometry.planar.classes.circle2d 'DiGi\.Geometry\.Planar\.Classes\.Circle2D')  
The circle, or null when the model is null, has no bounding box or its centre is not finite\.

<a name='DiGi.GIS.Analytical.Solar.Query.SolarRadiusKey(double)'></a>

## Query\.SolarRadiusKey\(double\) Method

Rounds a neighbour radius to [SolarRadiusDecimals](DiGi.GIS.Analytical.Solar.Constants.md#DiGi.GIS.Analytical.Solar.Constants.Default.SolarRadiusDecimals 'DiGi\.GIS\.Analytical\.Solar\.Constants\.Default\.SolarRadiusDecimals') decimal places \(0\.1 m\), the value a solar radiation request is solved with and its stored result is keyed by\.

The stored key compares the radius exactly, so it is rounded once, here, and the same value is then solved, looked up and stored; no layer below rounds again. [SolarRadiusIsolated](DiGi.GIS.Analytical.Solar.Constants.md#DiGi.GIS.Analytical.Solar.Constants.Default.SolarRadiusIsolated 'DiGi\.GIS\.Analytical\.Solar\.Constants\.Default\.SolarRadiusIsolated') (0) is its own key.

```csharp
public static double SolarRadiusKey(double radius);
```
#### Parameters

<a name='DiGi.GIS.Analytical.Solar.Query.SolarRadiusKey(double).radius'></a>

`radius` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The requested radius, in m\.

#### Returns
[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')  
The radius rounded to 0\.1 m, midpoints away from zero\.

<a name='DiGi.GIS.Analytical.Solar.Query.SolarReceiverNormals(thisDiGi.Analytical.Building.Classes.BuildingModel)'></a>

## Query\.SolarReceiverNormals\(this BuildingModel\) Method

Collects the receiving surfaces of a solar radiation calculation \- the external walls and roofs of a building \- with the outward unit normal of each\.

A component's stored normal is its drawing orientation, not the outward one, while the irradiance of a surface depends on which way it faces: with a stored normal pointing into the building, a north wall would receive the south wall's beam. The outward normals are therefore taken from [DiGi\.Analytical\.Building\.Classes\.BuildingModel\.GetExternalShell\(System\.Nullable\{DiGi\.Geometry\.Core\.Enums\.Side\},System\.Nullable\{DiGi\.Geometry\.Core\.Enums\.Orientation\},System\.Nullable\{DiGi\.Geometry\.Core\.Enums\.Orientation\},System\.Double\)](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.classes.buildingmodel.getexternalshell#digi-analytical-building-classes-buildingmodel-getexternalshell(system-nullable{digi-geometry-core-enums-side}-system-nullable{digi-geometry-core-enums-orientation}-system-nullable{digi-geometry-core-enums-orientation}-system-double) 'DiGi\.Analytical\.Building\.Classes\.BuildingModel\.GetExternalShell\(System\.Nullable\{DiGi\.Geometry\.Core\.Enums\.Side\},System\.Nullable\{DiGi\.Geometry\.Core\.Enums\.Orientation\},System\.Nullable\{DiGi\.Geometry\.Core\.Enums\.Orientation\},System\.Double\)') with [DiGi\.Geometry\.Core\.Enums\.Side\.External](https://learn.microsoft.com/en-us/dotnet/api/digi.geometry.core.enums.side.external 'DiGi\.Geometry\.Core\.Enums\.Side\.External'), whose faces are oriented over the whole envelope.

Floors are excluded because the ground floor faces the soil. Internal partitions are not part of the envelope and are excluded with them.

```csharp
public static System.Collections.Generic.Dictionary<string,DiGi.Geometry.Spatial.Classes.Vector3D>? SolarReceiverNormals(this DiGi.Analytical.Building.Classes.BuildingModel? buildingModel);
```
#### Parameters

<a name='DiGi.GIS.Analytical.Solar.Query.SolarReceiverNormals(thisDiGi.Analytical.Building.Classes.BuildingModel).buildingModel'></a>

`buildingModel` [DiGi\.Analytical\.Building\.Classes\.BuildingModel](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.classes.buildingmodel 'DiGi\.Analytical\.Building\.Classes\.BuildingModel')

The building model\. This value can be null\.

#### Returns
[System\.Collections\.Generic\.Dictionary&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2 'System\.Collections\.Generic\.Dictionary\`2')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[,](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2 'System\.Collections\.Generic\.Dictionary\`2')[DiGi\.Geometry\.Spatial\.Classes\.Vector3D](https://learn.microsoft.com/en-us/dotnet/api/digi.geometry.spatial.classes.vector3d 'DiGi\.Geometry\.Spatial\.Classes\.Vector3D')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2 'System\.Collections\.Generic\.Dictionary\`2')  
The outward unit normal of each receiving surface, keyed by the [DiGi\.Core\.Classes\.GuidReference](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.guidreference 'DiGi\.Core\.Classes\.GuidReference') string of its component \- the string `ToSolar` writes to the shading element \- or [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null') when the model has no external envelope \(no space relation, fewer than four external faces, or a component with more than one geometry\)\. A degenerate model, such as a sliver footprint with walls and no roof or floor, is answered with [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null')\.

<a name='DiGi.GIS.Analytical.Solar.Query.SolarReferenceDateTime(thisSystem.DateTime)'></a>

## Query\.SolarReferenceDateTime\(this DateTime\) Method

Maps the time stamp of an EPW record to the instant the solar radiation calculation samples the sun at: the middle of the hour the record covers, in [SolarReferenceYear](DiGi.GIS.Analytical.Solar.Constants.md#DiGi.GIS.Analytical.Solar.Constants.Default.SolarReferenceYear 'DiGi\.GIS\.Analytical\.Solar\.Constants\.Default\.SolarReferenceYear')\.

An EPW record is stamped with the end of its hour (`EPW.Convert.ToSystem_DateTime`: hour 1 is 01:00) and its radiation is the integral over the hour before, so the sun is sampled 30 minutes earlier. The time is local standard time, the fixed offset of the shading model, so no daylight saving shift applies.

Typical meteorological years mix calendar years month by month, and hour 24 of 31 December rolls into 1 January of the next year; moving the mid-hour instant into one fixed non-leap year keeps the series monotonic and one hour per record. 31 December 24:00 therefore maps to 31 December 23:30 of the reference year.

```csharp
public static System.Nullable<System.DateTime> SolarReferenceDateTime(this System.DateTime dateTime);
```
#### Parameters

<a name='DiGi.GIS.Analytical.Solar.Query.SolarReferenceDateTime(thisSystem.DateTime).dateTime'></a>

`dateTime` [System\.DateTime](https://learn.microsoft.com/en-us/dotnet/api/system.datetime 'System\.DateTime')

The hour\-ending time stamp of the EPW record\.

#### Returns
[System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.DateTime](https://learn.microsoft.com/en-us/dotnet/api/system.datetime 'System\.DateTime')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')  
The mid\-hour instant in the reference year, or [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null') for an hour on 29 February, which a non\-leap year does not have\.

<a name='DiGi.GIS.Analytical.Solar.Query.SolarReferenceDateTimes()'></a>

## Query\.SolarReferenceDateTimes\(\) Method

Gets the [SolarReferenceHourCount](DiGi.GIS.Analytical.Solar.Constants.md#DiGi.GIS.Analytical.Solar.Constants.Default.SolarReferenceHourCount 'DiGi\.GIS\.Analytical\.Solar\.Constants\.Default\.SolarReferenceHourCount') mid\-hour times of the solar reference year, one per hour in order, as [SolarReferenceDateTime\(this DateTime\)](DiGi.GIS.Analytical.Solar.md#DiGi.GIS.Analytical.Solar.Query.SolarReferenceDateTime(thisSystem.DateTime) 'DiGi\.GIS\.Analytical\.Solar\.Query\.SolarReferenceDateTime\(this System\.DateTime\)') maps EPW records: 1 January 00:30 to 31 December 23:30\.

The time series the shading solver samples. A surface's shading factors depend on the sun position only, so they are solved for every hour of the year, independent of which hours a weather source happens to hold (DiGi.GIS.WebAPI.UI#73).

```csharp
public static System.Collections.Generic.List<System.DateTime> SolarReferenceDateTimes();
```

#### Returns
[System\.Collections\.Generic\.List&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[System\.DateTime](https://learn.microsoft.com/en-us/dotnet/api/system.datetime 'System\.DateTime')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')  
The times, in order; element `i` lies in hour `i` \([SolarReferenceHourIndex\(this DateTime\)](DiGi.GIS.Analytical.Solar.md#DiGi.GIS.Analytical.Solar.Query.SolarReferenceHourIndex(thisSystem.DateTime) 'DiGi\.GIS\.Analytical\.Solar\.Query\.SolarReferenceHourIndex\(this System\.DateTime\)')\)\.

<a name='DiGi.GIS.Analytical.Solar.Query.SolarReferenceHourIndex(thisSystem.DateTime)'></a>

## Query\.SolarReferenceHourIndex\(this DateTime\) Method

Gets the hour of the solar reference year a reference date and time falls in: 0 for the hour starting on 1 January at midnight, [SolarReferenceHourCount](DiGi.GIS.Analytical.Solar.Constants.md#DiGi.GIS.Analytical.Solar.Constants.Default.SolarReferenceHourCount 'DiGi\.GIS\.Analytical\.Solar\.Constants\.Default\.SolarReferenceHourCount') \- 1 for the last hour of 31 December\.

The index of a surface's stored shading factors. A time from [SolarReferenceDateTime\(this DateTime\)](DiGi.GIS.Analytical.Solar.md#DiGi.GIS.Analytical.Solar.Query.SolarReferenceDateTime(thisSystem.DateTime) 'DiGi\.GIS\.Analytical\.Solar\.Query\.SolarReferenceDateTime\(this System\.DateTime\)') lies at mid-hour, so the index is the whole hours elapsed since the start of the year.

```csharp
public static System.Nullable<int> SolarReferenceHourIndex(this System.DateTime dateTime);
```
#### Parameters

<a name='DiGi.GIS.Analytical.Solar.Query.SolarReferenceHourIndex(thisSystem.DateTime).dateTime'></a>

`dateTime` [System\.DateTime](https://learn.microsoft.com/en-us/dotnet/api/system.datetime 'System\.DateTime')

A date and time in [SolarReferenceYear](DiGi.GIS.Analytical.Solar.Constants.md#DiGi.GIS.Analytical.Solar.Constants.Default.SolarReferenceYear 'DiGi\.GIS\.Analytical\.Solar\.Constants\.Default\.SolarReferenceYear')\.

#### Returns
[System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')  
The hour index, or null when [dateTime](DiGi.GIS.Analytical.Solar.md#DiGi.GIS.Analytical.Solar.Query.SolarReferenceHourIndex(thisSystem.DateTime).dateTime 'DiGi\.GIS\.Analytical\.Solar\.Query\.SolarReferenceHourIndex\(this System\.DateTime\)\.dateTime') lies outside the reference year\.