#### [DiGi\.GIS\.Analytical](DiGi.GIS.Analytical.Overview.md 'DiGi\.GIS\.Analytical\.Overview')

## DiGi\.GIS\.Analytical Namespace
### Classes

<a name='DiGi.GIS.Analytical.Convert'></a>

## Convert Class

```csharp
public static class Convert
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → Convert
### Methods

<a name='DiGi.GIS.Analytical.Convert.ToAnalytical(thisDiGi.CityGML.Interfaces.ISurface)'></a>

## Convert\.ToAnalytical\(this ISurface\) Method

Converts a CityGML surface to its corresponding analytical building component based on the surface type\.

```csharp
public static DiGi.Analytical.Building.Interfaces.IComponent? ToAnalytical(this DiGi.CityGML.Interfaces.ISurface? surface);
```
#### Parameters

<a name='DiGi.GIS.Analytical.Convert.ToAnalytical(thisDiGi.CityGML.Interfaces.ISurface).surface'></a>

`surface` [DiGi\.CityGML\.Interfaces\.ISurface](https://learn.microsoft.com/en-us/dotnet/api/digi.citygml.interfaces.isurface 'DiGi\.CityGML\.Interfaces\.ISurface')

The surface object to be converted\.

#### Returns
[DiGi\.Analytical\.Building\.Interfaces\.IComponent](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.interfaces.icomponent 'DiGi\.Analytical\.Building\.Interfaces\.IComponent')  
An [DiGi\.Analytical\.Building\.Interfaces\.IComponent](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.interfaces.icomponent 'DiGi\.Analytical\.Building\.Interfaces\.IComponent') representing the analytical version of the surface, or `null` if the input is null, the geometry is missing, or the surface type is not supported for conversion\.

<a name='DiGi.GIS.Analytical.Create'></a>

## Create Class

```csharp
public static class Create
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → Create
### Methods

<a name='DiGi.GIS.Analytical.Create.BuildingModel(thisDiGi.CityGML.Classes.Building,DiGi.GIS.Classes.Building2D,double,double,System.Collections.Generic.IEnumerable_double_)'></a>

## Create\.BuildingModel\(this Building, Building2D, double, double, IEnumerable\<double\>\) Method

Creates a [DiGi\.Analytical\.Building\.Classes\.BuildingModel](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.classes.buildingmodel 'DiGi\.Analytical\.Building\.Classes\.BuildingModel') from a 3D building and refines it with the data carried by the matching 2D building\.

