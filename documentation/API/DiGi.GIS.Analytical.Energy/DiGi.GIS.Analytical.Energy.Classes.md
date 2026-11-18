#### [DiGi\.GIS\.Analytical\.Energy](DiGi.GIS.Analytical.Energy.Overview.md 'DiGi\.GIS\.Analytical\.Energy\.Overview')

## DiGi\.GIS\.Analytical\.Energy\.Classes Namespace
### Classes

<a name='DiGi.GIS.Analytical.Energy.Classes.BuildingHeatDemandResult'></a>

## BuildingHeatDemandResult Class

Represents the monthly heat demand of a stored GIS building with the provenance of its inputs \(DiGi\-Organization/DiGi\.GIS\.Analytical\#14, for DiGi\-Organization/DiGi\.Analytical\#10\): what the model, the climate and the constructions were taken from, and the nested [DiGi\.Analytical\.Building\.Energy\.Classes\.HeatDemandResult](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.energy.classes.heatdemandresult 'DiGi\.Analytical\.Building\.Energy\.Classes\.HeatDemandResult')\.

Created by `Create.BuildingHeatDemandResult`; stored by DiGi.GIS.PostgreSQL in `building_heat_demand`. The constructor only assigns and clones.

```csharp
public class BuildingHeatDemandResult : DiGi.Core.Classes.SerializableResult, DiGi.GIS.Interfaces.IGISSerializableObject, DiGi.GIS.Interfaces.IGISObject, DiGi.Core.Interfaces.IObject, DiGi.Core.Interfaces.ISerializableObject, DiGi.Core.Interfaces.ICloneableObject<DiGi.Core.Interfaces.ISerializableObject>, DiGi.Core.Interfaces.ICloneableObject
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [DiGi\.Core\.Classes\.Object](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.object 'DiGi\.Core\.Classes\.Object') → [DiGi\.Core\.Classes\.SerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.serializableobject 'DiGi\.Core\.Classes\.SerializableObject') → [DiGi\.Core\.Classes\.SerializableResult](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.serializableresult 'DiGi\.Core\.Classes\.SerializableResult') → BuildingHeatDemandResult

Implements [DiGi\.GIS\.Interfaces\.IGISSerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.interfaces.igisserializableobject 'DiGi\.GIS\.Interfaces\.IGISSerializableObject'), [DiGi\.GIS\.Interfaces\.IGISObject](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.interfaces.igisobject 'DiGi\.GIS\.Interfaces\.IGISObject'), [DiGi\.Core\.Interfaces\.IObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iobject 'DiGi\.Core\.Interfaces\.IObject'), [DiGi\.Core\.Interfaces\.ISerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iserializableobject 'DiGi\.Core\.Interfaces\.ISerializableObject'), [DiGi\.Core\.Interfaces\.ICloneableObject&lt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject-1 'DiGi\.Core\.Interfaces\.ICloneableObject\`1')[DiGi\.Core\.Interfaces\.ISerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iserializableobject 'DiGi\.Core\.Interfaces\.ISerializableObject')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject-1 'DiGi\.Core\.Interfaces\.ICloneableObject\`1'), [DiGi\.Core\.Interfaces\.ICloneableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject 'DiGi\.Core\.Interfaces\.ICloneableObject')
### Constructors

<a name='DiGi.GIS.Analytical.Energy.Classes.BuildingHeatDemandResult.BuildingHeatDemandResult(DiGi.GIS.Analytical.Energy.Classes.BuildingHeatDemandResult)'></a>

## BuildingHeatDemandResult\(BuildingHeatDemandResult\) Constructor

Initializes a new instance of the [BuildingHeatDemandResult](DiGi.GIS.Analytical.Energy.Classes.md#DiGi.GIS.Analytical.Energy.Classes.BuildingHeatDemandResult 'DiGi\.GIS\.Analytical\.Energy\.Classes\.BuildingHeatDemandResult') class by copying an existing instance\.

```csharp
public BuildingHeatDemandResult(DiGi.GIS.Analytical.Energy.Classes.BuildingHeatDemandResult? buildingHeatDemandResult);
```
#### Parameters

<a name='DiGi.GIS.Analytical.Energy.Classes.BuildingHeatDemandResult.BuildingHeatDemandResult(DiGi.GIS.Analytical.Energy.Classes.BuildingHeatDemandResult).buildingHeatDemandResult'></a>

`buildingHeatDemandResult` [BuildingHeatDemandResult](DiGi.GIS.Analytical.Energy.Classes.md#DiGi.GIS.Analytical.Energy.Classes.BuildingHeatDemandResult 'DiGi\.GIS\.Analytical\.Energy\.Classes\.BuildingHeatDemandResult')

The [BuildingHeatDemandResult](DiGi.GIS.Analytical.Energy.Classes.md#DiGi.GIS.Analytical.Energy.Classes.BuildingHeatDemandResult 'DiGi\.GIS\.Analytical\.Energy\.Classes\.BuildingHeatDemandResult') to copy\. This value can be null\.

<a name='DiGi.GIS.Analytical.Energy.Classes.BuildingHeatDemandResult.BuildingHeatDemandResult(string,int,long,DiGi.GIS.Enums.WeatherSourceType,string,DiGi.GIS.Analytical.Energy.Enums.HeatDemandSolarSource,System.Nullable_int_,System.Nullable_double_,int,int,DiGi.Analytical.Building.Regulation.Enums.ConstructionFlavour,string,string,DiGi.Analytical.Building.Regulation.Enums.BuildingType,System.Nullable_short_,System.Nullable_DiGi.GIS.Enums.YearBuiltSource_,string,System.Nullable_System.DateTimeOffset_,DiGi.Analytical.Building.Energy.Classes.HeatDemandResult)'></a>

## BuildingHeatDemandResult\(string, int, long, WeatherSourceType, string, HeatDemandSolarSource, Nullable\<int\>, Nullable\<double\>, int, int, ConstructionFlavour, string, string, BuildingType, Nullable\<short\>, Nullable\<YearBuiltSource\>, string, Nullable\<DateTimeOffset\>, HeatDemandResult\) Constructor

Initializes a new instance of the [BuildingHeatDemandResult](DiGi.GIS.Analytical.Energy.Classes.md#DiGi.GIS.Analytical.Energy.Classes.BuildingHeatDemandResult 'DiGi\.GIS\.Analytical\.Energy\.Classes\.BuildingHeatDemandResult') class\.

The values are assigned and the heat-demand result cloned; `Create.BuildingHeatDemandResult` computes them.

```csharp
public BuildingHeatDemandResult(string? reference, int countyId, long buildingModelId, DiGi.GIS.Enums.WeatherSourceType weatherSourceType, string? weatherSourceId, DiGi.GIS.Analytical.Energy.Enums.HeatDemandSolarSource solarSource, System.Nullable<int> solarSolverVersion, System.Nullable<double> solarRadius, int matchedSurfaceCount, int unshadedSurfaceCount, DiGi.Analytical.Building.Regulation.Enums.ConstructionFlavour constructionFlavour, string? constructionLibraryVersion, string? constructionSetSource, DiGi.Analytical.Building.Regulation.Enums.BuildingType buildingType, System.Nullable<short> yearBuilt, System.Nullable<DiGi.GIS.Enums.YearBuiltSource> yearBuiltSource, string? usageSource, System.Nullable<System.DateTimeOffset> createdAt, DiGi.Analytical.Building.Energy.Classes.HeatDemandResult? heatDemandResult);
```
#### Parameters

<a name='DiGi.GIS.Analytical.Energy.Classes.BuildingHeatDemandResult.BuildingHeatDemandResult(string,int,long,DiGi.GIS.Enums.WeatherSourceType,string,DiGi.GIS.Analytical.Energy.Enums.HeatDemandSolarSource,System.Nullable_int_,System.Nullable_double_,int,int,DiGi.Analytical.Building.Regulation.Enums.ConstructionFlavour,string,string,DiGi.Analytical.Building.Regulation.Enums.BuildingType,System.Nullable_short_,System.Nullable_DiGi.GIS.Enums.YearBuiltSource_,string,System.Nullable_System.DateTimeOffset_,DiGi.Analytical.Building.Energy.Classes.HeatDemandResult).reference'></a>

`reference` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The `building_2d` reference of the building\. This value can be null\.

<a name='DiGi.GIS.Analytical.Energy.Classes.BuildingHeatDemandResult.BuildingHeatDemandResult(string,int,long,DiGi.GIS.Enums.WeatherSourceType,string,DiGi.GIS.Analytical.Energy.Enums.HeatDemandSolarSource,System.Nullable_int_,System.Nullable_double_,int,int,DiGi.Analytical.Building.Regulation.Enums.ConstructionFlavour,string,string,DiGi.Analytical.Building.Regulation.Enums.BuildingType,System.Nullable_short_,System.Nullable_DiGi.GIS.Enums.YearBuiltSource_,string,System.Nullable_System.DateTimeOffset_,DiGi.Analytical.Building.Energy.Classes.HeatDemandResult).countyId'></a>

`countyId` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The id of the county part the building is filed under\.

<a name='DiGi.GIS.Analytical.Energy.Classes.BuildingHeatDemandResult.BuildingHeatDemandResult(string,int,long,DiGi.GIS.Enums.WeatherSourceType,string,DiGi.GIS.Analytical.Energy.Enums.HeatDemandSolarSource,System.Nullable_int_,System.Nullable_double_,int,int,DiGi.Analytical.Building.Regulation.Enums.ConstructionFlavour,string,string,DiGi.Analytical.Building.Regulation.Enums.BuildingType,System.Nullable_short_,System.Nullable_DiGi.GIS.Enums.YearBuiltSource_,string,System.Nullable_System.DateTimeOffset_,DiGi.Analytical.Building.Energy.Classes.HeatDemandResult).buildingModelId'></a>

`buildingModelId` [System\.Int64](https://learn.microsoft.com/en-us/dotnet/api/system.int64 'System\.Int64')

The id of the stored building model the result was calculated from\.

<a name='DiGi.GIS.Analytical.Energy.Classes.BuildingHeatDemandResult.BuildingHeatDemandResult(string,int,long,DiGi.GIS.Enums.WeatherSourceType,string,DiGi.GIS.Analytical.Energy.Enums.HeatDemandSolarSource,System.Nullable_int_,System.Nullable_double_,int,int,DiGi.Analytical.Building.Regulation.Enums.ConstructionFlavour,string,string,DiGi.Analytical.Building.Regulation.Enums.BuildingType,System.Nullable_short_,System.Nullable_DiGi.GIS.Enums.YearBuiltSource_,string,System.Nullable_System.DateTimeOffset_,DiGi.Analytical.Building.Energy.Classes.HeatDemandResult).weatherSourceType'></a>

`weatherSourceType` [DiGi\.GIS\.Enums\.WeatherSourceType](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.enums.weathersourcetype 'DiGi\.GIS\.Enums\.WeatherSourceType')

The kind of the weather source of the temperatures and irradiation\.

<a name='DiGi.GIS.Analytical.Energy.Classes.BuildingHeatDemandResult.BuildingHeatDemandResult(string,int,long,DiGi.GIS.Enums.WeatherSourceType,string,DiGi.GIS.Analytical.Energy.Enums.HeatDemandSolarSource,System.Nullable_int_,System.Nullable_double_,int,int,DiGi.Analytical.Building.Regulation.Enums.ConstructionFlavour,string,string,DiGi.Analytical.Building.Regulation.Enums.BuildingType,System.Nullable_short_,System.Nullable_DiGi.GIS.Enums.YearBuiltSource_,string,System.Nullable_System.DateTimeOffset_,DiGi.Analytical.Building.Energy.Classes.HeatDemandResult).weatherSourceId'></a>

`weatherSourceId` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The id of the weather source \(the `epw_file` id of an EPW source\)\. This value can be null\.

<a name='DiGi.GIS.Analytical.Energy.Classes.BuildingHeatDemandResult.BuildingHeatDemandResult(string,int,long,DiGi.GIS.Enums.WeatherSourceType,string,DiGi.GIS.Analytical.Energy.Enums.HeatDemandSolarSource,System.Nullable_int_,System.Nullable_double_,int,int,DiGi.Analytical.Building.Regulation.Enums.ConstructionFlavour,string,string,DiGi.Analytical.Building.Regulation.Enums.BuildingType,System.Nullable_short_,System.Nullable_DiGi.GIS.Enums.YearBuiltSource_,string,System.Nullable_System.DateTimeOffset_,DiGi.Analytical.Building.Energy.Classes.HeatDemandResult).solarSource'></a>

`solarSource` [HeatDemandSolarSource](DiGi.GIS.Analytical.Energy.Enums.md#DiGi.GIS.Analytical.Energy.Enums.HeatDemandSolarSource 'DiGi\.GIS\.Analytical\.Energy\.Enums\.HeatDemandSolarSource')

Where the irradiation of the external surfaces comes from\.

<a name='DiGi.GIS.Analytical.Energy.Classes.BuildingHeatDemandResult.BuildingHeatDemandResult(string,int,long,DiGi.GIS.Enums.WeatherSourceType,string,DiGi.GIS.Analytical.Energy.Enums.HeatDemandSolarSource,System.Nullable_int_,System.Nullable_double_,int,int,DiGi.Analytical.Building.Regulation.Enums.ConstructionFlavour,string,string,DiGi.Analytical.Building.Regulation.Enums.BuildingType,System.Nullable_short_,System.Nullable_DiGi.GIS.Enums.YearBuiltSource_,string,System.Nullable_System.DateTimeOffset_,DiGi.Analytical.Building.Energy.Classes.HeatDemandResult).solarSolverVersion'></a>

`solarSolverVersion` [System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

The solver version of the stored solar result, or null when none was used\.

<a name='DiGi.GIS.Analytical.Energy.Classes.BuildingHeatDemandResult.BuildingHeatDemandResult(string,int,long,DiGi.GIS.Enums.WeatherSourceType,string,DiGi.GIS.Analytical.Energy.Enums.HeatDemandSolarSource,System.Nullable_int_,System.Nullable_double_,int,int,DiGi.Analytical.Building.Regulation.Enums.ConstructionFlavour,string,string,DiGi.Analytical.Building.Regulation.Enums.BuildingType,System.Nullable_short_,System.Nullable_DiGi.GIS.Enums.YearBuiltSource_,string,System.Nullable_System.DateTimeOffset_,DiGi.Analytical.Building.Energy.Classes.HeatDemandResult).solarRadius'></a>

`solarRadius` [System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

The neighbour radius of the stored solar result \[m\], or null when none was used\.

<a name='DiGi.GIS.Analytical.Energy.Classes.BuildingHeatDemandResult.BuildingHeatDemandResult(string,int,long,DiGi.GIS.Enums.WeatherSourceType,string,DiGi.GIS.Analytical.Energy.Enums.HeatDemandSolarSource,System.Nullable_int_,System.Nullable_double_,int,int,DiGi.Analytical.Building.Regulation.Enums.ConstructionFlavour,string,string,DiGi.Analytical.Building.Regulation.Enums.BuildingType,System.Nullable_short_,System.Nullable_DiGi.GIS.Enums.YearBuiltSource_,string,System.Nullable_System.DateTimeOffset_,DiGi.Analytical.Building.Energy.Classes.HeatDemandResult).matchedSurfaceCount'></a>

`matchedSurfaceCount` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of external surfaces created by the party\-wall split and matched to the stored solar surface of the wall they were split from\.

<a name='DiGi.GIS.Analytical.Energy.Classes.BuildingHeatDemandResult.BuildingHeatDemandResult(string,int,long,DiGi.GIS.Enums.WeatherSourceType,string,DiGi.GIS.Analytical.Energy.Enums.HeatDemandSolarSource,System.Nullable_int_,System.Nullable_double_,int,int,DiGi.Analytical.Building.Regulation.Enums.ConstructionFlavour,string,string,DiGi.Analytical.Building.Regulation.Enums.BuildingType,System.Nullable_short_,System.Nullable_DiGi.GIS.Enums.YearBuiltSource_,string,System.Nullable_System.DateTimeOffset_,DiGi.Analytical.Building.Energy.Classes.HeatDemandResult).unshadedSurfaceCount'></a>

`unshadedSurfaceCount` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of external surfaces that took the unshaded irradiation of their orientation and tilt, having no stored solar surface\.

<a name='DiGi.GIS.Analytical.Energy.Classes.BuildingHeatDemandResult.BuildingHeatDemandResult(string,int,long,DiGi.GIS.Enums.WeatherSourceType,string,DiGi.GIS.Analytical.Energy.Enums.HeatDemandSolarSource,System.Nullable_int_,System.Nullable_double_,int,int,DiGi.Analytical.Building.Regulation.Enums.ConstructionFlavour,string,string,DiGi.Analytical.Building.Regulation.Enums.BuildingType,System.Nullable_short_,System.Nullable_DiGi.GIS.Enums.YearBuiltSource_,string,System.Nullable_System.DateTimeOffset_,DiGi.Analytical.Building.Energy.Classes.HeatDemandResult).constructionFlavour'></a>

`constructionFlavour` [DiGi\.Analytical\.Building\.Regulation\.Enums\.ConstructionFlavour](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.regulation.enums.constructionflavour 'DiGi\.Analytical\.Building\.Regulation\.Enums\.ConstructionFlavour')

The construction flavour of the envelope and the openings\.

<a name='DiGi.GIS.Analytical.Energy.Classes.BuildingHeatDemandResult.BuildingHeatDemandResult(string,int,long,DiGi.GIS.Enums.WeatherSourceType,string,DiGi.GIS.Analytical.Energy.Enums.HeatDemandSolarSource,System.Nullable_int_,System.Nullable_double_,int,int,DiGi.Analytical.Building.Regulation.Enums.ConstructionFlavour,string,string,DiGi.Analytical.Building.Regulation.Enums.BuildingType,System.Nullable_short_,System.Nullable_DiGi.GIS.Enums.YearBuiltSource_,string,System.Nullable_System.DateTimeOffset_,DiGi.Analytical.Building.Energy.Classes.HeatDemandResult).constructionLibraryVersion'></a>

`constructionLibraryVersion` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The version of the construction library\. This value can be null\.

<a name='DiGi.GIS.Analytical.Energy.Classes.BuildingHeatDemandResult.BuildingHeatDemandResult(string,int,long,DiGi.GIS.Enums.WeatherSourceType,string,DiGi.GIS.Analytical.Energy.Enums.HeatDemandSolarSource,System.Nullable_int_,System.Nullable_double_,int,int,DiGi.Analytical.Building.Regulation.Enums.ConstructionFlavour,string,string,DiGi.Analytical.Building.Regulation.Enums.BuildingType,System.Nullable_short_,System.Nullable_DiGi.GIS.Enums.YearBuiltSource_,string,System.Nullable_System.DateTimeOffset_,DiGi.Analytical.Building.Energy.Classes.HeatDemandResult).constructionSetSource'></a>

`constructionSetSource` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The source text of the construction set used\. This value can be null\.

<a name='DiGi.GIS.Analytical.Energy.Classes.BuildingHeatDemandResult.BuildingHeatDemandResult(string,int,long,DiGi.GIS.Enums.WeatherSourceType,string,DiGi.GIS.Analytical.Energy.Enums.HeatDemandSolarSource,System.Nullable_int_,System.Nullable_double_,int,int,DiGi.Analytical.Building.Regulation.Enums.ConstructionFlavour,string,string,DiGi.Analytical.Building.Regulation.Enums.BuildingType,System.Nullable_short_,System.Nullable_DiGi.GIS.Enums.YearBuiltSource_,string,System.Nullable_System.DateTimeOffset_,DiGi.Analytical.Building.Energy.Classes.HeatDemandResult).buildingType'></a>

`buildingType` [DiGi\.Analytical\.Building\.Regulation\.Enums\.BuildingType](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.regulation.enums.buildingtype 'DiGi\.Analytical\.Building\.Regulation\.Enums\.BuildingType')

The building type the constructions and openings were looked up for\.

<a name='DiGi.GIS.Analytical.Energy.Classes.BuildingHeatDemandResult.BuildingHeatDemandResult(string,int,long,DiGi.GIS.Enums.WeatherSourceType,string,DiGi.GIS.Analytical.Energy.Enums.HeatDemandSolarSource,System.Nullable_int_,System.Nullable_double_,int,int,DiGi.Analytical.Building.Regulation.Enums.ConstructionFlavour,string,string,DiGi.Analytical.Building.Regulation.Enums.BuildingType,System.Nullable_short_,System.Nullable_DiGi.GIS.Enums.YearBuiltSource_,string,System.Nullable_System.DateTimeOffset_,DiGi.Analytical.Building.Energy.Classes.HeatDemandResult).yearBuilt'></a>

`yearBuilt` [System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Int16](https://learn.microsoft.com/en-us/dotnet/api/system.int16 'System\.Int16')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

The year built, or null when unknown\.

<a name='DiGi.GIS.Analytical.Energy.Classes.BuildingHeatDemandResult.BuildingHeatDemandResult(string,int,long,DiGi.GIS.Enums.WeatherSourceType,string,DiGi.GIS.Analytical.Energy.Enums.HeatDemandSolarSource,System.Nullable_int_,System.Nullable_double_,int,int,DiGi.Analytical.Building.Regulation.Enums.ConstructionFlavour,string,string,DiGi.Analytical.Building.Regulation.Enums.BuildingType,System.Nullable_short_,System.Nullable_DiGi.GIS.Enums.YearBuiltSource_,string,System.Nullable_System.DateTimeOffset_,DiGi.Analytical.Building.Energy.Classes.HeatDemandResult).yearBuiltSource'></a>

`yearBuiltSource` [System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[DiGi\.GIS\.Enums\.YearBuiltSource](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.enums.yearbuiltsource 'DiGi\.GIS\.Enums\.YearBuiltSource')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

Where the year built comes from, or null when unknown\.

<a name='DiGi.GIS.Analytical.Energy.Classes.BuildingHeatDemandResult.BuildingHeatDemandResult(string,int,long,DiGi.GIS.Enums.WeatherSourceType,string,DiGi.GIS.Analytical.Energy.Enums.HeatDemandSolarSource,System.Nullable_int_,System.Nullable_double_,int,int,DiGi.Analytical.Building.Regulation.Enums.ConstructionFlavour,string,string,DiGi.Analytical.Building.Regulation.Enums.BuildingType,System.Nullable_short_,System.Nullable_DiGi.GIS.Enums.YearBuiltSource_,string,System.Nullable_System.DateTimeOffset_,DiGi.Analytical.Building.Energy.Classes.HeatDemandResult).usageSource'></a>

`usageSource` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The source of the usage profile of the internal conditions, a fallback rule included\. This value can be null\.

<a name='DiGi.GIS.Analytical.Energy.Classes.BuildingHeatDemandResult.BuildingHeatDemandResult(string,int,long,DiGi.GIS.Enums.WeatherSourceType,string,DiGi.GIS.Analytical.Energy.Enums.HeatDemandSolarSource,System.Nullable_int_,System.Nullable_double_,int,int,DiGi.Analytical.Building.Regulation.Enums.ConstructionFlavour,string,string,DiGi.Analytical.Building.Regulation.Enums.BuildingType,System.Nullable_short_,System.Nullable_DiGi.GIS.Enums.YearBuiltSource_,string,System.Nullable_System.DateTimeOffset_,DiGi.Analytical.Building.Energy.Classes.HeatDemandResult).createdAt'></a>

`createdAt` [System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.DateTimeOffset](https://learn.microsoft.com/en-us/dotnet/api/system.datetimeoffset 'System\.DateTimeOffset')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

When the result was calculated\.

<a name='DiGi.GIS.Analytical.Energy.Classes.BuildingHeatDemandResult.BuildingHeatDemandResult(string,int,long,DiGi.GIS.Enums.WeatherSourceType,string,DiGi.GIS.Analytical.Energy.Enums.HeatDemandSolarSource,System.Nullable_int_,System.Nullable_double_,int,int,DiGi.Analytical.Building.Regulation.Enums.ConstructionFlavour,string,string,DiGi.Analytical.Building.Regulation.Enums.BuildingType,System.Nullable_short_,System.Nullable_DiGi.GIS.Enums.YearBuiltSource_,string,System.Nullable_System.DateTimeOffset_,DiGi.Analytical.Building.Energy.Classes.HeatDemandResult).heatDemandResult'></a>

`heatDemandResult` [DiGi\.Analytical\.Building\.Energy\.Classes\.HeatDemandResult](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.energy.classes.heatdemandresult 'DiGi\.Analytical\.Building\.Energy\.Classes\.HeatDemandResult')

The monthly heat demand of the building\. This value can be null\.

<a name='DiGi.GIS.Analytical.Energy.Classes.BuildingHeatDemandResult.BuildingHeatDemandResult(System.Text.Json.Nodes.JsonObject)'></a>

## BuildingHeatDemandResult\(JsonObject\) Constructor

Initializes a new instance of the [BuildingHeatDemandResult](DiGi.GIS.Analytical.Energy.Classes.md#DiGi.GIS.Analytical.Energy.Classes.BuildingHeatDemandResult 'DiGi\.GIS\.Analytical\.Energy\.Classes\.BuildingHeatDemandResult') class from a JSON object\.

```csharp
public BuildingHeatDemandResult(System.Text.Json.Nodes.JsonObject? jsonObject);
```
#### Parameters

<a name='DiGi.GIS.Analytical.Energy.Classes.BuildingHeatDemandResult.BuildingHeatDemandResult(System.Text.Json.Nodes.JsonObject).jsonObject'></a>

`jsonObject` [System\.Text\.Json\.Nodes\.JsonObject](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.nodes.jsonobject 'System\.Text\.Json\.Nodes\.JsonObject')

The JSON object containing the data\. This value can be null\.
### Properties

<a name='DiGi.GIS.Analytical.Energy.Classes.BuildingHeatDemandResult.BuildingModelId'></a>

## BuildingHeatDemandResult\.BuildingModelId Property

Gets the id of the stored building model the result was calculated from\.

```csharp
public long BuildingModelId { get; }
```

#### Property Value
[System\.Int64](https://learn.microsoft.com/en-us/dotnet/api/system.int64 'System\.Int64')

<a name='DiGi.GIS.Analytical.Energy.Classes.BuildingHeatDemandResult.BuildingType'></a>

## BuildingHeatDemandResult\.BuildingType Property

Gets the building type the constructions and openings were looked up for\.

```csharp
public DiGi.Analytical.Building.Regulation.Enums.BuildingType BuildingType { get; }
```

#### Property Value
[DiGi\.Analytical\.Building\.Regulation\.Enums\.BuildingType](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.regulation.enums.buildingtype 'DiGi\.Analytical\.Building\.Regulation\.Enums\.BuildingType')

<a name='DiGi.GIS.Analytical.Energy.Classes.BuildingHeatDemandResult.ConstructionFlavour'></a>

## BuildingHeatDemandResult\.ConstructionFlavour Property

Gets the construction flavour of the envelope and the openings\.

```csharp
public DiGi.Analytical.Building.Regulation.Enums.ConstructionFlavour ConstructionFlavour { get; }
```

#### Property Value
[DiGi\.Analytical\.Building\.Regulation\.Enums\.ConstructionFlavour](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.regulation.enums.constructionflavour 'DiGi\.Analytical\.Building\.Regulation\.Enums\.ConstructionFlavour')

<a name='DiGi.GIS.Analytical.Energy.Classes.BuildingHeatDemandResult.ConstructionLibraryVersion'></a>

## BuildingHeatDemandResult\.ConstructionLibraryVersion Property

Gets the version of the construction library\.

```csharp
public string? ConstructionLibraryVersion { get; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.GIS.Analytical.Energy.Classes.BuildingHeatDemandResult.ConstructionSetSource'></a>

## BuildingHeatDemandResult\.ConstructionSetSource Property

Gets the source text of the construction set used\.

```csharp
public string? ConstructionSetSource { get; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.GIS.Analytical.Energy.Classes.BuildingHeatDemandResult.CountyId'></a>

## BuildingHeatDemandResult\.CountyId Property

Gets the id of the county part the building is filed under\.

```csharp
public int CountyId { get; }
```

#### Property Value
[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

<a name='DiGi.GIS.Analytical.Energy.Classes.BuildingHeatDemandResult.CreatedAt'></a>

## BuildingHeatDemandResult\.CreatedAt Property

Gets when the result was calculated\.

```csharp
public System.Nullable<System.DateTimeOffset> CreatedAt { get; }
```

#### Property Value
[System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.DateTimeOffset](https://learn.microsoft.com/en-us/dotnet/api/system.datetimeoffset 'System\.DateTimeOffset')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

<a name='DiGi.GIS.Analytical.Energy.Classes.BuildingHeatDemandResult.HeatDemandResult'></a>

## BuildingHeatDemandResult\.HeatDemandResult Property

Gets a clone of the monthly heat demand of the building\.

```csharp
public DiGi.Analytical.Building.Energy.Classes.HeatDemandResult? HeatDemandResult { get; }
```

#### Property Value
[DiGi\.Analytical\.Building\.Energy\.Classes\.HeatDemandResult](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.energy.classes.heatdemandresult 'DiGi\.Analytical\.Building\.Energy\.Classes\.HeatDemandResult')

<a name='DiGi.GIS.Analytical.Energy.Classes.BuildingHeatDemandResult.MatchedSurfaceCount'></a>

## BuildingHeatDemandResult\.MatchedSurfaceCount Property

Gets the number of external surfaces created by the party\-wall split and matched to the stored solar surface of the wall they were split from\.

```csharp
public int MatchedSurfaceCount { get; }
```

#### Property Value
[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

<a name='DiGi.GIS.Analytical.Energy.Classes.BuildingHeatDemandResult.Reference'></a>

## BuildingHeatDemandResult\.Reference Property

Gets the `building_2d` reference of the building\.

```csharp
public string? Reference { get; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.GIS.Analytical.Energy.Classes.BuildingHeatDemandResult.SolarRadius'></a>

## BuildingHeatDemandResult\.SolarRadius Property

Gets the neighbour radius of the stored solar result \[m\], or null when none was used\.

```csharp
public System.Nullable<double> SolarRadius { get; }
```

#### Property Value
[System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

<a name='DiGi.GIS.Analytical.Energy.Classes.BuildingHeatDemandResult.SolarSolverVersion'></a>

## BuildingHeatDemandResult\.SolarSolverVersion Property

Gets the solver version of the stored solar result, or null when none was used\.

```csharp
public System.Nullable<int> SolarSolverVersion { get; }
```

#### Property Value
[System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

<a name='DiGi.GIS.Analytical.Energy.Classes.BuildingHeatDemandResult.SolarSource'></a>

## BuildingHeatDemandResult\.SolarSource Property

Gets where the irradiation of the external surfaces comes from\.

```csharp
public DiGi.GIS.Analytical.Energy.Enums.HeatDemandSolarSource SolarSource { get; }
```

#### Property Value
[HeatDemandSolarSource](DiGi.GIS.Analytical.Energy.Enums.md#DiGi.GIS.Analytical.Energy.Enums.HeatDemandSolarSource 'DiGi\.GIS\.Analytical\.Energy\.Enums\.HeatDemandSolarSource')

<a name='DiGi.GIS.Analytical.Energy.Classes.BuildingHeatDemandResult.UnshadedSurfaceCount'></a>

## BuildingHeatDemandResult\.UnshadedSurfaceCount Property

Gets the number of external surfaces that took the unshaded irradiation of their orientation and tilt, having no stored solar surface\.

```csharp
public int UnshadedSurfaceCount { get; }
```

#### Property Value
[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

<a name='DiGi.GIS.Analytical.Energy.Classes.BuildingHeatDemandResult.UsageSource'></a>

## BuildingHeatDemandResult\.UsageSource Property

Gets the source of the usage profile of the internal conditions, a fallback rule included\.

```csharp
public string? UsageSource { get; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.GIS.Analytical.Energy.Classes.BuildingHeatDemandResult.WeatherSourceId'></a>

## BuildingHeatDemandResult\.WeatherSourceId Property

Gets the id of the weather source \(the `epw_file` id of an EPW source\)\.

```csharp
public string? WeatherSourceId { get; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.GIS.Analytical.Energy.Classes.BuildingHeatDemandResult.WeatherSourceType'></a>

## BuildingHeatDemandResult\.WeatherSourceType Property

Gets the kind of the weather source of the temperatures and irradiation\.

```csharp
public DiGi.GIS.Enums.WeatherSourceType WeatherSourceType { get; }
```

#### Property Value
[DiGi\.GIS\.Enums\.WeatherSourceType](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.enums.weathersourcetype 'DiGi\.GIS\.Enums\.WeatherSourceType')

<a name='DiGi.GIS.Analytical.Energy.Classes.BuildingHeatDemandResult.YearBuilt'></a>

## BuildingHeatDemandResult\.YearBuilt Property

Gets the year built, or null when unknown\.

```csharp
public System.Nullable<short> YearBuilt { get; }
```

#### Property Value
[System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Int16](https://learn.microsoft.com/en-us/dotnet/api/system.int16 'System\.Int16')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

<a name='DiGi.GIS.Analytical.Energy.Classes.BuildingHeatDemandResult.YearBuiltSource'></a>

## BuildingHeatDemandResult\.YearBuiltSource Property

Gets where the year built comes from, or null when unknown\.

```csharp
public System.Nullable<DiGi.GIS.Enums.YearBuiltSource> YearBuiltSource { get; }
```

#### Property Value
[System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[DiGi\.GIS\.Enums\.YearBuiltSource](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.enums.yearbuiltsource 'DiGi\.GIS\.Enums\.YearBuiltSource')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

<a name='DiGi.GIS.Analytical.Energy.Classes.HeatDemandContext'></a>

## HeatDemandContext Class

Holds the inputs of the heat\-demand assembly shared by every building of a batch, read or created once per batch \(DiGi\-Organization/DiGi\.GIS\.Analytical\#14\): the construction library, the opening\-size library, the climate\-zone map and the heat\-demand options\.

Not serializable: the libraries are large and versioned on their own, and the batch records their versions in each result instead.

```csharp
public class HeatDemandContext
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → HeatDemandContext
### Constructors

<a name='DiGi.GIS.Analytical.Energy.Classes.HeatDemandContext.HeatDemandContext(DiGi.Analytical.Building.Regulation.Classes.ConstructionLibrary,DiGi.Analytical.Building.Regulation.Classes.OpeningSizeLibrary,DiGi.GIS.Classes.ClimateZoneMap,DiGi.Analytical.Building.Energy.Classes.HeatDemandOptions)'></a>

## HeatDemandContext\(ConstructionLibrary, OpeningSizeLibrary, ClimateZoneMap, HeatDemandOptions\) Constructor

Initializes a new instance of the [HeatDemandContext](DiGi.GIS.Analytical.Energy.Classes.md#DiGi.GIS.Analytical.Energy.Classes.HeatDemandContext 'DiGi\.GIS\.Analytical\.Energy\.Classes\.HeatDemandContext') class\.

```csharp
public HeatDemandContext(DiGi.Analytical.Building.Regulation.Classes.ConstructionLibrary? constructionLibrary, DiGi.Analytical.Building.Regulation.Classes.OpeningSizeLibrary? openingSizeLibrary, DiGi.GIS.Classes.ClimateZoneMap? climateZoneMap, DiGi.Analytical.Building.Energy.Classes.HeatDemandOptions? heatDemandOptions);
```
#### Parameters

<a name='DiGi.GIS.Analytical.Energy.Classes.HeatDemandContext.HeatDemandContext(DiGi.Analytical.Building.Regulation.Classes.ConstructionLibrary,DiGi.Analytical.Building.Regulation.Classes.OpeningSizeLibrary,DiGi.GIS.Classes.ClimateZoneMap,DiGi.Analytical.Building.Energy.Classes.HeatDemandOptions).constructionLibrary'></a>

`constructionLibrary` [DiGi\.Analytical\.Building\.Regulation\.Classes\.ConstructionLibrary](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.regulation.classes.constructionlibrary 'DiGi\.Analytical\.Building\.Regulation\.Classes\.ConstructionLibrary')

The construction library, or null for `Regulation.Query.EmbeddedConstructionLibrary_PL()` read per call\.

<a name='DiGi.GIS.Analytical.Energy.Classes.HeatDemandContext.HeatDemandContext(DiGi.Analytical.Building.Regulation.Classes.ConstructionLibrary,DiGi.Analytical.Building.Regulation.Classes.OpeningSizeLibrary,DiGi.GIS.Classes.ClimateZoneMap,DiGi.Analytical.Building.Energy.Classes.HeatDemandOptions).openingSizeLibrary'></a>

`openingSizeLibrary` [DiGi\.Analytical\.Building\.Regulation\.Classes\.OpeningSizeLibrary](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.regulation.classes.openingsizelibrary 'DiGi\.Analytical\.Building\.Regulation\.Classes\.OpeningSizeLibrary')

The opening\-size library, or null for `Regulation.Create.OpeningSizeLibrary_PL()` created per call\.

<a name='DiGi.GIS.Analytical.Energy.Classes.HeatDemandContext.HeatDemandContext(DiGi.Analytical.Building.Regulation.Classes.ConstructionLibrary,DiGi.Analytical.Building.Regulation.Classes.OpeningSizeLibrary,DiGi.GIS.Classes.ClimateZoneMap,DiGi.Analytical.Building.Energy.Classes.HeatDemandOptions).climateZoneMap'></a>

`climateZoneMap` [DiGi\.GIS\.Classes\.ClimateZoneMap](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.classes.climatezonemap 'DiGi\.GIS\.Classes\.ClimateZoneMap')

The climate\-zone map, or null for the embedded map read per call\.

<a name='DiGi.GIS.Analytical.Energy.Classes.HeatDemandContext.HeatDemandContext(DiGi.Analytical.Building.Regulation.Classes.ConstructionLibrary,DiGi.Analytical.Building.Regulation.Classes.OpeningSizeLibrary,DiGi.GIS.Classes.ClimateZoneMap,DiGi.Analytical.Building.Energy.Classes.HeatDemandOptions).heatDemandOptions'></a>

`heatDemandOptions` [DiGi\.Analytical\.Building\.Energy\.Classes\.HeatDemandOptions](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.energy.classes.heatdemandoptions 'DiGi\.Analytical\.Building\.Energy\.Classes\.HeatDemandOptions')

The heat\-demand options, or null for the defaults\.
### Properties

<a name='DiGi.GIS.Analytical.Energy.Classes.HeatDemandContext.ClimateZoneMap'></a>

## HeatDemandContext\.ClimateZoneMap Property

Gets the climate\-zone map\.

```csharp
public DiGi.GIS.Classes.ClimateZoneMap? ClimateZoneMap { get; }
```

#### Property Value
[DiGi\.GIS\.Classes\.ClimateZoneMap](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.classes.climatezonemap 'DiGi\.GIS\.Classes\.ClimateZoneMap')

<a name='DiGi.GIS.Analytical.Energy.Classes.HeatDemandContext.ConstructionLibrary'></a>

## HeatDemandContext\.ConstructionLibrary Property

Gets the construction library\.

```csharp
public DiGi.Analytical.Building.Regulation.Classes.ConstructionLibrary? ConstructionLibrary { get; }
```

#### Property Value
[DiGi\.Analytical\.Building\.Regulation\.Classes\.ConstructionLibrary](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.regulation.classes.constructionlibrary 'DiGi\.Analytical\.Building\.Regulation\.Classes\.ConstructionLibrary')

<a name='DiGi.GIS.Analytical.Energy.Classes.HeatDemandContext.HeatDemandOptions'></a>

## HeatDemandContext\.HeatDemandOptions Property

Gets the heat\-demand options\.

```csharp
public DiGi.Analytical.Building.Energy.Classes.HeatDemandOptions? HeatDemandOptions { get; }
```

#### Property Value
[DiGi\.Analytical\.Building\.Energy\.Classes\.HeatDemandOptions](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.energy.classes.heatdemandoptions 'DiGi\.Analytical\.Building\.Energy\.Classes\.HeatDemandOptions')

<a name='DiGi.GIS.Analytical.Energy.Classes.HeatDemandContext.OpeningSizeLibrary'></a>

## HeatDemandContext\.OpeningSizeLibrary Property

Gets the opening\-size library\.

```csharp
public DiGi.Analytical.Building.Regulation.Classes.OpeningSizeLibrary? OpeningSizeLibrary { get; }
```

#### Property Value
[DiGi\.Analytical\.Building\.Regulation\.Classes\.OpeningSizeLibrary](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.regulation.classes.openingsizelibrary 'DiGi\.Analytical\.Building\.Regulation\.Classes\.OpeningSizeLibrary')

<a name='DiGi.GIS.Analytical.Energy.Classes.HeatDemandInput'></a>

## HeatDemandInput Class

Represents the per\-building inputs of the heat\-demand assembly of a stored GIS building \(DiGi\-Organization/DiGi\.GIS\.Analytical\#14\): what the opening generation, the internal conditions and the provenance need beyond the model, its 2D building and its solar result\.

The construction flavour is `OpeningGenerationInput.OpeningGenerationOptions.ConstructionFlavour`; it is not held twice. The weather source is used only when the building has no solar result: with one, the climate comes from the weather the result was calculated from.

```csharp
public class HeatDemandInput : DiGi.Core.Classes.SerializableObject, DiGi.GIS.Interfaces.IGISSerializableObject, DiGi.GIS.Interfaces.IGISObject, DiGi.Core.Interfaces.IObject, DiGi.Core.Interfaces.ISerializableObject, DiGi.Core.Interfaces.ICloneableObject<DiGi.Core.Interfaces.ISerializableObject>, DiGi.Core.Interfaces.ICloneableObject
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [DiGi\.Core\.Classes\.Object](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.object 'DiGi\.Core\.Classes\.Object') → [DiGi\.Core\.Classes\.SerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.serializableobject 'DiGi\.Core\.Classes\.SerializableObject') → HeatDemandInput

Implements [DiGi\.GIS\.Interfaces\.IGISSerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.interfaces.igisserializableobject 'DiGi\.GIS\.Interfaces\.IGISSerializableObject'), [DiGi\.GIS\.Interfaces\.IGISObject](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.interfaces.igisobject 'DiGi\.GIS\.Interfaces\.IGISObject'), [DiGi\.Core\.Interfaces\.IObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iobject 'DiGi\.Core\.Interfaces\.IObject'), [DiGi\.Core\.Interfaces\.ISerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iserializableobject 'DiGi\.Core\.Interfaces\.ISerializableObject'), [DiGi\.Core\.Interfaces\.ICloneableObject&lt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject-1 'DiGi\.Core\.Interfaces\.ICloneableObject\`1')[DiGi\.Core\.Interfaces\.ISerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iserializableobject 'DiGi\.Core\.Interfaces\.ISerializableObject')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject-1 'DiGi\.Core\.Interfaces\.ICloneableObject\`1'), [DiGi\.Core\.Interfaces\.ICloneableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject 'DiGi\.Core\.Interfaces\.ICloneableObject')
### Constructors

<a name='DiGi.GIS.Analytical.Energy.Classes.HeatDemandInput.HeatDemandInput(DiGi.GIS.Analytical.Energy.Classes.HeatDemandInput)'></a>

## HeatDemandInput\(HeatDemandInput\) Constructor

Initializes a new instance of the [HeatDemandInput](DiGi.GIS.Analytical.Energy.Classes.md#DiGi.GIS.Analytical.Energy.Classes.HeatDemandInput 'DiGi\.GIS\.Analytical\.Energy\.Classes\.HeatDemandInput') class by copying an existing instance\.

```csharp
public HeatDemandInput(DiGi.GIS.Analytical.Energy.Classes.HeatDemandInput? heatDemandInput);
```
#### Parameters

<a name='DiGi.GIS.Analytical.Energy.Classes.HeatDemandInput.HeatDemandInput(DiGi.GIS.Analytical.Energy.Classes.HeatDemandInput).heatDemandInput'></a>

`heatDemandInput` [HeatDemandInput](DiGi.GIS.Analytical.Energy.Classes.md#DiGi.GIS.Analytical.Energy.Classes.HeatDemandInput 'DiGi\.GIS\.Analytical\.Energy\.Classes\.HeatDemandInput')

The [HeatDemandInput](DiGi.GIS.Analytical.Energy.Classes.md#DiGi.GIS.Analytical.Energy.Classes.HeatDemandInput 'DiGi\.GIS\.Analytical\.Energy\.Classes\.HeatDemandInput') to copy\. This value can be null\.

<a name='DiGi.GIS.Analytical.Energy.Classes.HeatDemandInput.HeatDemandInput(DiGi.GIS.Classes.OpeningGenerationInput,DiGi.GIS.Classes.OccupancyData,string,int,DiGi.GIS.Enums.WeatherSourceType,string)'></a>

## HeatDemandInput\(OpeningGenerationInput, OccupancyData, string, int, WeatherSourceType, string\) Constructor

Initializes a new instance of the [HeatDemandInput](DiGi.GIS.Analytical.Energy.Classes.md#DiGi.GIS.Analytical.Energy.Classes.HeatDemandInput 'DiGi\.GIS\.Analytical\.Energy\.Classes\.HeatDemandInput') class\.

The values are assigned and the objects cloned; nothing is validated here.

```csharp
public HeatDemandInput(DiGi.GIS.Classes.OpeningGenerationInput? openingGenerationInput, DiGi.GIS.Classes.OccupancyData? occupancyData, string? occupancySource, int countyId, DiGi.GIS.Enums.WeatherSourceType weatherSourceType, string? weatherSourceId);
```
#### Parameters

<a name='DiGi.GIS.Analytical.Energy.Classes.HeatDemandInput.HeatDemandInput(DiGi.GIS.Classes.OpeningGenerationInput,DiGi.GIS.Classes.OccupancyData,string,int,DiGi.GIS.Enums.WeatherSourceType,string).openingGenerationInput'></a>

`openingGenerationInput` [DiGi\.GIS\.Classes\.OpeningGenerationInput](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.classes.openinggenerationinput 'DiGi\.GIS\.Classes\.OpeningGenerationInput')

The input of the opening generation: the year built and its source, the address point, the climate zone, the panel system, the options \(the construction flavour among them\) and the roads\. This value can be null\.

<a name='DiGi.GIS.Analytical.Energy.Classes.HeatDemandInput.HeatDemandInput(DiGi.GIS.Classes.OpeningGenerationInput,DiGi.GIS.Classes.OccupancyData,string,int,DiGi.GIS.Enums.WeatherSourceType,string).occupancyData'></a>

`occupancyData` [DiGi\.GIS\.Classes\.OccupancyData](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.classes.occupancydata 'DiGi\.GIS\.Classes\.OccupancyData')

The occupancy estimate of the building, which scales the internal gains and hot water of the usage profile\. This value can be null\.

<a name='DiGi.GIS.Analytical.Energy.Classes.HeatDemandInput.HeatDemandInput(DiGi.GIS.Classes.OpeningGenerationInput,DiGi.GIS.Classes.OccupancyData,string,int,DiGi.GIS.Enums.WeatherSourceType,string).occupancySource'></a>

`occupancySource` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

Where the occupancy estimate comes from\. This value can be null\.

<a name='DiGi.GIS.Analytical.Energy.Classes.HeatDemandInput.HeatDemandInput(DiGi.GIS.Classes.OpeningGenerationInput,DiGi.GIS.Classes.OccupancyData,string,int,DiGi.GIS.Enums.WeatherSourceType,string).countyId'></a>

`countyId` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The id of the county part the building is filed under\.

<a name='DiGi.GIS.Analytical.Energy.Classes.HeatDemandInput.HeatDemandInput(DiGi.GIS.Classes.OpeningGenerationInput,DiGi.GIS.Classes.OccupancyData,string,int,DiGi.GIS.Enums.WeatherSourceType,string).weatherSourceType'></a>

`weatherSourceType` [DiGi\.GIS\.Enums\.WeatherSourceType](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.enums.weathersourcetype 'DiGi\.GIS\.Enums\.WeatherSourceType')

The kind of the weather source the climate is taken from, when the building has no solar result\.

<a name='DiGi.GIS.Analytical.Energy.Classes.HeatDemandInput.HeatDemandInput(DiGi.GIS.Classes.OpeningGenerationInput,DiGi.GIS.Classes.OccupancyData,string,int,DiGi.GIS.Enums.WeatherSourceType,string).weatherSourceId'></a>

`weatherSourceId` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The id of the weather source \(the `epw_file` id of an EPW source\), when the building has no solar result\. This value can be null\.

<a name='DiGi.GIS.Analytical.Energy.Classes.HeatDemandInput.HeatDemandInput(System.Text.Json.Nodes.JsonObject)'></a>

## HeatDemandInput\(JsonObject\) Constructor

Initializes a new instance of the [HeatDemandInput](DiGi.GIS.Analytical.Energy.Classes.md#DiGi.GIS.Analytical.Energy.Classes.HeatDemandInput 'DiGi\.GIS\.Analytical\.Energy\.Classes\.HeatDemandInput') class from a JSON object\.

```csharp
public HeatDemandInput(System.Text.Json.Nodes.JsonObject? jsonObject);
```
#### Parameters

<a name='DiGi.GIS.Analytical.Energy.Classes.HeatDemandInput.HeatDemandInput(System.Text.Json.Nodes.JsonObject).jsonObject'></a>

`jsonObject` [System\.Text\.Json\.Nodes\.JsonObject](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.nodes.jsonobject 'System\.Text\.Json\.Nodes\.JsonObject')

The JSON object containing the data\. This value can be null\.
### Properties

<a name='DiGi.GIS.Analytical.Energy.Classes.HeatDemandInput.CountyId'></a>

## HeatDemandInput\.CountyId Property

Gets the id of the county part the building is filed under\.

```csharp
public int CountyId { get; }
```

#### Property Value
[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

<a name='DiGi.GIS.Analytical.Energy.Classes.HeatDemandInput.OccupancyData'></a>

## HeatDemandInput\.OccupancyData Property

Gets a clone of the occupancy estimate of the building, which scales the internal gains and hot water of the usage profile\.

```csharp
public DiGi.GIS.Classes.OccupancyData? OccupancyData { get; }
```

#### Property Value
[DiGi\.GIS\.Classes\.OccupancyData](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.classes.occupancydata 'DiGi\.GIS\.Classes\.OccupancyData')

<a name='DiGi.GIS.Analytical.Energy.Classes.HeatDemandInput.OccupancySource'></a>

## HeatDemandInput\.OccupancySource Property

Gets where the occupancy estimate comes from\.

```csharp
public string? OccupancySource { get; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.GIS.Analytical.Energy.Classes.HeatDemandInput.OpeningGenerationInput'></a>

## HeatDemandInput\.OpeningGenerationInput Property

Gets a clone of the input of the opening generation: the year built and its source, the address point, the climate zone, the panel system, the options \(the construction flavour among them\) and the roads\.

```csharp
public DiGi.GIS.Classes.OpeningGenerationInput? OpeningGenerationInput { get; }
```

#### Property Value
[DiGi\.GIS\.Classes\.OpeningGenerationInput](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.classes.openinggenerationinput 'DiGi\.GIS\.Classes\.OpeningGenerationInput')

<a name='DiGi.GIS.Analytical.Energy.Classes.HeatDemandInput.WeatherSourceId'></a>

## HeatDemandInput\.WeatherSourceId Property

Gets the id of the weather source \(the `epw_file` id of an EPW source\), when the building has no solar result\.

```csharp
public string? WeatherSourceId { get; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.GIS.Analytical.Energy.Classes.HeatDemandInput.WeatherSourceType'></a>

## HeatDemandInput\.WeatherSourceType Property

Gets the kind of the weather source the climate is taken from, when the building has no solar result\.

```csharp
public DiGi.GIS.Enums.WeatherSourceType WeatherSourceType { get; }
```

#### Property Value
[DiGi\.GIS\.Enums\.WeatherSourceType](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.enums.weathersourcetype 'DiGi\.GIS\.Enums\.WeatherSourceType')