The model is built from the 3D geometry of [building](DiGi.GIS.Analytical.md#DiGi.GIS.Analytical.Create.BuildingModel(thisDiGi.CityGML.Classes.Building,DiGi.GIS.Classes.Building2D,double,double,System.Collections.Generic.IEnumerable_double_).building 'DiGi\.GIS\.Analytical\.Create\.BuildingModel\(this DiGi\.CityGML\.Classes\.Building, DiGi\.GIS\.Classes\.Building2D, double, double, System\.Collections\.Generic\.IEnumerable\<double\>\)\.building'). When that geometry is missing or cannot be converted, the model is extruded from the footprint of [building2D](DiGi.GIS.Analytical.md#DiGi.GIS.Analytical.Create.BuildingModel(thisDiGi.CityGML.Classes.Building,DiGi.GIS.Classes.Building2D,double,double,System.Collections.Generic.IEnumerable_double_).building2D 'DiGi\.GIS\.Analytical\.Create\.BuildingModel\(this DiGi\.CityGML\.Classes\.Building, DiGi\.GIS\.Classes\.Building2D, double, double, System\.Collections\.Generic\.IEnumerable\<double\>\)\.building2D') at [Default](DiGi.GIS.Analytical.Constants.md#DiGi.GIS.Analytical.Constants.StoreyHeight.Default 'DiGi\.GIS\.Analytical\.Constants\.StoreyHeight\.Default'), starting from [elevation](DiGi.GIS.Analytical.md#DiGi.GIS.Analytical.Create.BuildingModel(thisDiGi.CityGML.Classes.Building,DiGi.GIS.Classes.Building2D,double,double,System.Collections.Generic.IEnumerable_double_).elevation 'DiGi\.GIS\.Analytical\.Create\.BuildingModel\(this DiGi\.CityGML\.Classes\.Building, DiGi\.GIS\.Classes\.Building2D, double, double, System\.Collections\.Generic\.IEnumerable\<double\>\)\.elevation'). The footprint is extruded as well when the 3D geometry converts to fewer than four surfaces, since such a model can never enclose a volume.

The storey count of [building2D](DiGi.GIS.Analytical.md#DiGi.GIS.Analytical.Create.BuildingModel(thisDiGi.CityGML.Classes.Building,DiGi.GIS.Classes.Building2D,double,double,System.Collections.Generic.IEnumerable_double_).building2D 'DiGi\.GIS\.Analytical\.Create\.BuildingModel\(this DiGi\.CityGML\.Classes\.Building, DiGi\.GIS\.Classes\.Building2D, double, double, System\.Collections\.Generic\.IEnumerable\<double\>\)\.building2D') is used to cut the model into storeys. The storey height is derived from the extents of the model, rounded down to [Precision](DiGi.GIS.Analytical.Constants.md#DiGi.GIS.Analytical.Constants.StoreyHeight.Precision 'DiGi\.GIS\.Analytical\.Constants\.StoreyHeight\.Precision'), and the cutting planes are measured downwards from the top of the model so that the rounding remainder is left to the lowest storey. Nothing is cut when the derived storey height is below [Min](DiGi.GIS.Analytical.Constants.md#DiGi.GIS.Analytical.Constants.StoreyHeight.Min 'DiGi\.GIS\.Analytical\.Constants\.StoreyHeight\.Min').

A storey height above [Max](DiGi.GIS.Analytical.Constants.md#DiGi.GIS.Analytical.Constants.StoreyHeight.Max 'DiGi\.GIS\.Analytical\.Constants\.StoreyHeight\.Max') is handled by the function of the building. For a non residential building the storey height is clamped to [Max](DiGi.GIS.Analytical.Constants.md#DiGi.GIS.Analytical.Constants.StoreyHeight.Max 'DiGi\.GIS\.Analytical\.Constants\.StoreyHeight\.Max') and the storey count is kept, so the whole remainder is left to the lowest storey. For a residential building the storey count is treated as unreliable instead and recalculated from the extents of the model at [Default](DiGi.GIS.Analytical.Constants.md#DiGi.GIS.Analytical.Constants.StoreyHeight.Default 'DiGi\.GIS\.Analytical\.Constants\.StoreyHeight\.Default'), the storey height being derived again from that count - the resulting model may therefore hold a different number of storeys than [DiGi\.GIS\.Classes\.Building2D\.Storeys](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.classes.building2d.storeys 'DiGi\.GIS\.Classes\.Building2D\.Storeys'). When even the recalculated storey height stays above [Max](DiGi.GIS.Analytical.Constants.md#DiGi.GIS.Analytical.Constants.StoreyHeight.Max 'DiGi\.GIS\.Analytical\.Constants\.StoreyHeight\.Max') the model is returned unsplit.

The building reference ([DiGi\.GIS\.Classes\.GISGuidObject2D\.Reference](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.classes.gisguidobject2d.reference 'DiGi\.GIS\.Classes\.GISGuidObject2D\.Reference')) is carried over to [Reference](DiGi.GIS.Analytical.Enums.md#DiGi.GIS.Analytical.Enums.BuildingModelParameter.Reference 'DiGi\.GIS\.Analytical\.Enums\.BuildingModelParameter\.Reference').

The split does not re-host openings - windows and doors stay assigned to the fragment inheriting the identifier of the component they were hosted by, not to the fragment geometrically containing them.

The tolerance defaults to [Coordinate](DiGi.GIS.Analytical.Constants.md#DiGi.GIS.Analytical.Constants.Tolerance.Coordinate 'DiGi\.GIS\.Analytical\.Constants\.Tolerance\.Coordinate') rather than [DiGi\.Core\.Constants\.Tolerance\.Distance](https://learn.microsoft.com/en-us/dotnet/api/digi.core.constants.tolerance.distance 'DiGi\.Core\.Constants\.Tolerance\.Distance') because the coordinates of the national 3D building model carry two decimal places - at a finer tolerance the storey split leaves the ring assembled on the cutting plane open at the corners and no cut is made. Pass an explicit tolerance when the building comes from a more precise source.

```csharp
public static DiGi.Analytical.Building.Classes.BuildingModel? BuildingModel(this DiGi.CityGML.Classes.Building? building, DiGi.GIS.Classes.Building2D? building2D, double elevation=0.0, double tolerance=0.01, System.Collections.Generic.IEnumerable<double>? candidateTolerances=null);
```
#### Parameters

<a name='DiGi.GIS.Analytical.Create.BuildingModel(thisDiGi.CityGML.Classes.Building,DiGi.GIS.Classes.Building2D,double,double,System.Collections.Generic.IEnumerable_double_).building'></a>

`building` [DiGi\.CityGML\.Classes\.Building](https://learn.microsoft.com/en-us/dotnet/api/digi.citygml.classes.building 'DiGi\.CityGML\.Classes\.Building')

The 3D building object\.

<a name='DiGi.GIS.Analytical.Create.BuildingModel(thisDiGi.CityGML.Classes.Building,DiGi.GIS.Classes.Building2D,double,double,System.Collections.Generic.IEnumerable_double_).building2D'></a>

`building2D` [DiGi\.GIS\.Classes\.Building2D](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.classes.building2d 'DiGi\.GIS\.Classes\.Building2D')

The 2D building representation providing the storey count, the function and the reference\.

<a name='DiGi.GIS.Analytical.Create.BuildingModel(thisDiGi.CityGML.Classes.Building,DiGi.GIS.Classes.Building2D,double,double,System.Collections.Generic.IEnumerable_double_).elevation'></a>

`elevation` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The base elevation in meters above sea level\. It is read only on the extruded fallback and is ignored when the 3D geometry converts, since that geometry carries its own elevations\. A not\-a\-number elevation refuses the fallback and returns null instead of placing the building at a guessed height\.

<a name='DiGi.GIS.Analytical.Create.BuildingModel(thisDiGi.CityGML.Classes.Building,DiGi.GIS.Classes.Building2D,double,double,System.Collections.Generic.IEnumerable_double_).tolerance'></a>

`tolerance` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The distance tolerance for geometric calculations\.

<a name='DiGi.GIS.Analytical.Create.BuildingModel(thisDiGi.CityGML.Classes.Building,DiGi.GIS.Classes.Building2D,double,double,System.Collections.Generic.IEnumerable_double_).candidateTolerances'></a>

`candidateTolerances` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

Optional candidate tolerances to attempt if the polyhedron is not closed at the specified tolerance\.

#### Returns
[DiGi\.Analytical\.Building\.Classes\.BuildingModel](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.classes.buildingmodel 'DiGi\.Analytical\.Building\.Classes\.BuildingModel')  
A [DiGi\.Analytical\.Building\.Classes\.BuildingModel](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.classes.buildingmodel 'DiGi\.Analytical\.Building\.Classes\.BuildingModel') if successful; otherwise, null\.

<a name='DiGi.GIS.Analytical.Create.BuildingModel(thisDiGi.CityGML.Classes.Building,double)'></a>

## Create\.BuildingModel\(this Building, double\) Method

Creates a [DiGi\.Analytical\.Building\.Classes\.BuildingModel](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.classes.buildingmodel 'DiGi\.Analytical\.Building\.Classes\.BuildingModel') from a 3D building object\.

The tolerance defaults to [Coordinate](DiGi.GIS.Analytical.Constants.md#DiGi.GIS.Analytical.Constants.Tolerance.Coordinate 'DiGi\.GIS\.Analytical\.Constants\.Tolerance\.Coordinate') rather than [DiGi\.Core\.Constants\.Tolerance\.Distance](https://learn.microsoft.com/en-us/dotnet/api/digi.core.constants.tolerance.distance 'DiGi\.Core\.Constants\.Tolerance\.Distance') because the coordinates of the national 3D building model carry two decimal places - joining its boundary surfaces at a finer tolerance leaves the assembled rings open at the corners. Pass an explicit tolerance when the building comes from a more precise source.

A building whose surfaces convert to fewer than four faces cannot enclose a volume, and null is returned rather than a model of walls with no floor or roof.

```csharp
public static DiGi.Analytical.Building.Classes.BuildingModel? BuildingModel(this DiGi.CityGML.Classes.Building? building, double tolerance=0.01);
```
#### Parameters

<a name='DiGi.GIS.Analytical.Create.BuildingModel(thisDiGi.CityGML.Classes.Building,double).building'></a>

`building` [DiGi\.CityGML\.Classes\.Building](https://learn.microsoft.com/en-us/dotnet/api/digi.citygml.classes.building 'DiGi\.CityGML\.Classes\.Building')

The 3D building object\.

<a name='DiGi.GIS.Analytical.Create.BuildingModel(thisDiGi.CityGML.Classes.Building,double).tolerance'></a>

`tolerance` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The distance tolerance for geometric calculations\.

#### Returns
[DiGi\.Analytical\.Building\.Classes\.BuildingModel](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.classes.buildingmodel 'DiGi\.Analytical\.Building\.Classes\.BuildingModel')  
A [DiGi\.Analytical\.Building\.Classes\.BuildingModel](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.classes.buildingmodel 'DiGi\.Analytical\.Building\.Classes\.BuildingModel') if successful; otherwise, null\.

<a name='DiGi.GIS.Analytical.Create.BuildingModel(thisDiGi.Geometry.Spatial.Classes.Polyhedron,double)'></a>

## Create\.BuildingModel\(this Polyhedron, double\) Method

Creates a [DiGi\.Analytical\.Building\.Classes\.BuildingModel](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.classes.buildingmodel 'DiGi\.Analytical\.Building\.Classes\.BuildingModel') from a polyhedron representation\.

```csharp
public static DiGi.Analytical.Building.Classes.BuildingModel? BuildingModel(this DiGi.Geometry.Spatial.Classes.Polyhedron? polyhedron, double tolerance=1E-06);
```
#### Parameters

<a name='DiGi.GIS.Analytical.Create.BuildingModel(thisDiGi.Geometry.Spatial.Classes.Polyhedron,double).polyhedron'></a>

`polyhedron` [DiGi\.Geometry\.Spatial\.Classes\.Polyhedron](https://learn.microsoft.com/en-us/dotnet/api/digi.geometry.spatial.classes.polyhedron 'DiGi\.Geometry\.Spatial\.Classes\.Polyhedron')

The polyhedron representing the building geometry\.

<a name='DiGi.GIS.Analytical.Create.BuildingModel(thisDiGi.Geometry.Spatial.Classes.Polyhedron,double).tolerance'></a>

`tolerance` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The distance tolerance for geometric calculations\.

#### Returns
[DiGi\.Analytical\.Building\.Classes\.BuildingModel](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.classes.buildingmodel 'DiGi\.Analytical\.Building\.Classes\.BuildingModel')  
A [DiGi\.Analytical\.Building\.Classes\.BuildingModel](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.classes.buildingmodel 'DiGi\.Analytical\.Building\.Classes\.BuildingModel') if successful; otherwise, null\.

<a name='DiGi.GIS.Analytical.Create.BuildingModel(thisDiGi.Geometry.Spatial.Interfaces.IPolygonalFace3D,ushort,double,double)'></a>

## Create\.BuildingModel\(this IPolygonalFace3D, ushort, double, double\) Method

Creates a [DiGi\.Analytical\.Building\.Classes\.BuildingModel](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.classes.buildingmodel 'DiGi\.Analytical\.Building\.Classes\.BuildingModel') by extruding a polygonal face into the specified number of storeys\.

```csharp
public static DiGi.Analytical.Building.Classes.BuildingModel? BuildingModel(this DiGi.Geometry.Spatial.Interfaces.IPolygonalFace3D? polygonalFace3D, ushort storeys, double storeyHeight=3.0, double tolerance=1E-06);
```
#### Parameters

<a name='DiGi.GIS.Analytical.Create.BuildingModel(thisDiGi.Geometry.Spatial.Interfaces.IPolygonalFace3D,ushort,double,double).polygonalFace3D'></a>

`polygonalFace3D` [DiGi\.Geometry\.Spatial\.Interfaces\.IPolygonalFace3D](https://learn.microsoft.com/en-us/dotnet/api/digi.geometry.spatial.interfaces.ipolygonalface3d 'DiGi\.Geometry\.Spatial\.Interfaces\.IPolygonalFace3D')

The base polygonal face to extrude\.

<a name='DiGi.GIS.Analytical.Create.BuildingModel(thisDiGi.Geometry.Spatial.Interfaces.IPolygonalFace3D,ushort,double,double).storeys'></a>

`storeys` [System\.UInt16](https://learn.microsoft.com/en-us/dotnet/api/system.uint16 'System\.UInt16')

The number of storeys to generate\.

<a name='DiGi.GIS.Analytical.Create.BuildingModel(thisDiGi.Geometry.Spatial.Interfaces.IPolygonalFace3D,ushort,double,double).storeyHeight'></a>

`storeyHeight` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The height of each storey in meters\.

<a name='DiGi.GIS.Analytical.Create.BuildingModel(thisDiGi.Geometry.Spatial.Interfaces.IPolygonalFace3D,ushort,double,double).tolerance'></a>

`tolerance` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The distance tolerance for geometric calculations\. A footprint whose area is below it cannot carry a floor, and the method then returns null rather than a model of walls with no floor or roof\.

#### Returns
[DiGi\.Analytical\.Building\.Classes\.BuildingModel](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.classes.buildingmodel 'DiGi\.Analytical\.Building\.Classes\.BuildingModel')  
A [DiGi\.Analytical\.Building\.Classes\.BuildingModel](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.classes.buildingmodel 'DiGi\.Analytical\.Building\.Classes\.BuildingModel') if successful; otherwise, null\.

<a name='DiGi.GIS.Analytical.Create.BuildingModel(thisDiGi.GIS.Classes.Building2D,double,double,double)'></a>

## Create\.BuildingModel\(this Building2D, double, double, double\) Method

Creates a [DiGi\.Analytical\.Building\.Classes\.BuildingModel](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.classes.buildingmodel 'DiGi\.Analytical\.Building\.Classes\.BuildingModel') from a 2D building representation by extruding it storey by storey from the given base elevation\.

The building reference ([DiGi\.GIS\.Classes\.GISGuidObject2D\.Reference](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.classes.gisguidobject2d.reference 'DiGi\.GIS\.Classes\.GISGuidObject2D\.Reference')) is carried over to [Reference](DiGi.GIS.Analytical.Enums.md#DiGi.GIS.Analytical.Enums.BuildingModelParameter.Reference 'DiGi\.GIS\.Analytical\.Enums\.BuildingModelParameter\.Reference').

```csharp
public static DiGi.Analytical.Building.Classes.BuildingModel? BuildingModel(this DiGi.GIS.Classes.Building2D? building2D, double elevation=0.0, double storeyHeight=3.0, double tolerance=1E-06);
```
#### Parameters

<a name='DiGi.GIS.Analytical.Create.BuildingModel(thisDiGi.GIS.Classes.Building2D,double,double,double).building2D'></a>

`building2D` [DiGi\.GIS\.Classes\.Building2D](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.classes.building2d 'DiGi\.GIS\.Classes\.Building2D')

The 2D building representation\.

<a name='DiGi.GIS.Analytical.Create.BuildingModel(thisDiGi.GIS.Classes.Building2D,double,double,double).elevation'></a>

`elevation` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The base elevation in meters above sea level the footprint is extruded from\. A not\-a\-number elevation means that no elevation is known and the method returns null rather than placing the building at a guessed height \- the signal [BuildingModelAsync\(this HttpClient, Building, Building2D, double, IEnumerable&lt;double&gt;\)](DiGi.GIS.Analytical.md#DiGi.GIS.Analytical.Create.BuildingModelAsync(thisSystem.Net.Http.HttpClient,DiGi.CityGML.Classes.Building,DiGi.GIS.Classes.Building2D,double,System.Collections.Generic.IEnumerable_double_) 'DiGi\.GIS\.Analytical\.Create\.BuildingModelAsync\(this System\.Net\.Http\.HttpClient, DiGi\.CityGML\.Classes\.Building, DiGi\.GIS\.Classes\.Building2D, double, System\.Collections\.Generic\.IEnumerable\<double\>\)') relies on to decide whether the terrain service has to be queried\.

<a name='DiGi.GIS.Analytical.Create.BuildingModel(thisDiGi.GIS.Classes.Building2D,double,double,double).storeyHeight'></a>

`storeyHeight` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The height of a single storey in meters used for the extrusion\.

<a name='DiGi.GIS.Analytical.Create.BuildingModel(thisDiGi.GIS.Classes.Building2D,double,double,double).tolerance'></a>

`tolerance` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The distance tolerance for geometric calculations\.

#### Returns
[DiGi\.Analytical\.Building\.Classes\.BuildingModel](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.classes.buildingmodel 'DiGi\.Analytical\.Building\.Classes\.BuildingModel')  
A [DiGi\.Analytical\.Building\.Classes\.BuildingModel](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.classes.buildingmodel 'DiGi\.Analytical\.Building\.Classes\.BuildingModel') instance if successful; otherwise, null\.

<a name='DiGi.GIS.Analytical.Create.BuildingModel(thisDiGi.GIS.Classes.Building2D,System.Collections.Generic.IEnumerable_DiGi.CityGML.Classes.CityModel_,double)'></a>

## Create\.BuildingModel\(this Building2D, IEnumerable\<CityModel\>, double\) Method

Creates a [DiGi\.Analytical\.Building\.Classes\.BuildingModel](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.classes.buildingmodel 'DiGi\.Analytical\.Building\.Classes\.BuildingModel') based on a 2D building and a collection of city models\.

The model is built from the 3D building found in [cityModels](DiGi.GIS.Analytical.md#DiGi.GIS.Analytical.Create.BuildingModel(thisDiGi.GIS.Classes.Building2D,System.Collections.Generic.IEnumerable_DiGi.CityGML.Classes.CityModel_,double).cityModels 'DiGi\.GIS\.Analytical\.Create\.BuildingModel\(this DiGi\.GIS\.Classes\.Building2D, System\.Collections\.Generic\.IEnumerable\<DiGi\.CityGML\.Classes\.CityModel\>, double\)\.cityModels'), so the tolerance defaults to [Coordinate](DiGi.GIS.Analytical.Constants.md#DiGi.GIS.Analytical.Constants.Tolerance.Coordinate 'DiGi\.GIS\.Analytical\.Constants\.Tolerance\.Coordinate'), the coordinate precision of the national 3D building model. Pass an explicit tolerance when the city models come from a more precise source.

```csharp
public static DiGi.Analytical.Building.Classes.BuildingModel? BuildingModel(this DiGi.GIS.Classes.Building2D? building2D, System.Collections.Generic.IEnumerable<DiGi.CityGML.Classes.CityModel>? cityModels, double tolerance=0.01);
```
#### Parameters

<a name='DiGi.GIS.Analytical.Create.BuildingModel(thisDiGi.GIS.Classes.Building2D,System.Collections.Generic.IEnumerable_DiGi.CityGML.Classes.CityModel_,double).building2D'></a>

`building2D` [DiGi\.GIS\.Classes\.Building2D](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.classes.building2d 'DiGi\.GIS\.Classes\.Building2D')

The 2D building representation\.

<a name='DiGi.GIS.Analytical.Create.BuildingModel(thisDiGi.GIS.Classes.Building2D,System.Collections.Generic.IEnumerable_DiGi.CityGML.Classes.CityModel_,double).cityModels'></a>

`cityModels` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[DiGi\.CityGML\.Classes\.CityModel](https://learn.microsoft.com/en-us/dotnet/api/digi.citygml.classes.citymodel 'DiGi\.CityGML\.Classes\.CityModel')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

A collection of city models used to find the corresponding 3D building\.

<a name='DiGi.GIS.Analytical.Create.BuildingModel(thisDiGi.GIS.Classes.Building2D,System.Collections.Generic.IEnumerable_DiGi.CityGML.Classes.CityModel_,double).tolerance'></a>

`tolerance` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The distance tolerance for geometric calculations\.

#### Returns
[DiGi\.Analytical\.Building\.Classes\.BuildingModel](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.classes.buildingmodel 'DiGi\.Analytical\.Building\.Classes\.BuildingModel')  
A [DiGi\.Analytical\.Building\.Classes\.BuildingModel](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.classes.buildingmodel 'DiGi\.Analytical\.Building\.Classes\.BuildingModel') if successful; otherwise, null\.

<a name='DiGi.GIS.Analytical.Create.BuildingModelAsync(thisSystem.Net.Http.HttpClient,DiGi.CityGML.Classes.Building,DiGi.GIS.Classes.Building2D,double,System.Collections.Generic.IEnumerable_double_)'></a>

## Create\.BuildingModelAsync\(this HttpClient, Building, Building2D, double, IEnumerable\<double\>\) Method

Asynchronously creates a [DiGi\.Analytical\.Building\.Classes\.BuildingModel](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.classes.buildingmodel 'DiGi\.Analytical\.Building\.Classes\.BuildingModel') from a 3D building, refines it with the data carried by the matching 2D building and queries the terrain elevation only when the footprint has to be extruded\.

The model is attempted from the 3D geometry first, with the elevation withheld as a not-a-number, so the extruded fallback of [BuildingModel\(this Building, Building2D, double, double, IEnumerable&lt;double&gt;\)](DiGi.GIS.Analytical.md#DiGi.GIS.Analytical.Create.BuildingModel(thisDiGi.CityGML.Classes.Building,DiGi.GIS.Classes.Building2D,double,double,System.Collections.Generic.IEnumerable_double_) 'DiGi\.GIS\.Analytical\.Create\.BuildingModel\(this DiGi\.CityGML\.Classes\.Building, DiGi\.GIS\.Classes\.Building2D, double, double, System\.Collections\.Generic\.IEnumerable\<double\>\)') refuses to run. A model returned by that attempt was therefore built from the 3D geometry, which carries its own elevations, and no terrain query is made. Only when it returns null is the elevation fetched and the creation repeated.

The elevation enriches the model, it is not a precondition - when the terrain service cannot be reached the footprint is still extruded, from an elevation of zero.

```csharp
public static System.Threading.Tasks.Task<DiGi.Analytical.Building.Classes.BuildingModel?> BuildingModelAsync(this System.Net.Http.HttpClient? httpClient, DiGi.CityGML.Classes.Building? building, DiGi.GIS.Classes.Building2D? building2D, double tolerance=0.01, System.Collections.Generic.IEnumerable<double>? candidateTolerances=null);
```
#### Parameters

<a name='DiGi.GIS.Analytical.Create.BuildingModelAsync(thisSystem.Net.Http.HttpClient,DiGi.CityGML.Classes.Building,DiGi.GIS.Classes.Building2D,double,System.Collections.Generic.IEnumerable_double_).httpClient'></a>

`httpClient` [System\.Net\.Http\.HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient 'System\.Net\.Http\.HttpClient')

The HTTP client used to query terrain elevation\.

<a name='DiGi.GIS.Analytical.Create.BuildingModelAsync(thisSystem.Net.Http.HttpClient,DiGi.CityGML.Classes.Building,DiGi.GIS.Classes.Building2D,double,System.Collections.Generic.IEnumerable_double_).building'></a>

`building` [DiGi\.CityGML\.Classes\.Building](https://learn.microsoft.com/en-us/dotnet/api/digi.citygml.classes.building 'DiGi\.CityGML\.Classes\.Building')

The 3D building object\.

<a name='DiGi.GIS.Analytical.Create.BuildingModelAsync(thisSystem.Net.Http.HttpClient,DiGi.CityGML.Classes.Building,DiGi.GIS.Classes.Building2D,double,System.Collections.Generic.IEnumerable_double_).building2D'></a>

`building2D` [DiGi\.GIS\.Classes\.Building2D](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.classes.building2d 'DiGi\.GIS\.Classes\.Building2D')

The 2D building representation\.

<a name='DiGi.GIS.Analytical.Create.BuildingModelAsync(thisSystem.Net.Http.HttpClient,DiGi.CityGML.Classes.Building,DiGi.GIS.Classes.Building2D,double,System.Collections.Generic.IEnumerable_double_).tolerance'></a>

`tolerance` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The distance tolerance for geometric calculations\.

<a name='DiGi.GIS.Analytical.Create.BuildingModelAsync(thisSystem.Net.Http.HttpClient,DiGi.CityGML.Classes.Building,DiGi.GIS.Classes.Building2D,double,System.Collections.Generic.IEnumerable_double_).candidateTolerances'></a>

`candidateTolerances` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

Optional candidate tolerances to attempt if the polyhedron is not closed\.

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[DiGi\.Analytical\.Building\.Classes\.BuildingModel](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.classes.buildingmodel 'DiGi\.Analytical\.Building\.Classes\.BuildingModel')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
A [DiGi\.Analytical\.Building\.Classes\.BuildingModel](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.classes.buildingmodel 'DiGi\.Analytical\.Building\.Classes\.BuildingModel') if successful; otherwise, null\.

<a name='DiGi.GIS.Analytical.Create.BuildingModelAsync(thisSystem.Net.Http.HttpClient,DiGi.GIS.Classes.Building2D,double,double)'></a>

## Create\.BuildingModelAsync\(this HttpClient, Building2D, double, double\) Method

Asynchronously creates a [DiGi\.Analytical\.Building\.Classes\.BuildingModel](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.classes.buildingmodel 'DiGi\.Analytical\.Building\.Classes\.BuildingModel') from a 2D building representation by extruding it storey by storey from the terrain elevation of its footprint\.

The elevation is queried once, for the internal point of the footprint, through [DiGi\.GIS\.Query\.ElevationAsync\(System\.Net\.Http\.HttpClient,DiGi\.Geometry\.Planar\.Classes\.Point2D\)](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.query.elevationasync#digi-gis-query-elevationasync(system-net-http-httpclient-digi-geometry-planar-classes-point2d) 'DiGi\.GIS\.Query\.ElevationAsync\(System\.Net\.Http\.HttpClient,DiGi\.Geometry\.Planar\.Classes\.Point2D\)').

The elevation enriches the model, it is not a precondition - when the terrain service cannot be reached the model is still extruded, from an elevation of zero. Only a null client or a footprint that cannot be extruded yields null.

```csharp
public static System.Threading.Tasks.Task<DiGi.Analytical.Building.Classes.BuildingModel?> BuildingModelAsync(this System.Net.Http.HttpClient? httpClient, DiGi.GIS.Classes.Building2D? building2D, double storeyHeight=3.0, double tolerance=1E-06);
```
#### Parameters

<a name='DiGi.GIS.Analytical.Create.BuildingModelAsync(thisSystem.Net.Http.HttpClient,DiGi.GIS.Classes.Building2D,double,double).httpClient'></a>

`httpClient` [System\.Net\.Http\.HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient 'System\.Net\.Http\.HttpClient')

The HTTP client used to query terrain elevation\.

<a name='DiGi.GIS.Analytical.Create.BuildingModelAsync(thisSystem.Net.Http.HttpClient,DiGi.GIS.Classes.Building2D,double,double).building2D'></a>

`building2D` [DiGi\.GIS\.Classes\.Building2D](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.classes.building2d 'DiGi\.GIS\.Classes\.Building2D')

The 2D building representation\.

<a name='DiGi.GIS.Analytical.Create.BuildingModelAsync(thisSystem.Net.Http.HttpClient,DiGi.GIS.Classes.Building2D,double,double).storeyHeight'></a>

`storeyHeight` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The height of a single storey in meters used for the extrusion\.

<a name='DiGi.GIS.Analytical.Create.BuildingModelAsync(thisSystem.Net.Http.HttpClient,DiGi.GIS.Classes.Building2D,double,double).tolerance'></a>

`tolerance` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The distance tolerance for geometric calculations\.

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[DiGi\.Analytical\.Building\.Classes\.BuildingModel](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.classes.buildingmodel 'DiGi\.Analytical\.Building\.Classes\.BuildingModel')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
A [DiGi\.Analytical\.Building\.Classes\.BuildingModel](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.classes.buildingmodel 'DiGi\.Analytical\.Building\.Classes\.BuildingModel') instance if successful; otherwise, null\.

<a name='DiGi.GIS.Analytical.Create.BuildingModels(thisDiGi.GIS.Classes.GISModelFile,string,double)'></a>

## Create\.BuildingModels\(this GISModelFile, string, double\) Method

Creates a list of building models by correlating 2D building data from a GIS model file with corresponding 3D CityGML data found in the specified directory\.

```csharp
public static System.Collections.Generic.List<DiGi.Analytical.Building.Classes.BuildingModel>? BuildingModels(this DiGi.GIS.Classes.GISModelFile? gISModelFile, string directory_CityGML, double tolerance=1E-06);
```
#### Parameters

<a name='DiGi.GIS.Analytical.Create.BuildingModels(thisDiGi.GIS.Classes.GISModelFile,string,double).gISModelFile'></a>

`gISModelFile` [DiGi\.GIS\.Classes\.GISModelFile](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.classes.gismodelfile 'DiGi\.GIS\.Classes\.GISModelFile')

The source GIS model file containing the building data\.

<a name='DiGi.GIS.Analytical.Create.BuildingModels(thisDiGi.GIS.Classes.GISModelFile,string,double).directory_CityGML'></a>

`directory_CityGML` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The directory path where the CityGML zip files are stored\.

<a name='DiGi.GIS.Analytical.Create.BuildingModels(thisDiGi.GIS.Classes.GISModelFile,string,double).tolerance'></a>

`tolerance` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The distance tolerance used for geometric projections and matching operations\.

#### Returns
[System\.Collections\.Generic\.List&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[DiGi\.Analytical\.Building\.Classes\.BuildingModel](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.classes.buildingmodel 'DiGi\.Analytical\.Building\.Classes\.BuildingModel')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')  
A list of [DiGi\.Analytical\.Building\.Classes\.BuildingModel](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.classes.buildingmodel 'DiGi\.Analytical\.Building\.Classes\.BuildingModel') objects if successful; otherwise, null if the input file is invalid or no buildings are found\.

<a name='DiGi.GIS.Analytical.Create.BuildingModels(thisSystem.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2D_,System.Collections.Generic.IEnumerable_DiGi.CityGML.Classes.Building_,double)'></a>

## Create\.BuildingModels\(this IEnumerable\<Building2D\>, IEnumerable\<Building\>, double\) Method

Creates a list of building models from a collection of 2D buildings and CityGML buildings, matching them by reference, with fallback logic for buildings that cannot be directly matched\.

Unlike the city model overload the match is a straight reference join of the 2D building reference against the CityGML building reference, so the caller is expected to have resolved any level of detail or year ranking beforehand.

```csharp
public static System.Collections.Generic.List<DiGi.Analytical.Building.Classes.BuildingModel>? BuildingModels(this System.Collections.Generic.IEnumerable<DiGi.GIS.Classes.Building2D>? building2Ds, System.Collections.Generic.IEnumerable<DiGi.CityGML.Classes.Building>? buildings, double tolerance=1E-06);
```
#### Parameters

<a name='DiGi.GIS.Analytical.Create.BuildingModels(thisSystem.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2D_,System.Collections.Generic.IEnumerable_DiGi.CityGML.Classes.Building_,double).building2Ds'></a>

`building2Ds` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[DiGi\.GIS\.Classes\.Building2D](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.classes.building2d 'DiGi\.GIS\.Classes\.Building2D')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The 2D building data to convert\.

<a name='DiGi.GIS.Analytical.Create.BuildingModels(thisSystem.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2D_,System.Collections.Generic.IEnumerable_DiGi.CityGML.Classes.Building_,double).buildings'></a>

`buildings` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[DiGi\.CityGML\.Classes\.Building](https://learn.microsoft.com/en-us/dotnet/api/digi.citygml.classes.building 'DiGi\.CityGML\.Classes\.Building')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The CityGML buildings used to find corresponding 3D geometry\.

<a name='DiGi.GIS.Analytical.Create.BuildingModels(thisSystem.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2D_,System.Collections.Generic.IEnumerable_DiGi.CityGML.Classes.Building_,double).tolerance'></a>

`tolerance` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The distance tolerance for geometric calculations\.

#### Returns
[System\.Collections\.Generic\.List&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[DiGi\.Analytical\.Building\.Classes\.BuildingModel](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.classes.buildingmodel 'DiGi\.Analytical\.Building\.Classes\.BuildingModel')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')  
A list of [DiGi\.Analytical\.Building\.Classes\.BuildingModel](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.classes.buildingmodel 'DiGi\.Analytical\.Building\.Classes\.BuildingModel') objects if successful; otherwise, null\.

<a name='DiGi.GIS.Analytical.Create.BuildingModels(thisSystem.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2D_,System.Collections.Generic.IEnumerable_DiGi.CityGML.Classes.CityModel_,double)'></a>

## Create\.BuildingModels\(this IEnumerable\<Building2D\>, IEnumerable\<CityModel\>, double\) Method

Creates a list of building models from a collection of 2D buildings and city models, with fallback logic for buildings that cannot be directly matched\.

```csharp
public static System.Collections.Generic.List<DiGi.Analytical.Building.Classes.BuildingModel>? BuildingModels(this System.Collections.Generic.IEnumerable<DiGi.GIS.Classes.Building2D>? building2Ds, System.Collections.Generic.IEnumerable<DiGi.CityGML.Classes.CityModel> cityModels, double tolerance=1E-06);
```
#### Parameters

<a name='DiGi.GIS.Analytical.Create.BuildingModels(thisSystem.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2D_,System.Collections.Generic.IEnumerable_DiGi.CityGML.Classes.CityModel_,double).building2Ds'></a>

`building2Ds` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[DiGi\.GIS\.Classes\.Building2D](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.classes.building2d 'DiGi\.GIS\.Classes\.Building2D')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The 2D building data to convert\.

<a name='DiGi.GIS.Analytical.Create.BuildingModels(thisSystem.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2D_,System.Collections.Generic.IEnumerable_DiGi.CityGML.Classes.CityModel_,double).cityModels'></a>

`cityModels` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[DiGi\.CityGML\.Classes\.CityModel](https://learn.microsoft.com/en-us/dotnet/api/digi.citygml.classes.citymodel 'DiGi\.CityGML\.Classes\.CityModel')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The city models used to find corresponding 3D buildings\.

<a name='DiGi.GIS.Analytical.Create.BuildingModels(thisSystem.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2D_,System.Collections.Generic.IEnumerable_DiGi.CityGML.Classes.CityModel_,double).tolerance'></a>

`tolerance` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The distance tolerance for geometric calculations\.

#### Returns
[System\.Collections\.Generic\.List&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[DiGi\.Analytical\.Building\.Classes\.BuildingModel](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.classes.buildingmodel 'DiGi\.Analytical\.Building\.Classes\.BuildingModel')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')  
A list of [DiGi\.Analytical\.Building\.Classes\.BuildingModel](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.classes.buildingmodel 'DiGi\.Analytical\.Building\.Classes\.BuildingModel') objects if successful; otherwise, null\.

<a name='DiGi.GIS.Analytical.Create.BuildingModels_Unidentified(thisSystem.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2D_,System.Collections.Generic.IEnumerable_DiGi.CityGML.Classes.Building_,double)'></a>

## Create\.BuildingModels\_Unidentified\(this IEnumerable\<Building2D\>, IEnumerable\<Building\>, double\) Method

Creates building models for 2D buildings that could not be matched to a CityGML building directly\.

Each 2D building is first matched spatially - its internal point is tested against the CityGML buildings projected onto the world XY plane - and the remainder are extruded from their footprint at an assumed storey height, with the base elevation interpolated from the nearest CityGML geometry.

```csharp
public static System.Collections.Generic.List<DiGi.Analytical.Building.Classes.BuildingModel>? BuildingModels_Unidentified(this System.Collections.Generic.IEnumerable<DiGi.GIS.Classes.Building2D>? building2Ds, System.Collections.Generic.IEnumerable<DiGi.CityGML.Classes.Building>? buildings, double tolerance=1E-06);
```
#### Parameters

<a name='DiGi.GIS.Analytical.Create.BuildingModels_Unidentified(thisSystem.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2D_,System.Collections.Generic.IEnumerable_DiGi.CityGML.Classes.Building_,double).building2Ds'></a>

`building2Ds` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[DiGi\.GIS\.Classes\.Building2D](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.classes.building2d 'DiGi\.GIS\.Classes\.Building2D')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The unmatched 2D building data to convert\.

<a name='DiGi.GIS.Analytical.Create.BuildingModels_Unidentified(thisSystem.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2D_,System.Collections.Generic.IEnumerable_DiGi.CityGML.Classes.Building_,double).buildings'></a>

`buildings` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[DiGi\.CityGML\.Classes\.Building](https://learn.microsoft.com/en-us/dotnet/api/digi.citygml.classes.building 'DiGi\.CityGML\.Classes\.Building')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The CityGML buildings used for the spatial match and for the base elevation of the extruded models\.

<a name='DiGi.GIS.Analytical.Create.BuildingModels_Unidentified(thisSystem.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2D_,System.Collections.Generic.IEnumerable_DiGi.CityGML.Classes.Building_,double).tolerance'></a>

`tolerance` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The distance tolerance for geometric calculations\.

#### Returns
[System\.Collections\.Generic\.List&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[DiGi\.Analytical\.Building\.Classes\.BuildingModel](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.classes.buildingmodel 'DiGi\.Analytical\.Building\.Classes\.BuildingModel')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')  
A list of [DiGi\.Analytical\.Building\.Classes\.BuildingModel](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.classes.buildingmodel 'DiGi\.Analytical\.Building\.Classes\.BuildingModel') objects for the 2D buildings that could be resolved; otherwise, null\.

<a name='DiGi.GIS.Analytical.Create.BuildingModelValidationResult(thisDiGi.Analytical.Building.Classes.BuildingModel,double)'></a>

## Create\.BuildingModelValidationResult\(this BuildingModel, double\) Method

Validates a building model and collects everything that is wrong with it into a single result\.

Every check is run and every failure recorded - the method does not stop at the first one, because a model is usually broken in more than one way and knowing which combination it carries is what points at the stage that broke it.

Enclosure is the check this exists for. It is evaluated per space through [DiGi\.Analytical\.Building\.Classes\.BuildingModel\.GetShell\(DiGi\.Analytical\.Building\.Interfaces\.ISpace,System\.Nullable\{DiGi\.Geometry\.Core\.Enums\.Side\},System\.Nullable\{DiGi\.Geometry\.Core\.Enums\.Orientation\},System\.Nullable\{DiGi\.Geometry\.Core\.Enums\.Orientation\},System\.Double\)](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.classes.buildingmodel.getshell#digi-analytical-building-classes-buildingmodel-getshell(digi-analytical-building-interfaces-ispace-system-nullable{digi-geometry-core-enums-side}-system-nullable{digi-geometry-core-enums-orientation}-system-nullable{digi-geometry-core-enums-orientation}-system-double) 'DiGi\.Analytical\.Building\.Classes\.BuildingModel\.GetShell\(DiGi\.Analytical\.Building\.Interfaces\.ISpace,System\.Nullable\{DiGi\.Geometry\.Core\.Enums\.Side\},System\.Nullable\{DiGi\.Geometry\.Core\.Enums\.Orientation\},System\.Nullable\{DiGi\.Geometry\.Core\.Enums\.Orientation\},System\.Double\)'), so a curve wall is resolved into the surface it sweeps and an extruded model is judged by the same rule as one converted from CityGML. Alongside the verdict the smallest tolerance at which the whole model closes is reported, which separates a model whose source geometry is merely imprecise from one that never had a boundary.

```csharp
public static DiGi.GIS.Classes.BuildingModelValidationResult? BuildingModelValidationResult(this DiGi.Analytical.Building.Classes.BuildingModel? buildingModel, double tolerance=0.05);
```
#### Parameters

<a name='DiGi.GIS.Analytical.Create.BuildingModelValidationResult(thisDiGi.Analytical.Building.Classes.BuildingModel,double).buildingModel'></a>

`buildingModel` [DiGi\.Analytical\.Building\.Classes\.BuildingModel](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.classes.buildingmodel 'DiGi\.Analytical\.Building\.Classes\.BuildingModel')

The building model to validate\.

<a name='DiGi.GIS.Analytical.Create.BuildingModelValidationResult(thisDiGi.Analytical.Building.Classes.BuildingModel,double).tolerance'></a>

`tolerance` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The distance tolerance the enclosure is required to hold at\.

#### Returns
[BuildingModelValidationResult](DiGi.GIS.Classes.md#DiGi.GIS.Classes.BuildingModelValidationResult 'DiGi\.GIS\.Classes\.BuildingModelValidationResult')  
A [BuildingModelValidationResult\(this BuildingModel, double\)](DiGi.GIS.Analytical.md#DiGi.GIS.Analytical.Create.BuildingModelValidationResult(thisDiGi.Analytical.Building.Classes.BuildingModel,double) 'DiGi\.GIS\.Analytical\.Create\.BuildingModelValidationResult\(this DiGi\.Analytical\.Building\.Classes\.BuildingModel, double\)'), or null when [buildingModel](DiGi.GIS.Analytical.md#DiGi.GIS.Analytical.Create.BuildingModelValidationResult(thisDiGi.Analytical.Building.Classes.BuildingModel,double).buildingModel 'DiGi\.GIS\.Analytical\.Create\.BuildingModelValidationResult\(this DiGi\.Analytical\.Building\.Classes\.BuildingModel, double\)\.buildingModel') is null\.

<a name='DiGi.GIS.Analytical.Create.Component(thisDiGi.Geometry.Spatial.Interfaces.IPolygonalFace3D,DiGi.Geometry.Spatial.Classes.Polyhedron,double)'></a>

## Create\.Component\(this IPolygonalFace3D, Polyhedron, double\) Method

Creates a building component from a polygonal face 3D, determining whether it is a wall, floor, or roof based on its orientation and spatial relationship to an optional polyhedron\.

```csharp
public static DiGi.Analytical.Building.Interfaces.IComponent? Component(this DiGi.Geometry.Spatial.Interfaces.IPolygonalFace3D? polygonalFace3D, DiGi.Geometry.Spatial.Classes.Polyhedron? polyhedron, double tolerance=1E-06);
```
#### Parameters

<a name='DiGi.GIS.Analytical.Create.Component(thisDiGi.Geometry.Spatial.Interfaces.IPolygonalFace3D,DiGi.Geometry.Spatial.Classes.Polyhedron,double).polygonalFace3D'></a>

`polygonalFace3D` [DiGi\.Geometry\.Spatial\.Interfaces\.IPolygonalFace3D](https://learn.microsoft.com/en-us/dotnet/api/digi.geometry.spatial.interfaces.ipolygonalface3d 'DiGi\.Geometry\.Spatial\.Interfaces\.IPolygonalFace3D')

The polygonal face 3D to convert into a component\.

<a name='DiGi.GIS.Analytical.Create.Component(thisDiGi.Geometry.Spatial.Interfaces.IPolygonalFace3D,DiGi.Geometry.Spatial.Classes.Polyhedron,double).polyhedron'></a>

`polyhedron` [DiGi\.Geometry\.Spatial\.Classes\.Polyhedron](https://learn.microsoft.com/en-us/dotnet/api/digi.geometry.spatial.classes.polyhedron 'DiGi\.Geometry\.Spatial\.Classes\.Polyhedron')

An optional polyhedron used to determine if the face is a floor or roof based on vertical intersection analysis\.

<a name='DiGi.GIS.Analytical.Create.Component(thisDiGi.Geometry.Spatial.Interfaces.IPolygonalFace3D,DiGi.Geometry.Spatial.Classes.Polyhedron,double).tolerance'></a>

`tolerance` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The distance tolerance for geometric calculations\.

#### Returns
[DiGi\.Analytical\.Building\.Interfaces\.IComponent](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.interfaces.icomponent 'DiGi\.Analytical\.Building\.Interfaces\.IComponent')  
A building component \([DiGi\.Analytical\.Building\.Interfaces\.IComponent](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.interfaces.icomponent 'DiGi\.Analytical\.Building\.Interfaces\.IComponent')\) such as a wall, floor, or roof; otherwise, `null` if the face's normal cannot be determined\.

<a name='DiGi.GIS.Analytical.Create.OpeningGenerationOptions(DiGi.Analytical.Building.Regulation.Enums.BuildingRegulation)'></a>

## Create\.OpeningGenerationOptions\(BuildingRegulation\) Method

Creates the rules `Modify.GenerateOpenings` applies to a building designed under the specified regime \(DiGi\-Organization/DiGi\.GIS\.Analytical\#2\)\.

Every value read in the Dz.U. text (ISAP, 2026-11-01) cites its paragraph in the documentation of its option:
- <b>Daylight ratio:</b> 1:10 before 1961 (the 1928 regulation, also taken for buildings before 1928); 1:8 from the 1994 conditions on (§ 57); a decided 1:8 for the 1961 and 1980 regimes, whose texts give no ratio.
- <b>Maximum glazed area A0max:</b> single-family buildings only, for windows of U ≥ 2.0, under the original conditions of 2002; residential buildings, U ≥ 1.5, from 2009; U ≥ 0.9 from 2014. None from the 2017 stage on: the annex was replaced from 1 January 2018 without it, a year into that stage.
- <b>Sills, interstorey strip, entrance door:</b> the same values for every regime (§ 301, § 223, § 62), read for 2002 and, for the sill, 1994 and 1980; assumed before that.
- <b>Street façade weight</b> (a decided default): 1.5 for multi-family buildings and apartment blocks before 1961, the frontage blocks; 1.3 for single-family and terraced buildings from the 1994 regime on; 1.0 otherwise, including the 1961-1993 panel blocks.

```csharp
public static DiGi.GIS.Classes.OpeningGenerationOptions OpeningGenerationOptions(DiGi.Analytical.Building.Regulation.Enums.BuildingRegulation buildingRegulation);
```
#### Parameters

<a name='DiGi.GIS.Analytical.Create.OpeningGenerationOptions(DiGi.Analytical.Building.Regulation.Enums.BuildingRegulation).buildingRegulation'></a>

`buildingRegulation` [DiGi\.Analytical\.Building\.Regulation\.Enums\.BuildingRegulation](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.regulation.enums.buildingregulation 'DiGi\.Analytical\.Building\.Regulation\.Enums\.BuildingRegulation')

The regime the building was designed under; [DiGi\.Analytical\.Building\.Regulation\.Enums\.BuildingRegulation\.Undefined](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.regulation.enums.buildingregulation.undefined 'DiGi\.Analytical\.Building\.Regulation\.Enums\.BuildingRegulation\.Undefined') takes the values of the current regime\.

#### Returns
[OpeningGenerationOptions](DiGi.GIS.Classes.md#DiGi.GIS.Classes.OpeningGenerationOptions 'DiGi\.GIS\.Classes\.OpeningGenerationOptions')  
The options of the regime\.

<a name='DiGi.GIS.Analytical.Modify'></a>

## Modify Class

```csharp
public static class Modify
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → Modify
### Fields

<a name='DiGi.GIS.Analytical.Modify.GenerateOpenings_GeneratedBy'></a>

## Modify\.GenerateOpenings\_GeneratedBy Field

The text [GeneratedBy](DiGi.GIS.Analytical.Enums.md#DiGi.GIS.Analytical.Enums.OpeningParameter.GeneratedBy 'DiGi\.GIS\.Analytical\.Enums\.OpeningParameter\.GeneratedBy') carries on every opening [GenerateOpenings\(this BuildingModel, Building2D, OpeningGenerationInput, IEnumerable&lt;BuildingModel&gt;, ConstructionLibrary, OpeningSizeLibrary, double\)](DiGi.GIS.Analytical.md#DiGi.GIS.Analytical.Modify.GenerateOpenings(thisDiGi.Analytical.Building.Classes.BuildingModel,DiGi.GIS.Classes.Building2D,DiGi.GIS.Classes.OpeningGenerationInput,System.Collections.Generic.IEnumerable_DiGi.Analytical.Building.Classes.BuildingModel_,DiGi.Analytical.Building.Regulation.Classes.ConstructionLibrary,DiGi.Analytical.Building.Regulation.Classes.OpeningSizeLibrary,double) 'DiGi\.GIS\.Analytical\.Modify\.GenerateOpenings\(this DiGi\.Analytical\.Building\.Classes\.BuildingModel, DiGi\.GIS\.Classes\.Building2D, DiGi\.GIS\.Classes\.OpeningGenerationInput, System\.Collections\.Generic\.IEnumerable\<DiGi\.Analytical\.Building\.Classes\.BuildingModel\>, DiGi\.Analytical\.Building\.Regulation\.Classes\.ConstructionLibrary, DiGi\.Analytical\.Building\.Regulation\.Classes\.OpeningSizeLibrary, double\)') places\.

```csharp
public const string GenerateOpenings_GeneratedBy = "DiGi.GIS.Analytical.Modify.GenerateOpenings";
```

#### Field Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')
### Methods

<a name='DiGi.GIS.Analytical.Modify.AssignInternalConditions(thisDiGi.Analytical.Building.Classes.BuildingModel,DiGi.GIS.Classes.Building2D,DiGi.GIS.Classes.OccupancyData,System.Nullable_short_,string)'></a>

## Modify\.AssignInternalConditions\(this BuildingModel, Building2D, OccupancyData, Nullable\<short\>, string\) Method

Assigns the standard\-use internal condition of a BDOT10k building to every space of its model: the usage type from [UsageType\(this Building2D\)](DiGi.GIS.Analytical.md#DiGi.GIS.Analytical.Query.UsageType(thisDiGi.GIS.Classes.Building2D) 'DiGi\.GIS\.Analytical\.Query\.UsageType\(this DiGi\.GIS\.Classes\.Building2D\)'), its usage profile and the internal condition built from it \(DiGi\-Organization/DiGi\.Analytical\#9\)\.

<b>Fallback.</b> When the functions name no usage type, a residential or occupied building (`GIS.Query.IsResidential`, `GIS.Query.IsOccupied`) is treated as multi-family and any other as an office, and [DiGi\.Analytical\.Building\.HVAC\.Enums\.InternalConditionParameter\.UsageSource](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.hvac.enums.internalconditionparameter.usagesource 'DiGi\.Analytical\.Building\.HVAC\.Enums\.InternalConditionParameter\.UsageSource') starts with `fallback` naming the rule, so every space has a condition and the guess stays visible.

<b>Occupancy.</b> The persons are [DiGi\.GIS\.Classes\.OccupancyData\.Occupancy](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.classes.occupancydata.occupancy 'DiGi\.GIS\.Classes\.OccupancyData\.Occupancy') and the floor area they share is [DiGi\.GIS\.Classes\.OccupancyData\.OccupancyArea](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.classes.occupancydata.occupancyarea 'DiGi\.GIS\.Classes\.OccupancyData\.OccupancyArea'), else the footprint area times the storeys - the area the occupancy estimate is made for. Without persons the per-area values of the methodology apply unscaled.

```csharp
public static bool AssignInternalConditions(this DiGi.Analytical.Building.Classes.BuildingModel? buildingModel, DiGi.GIS.Classes.Building2D? building2D, DiGi.GIS.Classes.OccupancyData? occupancyData=null, System.Nullable<short> yearBuilt=null, string? occupancySource=null);
```
#### Parameters

<a name='DiGi.GIS.Analytical.Modify.AssignInternalConditions(thisDiGi.Analytical.Building.Classes.BuildingModel,DiGi.GIS.Classes.Building2D,DiGi.GIS.Classes.OccupancyData,System.Nullable_short_,string).buildingModel'></a>

`buildingModel` [DiGi\.Analytical\.Building\.Classes\.BuildingModel](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.classes.buildingmodel 'DiGi\.Analytical\.Building\.Classes\.BuildingModel')

The building model of [building2D](DiGi.GIS.Analytical.md#DiGi.GIS.Analytical.Modify.AssignInternalConditions(thisDiGi.Analytical.Building.Classes.BuildingModel,DiGi.GIS.Classes.Building2D,DiGi.GIS.Classes.OccupancyData,System.Nullable_short_,string).building2D 'DiGi\.GIS\.Analytical\.Modify\.AssignInternalConditions\(this DiGi\.Analytical\.Building\.Classes\.BuildingModel, DiGi\.GIS\.Classes\.Building2D, DiGi\.GIS\.Classes\.OccupancyData, System\.Nullable\<short\>, string\)\.building2D')\.

<a name='DiGi.GIS.Analytical.Modify.AssignInternalConditions(thisDiGi.Analytical.Building.Classes.BuildingModel,DiGi.GIS.Classes.Building2D,DiGi.GIS.Classes.OccupancyData,System.Nullable_short_,string).building2D'></a>

`building2D` [DiGi\.GIS\.Classes\.Building2D](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.classes.building2d 'DiGi\.GIS\.Classes\.Building2D')

The BDOT10k building\.

<a name='DiGi.GIS.Analytical.Modify.AssignInternalConditions(thisDiGi.Analytical.Building.Classes.BuildingModel,DiGi.GIS.Classes.Building2D,DiGi.GIS.Classes.OccupancyData,System.Nullable_short_,string).occupancyData'></a>

`occupancyData` [DiGi\.GIS\.Classes\.OccupancyData](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.classes.occupancydata 'DiGi\.GIS\.Classes\.OccupancyData')

The occupancy estimate of the building \(`occupancy_data_building_2d`\)\. This value can be null\.

<a name='DiGi.GIS.Analytical.Modify.AssignInternalConditions(thisDiGi.Analytical.Building.Classes.BuildingModel,DiGi.GIS.Classes.Building2D,DiGi.GIS.Classes.OccupancyData,System.Nullable_short_,string).yearBuilt'></a>

`yearBuilt` [System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Int16](https://learn.microsoft.com/en-us/dotnet/api/system.int16 'System\.Int16')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

The year the building was erected, which selects the infiltration; null when unknown\.

<a name='DiGi.GIS.Analytical.Modify.AssignInternalConditions(thisDiGi.Analytical.Building.Classes.BuildingModel,DiGi.GIS.Classes.Building2D,DiGi.GIS.Classes.OccupancyData,System.Nullable_short_,string).occupancySource'></a>

`occupancySource` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

Where [occupancyData](DiGi.GIS.Analytical.md#DiGi.GIS.Analytical.Modify.AssignInternalConditions(thisDiGi.Analytical.Building.Classes.BuildingModel,DiGi.GIS.Classes.Building2D,DiGi.GIS.Classes.OccupancyData,System.Nullable_short_,string).occupancyData 'DiGi\.GIS\.Analytical\.Modify\.AssignInternalConditions\(this DiGi\.Analytical\.Building\.Classes\.BuildingModel, DiGi\.GIS\.Classes\.Building2D, DiGi\.GIS\.Classes\.OccupancyData, System\.Nullable\<short\>, string\)\.occupancyData') comes from, recorded on the condition\. This value can be null\.

#### Returns
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')  
True when every space of the model was assigned; otherwise, false\.

<a name='DiGi.GIS.Analytical.Modify.GenerateOpenings(thisDiGi.Analytical.Building.Classes.BuildingModel,DiGi.GIS.Classes.Building2D,DiGi.GIS.Classes.OpeningGenerationInput,System.Collections.Generic.IEnumerable_DiGi.Analytical.Building.Classes.BuildingModel_,DiGi.Analytical.Building.Regulation.Classes.ConstructionLibrary,DiGi.Analytical.Building.Regulation.Classes.OpeningSizeLibrary,double)'></a>

## Modify\.GenerateOpenings\(this BuildingModel, Building2D, OpeningGenerationInput, IEnumerable\<BuildingModel\>, ConstructionLibrary, OpeningSizeLibrary, double\) Method

Places windows and doors on the external walls of a building model, following the Polish rules of the building's period \(DiGi\-Organization/DiGi\.GIS\.Analytical\#2, phase A\)\.

<b>Keys.</b> The regime is `Regulation.Query.BuildingRegulation(yearBuilt, DesignLag)`. The building type is [BuildingType\(this Building2D, bool\)](DiGi.GIS.Analytical.md#DiGi.GIS.Analytical.Query.BuildingType(thisDiGi.GIS.Classes.Building2D,bool) 'DiGi\.GIS\.Analytical\.Query\.BuildingType\(this DiGi\.GIS\.Classes\.Building2D, bool\)'), terraced when any wall carries [DiGi\.Analytical\.Building\.Enums\.ComponentParameter\.PartyWall](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.enums.componentparameter.partywall 'DiGi\.Analytical\.Building\.Enums\.ComponentParameter\.PartyWall'); a non-residential building takes the multi-family sets. The sizes come from the opening-size set of the year built, type and panel system, and the thermal values from the construction set of the chosen flavour, a role it lacks falling back to TypicalAsBuilt. With no year built, the latest sets are used.

<b>Storeys.</b> Openings are placed per storey band ([StoreyBands\(this BuildingModel, ushort, double, StoreySource, double\)](DiGi.GIS.Analytical.md#DiGi.GIS.Analytical.Query.StoreyBands(thisDiGi.Analytical.Building.Classes.BuildingModel,ushort,double,DiGi.GIS.Analytical.Enums.StoreySource,double) 'DiGi\.GIS\.Analytical\.Query\.StoreyBands\(this DiGi\.Analytical\.Building\.Classes\.BuildingModel, ushort, double, DiGi\.GIS\.Analytical\.Enums\.StoreySource, double\)')), never assuming that one space is one storey, so an unsplit 3D model and a building with no storey count get windows on every storey. Every band uses the same positions along a wall where its allowed walls are the same, so windows stack.

<b>Windows.</b> The target of a band is the daylight ratio times the habitable floor fraction times the footprint area, as glazed area in the clear of the frames. It is split over the living-room, kitchen and bathroom sizes by the room mix of the building type (a use the set lists as windowless gives its share to the living room) and interleaved by largest remainder. Where the regime has a maximum glazed area A0max and the window U-value reaches its threshold, the windows are cut to it. The windows are distributed over the allowed walls in proportion to their usable length, the front wall weighted by the street façade weight; spaced evenly, keeping the corner margin and the minimum pier, and snapped to the façade module of a large-panel set where it fits. The sill is the size's own, raised on upper storeys to the option sill (or the high sill above 25 m) and to keep the interstorey strip above the openings below; a window whose head would not clear the band top less the head clearance falls back to the tallest narrower size that fits. What does not fit is the band's shortfall, reported, not an error.

<b>Walls.</b> A wall carrying [DiGi\.Analytical\.Building\.Enums\.ComponentParameter\.PartyWall](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.enums.componentparameter.partywall 'DiGi\.Analytical\.Building\.Enums\.ComponentParameter\.PartyWall') (split beforehand by `DiGi.Analytical.Building.Modify.SplitPartyWalls`) or too short for the narrowest window gets nothing, and the result records why.

<b>Doors.</b> The front wall is the external ground-storey wall nearest the address point, else the longest unrestricted one. A single-family or terraced building gets one entrance door centred on it; any other building one staircase entrance door per staircase spacing, each with a staircase window above it on every upper storey, outside the daylight target. A door below the § 62 clear size is reported, not resized.

<b>Constructions.</b> Each distinct size gets one construction (`Regulation.Create.WindowConstruction` or `DoorConstruction`), named after its kind and size, carrying the declared U-value, g and τv of the library construction of its role. Identifiers are derived from stable keys, so the same model and input give the same openings.

<b>Neighbours.</b> When neighbours are given, every external wall is measured against them first, by [WallOpeningResults\(this BuildingModel, IEnumerable&lt;BuildingModel&gt;, OpeningGenerationOptions, Nullable&lt;BuildingGeneralFunction&gt;, double\)](DiGi.GIS.Analytical.md#DiGi.GIS.Analytical.Query.WallOpeningResults(thisDiGi.Analytical.Building.Classes.BuildingModel,System.Collections.Generic.IEnumerable_DiGi.Analytical.Building.Classes.BuildingModel_,DiGi.GIS.Classes.OpeningGenerationOptions,System.Nullable_DiGi.GIS.Enums.BuildingGeneralFunction_,double) 'DiGi\.GIS\.Analytical\.Query\.WallOpeningResults\(this DiGi\.Analytical\.Building\.Classes\.BuildingModel, System\.Collections\.Generic\.IEnumerable\<DiGi\.Analytical\.Building\.Classes\.BuildingModel\>, DiGi\.GIS\.Classes\.OpeningGenerationOptions, System\.Nullable\<DiGi\.GIS\.Enums\.BuildingGeneralFunction\>, double\)'): a wall closer to a facing neighbour than § 271 allows gets no openings at all ([FireSeparation](DiGi.GIS.Analytical.Enums.md#DiGi.GIS.Analytical.Enums.WallOpeningRestriction.FireSeparation 'DiGi\.GIS\.Analytical\.Enums\.WallOpeningRestriction\.FireSeparation')), and a wall with an obstructing object inside the 60 degree sector of § 13 gets no windows of rooms for people, while its entrance door and staircase window stay allowed ([Obstruction](DiGi.GIS.Analytical.Enums.md#DiGi.GIS.Analytical.Enums.WallOpeningRestriction.Obstruction 'DiGi\.GIS\.Analytical\.Enums\.WallOpeningRestriction\.Obstruction')). Both reasons are reported in [WallOpeningRestrictions](DiGi.GIS.Classes.md#DiGi.GIS.Classes.OpeningGenerationResult.WallOpeningRestrictions 'DiGi\.GIS\.Classes\.OpeningGenerationResult\.WallOpeningRestrictions').

Every opening carries [OpeningParameter](DiGi.GIS.Analytical.Enums.md#DiGi.GIS.Analytical.Enums.OpeningParameter 'DiGi\.GIS\.Analytical\.Enums\.OpeningParameter') values. The rules, defaults, constraints and limits are documented on the wiki page Opening Generation.

```csharp
public static DiGi.GIS.Classes.OpeningGenerationResult? GenerateOpenings(this DiGi.Analytical.Building.Classes.BuildingModel? buildingModel, DiGi.GIS.Classes.Building2D? building2D, DiGi.GIS.Classes.OpeningGenerationInput? openingGenerationInput, System.Collections.Generic.IEnumerable<DiGi.Analytical.Building.Classes.BuildingModel?>? buildingModels_Neighbour=null, DiGi.Analytical.Building.Regulation.Classes.ConstructionLibrary? constructionLibrary=null, DiGi.Analytical.Building.Regulation.Classes.OpeningSizeLibrary? openingSizeLibrary=null, double tolerance=1E-06);
```
#### Parameters

<a name='DiGi.GIS.Analytical.Modify.GenerateOpenings(thisDiGi.Analytical.Building.Classes.BuildingModel,DiGi.GIS.Classes.Building2D,DiGi.GIS.Classes.OpeningGenerationInput,System.Collections.Generic.IEnumerable_DiGi.Analytical.Building.Classes.BuildingModel_,DiGi.Analytical.Building.Regulation.Classes.ConstructionLibrary,DiGi.Analytical.Building.Regulation.Classes.OpeningSizeLibrary,double).buildingModel'></a>

`buildingModel` [DiGi\.Analytical\.Building\.Classes\.BuildingModel](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.classes.buildingmodel 'DiGi\.Analytical\.Building\.Classes\.BuildingModel')

The building model to place the openings on\.

<a name='DiGi.GIS.Analytical.Modify.GenerateOpenings(thisDiGi.Analytical.Building.Classes.BuildingModel,DiGi.GIS.Classes.Building2D,DiGi.GIS.Classes.OpeningGenerationInput,System.Collections.Generic.IEnumerable_DiGi.Analytical.Building.Classes.BuildingModel_,DiGi.Analytical.Building.Regulation.Classes.ConstructionLibrary,DiGi.Analytical.Building.Regulation.Classes.OpeningSizeLibrary,double).building2D'></a>

`building2D` [DiGi\.GIS\.Classes\.Building2D](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.classes.building2d 'DiGi\.GIS\.Classes\.Building2D')

The 2D building of the model, giving its function and storey count\. This value can be null\.

<a name='DiGi.GIS.Analytical.Modify.GenerateOpenings(thisDiGi.Analytical.Building.Classes.BuildingModel,DiGi.GIS.Classes.Building2D,DiGi.GIS.Classes.OpeningGenerationInput,System.Collections.Generic.IEnumerable_DiGi.Analytical.Building.Classes.BuildingModel_,DiGi.Analytical.Building.Regulation.Classes.ConstructionLibrary,DiGi.Analytical.Building.Regulation.Classes.OpeningSizeLibrary,double).openingGenerationInput'></a>

`openingGenerationInput` [OpeningGenerationInput](DiGi.GIS.Classes.md#DiGi.GIS.Classes.OpeningGenerationInput 'DiGi\.GIS\.Classes\.OpeningGenerationInput')

The year built, address point, climate zone, panel system and options\. This value can be null\.

<a name='DiGi.GIS.Analytical.Modify.GenerateOpenings(thisDiGi.Analytical.Building.Classes.BuildingModel,DiGi.GIS.Classes.Building2D,DiGi.GIS.Classes.OpeningGenerationInput,System.Collections.Generic.IEnumerable_DiGi.Analytical.Building.Classes.BuildingModel_,DiGi.Analytical.Building.Regulation.Classes.ConstructionLibrary,DiGi.Analytical.Building.Regulation.Classes.OpeningSizeLibrary,double).buildingModels_Neighbour'></a>

`buildingModels_Neighbour` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[DiGi\.Analytical\.Building\.Classes\.BuildingModel](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.classes.buildingmodel 'DiGi\.Analytical\.Building\.Classes\.BuildingModel')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The building models of the adjacent buildings, measured against before placement under § 271 and § 13; null skips the neighbour rules\. This value can be null\.

<a name='DiGi.GIS.Analytical.Modify.GenerateOpenings(thisDiGi.Analytical.Building.Classes.BuildingModel,DiGi.GIS.Classes.Building2D,DiGi.GIS.Classes.OpeningGenerationInput,System.Collections.Generic.IEnumerable_DiGi.Analytical.Building.Classes.BuildingModel_,DiGi.Analytical.Building.Regulation.Classes.ConstructionLibrary,DiGi.Analytical.Building.Regulation.Classes.OpeningSizeLibrary,double).constructionLibrary'></a>

`constructionLibrary` [DiGi\.Analytical\.Building\.Regulation\.Classes\.ConstructionLibrary](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.regulation.classes.constructionlibrary 'DiGi\.Analytical\.Building\.Regulation\.Classes\.ConstructionLibrary')

The construction library, or null for `Regulation.Query.EmbeddedConstructionLibrary_PL()`\. A batch caller passes it to read it once\.

<a name='DiGi.GIS.Analytical.Modify.GenerateOpenings(thisDiGi.Analytical.Building.Classes.BuildingModel,DiGi.GIS.Classes.Building2D,DiGi.GIS.Classes.OpeningGenerationInput,System.Collections.Generic.IEnumerable_DiGi.Analytical.Building.Classes.BuildingModel_,DiGi.Analytical.Building.Regulation.Classes.ConstructionLibrary,DiGi.Analytical.Building.Regulation.Classes.OpeningSizeLibrary,double).openingSizeLibrary'></a>

`openingSizeLibrary` [DiGi\.Analytical\.Building\.Regulation\.Classes\.OpeningSizeLibrary](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.regulation.classes.openingsizelibrary 'DiGi\.Analytical\.Building\.Regulation\.Classes\.OpeningSizeLibrary')

The opening\-size library, or null for `Regulation.Create.OpeningSizeLibrary_PL()`\. A batch caller passes it to create it once\.

<a name='DiGi.GIS.Analytical.Modify.GenerateOpenings(thisDiGi.Analytical.Building.Classes.BuildingModel,DiGi.GIS.Classes.Building2D,DiGi.GIS.Classes.OpeningGenerationInput,System.Collections.Generic.IEnumerable_DiGi.Analytical.Building.Classes.BuildingModel_,DiGi.Analytical.Building.Regulation.Classes.ConstructionLibrary,DiGi.Analytical.Building.Regulation.Classes.OpeningSizeLibrary,double).tolerance'></a>

`tolerance` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The distance tolerance\.

#### Returns
[OpeningGenerationResult](DiGi.GIS.Classes.md#DiGi.GIS.Classes.OpeningGenerationResult 'DiGi\.GIS\.Classes\.OpeningGenerationResult')  
What was placed and what could not be, or null when the model is null or no opening\-size set matches the building\.

<a name='DiGi.GIS.Analytical.Modify.UpdateBuildingInformation(thisDiGi.Analytical.Building.Classes.BuildingModel)'></a>

## Modify\.UpdateBuildingInformation\(this BuildingModel\) Method

Sets the WGS 84 coordinates and the Polish standard time zone on the model's [DiGi\.Analytical\.Building\.Classes\.BuildingModel\.BuildingInformation](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.classes.buildingmodel.buildinginformation 'DiGi\.Analytical\.Building\.Classes\.BuildingModel\.BuildingInformation')\.

The coordinates are the WGS 84 conversion of the centre of the model's bounding box, whose geometry is in EPSG:2180. The UTC offset is fixed to [DiGi\.Core\.Enums\.UTC\.Plus0100](https://learn.microsoft.com/en-us/dotnet/api/digi.core.enums.utc.plus0100 'DiGi\.Core\.Enums\.UTC\.Plus0100') (CET), deliberately without daylight saving: a shading model holds one offset for its whole life, so a solve over a date range would be wrong by one hour for half of every year if the offset switched with the season. Every time given to the solver is local standard time; a caller holding wall-clock summer time subtracts one hour before solving.

The method is idempotent: it always overwrites and never reads the previous values, so the unlocated default of (0, 0) is never treated as "already set". The [DiGi\.Analytical\.Building\.Classes\.BuildingInformation\.Address](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.classes.buildinginformation.address 'DiGi\.Analytical\.Building\.Classes\.BuildingInformation\.Address') is preserved through the copy constructor.

```csharp
public static bool UpdateBuildingInformation(this DiGi.Analytical.Building.Classes.BuildingModel? buildingModel);
```
#### Parameters

<a name='DiGi.GIS.Analytical.Modify.UpdateBuildingInformation(thisDiGi.Analytical.Building.Classes.BuildingModel).buildingModel'></a>

`buildingModel` [DiGi\.Analytical\.Building\.Classes\.BuildingModel](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.classes.buildingmodel 'DiGi\.Analytical\.Building\.Classes\.BuildingModel')

The building model to locate\.

#### Returns
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')  
[false](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/builtin\-types/bool') when the model is null, has no bounding box, or the bounding\-box centre converts to a WGS 84 position outside the Polish range \(latitude \[48\.9, 55\.0\], longitude \[14\.05, 24\.25\]\) \- in which case the geometry is not in EPSG:2180 and the model is left unchanged\.

<a name='DiGi.GIS.Analytical.Query'></a>

## Query Class

```csharp
public static class Query
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → Query
### Fields

<a name='DiGi.GIS.Analytical.Query.ApartmentBlockStoreys'></a>

## Query\.ApartmentBlockStoreys Field

The number of storeys from which a multi\-family building is taken as an apartment block, a default: the TABULA Polish apartment blocks have 5 to 11 storeys, and no threshold is published\.

```csharp
public const ushort ApartmentBlockStoreys = 5;
```

#### Field Value
[System\.UInt16](https://learn.microsoft.com/en-us/dotnet/api/system.uint16 'System\.UInt16')
### Methods

<a name='DiGi.GIS.Analytical.Query.Building(thisDiGi.GIS.Classes.Building2D,System.Collections.Generic.IEnumerable_DiGi.CityGML.Classes.CityModel_)'></a>

## Query\.Building\(this Building2D, IEnumerable\<CityModel\>\) Method

Retrieves the most appropriate [Building\(this Building2D, IEnumerable&lt;CityModel&gt;\)](DiGi.GIS.Analytical.md#DiGi.GIS.Analytical.Query.Building(thisDiGi.GIS.Classes.Building2D,System.Collections.Generic.IEnumerable_DiGi.CityGML.Classes.CityModel_) 'DiGi\.GIS\.Analytical\.Query\.Building\(this DiGi\.GIS\.Classes\.Building2D, System\.Collections\.Generic\.IEnumerable\<DiGi\.CityGML\.Classes\.CityModel\>\)') from a collection of city models based on a 2D building reference\.
The method prioritizes buildings with LOD2 over LOD1, and among those with the same LOD, it selects the one from the most recent year\.

```csharp
public static DiGi.CityGML.Classes.Building? Building(this DiGi.GIS.Classes.Building2D? building2D, System.Collections.Generic.IEnumerable<DiGi.CityGML.Classes.CityModel>? cityModels);
```
#### Parameters

<a name='DiGi.GIS.Analytical.Query.Building(thisDiGi.GIS.Classes.Building2D,System.Collections.Generic.IEnumerable_DiGi.CityGML.Classes.CityModel_).building2D'></a>

`building2D` [DiGi\.GIS\.Classes\.Building2D](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.classes.building2d 'DiGi\.GIS\.Classes\.Building2D')

The 2D building instance providing the reference for the search\.

<a name='DiGi.GIS.Analytical.Query.Building(thisDiGi.GIS.Classes.Building2D,System.Collections.Generic.IEnumerable_DiGi.CityGML.Classes.CityModel_).cityModels'></a>

`cityModels` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[DiGi\.CityGML\.Classes\.CityModel](https://learn.microsoft.com/en-us/dotnet/api/digi.citygml.classes.citymodel 'DiGi\.CityGML\.Classes\.CityModel')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The collection of city models to be searched for a matching building\.

#### Returns
[DiGi\.CityGML\.Classes\.Building](https://learn.microsoft.com/en-us/dotnet/api/digi.citygml.classes.building 'DiGi\.CityGML\.Classes\.Building')  
The matching [Building\(this Building2D, IEnumerable&lt;CityModel&gt;\)](DiGi.GIS.Analytical.md#DiGi.GIS.Analytical.Query.Building(thisDiGi.GIS.Classes.Building2D,System.Collections.Generic.IEnumerable_DiGi.CityGML.Classes.CityModel_) 'DiGi\.GIS\.Analytical\.Query\.Building\(this DiGi\.GIS\.Classes\.Building2D, System\.Collections\.Generic\.IEnumerable\<DiGi\.CityGML\.Classes\.CityModel\>\)') based on priority rules, or [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null') if no match is found or inputs are null\.

<a name='DiGi.GIS.Analytical.Query.BuildingModelDictionary(DiGi.GIS.Classes.GISModelFile,System.Collections.Generic.IEnumerable_string_)'></a>

## Query\.BuildingModelDictionary\(GISModelFile, IEnumerable\<string\>\) Method

Retrieves a dictionary of building models associated with the specified GIS model file based on the provided references\.

```csharp
public static System.Collections.Generic.Dictionary<string,DiGi.Analytical.Building.Classes.BuildingModel>? BuildingModelDictionary(DiGi.GIS.Classes.GISModelFile? gISModelFile, System.Collections.Generic.IEnumerable<string>? references);
```
#### Parameters

<a name='DiGi.GIS.Analytical.Query.BuildingModelDictionary(DiGi.GIS.Classes.GISModelFile,System.Collections.Generic.IEnumerable_string_).gISModelFile'></a>

`gISModelFile` [DiGi\.GIS\.Classes\.GISModelFile](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.classes.gismodelfile 'DiGi\.GIS\.Classes\.GISModelFile')

The GIS model file used to determine the location and name of the corresponding building models file\.

<a name='DiGi.GIS.Analytical.Query.BuildingModelDictionary(DiGi.GIS.Classes.GISModelFile,System.Collections.Generic.IEnumerable_string_).references'></a>

`references` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

A collection of reference strings used to identify the building models to retrieve\.

#### Returns
[System\.Collections\.Generic\.Dictionary&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2 'System\.Collections\.Generic\.Dictionary\`2')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[,](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2 'System\.Collections\.Generic\.Dictionary\`2')[DiGi\.Analytical\.Building\.Classes\.BuildingModel](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.classes.buildingmodel 'DiGi\.Analytical\.Building\.Classes\.BuildingModel')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2 'System\.Collections\.Generic\.Dictionary\`2')  
A dictionary mapping unique identifiers to [DiGi\.Analytical\.Building\.Classes\.BuildingModel](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.classes.buildingmodel 'DiGi\.Analytical\.Building\.Classes\.BuildingModel') objects, or null if the GIS model file or references are null\.

<a name='DiGi.GIS.Analytical.Query.BuildingModelDictionary(string,System.Collections.Generic.IEnumerable_string_)'></a>

## Query\.BuildingModelDictionary\(string, IEnumerable\<string\>\) Method

Retrieves a dictionary of building models from the specified file path based on the provided references\.

```csharp
public static System.Collections.Generic.Dictionary<string,DiGi.Analytical.Building.Classes.BuildingModel>? BuildingModelDictionary(string? path, System.Collections.Generic.IEnumerable<string>? references);
```
#### Parameters

<a name='DiGi.GIS.Analytical.Query.BuildingModelDictionary(string,System.Collections.Generic.IEnumerable_string_).path'></a>

`path` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The file system path to the building models file\.

<a name='DiGi.GIS.Analytical.Query.BuildingModelDictionary(string,System.Collections.Generic.IEnumerable_string_).references'></a>

`references` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

A collection of reference strings used to identify the building models to retrieve\.

#### Returns
[System\.Collections\.Generic\.Dictionary&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2 'System\.Collections\.Generic\.Dictionary\`2')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[,](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2 'System\.Collections\.Generic\.Dictionary\`2')[DiGi\.Analytical\.Building\.Classes\.BuildingModel](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.classes.buildingmodel 'DiGi\.Analytical\.Building\.Classes\.BuildingModel')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2 'System\.Collections\.Generic\.Dictionary\`2')  
A dictionary mapping unique identifiers to [DiGi\.Analytical\.Building\.Classes\.BuildingModel](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.classes.buildingmodel 'DiGi\.Analytical\.Building\.Classes\.BuildingModel') objects, or null if the path is invalid or references are null\.

<a name='DiGi.GIS.Analytical.Query.BuildingType(thisDiGi.GIS.Classes.Building2D,bool)'></a>

## Query\.BuildingType\(this Building2D, bool\) Method

Gets the TABULA residential building type of a BDOT10k building, the key of the construction library and of the opening size library \(DiGi\-Organization/DiGi\.GIS\.Analytical\#6\)\.

A single-family building (specific function `single_family_building`) is [DiGi\.Analytical\.Building\.Regulation\.Enums\.BuildingType\.SingleFamily](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.regulation.enums.buildingtype.singlefamily 'DiGi\.Analytical\.Building\.Regulation\.Enums\.BuildingType\.SingleFamily'), or [DiGi\.Analytical\.Building\.Regulation\.Enums\.BuildingType\.Terraced](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.regulation.enums.buildingtype.terraced 'DiGi\.Analytical\.Building\.Regulation\.Enums\.BuildingType\.Terraced') when it has party walls (`Analytical.Building.Query.PartyWalls`, DiGi-Organization/DiGi.GIS.Analytical#4). A multi-family building (`multi_family_building`, which wins when both are given) is [DiGi\.Analytical\.Building\.Regulation\.Enums\.BuildingType\.ApartmentBlock](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.regulation.enums.buildingtype.apartmentblock 'DiGi\.Analytical\.Building\.Regulation\.Enums\.BuildingType\.ApartmentBlock') from [ApartmentBlockStoreys](DiGi.GIS.Analytical.md#DiGi.GIS.Analytical.Query.ApartmentBlockStoreys 'DiGi\.GIS\.Analytical\.Query\.ApartmentBlockStoreys') storeys and [DiGi\.Analytical\.Building\.Regulation\.Enums\.BuildingType\.MultiFamily](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.regulation.enums.buildingtype.multifamily 'DiGi\.Analytical\.Building\.Regulation\.Enums\.BuildingType\.MultiFamily') below. Any other building is [DiGi\.Analytical\.Building\.Regulation\.Enums\.BuildingType\.Undefined](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.regulation.enums.buildingtype.undefined 'DiGi\.Analytical\.Building\.Regulation\.Enums\.BuildingType\.Undefined').

```csharp
public static DiGi.Analytical.Building.Regulation.Enums.BuildingType BuildingType(this DiGi.GIS.Classes.Building2D? building2D, bool partyWalls=false);
```
#### Parameters

<a name='DiGi.GIS.Analytical.Query.BuildingType(thisDiGi.GIS.Classes.Building2D,bool).building2D'></a>

`building2D` [DiGi\.GIS\.Classes\.Building2D](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.classes.building2d 'DiGi\.GIS\.Classes\.Building2D')

The building\.

<a name='DiGi.GIS.Analytical.Query.BuildingType(thisDiGi.GIS.Classes.Building2D,bool).partyWalls'></a>

`partyWalls` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

True when the building has party walls with a neighbour\.

#### Returns
[DiGi\.Analytical\.Building\.Regulation\.Enums\.BuildingType](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.regulation.enums.buildingtype 'DiGi\.Analytical\.Building\.Regulation\.Enums\.BuildingType')  
The building type\.

<a name='DiGi.GIS.Analytical.Query.Elevation(thisDiGi.Geometry.Spatial.Classes.Point3D)'></a>

## Query\.Elevation\(this Point3D\) Method

Reads the elevation carried by a point fetched from the terrain service\.

A point that was never fetched, or one whose elevation the service reported as not a number, falls back to zero - the terrain service may not decide whether a building is created, so a model placed at sea level is preferred over no model at all.

```csharp
public static double Elevation(this DiGi.Geometry.Spatial.Classes.Point3D? point3D);
```
#### Parameters

<a name='DiGi.GIS.Analytical.Query.Elevation(thisDiGi.Geometry.Spatial.Classes.Point3D).point3D'></a>

`point3D` [DiGi\.Geometry\.Spatial\.Classes\.Point3D](https://learn.microsoft.com/en-us/dotnet/api/digi.geometry.spatial.classes.point3d 'DiGi\.Geometry\.Spatial\.Classes\.Point3D')

The point returned by the terrain service\.

#### Returns
[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')  
The elevation of the point, or zero when it carries none\.

<a name='DiGi.GIS.Analytical.Query.FireClass(thisSystem.Nullable_DiGi.GIS.Enums.BuildingGeneralFunction_)'></a>

## Query\.FireClass\(this Nullable\<BuildingGeneralFunction\>\) Method

Gets the kind of building of § 271 for the general function of a 2D building \(DiGi\-Organization/DiGi\.GIS\.Analytical\#9\)\.

§ 209 ust. 1 of the technical conditions of 2002 (Dz.U. 2022 poz. 1225), read in ISAP on 2026-11-01, divides buildings into ZL (residential, collective-residence and public-utility), PM (production and storage) and IN (livestock): residential, office, commercial, education/science/culture/sports, hospital/healthcare, transport, other non-residential and unknown functions take ZL, agricultural production for agriculture and industrial, tanks/silos/storage take PM. The kind decides the row of the § 271 table together with the fuel-load density Q of `OpeningGenerationOptions.FireSeparationHeatRelease`; with Q unknown the ZL, IN and PM rows of Q <= 1000 MJ/m2 all give the same distance.

```csharp
public static System.Nullable<DiGi.GIS.Analytical.Enums.FireClass> FireClass(this System.Nullable<DiGi.GIS.Enums.BuildingGeneralFunction> buildingGeneralFunction);
```
#### Parameters

<a name='DiGi.GIS.Analytical.Query.FireClass(thisSystem.Nullable_DiGi.GIS.Enums.BuildingGeneralFunction_).buildingGeneralFunction'></a>

`buildingGeneralFunction` [System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[DiGi\.GIS\.Enums\.BuildingGeneralFunction](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.enums.buildinggeneralfunction 'DiGi\.GIS\.Enums\.BuildingGeneralFunction')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

The general function of the building, or null when unknown\.

#### Returns
[System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[FireClass](DiGi.GIS.Analytical.Enums.md#DiGi.GIS.Analytical.Enums.FireClass 'DiGi\.GIS\.Analytical\.Enums\.FireClass')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')  
The kind of building, or null when the function is null\.

<a name='DiGi.GIS.Analytical.Query.Horizontal(thisDiGi.Geometry.Spatial.Classes.Vector3D,double)'></a>

## Query\.Horizontal\(this Vector3D, double\) Method

Determines whether the specified 3D vector is horizontal \(perpendicular to the World Z axis\) within a given tolerance\.

```csharp
public static bool Horizontal(this DiGi.Geometry.Spatial.Classes.Vector3D? vector3D, double tolerance=0.0349066);
```
#### Parameters

<a name='DiGi.GIS.Analytical.Query.Horizontal(thisDiGi.Geometry.Spatial.Classes.Vector3D,double).vector3D'></a>

`vector3D` [DiGi\.Geometry\.Spatial\.Classes\.Vector3D](https://learn.microsoft.com/en-us/dotnet/api/digi.geometry.spatial.classes.vector3d 'DiGi\.Geometry\.Spatial\.Classes\.Vector3D')

The 3D vector to evaluate\.

<a name='DiGi.GIS.Analytical.Query.Horizontal(thisDiGi.Geometry.Spatial.Classes.Vector3D,double).tolerance'></a>

`tolerance` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The angular tolerance used to determine if the vector is horizontal\.

#### Returns
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')  
`true` if the vector is horizontal within the specified tolerance; otherwise, `false`\.

<a name='DiGi.GIS.Analytical.Query.IsLocated(thisDiGi.Analytical.Building.Classes.BuildingModel)'></a>

## Query\.IsLocated\(this BuildingModel\) Method

Checks that the building model carries a located [DiGi\.Analytical\.Building\.Classes\.BuildingModel\.BuildingInformation](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.classes.buildingmodel.buildinginformation 'DiGi\.Analytical\.Building\.Classes\.BuildingModel\.BuildingInformation')\.

True when all three conditions hold: the [DiGi\.Analytical\.Building\.Classes\.BuildingInformation\.Coordinates](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.classes.buildinginformation.coordinates 'DiGi\.Analytical\.Building\.Classes\.BuildingInformation\.Coordinates') is not null, it is not the unlocated (0, 0) default, and the [DiGi\.Analytical\.Building\.Classes\.BuildingInformation\.UTC](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.classes.buildinginformation.utc 'DiGi\.Analytical\.Building\.Classes\.BuildingInformation\.UTC') is not [DiGi\.Core\.Enums\.UTC\.Undefined](https://learn.microsoft.com/en-us/dotnet/api/digi.core.enums.utc.undefined 'DiGi\.Core\.Enums\.UTC\.Undefined'). A model failing any one of the three still computes its sun path at (0, 0) or with a not-a-number offset, so it is unlocated even when the other conditions hold.

```csharp
public static bool IsLocated(this DiGi.Analytical.Building.Classes.BuildingModel? buildingModel);
```
#### Parameters

<a name='DiGi.GIS.Analytical.Query.IsLocated(thisDiGi.Analytical.Building.Classes.BuildingModel).buildingModel'></a>

`buildingModel` [DiGi\.Analytical\.Building\.Classes\.BuildingModel](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.classes.buildingmodel 'DiGi\.Analytical\.Building\.Classes\.BuildingModel')

The building model to check\.

#### Returns
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')  
[true](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/builtin\-types/bool') when the building model carries located coordinates and a defined UTC offset; otherwise, [false](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/builtin\-types/bool')\.

<a name='DiGi.GIS.Analytical.Query.StoreyBands(thisDiGi.Analytical.Building.Classes.BuildingModel,ushort,double,DiGi.GIS.Analytical.Enums.StoreySource,double)'></a>

## Query\.StoreyBands\(this BuildingModel, ushort, double, StoreySource, double\) Method

Derives the storey bands of a building model, the elevation range of each storey from the ground up, without assuming that one space is one storey \(DiGi\-Organization/DiGi\.GIS\.Analytical\#2\)\.

The bands come from the first source that gives them, reported in [storeySource](DiGi.GIS.Analytical.md#DiGi.GIS.Analytical.Query.StoreyBands(thisDiGi.Analytical.Building.Classes.BuildingModel,ushort,double,DiGi.GIS.Analytical.Enums.StoreySource,double).storeySource 'DiGi\.GIS\.Analytical\.Query\.StoreyBands\(this DiGi\.Analytical\.Building\.Classes\.BuildingModel, ushort, double, DiGi\.GIS\.Analytical\.Enums\.StoreySource, double\)\.storeySource'):
- [Spaces](DiGi.GIS.Analytical.Enums.md#DiGi.GIS.Analytical.Enums.StoreySource.Spaces 'DiGi\.GIS\.Analytical\.Enums\.StoreySource\.Spaces'): two or more spaces with walls; each band is the elevation range of the walls of one space.
- [Building2D](DiGi.GIS.Analytical.Enums.md#DiGi.GIS.Analytical.Enums.StoreySource.Building2D 'DiGi\.GIS\.Analytical\.Enums\.StoreySource\.Building2D'): one space, which the 3D path leaves unsplit when its derived storey height is too low, and [storeys](DiGi.GIS.Analytical.md#DiGi.GIS.Analytical.Query.StoreyBands(thisDiGi.Analytical.Building.Classes.BuildingModel,ushort,double,DiGi.GIS.Analytical.Enums.StoreySource,double).storeys 'DiGi\.GIS\.Analytical\.Query\.StoreyBands\(this DiGi\.Analytical\.Building\.Classes\.BuildingModel, ushort, double, DiGi\.GIS\.Analytical\.Enums\.StoreySource, double\)\.storeys') > 0; the wall height is divided into that many equal bands.
- [Estimated](DiGi.GIS.Analytical.Enums.md#DiGi.GIS.Analytical.Enums.StoreySource.Estimated 'DiGi\.GIS\.Analytical\.Enums\.StoreySource\.Estimated'): one space and no storey count; the count is the wall height over [storeyHeight](DiGi.GIS.Analytical.md#DiGi.GIS.Analytical.Query.StoreyBands(thisDiGi.Analytical.Building.Classes.BuildingModel,ushort,double,DiGi.GIS.Analytical.Enums.StoreySource,double).storeyHeight 'DiGi\.GIS\.Analytical\.Query\.StoreyBands\(this DiGi\.Analytical\.Building\.Classes\.BuildingModel, ushort, double, DiGi\.GIS\.Analytical\.Enums\.StoreySource, double\)\.storeyHeight'), rounded, at least 1.
- [Single](DiGi.GIS.Analytical.Enums.md#DiGi.GIS.Analytical.Enums.StoreySource.Single 'DiGi\.GIS\.Analytical\.Enums\.StoreySource\.Single'): no storey count and no storey height; one band, the whole wall.

```csharp
public static System.Collections.Generic.List<DiGi.Core.Classes.Range<double>>? StoreyBands(this DiGi.Analytical.Building.Classes.BuildingModel? buildingModel, ushort storeys, double storeyHeight, out DiGi.GIS.Analytical.Enums.StoreySource storeySource, double tolerance=1E-06);
```
#### Parameters

<a name='DiGi.GIS.Analytical.Query.StoreyBands(thisDiGi.Analytical.Building.Classes.BuildingModel,ushort,double,DiGi.GIS.Analytical.Enums.StoreySource,double).buildingModel'></a>

`buildingModel` [DiGi\.Analytical\.Building\.Classes\.BuildingModel](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.classes.buildingmodel 'DiGi\.Analytical\.Building\.Classes\.BuildingModel')

The building model\.

<a name='DiGi.GIS.Analytical.Query.StoreyBands(thisDiGi.Analytical.Building.Classes.BuildingModel,ushort,double,DiGi.GIS.Analytical.Enums.StoreySource,double).storeys'></a>

`storeys` [System\.UInt16](https://learn.microsoft.com/en-us/dotnet/api/system.uint16 'System\.UInt16')

The storey count of the 2D building, or 0 when unknown\.

<a name='DiGi.GIS.Analytical.Query.StoreyBands(thisDiGi.Analytical.Building.Classes.BuildingModel,ushort,double,DiGi.GIS.Analytical.Enums.StoreySource,double).storeyHeight'></a>

`storeyHeight` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The typical storey height of the building's stock \[m\], used to estimate the count; not a number when unknown\.

<a name='DiGi.GIS.Analytical.Query.StoreyBands(thisDiGi.Analytical.Building.Classes.BuildingModel,ushort,double,DiGi.GIS.Analytical.Enums.StoreySource,double).storeySource'></a>

`storeySource` [StoreySource](DiGi.GIS.Analytical.Enums.md#DiGi.GIS.Analytical.Enums.StoreySource 'DiGi\.GIS\.Analytical\.Enums\.StoreySource')

Where the bands come from; [Undefined](DiGi.GIS.Analytical.Enums.md#DiGi.GIS.Analytical.Enums.StoreySource.Undefined 'DiGi\.GIS\.Analytical\.Enums\.StoreySource\.Undefined') when the model has no walls\.

<a name='DiGi.GIS.Analytical.Query.StoreyBands(thisDiGi.Analytical.Building.Classes.BuildingModel,ushort,double,DiGi.GIS.Analytical.Enums.StoreySource,double).tolerance'></a>

`tolerance` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The distance tolerance\.

#### Returns
[System\.Collections\.Generic\.List&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[DiGi\.Core\.Classes\.Range&lt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.range-1 'DiGi\.Core\.Classes\.Range\`1')[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.range-1 'DiGi\.Core\.Classes\.Range\`1')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')  
The bands from the ground up, or null when the model is null or has no walls\.

<a name='DiGi.GIS.Analytical.Query.UsageType(thisDiGi.GIS.Classes.Building2D)'></a>

## Query\.UsageType\(this Building2D\) Method

Gets the usage type of the Polish energy\-certificate methodology \(Dz\.U\. 2015 poz\. 376, Annex 1, Tables 23\-27\) a BDOT10k building is used as, which selects its usage profile \(DiGi\-Organization/DiGi\.Analytical\#9\)\.

<b>Specific functions first.</b> Each specific function that names a usage maps to one, and when several do, the first in the order MultiFamily, SingleFamily, CollectiveResidence, Healthcare, Education, Sport, Gastronomy, Retail, Office, Production, Storage wins - people living in a building outweigh what else it is used for:
- SingleFamily: `single_family_building`; MultiFamily: `multi_family_building` (a building with both is multi-family), the same specific functions as `GIS.Query.IsResidential`.
- CollectiveResidence: dormitories, boarding schools, social-care, children's and juvenile homes, homeless and tourist shelters, monasteries, retreat and parish houses, hotels, motels, workers' hotels, guesthouses, barracks, prisons and correctional facilities.
- Healthcare: hospitals, healthcare facilities, hospices, emergency medical units, blood donation and sanitary-epidemiological stations, sobering-up stations.
- Education: nurseries, kindergartens, primary and secondary schools, universities, other educational and care-educational facilities, research facilities, observatories.
- Sport: sports halls, gyms, swimming pools, ice rinks, arenas, tennis courts, riding halls, bowling alleys, go-kart tracks, sports clubs.
- Gastronomy: restaurants, inns, clubs and discos, wedding houses.
- Retail: shopping centres, department stores, hypermarkets, market halls, commercial and service buildings, pharmacies, banks.
- Office: ministries, voivodeship, marshal's, county, municipal and city offices, courts, prosecutors, other public administration, company headquarters, postal and diplomatic offices.
- Production: production and livestock buildings, repair workshops, refineries, mills, greenhouses.
- Storage: warehouses, cold stores, archives, silos, grain elevators.

<b>Then the general function:</b> office → Office, commercial and service → Retail, education, science, culture and sport → Education, hospital and healthcare → Healthcare, agricultural production and industrial → Production, tanks, silos and storage → Storage. Residential buildings without a single- or multi-family specific function, transport and communication, other non-residential buildings and an unknown function give [DiGi\.Analytical\.Building\.HVAC\.Enums\.UsageType\.Undefined](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.hvac.enums.usagetype.undefined 'DiGi\.Analytical\.Building\.HVAC\.Enums\.UsageType\.Undefined'), which the caller resolves by a fallback ([AssignInternalConditions\(this BuildingModel, Building2D, OccupancyData, Nullable&lt;short&gt;, string\)](DiGi.GIS.Analytical.md#DiGi.GIS.Analytical.Modify.AssignInternalConditions(thisDiGi.Analytical.Building.Classes.BuildingModel,DiGi.GIS.Classes.Building2D,DiGi.GIS.Classes.OccupancyData,System.Nullable_short_,string) 'DiGi\.GIS\.Analytical\.Modify\.AssignInternalConditions\(this DiGi\.Analytical\.Building\.Classes\.BuildingModel, DiGi\.GIS\.Classes\.Building2D, DiGi\.GIS\.Classes\.OccupancyData, System\.Nullable\<short\>, string\)')).

```csharp
public static DiGi.Analytical.Building.HVAC.Enums.UsageType UsageType(this DiGi.GIS.Classes.Building2D? building2D);
```
#### Parameters

<a name='DiGi.GIS.Analytical.Query.UsageType(thisDiGi.GIS.Classes.Building2D).building2D'></a>

`building2D` [DiGi\.GIS\.Classes\.Building2D](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.classes.building2d 'DiGi\.GIS\.Classes\.Building2D')

The building\.

#### Returns
[DiGi\.Analytical\.Building\.HVAC\.Enums\.UsageType](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.hvac.enums.usagetype 'DiGi\.Analytical\.Building\.HVAC\.Enums\.UsageType')  
The usage type, or [DiGi\.Analytical\.Building\.HVAC\.Enums\.UsageType\.Undefined](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.hvac.enums.usagetype.undefined 'DiGi\.Analytical\.Building\.HVAC\.Enums\.UsageType\.Undefined') when the functions name none or [building2D](DiGi.GIS.Analytical.md#DiGi.GIS.Analytical.Query.UsageType(thisDiGi.GIS.Classes.Building2D).building2D 'DiGi\.GIS\.Analytical\.Query\.UsageType\(this DiGi\.GIS\.Classes\.Building2D\)\.building2D') is null\.

<a name='DiGi.GIS.Analytical.Query.WallOpeningResults(thisDiGi.Analytical.Building.Classes.BuildingModel,System.Collections.Generic.IEnumerable_DiGi.Analytical.Building.Classes.BuildingModel_,DiGi.GIS.Classes.OpeningGenerationOptions,System.Nullable_DiGi.GIS.Enums.BuildingGeneralFunction_,double)'></a>

## Query\.WallOpeningResults\(this BuildingModel, IEnumerable\<BuildingModel\>, OpeningGenerationOptions, Nullable\<BuildingGeneralFunction\>, double\) Method

Gets, for every external wall of a building model, why it may carry no openings under the neighbour rules of the opening generation, and the distances measured behind that decision: § 271 fire separation and § 13 daylight obstruction \(DiGi\-Organization/DiGi\.GIS\.Analytical\#9\)\.

<b>§ 271 fire separation.</b> Each external wall that is not a party wall (a fire-separation wall is excluded by ust. 1) is compared with every wall of a neighbour model within reach. A pair counts when the walls mutually face each other, judged at their midpoints, and the angle between the wall planes on the side of the gap is read from their outward normals: parallel facing walls give 0 deg and the full distance, 60 deg to less than 120 deg halves it (ust. 11), at 120 deg and above the rule does not apply (ust. 12 pkt 2). The required distance is the larger value of the § 271 table for the two [FireClass\(this Nullable&lt;BuildingGeneralFunction&gt;\)](DiGi.GIS.Analytical.md#DiGi.GIS.Analytical.Query.FireClass(thisSystem.Nullable_DiGi.GIS.Enums.BuildingGeneralFunction_) 'DiGi\.GIS\.Analytical\.Query\.FireClass\(this System\.Nullable\<DiGi\.GIS\.Enums\.BuildingGeneralFunction\>\)') kinds, taken through the local `FireSeparationBase` and multiplied by the spread factors of ust. 2, the no-openings factor of ust. 9 when both facing walls carry openings-free walls and neither building spreads fire, and the half-strip factor. The wall fails when the measured distance falls short, and it then gets no openings at all. Not modelled, as the stock data carries none of it: the E-class surface precondition of ust. 1, explosion-hazard rooms (ust. 3), the E-class coverage factors of ust. 4-5 and the sprinkler reductions of ust. 6-7; see also [FireSeparationNoOpeningsFactor](DiGi.GIS.Classes.md#DiGi.GIS.Classes.OpeningGenerationOptions.FireSeparationNoOpeningsFactor 'DiGi\.GIS\.Classes\.OpeningGenerationOptions\.FireSeparationNoOpeningsFactor') for what of ust. 9 is reached.

<b>§ 13 daylight obstruction.</b> On each window axis - both ends of the usable wall length, its midpoint, and the axis of each neighbour's point nearest the wall - a horizontal sector of [ObstructionSectorAngle](DiGi.GIS.Classes.md#DiGi.GIS.Classes.OpeningGenerationOptions.ObstructionSectorAngle 'DiGi\.GIS\.Classes\.OpeningGenerationOptions\.ObstructionSectorAngle') opens from the wall line, bisected by the outward normal. Every part of a neighbour's solid, and every other part of the same building, that falls inside the sector must be at least its height of shading away: the obstructing top minus the lowest window sill, taken as the ground elevation plus [SillHeight](DiGi.GIS.Classes.md#DiGi.GIS.Classes.OpeningGenerationOptions.SillHeight 'DiGi\.GIS\.Classes\.OpeningGenerationOptions\.SillHeight'), capped at [ObstructionMaxDistance](DiGi.GIS.Classes.md#DiGi.GIS.Classes.OpeningGenerationOptions.ObstructionMaxDistance 'DiGi\.GIS\.Classes\.OpeningGenerationOptions\.ObstructionMaxDistance'); a slender object of [ObstructionSlenderWidth](DiGi.GIS.Classes.md#DiGi.GIS.Classes.OpeningGenerationOptions.ObstructionSlenderWidth 'DiGi\.GIS\.Classes\.OpeningGenerationOptions\.ObstructionSlenderWidth') or less measured parallel to the wall instead answers to [ObstructionSlenderDistance](DiGi.GIS.Classes.md#DiGi.GIS.Classes.OpeningGenerationOptions.ObstructionSlenderDistance 'DiGi\.GIS\.Classes\.OpeningGenerationOptions\.ObstructionSlenderDistance') (§ 13 ust. 3), and [ObstructionInnerCityFactor](DiGi.GIS.Classes.md#DiGi.GIS.Classes.OpeningGenerationOptions.ObstructionInnerCityFactor 'DiGi\.GIS\.Classes\.OpeningGenerationOptions\.ObstructionInnerCityFactor') reduces the result. The wall fails when any axis violates the requirement, and it then gets no windows of rooms for people, doors and the staircase window staying allowed. Distances are measured from the wall plane: a wall with thickness moves the inner face of the statute inward, which only widens the measured distance, so the stricter value is taken here.

Neighbours with the identifier of the model are skipped, so the model may be passed in its own neighbour list, and only those whose bounding box comes within `max(, the largest § 271 distance times the both-sides factor)` are measured. The models themselves are not changed. The overload taking 2D buildings derives each neighbour's height from its storey count at [Default](DiGi.GIS.Analytical.Constants.md#DiGi.GIS.Analytical.Constants.StoreyHeight.Default 'DiGi\.GIS\.Analytical\.Constants\.StoreyHeight\.Default'), and its kind from its function; a model-only neighbour has no function, so with a fuel load stated it takes the row that load describes.

```csharp
public static System.Collections.Generic.List<DiGi.GIS.Classes.WallOpeningResult>? WallOpeningResults(this DiGi.Analytical.Building.Classes.BuildingModel? buildingModel, System.Collections.Generic.IEnumerable<DiGi.Analytical.Building.Classes.BuildingModel?>? buildingModels_Neighbour, DiGi.GIS.Classes.OpeningGenerationOptions? options, System.Nullable<DiGi.GIS.Enums.BuildingGeneralFunction> buildingGeneralFunction=null, double tolerance=1E-06);
```
#### Parameters

<a name='DiGi.GIS.Analytical.Query.WallOpeningResults(thisDiGi.Analytical.Building.Classes.BuildingModel,System.Collections.Generic.IEnumerable_DiGi.Analytical.Building.Classes.BuildingModel_,DiGi.GIS.Classes.OpeningGenerationOptions,System.Nullable_DiGi.GIS.Enums.BuildingGeneralFunction_,double).buildingModel'></a>

`buildingModel` [DiGi\.Analytical\.Building\.Classes\.BuildingModel](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.classes.buildingmodel 'DiGi\.Analytical\.Building\.Classes\.BuildingModel')

The building model examined\. This value can be null\.

<a name='DiGi.GIS.Analytical.Query.WallOpeningResults(thisDiGi.Analytical.Building.Classes.BuildingModel,System.Collections.Generic.IEnumerable_DiGi.Analytical.Building.Classes.BuildingModel_,DiGi.GIS.Classes.OpeningGenerationOptions,System.Nullable_DiGi.GIS.Enums.BuildingGeneralFunction_,double).buildingModels_Neighbour'></a>

`buildingModels_Neighbour` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[DiGi\.Analytical\.Building\.Classes\.BuildingModel](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.classes.buildingmodel 'DiGi\.Analytical\.Building\.Classes\.BuildingModel')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The building models of the adjacent buildings, which get no results themselves\. A model with the identifier of the examined one is skipped\. This value can be null\.

<a name='DiGi.GIS.Analytical.Query.WallOpeningResults(thisDiGi.Analytical.Building.Classes.BuildingModel,System.Collections.Generic.IEnumerable_DiGi.Analytical.Building.Classes.BuildingModel_,DiGi.GIS.Classes.OpeningGenerationOptions,System.Nullable_DiGi.GIS.Enums.BuildingGeneralFunction_,double).options'></a>

`options` [OpeningGenerationOptions](DiGi.GIS.Classes.md#DiGi.GIS.Classes.OpeningGenerationOptions 'DiGi\.GIS\.Classes\.OpeningGenerationOptions')

The rules to apply, or null for the defaults of [OpeningGenerationOptions](DiGi.GIS.Classes.md#DiGi.GIS.Classes.OpeningGenerationOptions 'DiGi\.GIS\.Classes\.OpeningGenerationOptions')\.

<a name='DiGi.GIS.Analytical.Query.WallOpeningResults(thisDiGi.Analytical.Building.Classes.BuildingModel,System.Collections.Generic.IEnumerable_DiGi.Analytical.Building.Classes.BuildingModel_,DiGi.GIS.Classes.OpeningGenerationOptions,System.Nullable_DiGi.GIS.Enums.BuildingGeneralFunction_,double).buildingGeneralFunction'></a>

`buildingGeneralFunction` [System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[DiGi\.GIS\.Enums\.BuildingGeneralFunction](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.enums.buildinggeneralfunction 'DiGi\.GIS\.Enums\.BuildingGeneralFunction')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

The general function of the examined building, giving its [FireClass\(this Nullable&lt;BuildingGeneralFunction&gt;\)](DiGi.GIS.Analytical.md#DiGi.GIS.Analytical.Query.FireClass(thisSystem.Nullable_DiGi.GIS.Enums.BuildingGeneralFunction_) 'DiGi\.GIS\.Analytical\.Query\.FireClass\(this System\.Nullable\<DiGi\.GIS\.Enums\.BuildingGeneralFunction\>\)'), or null when unknown\.

<a name='DiGi.GIS.Analytical.Query.WallOpeningResults(thisDiGi.Analytical.Building.Classes.BuildingModel,System.Collections.Generic.IEnumerable_DiGi.Analytical.Building.Classes.BuildingModel_,DiGi.GIS.Classes.OpeningGenerationOptions,System.Nullable_DiGi.GIS.Enums.BuildingGeneralFunction_,double).tolerance'></a>

`tolerance` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The distance tolerance\.

#### Returns
[System\.Collections\.Generic\.List&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[WallOpeningResult](DiGi.GIS.Classes.md#DiGi.GIS.Classes.WallOpeningResult 'DiGi\.GIS\.Classes\.WallOpeningResult')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')  
One result per external wall that is not a party wall, in envelope order; an empty list when the model has none; or null when the model is null\.

<a name='DiGi.GIS.Analytical.Query.WallOpeningResults(thisDiGi.Analytical.Building.Classes.BuildingModel,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2D_,DiGi.GIS.Classes.OpeningGenerationOptions,System.Nullable_DiGi.GIS.Enums.BuildingGeneralFunction_,double)'></a>

## Query\.WallOpeningResults\(this BuildingModel, IEnumerable\<Building2D\>, OpeningGenerationOptions, Nullable\<BuildingGeneralFunction\>, double\) Method

Gets the same per\-wall neighbour results when only the 2D buildings of the neighbours are known \(DiGi\-Organization/DiGi\.GIS\.Analytical\#9\)\.

Each neighbour is extruded from its footprint at the ground elevation of the examined model to [Default](DiGi.GIS.Analytical.Constants.md#DiGi.GIS.Analytical.Constants.StoreyHeight.Default 'DiGi\.GIS\.Analytical\.Constants\.StoreyHeight\.Default') times its [DiGi\.GIS\.Classes\.Building2D\.Storeys](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.classes.building2d.storeys 'DiGi\.GIS\.Classes\.Building2D\.Storeys') storeys, so its height comes from the 2D building, and its [FireClass\(this Nullable&lt;BuildingGeneralFunction&gt;\)](DiGi.GIS.Analytical.md#DiGi.GIS.Analytical.Query.FireClass(thisSystem.Nullable_DiGi.GIS.Enums.BuildingGeneralFunction_) 'DiGi\.GIS\.Analytical\.Query\.FireClass\(this System\.Nullable\<DiGi\.GIS\.Enums\.BuildingGeneralFunction\>\)') from its general function. The results are those of [WallOpeningResults\(this BuildingModel, IEnumerable&lt;BuildingModel&gt;, OpeningGenerationOptions, Nullable&lt;BuildingGeneralFunction&gt;, double\)](DiGi.GIS.Analytical.md#DiGi.GIS.Analytical.Query.WallOpeningResults(thisDiGi.Analytical.Building.Classes.BuildingModel,System.Collections.Generic.IEnumerable_DiGi.Analytical.Building.Classes.BuildingModel_,DiGi.GIS.Classes.OpeningGenerationOptions,System.Nullable_DiGi.GIS.Enums.BuildingGeneralFunction_,double) 'DiGi\.GIS\.Analytical\.Query\.WallOpeningResults\(this DiGi\.Analytical\.Building\.Classes\.BuildingModel, System\.Collections\.Generic\.IEnumerable\<DiGi\.Analytical\.Building\.Classes\.BuildingModel\>, DiGi\.GIS\.Classes\.OpeningGenerationOptions, System\.Nullable\<DiGi\.GIS\.Enums\.BuildingGeneralFunction\>, double\)').

```csharp
public static System.Collections.Generic.List<DiGi.GIS.Classes.WallOpeningResult>? WallOpeningResults(this DiGi.Analytical.Building.Classes.BuildingModel? buildingModel, System.Collections.Generic.IEnumerable<DiGi.GIS.Classes.Building2D?>? building2Ds_Neighbour, DiGi.GIS.Classes.OpeningGenerationOptions? options, System.Nullable<DiGi.GIS.Enums.BuildingGeneralFunction> buildingGeneralFunction=null, double tolerance=1E-06);
```
#### Parameters

<a name='DiGi.GIS.Analytical.Query.WallOpeningResults(thisDiGi.Analytical.Building.Classes.BuildingModel,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2D_,DiGi.GIS.Classes.OpeningGenerationOptions,System.Nullable_DiGi.GIS.Enums.BuildingGeneralFunction_,double).buildingModel'></a>

`buildingModel` [DiGi\.Analytical\.Building\.Classes\.BuildingModel](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.classes.buildingmodel 'DiGi\.Analytical\.Building\.Classes\.BuildingModel')

The building model examined\. This value can be null\.

<a name='DiGi.GIS.Analytical.Query.WallOpeningResults(thisDiGi.Analytical.Building.Classes.BuildingModel,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2D_,DiGi.GIS.Classes.OpeningGenerationOptions,System.Nullable_DiGi.GIS.Enums.BuildingGeneralFunction_,double).building2Ds_Neighbour'></a>

`building2Ds_Neighbour` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[DiGi\.GIS\.Classes\.Building2D](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.classes.building2d 'DiGi\.GIS\.Classes\.Building2D')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The 2D buildings of the adjacent buildings, extruded for the measurement\. This value can be null\.

<a name='DiGi.GIS.Analytical.Query.WallOpeningResults(thisDiGi.Analytical.Building.Classes.BuildingModel,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2D_,DiGi.GIS.Classes.OpeningGenerationOptions,System.Nullable_DiGi.GIS.Enums.BuildingGeneralFunction_,double).options'></a>

`options` [OpeningGenerationOptions](DiGi.GIS.Classes.md#DiGi.GIS.Classes.OpeningGenerationOptions 'DiGi\.GIS\.Classes\.OpeningGenerationOptions')

The rules to apply, or null for the defaults of [OpeningGenerationOptions](DiGi.GIS.Classes.md#DiGi.GIS.Classes.OpeningGenerationOptions 'DiGi\.GIS\.Classes\.OpeningGenerationOptions')\.

<a name='DiGi.GIS.Analytical.Query.WallOpeningResults(thisDiGi.Analytical.Building.Classes.BuildingModel,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2D_,DiGi.GIS.Classes.OpeningGenerationOptions,System.Nullable_DiGi.GIS.Enums.BuildingGeneralFunction_,double).buildingGeneralFunction'></a>

`buildingGeneralFunction` [System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[DiGi\.GIS\.Enums\.BuildingGeneralFunction](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.enums.buildinggeneralfunction 'DiGi\.GIS\.Enums\.BuildingGeneralFunction')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

The general function of the examined building, giving its [FireClass\(this Nullable&lt;BuildingGeneralFunction&gt;\)](DiGi.GIS.Analytical.md#DiGi.GIS.Analytical.Query.FireClass(thisSystem.Nullable_DiGi.GIS.Enums.BuildingGeneralFunction_) 'DiGi\.GIS\.Analytical\.Query\.FireClass\(this System\.Nullable\<DiGi\.GIS\.Enums\.BuildingGeneralFunction\>\)'), or null when unknown\.

<a name='DiGi.GIS.Analytical.Query.WallOpeningResults(thisDiGi.Analytical.Building.Classes.BuildingModel,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2D_,DiGi.GIS.Classes.OpeningGenerationOptions,System.Nullable_DiGi.GIS.Enums.BuildingGeneralFunction_,double).tolerance'></a>

`tolerance` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The distance tolerance\.

#### Returns
[System\.Collections\.Generic\.List&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[WallOpeningResult](DiGi.GIS.Classes.md#DiGi.GIS.Classes.WallOpeningResult 'DiGi\.GIS\.Classes\.WallOpeningResult')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')  
One result per external wall that is not a party wall, in envelope order; an empty list when the model has none; or null when the model is null\.