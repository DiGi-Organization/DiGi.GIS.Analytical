#### [DiGi\.GIS\.Analytical](DiGi.GIS.Analytical.Overview.md 'DiGi\.GIS\.Analytical\.Overview')

## DiGi\.GIS\.Classes Namespace
### Classes

<a name='DiGi.GIS.Classes.BuildingModelsFile'></a>

## BuildingModelsFile Class

Represents a storage file for building models, providing functionality to manage and retrieve
unique references associated with building model data\.

```csharp
public class BuildingModelsFile : DiGi.Core.IO.File.Classes.StorageFile<DiGi.Analytical.Building.Classes.BuildingModel>, DiGi.GIS.Interfaces.IGISObject, DiGi.Core.Interfaces.IObject
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [DiGi\.Core\.Classes\.Object](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.object 'DiGi\.Core\.Classes\.Object') → [DiGi\.Core\.Classes\.SerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.serializableobject 'DiGi\.Core\.Classes\.SerializableObject') → [DiGi\.Core\.IO\.File\.Classes\.File](https://learn.microsoft.com/en-us/dotnet/api/digi.core.io.file.classes.file 'DiGi\.Core\.IO\.File\.Classes\.File') → [DiGi\.Core\.IO\.File\.Classes\.StorageFile&lt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.io.file.classes.storagefile-1 'DiGi\.Core\.IO\.File\.Classes\.StorageFile\`1')[DiGi\.Analytical\.Building\.Classes\.BuildingModel](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.classes.buildingmodel 'DiGi\.Analytical\.Building\.Classes\.BuildingModel')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.io.file.classes.storagefile-1 'DiGi\.Core\.IO\.File\.Classes\.StorageFile\`1') → BuildingModelsFile

Implements [DiGi\.GIS\.Interfaces\.IGISObject](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.interfaces.igisobject 'DiGi\.GIS\.Interfaces\.IGISObject'), [DiGi\.Core\.Interfaces\.IObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iobject 'DiGi\.Core\.Interfaces\.IObject')
### Constructors

<a name='DiGi.GIS.Classes.BuildingModelsFile.BuildingModelsFile(DiGi.GIS.Classes.BuildingModelsFile)'></a>

## BuildingModelsFile\(BuildingModelsFile\) Constructor

Initializes a new instance of the [BuildingModelsFile](DiGi.GIS.Classes.md#DiGi.GIS.Classes.BuildingModelsFile 'DiGi\.GIS\.Classes\.BuildingModelsFile') class by copying an existing building models file\.

```csharp
public BuildingModelsFile(DiGi.GIS.Classes.BuildingModelsFile? buildingModelsFile);
```
#### Parameters

<a name='DiGi.GIS.Classes.BuildingModelsFile.BuildingModelsFile(DiGi.GIS.Classes.BuildingModelsFile).buildingModelsFile'></a>

`buildingModelsFile` [BuildingModelsFile](DiGi.GIS.Classes.md#DiGi.GIS.Classes.BuildingModelsFile 'DiGi\.GIS\.Classes\.BuildingModelsFile')

The source [BuildingModelsFile](DiGi.GIS.Classes.md#DiGi.GIS.Classes.BuildingModelsFile 'DiGi\.GIS\.Classes\.BuildingModelsFile') to copy\.

<a name='DiGi.GIS.Classes.BuildingModelsFile.BuildingModelsFile(string)'></a>

## BuildingModelsFile\(string\) Constructor

Initializes a new instance of the [BuildingModelsFile](DiGi.GIS.Classes.md#DiGi.GIS.Classes.BuildingModelsFile 'DiGi\.GIS\.Classes\.BuildingModelsFile') class from a specified file path\.

```csharp
public BuildingModelsFile(string? path);
```
#### Parameters

<a name='DiGi.GIS.Classes.BuildingModelsFile.BuildingModelsFile(string).path'></a>

`path` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The system path to the building models file\.

<a name='DiGi.GIS.Classes.BuildingModelsFile.BuildingModelsFile(System.Text.Json.Nodes.JsonObject)'></a>

## BuildingModelsFile\(JsonObject\) Constructor

Initializes a new instance of the [BuildingModelsFile](DiGi.GIS.Classes.md#DiGi.GIS.Classes.BuildingModelsFile 'DiGi\.GIS\.Classes\.BuildingModelsFile') class from a JSON object\.

```csharp
public BuildingModelsFile(System.Text.Json.Nodes.JsonObject? jsonObject);
```
#### Parameters

<a name='DiGi.GIS.Classes.BuildingModelsFile.BuildingModelsFile(System.Text.Json.Nodes.JsonObject).jsonObject'></a>

`jsonObject` [System\.Text\.Json\.Nodes\.JsonObject](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.nodes.jsonobject 'System\.Text\.Json\.Nodes\.JsonObject')

The [System\.Text\.Json\.Nodes\.JsonObject](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.nodes.jsonobject 'System\.Text\.Json\.Nodes\.JsonObject') containing the building models file data\.
### Methods

<a name='DiGi.GIS.Classes.BuildingModelsFile.GetUniqueReference(DiGi.Analytical.Building.Classes.BuildingModel)'></a>

## BuildingModelsFile\.GetUniqueReference\(BuildingModel\) Method

Gets the unique reference for the specified building model by extracting its reference parameter\.

```csharp
public override DiGi.Core.Classes.UniqueReference? GetUniqueReference(DiGi.Analytical.Building.Classes.BuildingModel? buildingModel);
```
#### Parameters

<a name='DiGi.GIS.Classes.BuildingModelsFile.GetUniqueReference(DiGi.Analytical.Building.Classes.BuildingModel).buildingModel'></a>

`buildingModel` [DiGi\.Analytical\.Building\.Classes\.BuildingModel](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.classes.buildingmodel 'DiGi\.Analytical\.Building\.Classes\.BuildingModel')

The building model instance to retrieve the reference from\.

#### Returns
[DiGi\.Core\.Classes\.UniqueReference](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.uniquereference 'DiGi\.Core\.Classes\.UniqueReference')  
A [DiGi\.Core\.Classes\.UniqueReference](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.uniquereference 'DiGi\.Core\.Classes\.UniqueReference') if a valid reference is found; otherwise, `null`\.

<a name='DiGi.GIS.Classes.BuildingModelsFile.GetUniqueReference(string)'></a>

## BuildingModelsFile\.GetUniqueReference\(string\) Method

Creates a unique reference for a building model based on the provided string identifier\.

```csharp
public static DiGi.Core.Classes.UniqueReference? GetUniqueReference(string? reference);
```
#### Parameters

<a name='DiGi.GIS.Classes.BuildingModelsFile.GetUniqueReference(string).reference'></a>

`reference` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The string representation of the reference\.

#### Returns
[DiGi\.Core\.Classes\.UniqueReference](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.uniquereference 'DiGi\.Core\.Classes\.UniqueReference')  
A new [DiGi\.Core\.Classes\.UniqueReference](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.uniquereference 'DiGi\.Core\.Classes\.UniqueReference') instance if the reference is not null; otherwise, `null`\.

<a name='DiGi.GIS.Classes.BuildingModelValidationResult'></a>

## BuildingModelValidationResult Class

Holds the outcome of validating a single [DiGi\.Analytical\.Building\.Classes\.BuildingModel](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.classes.buildingmodel 'DiGi\.Analytical\.Building\.Classes\.BuildingModel')\.

The counts and extents are kept next to the validation codes on purpose: a model failing on enclosure is only actionable once it is known how many spaces it holds and how far off the closing tolerance it was, which is what tells a shell that never had a boundary apart from one whose source geometry is merely imprecise.

```csharp
public class BuildingModelValidationResult : DiGi.Core.Classes.SerializableObject, DiGi.GIS.Interfaces.IGISSerializableObject, DiGi.GIS.Interfaces.IGISObject, DiGi.Core.Interfaces.IObject, DiGi.Core.Interfaces.ISerializableObject, DiGi.Core.Interfaces.ICloneableObject<DiGi.Core.Interfaces.ISerializableObject>, DiGi.Core.Interfaces.ICloneableObject
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [DiGi\.Core\.Classes\.Object](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.object 'DiGi\.Core\.Classes\.Object') → [DiGi\.Core\.Classes\.SerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.serializableobject 'DiGi\.Core\.Classes\.SerializableObject') → BuildingModelValidationResult

Implements [DiGi\.GIS\.Interfaces\.IGISSerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.interfaces.igisserializableobject 'DiGi\.GIS\.Interfaces\.IGISSerializableObject'), [DiGi\.GIS\.Interfaces\.IGISObject](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.interfaces.igisobject 'DiGi\.GIS\.Interfaces\.IGISObject'), [DiGi\.Core\.Interfaces\.IObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iobject 'DiGi\.Core\.Interfaces\.IObject'), [DiGi\.Core\.Interfaces\.ISerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iserializableobject 'DiGi\.Core\.Interfaces\.ISerializableObject'), [DiGi\.Core\.Interfaces\.ICloneableObject&lt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject-1 'DiGi\.Core\.Interfaces\.ICloneableObject\`1')[DiGi\.Core\.Interfaces\.ISerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iserializableobject 'DiGi\.Core\.Interfaces\.ISerializableObject')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject-1 'DiGi\.Core\.Interfaces\.ICloneableObject\`1'), [DiGi\.Core\.Interfaces\.ICloneableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject 'DiGi\.Core\.Interfaces\.ICloneableObject')
### Constructors

<a name='DiGi.GIS.Classes.BuildingModelValidationResult.BuildingModelValidationResult(DiGi.GIS.Classes.BuildingModelValidationResult)'></a>

## BuildingModelValidationResult\(BuildingModelValidationResult\) Constructor

Initializes a new instance of the [BuildingModelValidationResult](DiGi.GIS.Classes.md#DiGi.GIS.Classes.BuildingModelValidationResult 'DiGi\.GIS\.Classes\.BuildingModelValidationResult') class by copying an existing one\.

```csharp
public BuildingModelValidationResult(DiGi.GIS.Classes.BuildingModelValidationResult? buildingModelValidationResult);
```
#### Parameters

<a name='DiGi.GIS.Classes.BuildingModelValidationResult.BuildingModelValidationResult(DiGi.GIS.Classes.BuildingModelValidationResult).buildingModelValidationResult'></a>

`buildingModelValidationResult` [BuildingModelValidationResult](DiGi.GIS.Classes.md#DiGi.GIS.Classes.BuildingModelValidationResult 'DiGi\.GIS\.Classes\.BuildingModelValidationResult')

The source result to copy data from\. If null, a default instance is initialized\.

<a name='DiGi.GIS.Classes.BuildingModelValidationResult.BuildingModelValidationResult(string,string,double,int,int,int,int,double,double,double,System.Collections.Generic.IEnumerable_DiGi.GIS.Analytical.Enums.BuildingModelValidationCode_)'></a>

## BuildingModelValidationResult\(string, string, double, int, int, int, int, double, double, double, IEnumerable\<BuildingModelValidationCode\>\) Constructor

Initializes a new instance of the [BuildingModelValidationResult](DiGi.GIS.Classes.md#DiGi.GIS.Classes.BuildingModelValidationResult 'DiGi\.GIS\.Classes\.BuildingModelValidationResult') class\.

```csharp
public BuildingModelValidationResult(string? reference, string? code, double tolerance, int spaceCount, int componentCount, int shellCount, int enclosedShellCount, double minEnclosingTolerance, double minZ, double maxZ, System.Collections.Generic.IEnumerable<DiGi.GIS.Analytical.Enums.BuildingModelValidationCode>? validationCodes);
```
#### Parameters

<a name='DiGi.GIS.Classes.BuildingModelValidationResult.BuildingModelValidationResult(string,string,double,int,int,int,int,double,double,double,System.Collections.Generic.IEnumerable_DiGi.GIS.Analytical.Enums.BuildingModelValidationCode_).reference'></a>

`reference` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The reference of the 2D building the validated model belongs to\.

<a name='DiGi.GIS.Classes.BuildingModelValidationResult.BuildingModelValidationResult(string,string,double,int,int,int,int,double,double,double,System.Collections.Generic.IEnumerable_DiGi.GIS.Analytical.Enums.BuildingModelValidationCode_).code'></a>

`code` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The administrative area code the validated model belongs to\.

<a name='DiGi.GIS.Classes.BuildingModelValidationResult.BuildingModelValidationResult(string,string,double,int,int,int,int,double,double,double,System.Collections.Generic.IEnumerable_DiGi.GIS.Analytical.Enums.BuildingModelValidationCode_).tolerance'></a>

`tolerance` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The distance tolerance the enclosure was required to hold at\.

<a name='DiGi.GIS.Classes.BuildingModelValidationResult.BuildingModelValidationResult(string,string,double,int,int,int,int,double,double,double,System.Collections.Generic.IEnumerable_DiGi.GIS.Analytical.Enums.BuildingModelValidationCode_).spaceCount'></a>

`spaceCount` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of spaces held by the model\.

<a name='DiGi.GIS.Classes.BuildingModelValidationResult.BuildingModelValidationResult(string,string,double,int,int,int,int,double,double,double,System.Collections.Generic.IEnumerable_DiGi.GIS.Analytical.Enums.BuildingModelValidationCode_).componentCount'></a>

`componentCount` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of components held by the model\.

<a name='DiGi.GIS.Classes.BuildingModelValidationResult.BuildingModelValidationResult(string,string,double,int,int,int,int,double,double,double,System.Collections.Generic.IEnumerable_DiGi.GIS.Analytical.Enums.BuildingModelValidationCode_).shellCount'></a>

`shellCount` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of shells that could be assembled from those spaces\.

<a name='DiGi.GIS.Classes.BuildingModelValidationResult.BuildingModelValidationResult(string,string,double,int,int,int,int,double,double,double,System.Collections.Generic.IEnumerable_DiGi.GIS.Analytical.Enums.BuildingModelValidationCode_).enclosedShellCount'></a>

`enclosedShellCount` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of those shells closing at [tolerance](DiGi.GIS.Classes.md#DiGi.GIS.Classes.BuildingModelValidationResult.BuildingModelValidationResult(string,string,double,int,int,int,int,double,double,double,System.Collections.Generic.IEnumerable_DiGi.GIS.Analytical.Enums.BuildingModelValidationCode_).tolerance 'DiGi\.GIS\.Classes\.BuildingModelValidationResult\.BuildingModelValidationResult\(string, string, double, int, int, int, int, double, double, double, System\.Collections\.Generic\.IEnumerable\<DiGi\.GIS\.Analytical\.Enums\.BuildingModelValidationCode\>\)\.tolerance')\.

<a name='DiGi.GIS.Classes.BuildingModelValidationResult.BuildingModelValidationResult(string,string,double,int,int,int,int,double,double,double,System.Collections.Generic.IEnumerable_DiGi.GIS.Analytical.Enums.BuildingModelValidationCode_).minEnclosingTolerance'></a>

`minEnclosingTolerance` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The smallest tolerance at which every shell of the model closes, or not a number when at least one of them never closes\.

<a name='DiGi.GIS.Classes.BuildingModelValidationResult.BuildingModelValidationResult(string,string,double,int,int,int,int,double,double,double,System.Collections.Generic.IEnumerable_DiGi.GIS.Analytical.Enums.BuildingModelValidationCode_).minZ'></a>

`minZ` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The lowest elevation of the model\.

<a name='DiGi.GIS.Classes.BuildingModelValidationResult.BuildingModelValidationResult(string,string,double,int,int,int,int,double,double,double,System.Collections.Generic.IEnumerable_DiGi.GIS.Analytical.Enums.BuildingModelValidationCode_).maxZ'></a>

`maxZ` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The highest elevation of the model\.

<a name='DiGi.GIS.Classes.BuildingModelValidationResult.BuildingModelValidationResult(string,string,double,int,int,int,int,double,double,double,System.Collections.Generic.IEnumerable_DiGi.GIS.Analytical.Enums.BuildingModelValidationCode_).validationCodes'></a>

`validationCodes` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[BuildingModelValidationCode](DiGi.GIS.Analytical.Enums.md#DiGi.GIS.Analytical.Enums.BuildingModelValidationCode 'DiGi\.GIS\.Analytical\.Enums\.BuildingModelValidationCode')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The ways in which the model failed validation\. An empty or null collection means it passed\.

<a name='DiGi.GIS.Classes.BuildingModelValidationResult.BuildingModelValidationResult(System.Text.Json.Nodes.JsonObject)'></a>

## BuildingModelValidationResult\(JsonObject\) Constructor

Initializes a new instance of the [BuildingModelValidationResult](DiGi.GIS.Classes.md#DiGi.GIS.Classes.BuildingModelValidationResult 'DiGi\.GIS\.Classes\.BuildingModelValidationResult') class using the specified [System\.Text\.Json\.Nodes\.JsonObject](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.nodes.jsonobject 'System\.Text\.Json\.Nodes\.JsonObject')\.

```csharp
public BuildingModelValidationResult(System.Text.Json.Nodes.JsonObject? jsonObject);
```
#### Parameters

<a name='DiGi.GIS.Classes.BuildingModelValidationResult.BuildingModelValidationResult(System.Text.Json.Nodes.JsonObject).jsonObject'></a>

`jsonObject` [System\.Text\.Json\.Nodes\.JsonObject](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.nodes.jsonobject 'System\.Text\.Json\.Nodes\.JsonObject')

The [System\.Text\.Json\.Nodes\.JsonObject](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.nodes.jsonobject 'System\.Text\.Json\.Nodes\.JsonObject') containing the result data, or null if no data is provided\.
### Properties

<a name='DiGi.GIS.Classes.BuildingModelValidationResult.Code'></a>

## BuildingModelValidationResult\.Code Property

Gets the administrative area code the validated model belongs to\.

```csharp
public string? Code { get; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.GIS.Classes.BuildingModelValidationResult.ComponentCount'></a>

## BuildingModelValidationResult\.ComponentCount Property

Gets the number of components held by the model\.

```csharp
public int ComponentCount { get; }
```

#### Property Value
[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

<a name='DiGi.GIS.Classes.BuildingModelValidationResult.EnclosedShellCount'></a>

## BuildingModelValidationResult\.EnclosedShellCount Property

Gets the number of shells closing at [Tolerance](DiGi.GIS.Classes.md#DiGi.GIS.Classes.BuildingModelValidationResult.Tolerance 'DiGi\.GIS\.Classes\.BuildingModelValidationResult\.Tolerance')\.

```csharp
public int EnclosedShellCount { get; }
```

#### Property Value
[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

<a name='DiGi.GIS.Classes.BuildingModelValidationResult.IsValid'></a>

## BuildingModelValidationResult\.IsValid Property

Gets a value indicating whether the model passed every check\.

```csharp
public bool IsValid { get; }
```

#### Property Value
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

<a name='DiGi.GIS.Classes.BuildingModelValidationResult.MaxZ'></a>

## BuildingModelValidationResult\.MaxZ Property

Gets the highest elevation of the model\.

```csharp
public double MaxZ { get; }
```

#### Property Value
[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

<a name='DiGi.GIS.Classes.BuildingModelValidationResult.MinEnclosingTolerance'></a>

## BuildingModelValidationResult\.MinEnclosingTolerance Property

Gets the smallest tolerance at which every shell of the model closes, or not a number when at least one of them never closes\.

```csharp
public double MinEnclosingTolerance { get; }
```

#### Property Value
[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

<a name='DiGi.GIS.Classes.BuildingModelValidationResult.MinZ'></a>

## BuildingModelValidationResult\.MinZ Property

Gets the lowest elevation of the model\.

```csharp
public double MinZ { get; }
```

#### Property Value
[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

<a name='DiGi.GIS.Classes.BuildingModelValidationResult.Reference'></a>

## BuildingModelValidationResult\.Reference Property

Gets the reference of the 2D building the validated model belongs to\.

```csharp
public string? Reference { get; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.GIS.Classes.BuildingModelValidationResult.ShellCount'></a>

## BuildingModelValidationResult\.ShellCount Property

Gets the number of shells that could be assembled from the spaces of the model\.

```csharp
public int ShellCount { get; }
```

#### Property Value
[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

<a name='DiGi.GIS.Classes.BuildingModelValidationResult.SpaceCount'></a>

## BuildingModelValidationResult\.SpaceCount Property

Gets the number of spaces held by the model\.

```csharp
public int SpaceCount { get; }
```

#### Property Value
[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

<a name='DiGi.GIS.Classes.BuildingModelValidationResult.Tolerance'></a>

## BuildingModelValidationResult\.Tolerance Property

Gets the distance tolerance the enclosure was required to hold at\.

```csharp
public double Tolerance { get; }
```

#### Property Value
[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

<a name='DiGi.GIS.Classes.BuildingModelValidationResult.ValidationCodes'></a>

## BuildingModelValidationResult\.ValidationCodes Property

Gets the ways in which the model failed validation\. An empty list means it passed\.

```csharp
public System.Collections.Generic.List<DiGi.GIS.Analytical.Enums.BuildingModelValidationCode>? ValidationCodes { get; }
```

#### Property Value
[System\.Collections\.Generic\.List&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[BuildingModelValidationCode](DiGi.GIS.Analytical.Enums.md#DiGi.GIS.Analytical.Enums.BuildingModelValidationCode 'DiGi\.GIS\.Analytical\.Enums\.BuildingModelValidationCode')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')

<a name='DiGi.GIS.Classes.OpeningGenerationInput'></a>

## OpeningGenerationInput Class

Holds the building\-specific inputs of `Modify.GenerateOpenings` that the model and its 2D building do not carry \(DiGi\-Organization/DiGi\.GIS\.Analytical\#2\)\.

```csharp
public class OpeningGenerationInput : DiGi.Core.Classes.SerializableObject, DiGi.GIS.Interfaces.IGISSerializableObject, DiGi.GIS.Interfaces.IGISObject, DiGi.Core.Interfaces.IObject, DiGi.Core.Interfaces.ISerializableObject, DiGi.Core.Interfaces.ICloneableObject<DiGi.Core.Interfaces.ISerializableObject>, DiGi.Core.Interfaces.ICloneableObject
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [DiGi\.Core\.Classes\.Object](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.object 'DiGi\.Core\.Classes\.Object') → [DiGi\.Core\.Classes\.SerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.serializableobject 'DiGi\.Core\.Classes\.SerializableObject') → OpeningGenerationInput

Implements [DiGi\.GIS\.Interfaces\.IGISSerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.interfaces.igisserializableobject 'DiGi\.GIS\.Interfaces\.IGISSerializableObject'), [DiGi\.GIS\.Interfaces\.IGISObject](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.interfaces.igisobject 'DiGi\.GIS\.Interfaces\.IGISObject'), [DiGi\.Core\.Interfaces\.IObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iobject 'DiGi\.Core\.Interfaces\.IObject'), [DiGi\.Core\.Interfaces\.ISerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iserializableobject 'DiGi\.Core\.Interfaces\.ISerializableObject'), [DiGi\.Core\.Interfaces\.ICloneableObject&lt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject-1 'DiGi\.Core\.Interfaces\.ICloneableObject\`1')[DiGi\.Core\.Interfaces\.ISerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iserializableobject 'DiGi\.Core\.Interfaces\.ISerializableObject')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject-1 'DiGi\.Core\.Interfaces\.ICloneableObject\`1'), [DiGi\.Core\.Interfaces\.ICloneableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject 'DiGi\.Core\.Interfaces\.ICloneableObject')
### Constructors

<a name='DiGi.GIS.Classes.OpeningGenerationInput.OpeningGenerationInput(DiGi.GIS.Classes.OpeningGenerationInput)'></a>

## OpeningGenerationInput\(OpeningGenerationInput\) Constructor

Initializes a new instance of the [OpeningGenerationInput](DiGi.GIS.Classes.md#DiGi.GIS.Classes.OpeningGenerationInput 'DiGi\.GIS\.Classes\.OpeningGenerationInput') class by copying another instance\.

```csharp
public OpeningGenerationInput(DiGi.GIS.Classes.OpeningGenerationInput? openingGenerationInput);
```
#### Parameters

<a name='DiGi.GIS.Classes.OpeningGenerationInput.OpeningGenerationInput(DiGi.GIS.Classes.OpeningGenerationInput).openingGenerationInput'></a>

`openingGenerationInput` [OpeningGenerationInput](DiGi.GIS.Classes.md#DiGi.GIS.Classes.OpeningGenerationInput 'DiGi\.GIS\.Classes\.OpeningGenerationInput')

The input to copy\. This value can be null\.

<a name='DiGi.GIS.Classes.OpeningGenerationInput.OpeningGenerationInput(System.Nullable_short_,System.Nullable_DiGi.GIS.Enums.YearBuiltSource_,DiGi.Geometry.Planar.Classes.Point2D,DiGi.Analytical.Building.Regulation.Enums.ClimateZone,string,DiGi.GIS.Classes.OpeningGenerationOptions,System.Collections.Generic.IEnumerable_DiGi.Geometry.Planar.Classes.Polyline2D_)'></a>

## OpeningGenerationInput\(Nullable\<short\>, Nullable\<YearBuiltSource\>, Point2D, ClimateZone, string, OpeningGenerationOptions, IEnumerable\<Polyline2D\>\) Constructor

Initializes a new instance of the [OpeningGenerationInput](DiGi.GIS.Classes.md#DiGi.GIS.Classes.OpeningGenerationInput 'DiGi\.GIS\.Classes\.OpeningGenerationInput') class\.

```csharp
public OpeningGenerationInput(System.Nullable<short> yearBuilt, System.Nullable<DiGi.GIS.Enums.YearBuiltSource> yearBuiltSource, DiGi.Geometry.Planar.Classes.Point2D? addressPoint, DiGi.Analytical.Building.Regulation.Enums.ClimateZone climateZone, string? panelSystem, DiGi.GIS.Classes.OpeningGenerationOptions? openingGenerationOptions, System.Collections.Generic.IEnumerable<DiGi.Geometry.Planar.Classes.Polyline2D>? roads=null);
```
#### Parameters

<a name='DiGi.GIS.Classes.OpeningGenerationInput.OpeningGenerationInput(System.Nullable_short_,System.Nullable_DiGi.GIS.Enums.YearBuiltSource_,DiGi.Geometry.Planar.Classes.Point2D,DiGi.Analytical.Building.Regulation.Enums.ClimateZone,string,DiGi.GIS.Classes.OpeningGenerationOptions,System.Collections.Generic.IEnumerable_DiGi.Geometry.Planar.Classes.Polyline2D_).yearBuilt'></a>

`yearBuilt` [System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Int16](https://learn.microsoft.com/en-us/dotnet/api/system.int16 'System\.Int16')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

The year the building was completed, or null when unknown\.

<a name='DiGi.GIS.Classes.OpeningGenerationInput.OpeningGenerationInput(System.Nullable_short_,System.Nullable_DiGi.GIS.Enums.YearBuiltSource_,DiGi.Geometry.Planar.Classes.Point2D,DiGi.Analytical.Building.Regulation.Enums.ClimateZone,string,DiGi.GIS.Classes.OpeningGenerationOptions,System.Collections.Generic.IEnumerable_DiGi.Geometry.Planar.Classes.Polyline2D_).yearBuiltSource'></a>

`yearBuiltSource` [System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[DiGi\.GIS\.Enums\.YearBuiltSource](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.enums.yearbuiltsource 'DiGi\.GIS\.Enums\.YearBuiltSource')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

Where [yearBuilt](DiGi.GIS.Classes.md#DiGi.GIS.Classes.OpeningGenerationInput.OpeningGenerationInput(System.Nullable_short_,System.Nullable_DiGi.GIS.Enums.YearBuiltSource_,DiGi.Geometry.Planar.Classes.Point2D,DiGi.Analytical.Building.Regulation.Enums.ClimateZone,string,DiGi.GIS.Classes.OpeningGenerationOptions,System.Collections.Generic.IEnumerable_DiGi.Geometry.Planar.Classes.Polyline2D_).yearBuilt 'DiGi\.GIS\.Classes\.OpeningGenerationInput\.OpeningGenerationInput\(System\.Nullable\<short\>, System\.Nullable\<DiGi\.GIS\.Enums\.YearBuiltSource\>, DiGi\.Geometry\.Planar\.Classes\.Point2D, DiGi\.Analytical\.Building\.Regulation\.Enums\.ClimateZone, string, DiGi\.GIS\.Classes\.OpeningGenerationOptions, System\.Collections\.Generic\.IEnumerable\<DiGi\.Geometry\.Planar\.Classes\.Polyline2D\>\)\.yearBuilt') comes from, or null when no year is known\.

<a name='DiGi.GIS.Classes.OpeningGenerationInput.OpeningGenerationInput(System.Nullable_short_,System.Nullable_DiGi.GIS.Enums.YearBuiltSource_,DiGi.Geometry.Planar.Classes.Point2D,DiGi.Analytical.Building.Regulation.Enums.ClimateZone,string,DiGi.GIS.Classes.OpeningGenerationOptions,System.Collections.Generic.IEnumerable_DiGi.Geometry.Planar.Classes.Polyline2D_).addressPoint'></a>

`addressPoint` [DiGi\.Geometry\.Planar\.Classes\.Point2D](https://learn.microsoft.com/en-us/dotnet/api/digi.geometry.planar.classes.point2d 'DiGi\.Geometry\.Planar\.Classes\.Point2D')

The location of the building's address point in the coordinate system of the model, or null; the entrance goes on the external wall nearest it\.

<a name='DiGi.GIS.Classes.OpeningGenerationInput.OpeningGenerationInput(System.Nullable_short_,System.Nullable_DiGi.GIS.Enums.YearBuiltSource_,DiGi.Geometry.Planar.Classes.Point2D,DiGi.Analytical.Building.Regulation.Enums.ClimateZone,string,DiGi.GIS.Classes.OpeningGenerationOptions,System.Collections.Generic.IEnumerable_DiGi.Geometry.Planar.Classes.Polyline2D_).climateZone'></a>

`climateZone` [DiGi\.Analytical\.Building\.Regulation\.Enums\.ClimateZone](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.regulation.enums.climatezone 'DiGi\.Analytical\.Building\.Regulation\.Enums\.ClimateZone')

The climatic zone of the building; [DiGi\.Analytical\.Building\.Regulation\.Enums\.ClimateZone\.Undefined](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.regulation.enums.climatezone.undefined 'DiGi\.Analytical\.Building\.Regulation\.Enums\.ClimateZone\.Undefined') takes the zone I\-III window limits\.

<a name='DiGi.GIS.Classes.OpeningGenerationInput.OpeningGenerationInput(System.Nullable_short_,System.Nullable_DiGi.GIS.Enums.YearBuiltSource_,DiGi.Geometry.Planar.Classes.Point2D,DiGi.Analytical.Building.Regulation.Enums.ClimateZone,string,DiGi.GIS.Classes.OpeningGenerationOptions,System.Collections.Generic.IEnumerable_DiGi.Geometry.Planar.Classes.Polyline2D_).panelSystem'></a>

`panelSystem` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The large\-panel system of a 1967\-1985 apartment block \("W\-70", "OWT\-67", \.\.\.\), or null for the default W\-70\.

<a name='DiGi.GIS.Classes.OpeningGenerationInput.OpeningGenerationInput(System.Nullable_short_,System.Nullable_DiGi.GIS.Enums.YearBuiltSource_,DiGi.Geometry.Planar.Classes.Point2D,DiGi.Analytical.Building.Regulation.Enums.ClimateZone,string,DiGi.GIS.Classes.OpeningGenerationOptions,System.Collections.Generic.IEnumerable_DiGi.Geometry.Planar.Classes.Polyline2D_).openingGenerationOptions'></a>

`openingGenerationOptions` [OpeningGenerationOptions](DiGi.GIS.Classes.md#DiGi.GIS.Classes.OpeningGenerationOptions 'DiGi\.GIS\.Classes\.OpeningGenerationOptions')

The rules to apply, or null for those of the building's regime\.

<a name='DiGi.GIS.Classes.OpeningGenerationInput.OpeningGenerationInput(System.Nullable_short_,System.Nullable_DiGi.GIS.Enums.YearBuiltSource_,DiGi.Geometry.Planar.Classes.Point2D,DiGi.Analytical.Building.Regulation.Enums.ClimateZone,string,DiGi.GIS.Classes.OpeningGenerationOptions,System.Collections.Generic.IEnumerable_DiGi.Geometry.Planar.Classes.Polyline2D_).roads'></a>

`roads` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[DiGi\.Geometry\.Planar\.Classes\.Polyline2D](https://learn.microsoft.com/en-us/dotnet/api/digi.geometry.planar.classes.polyline2d 'DiGi\.Geometry\.Planar\.Classes\.Polyline2D')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The road polylines near the building \(BDOT10k OT\_SKJZ\_L, OT\_SKDR\_L, OT\_SKRP\_L\), or null for no road context; a wall whose facing strip up to `OpeningGenerationOptions.RoadFrontageDistance` reaches one is reported as road frontage \(DiGi\-Organization/DiGi\.GIS\.Analytical\#10\)\.

<a name='DiGi.GIS.Classes.OpeningGenerationInput.OpeningGenerationInput(System.Text.Json.Nodes.JsonObject)'></a>

## OpeningGenerationInput\(JsonObject\) Constructor

Initializes a new instance of the [OpeningGenerationInput](DiGi.GIS.Classes.md#DiGi.GIS.Classes.OpeningGenerationInput 'DiGi\.GIS\.Classes\.OpeningGenerationInput') class from a JSON object\.

```csharp
public OpeningGenerationInput(System.Text.Json.Nodes.JsonObject? jsonObject);
```
#### Parameters

<a name='DiGi.GIS.Classes.OpeningGenerationInput.OpeningGenerationInput(System.Text.Json.Nodes.JsonObject).jsonObject'></a>

`jsonObject` [System\.Text\.Json\.Nodes\.JsonObject](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.nodes.jsonobject 'System\.Text\.Json\.Nodes\.JsonObject')

The JSON object containing the data\. This value can be null\.
### Properties

<a name='DiGi.GIS.Classes.OpeningGenerationInput.AddressPoint'></a>

## OpeningGenerationInput\.AddressPoint Property

Gets a CLONE of the location of the building's address point, or null\.

```csharp
public DiGi.Geometry.Planar.Classes.Point2D? AddressPoint { get; }
```

#### Property Value
[DiGi\.Geometry\.Planar\.Classes\.Point2D](https://learn.microsoft.com/en-us/dotnet/api/digi.geometry.planar.classes.point2d 'DiGi\.Geometry\.Planar\.Classes\.Point2D')

<a name='DiGi.GIS.Classes.OpeningGenerationInput.ClimateZone'></a>

## OpeningGenerationInput\.ClimateZone Property

Gets the climatic zone of the building\.

```csharp
public DiGi.Analytical.Building.Regulation.Enums.ClimateZone ClimateZone { get; }
```

#### Property Value
[DiGi\.Analytical\.Building\.Regulation\.Enums\.ClimateZone](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.regulation.enums.climatezone 'DiGi\.Analytical\.Building\.Regulation\.Enums\.ClimateZone')

<a name='DiGi.GIS.Classes.OpeningGenerationInput.OpeningGenerationOptions'></a>

## OpeningGenerationInput\.OpeningGenerationOptions Property

Gets a CLONE of the rules to apply, or null for those of the building's regime\.

```csharp
public DiGi.GIS.Classes.OpeningGenerationOptions? OpeningGenerationOptions { get; }
```

#### Property Value
[OpeningGenerationOptions](DiGi.GIS.Classes.md#DiGi.GIS.Classes.OpeningGenerationOptions 'DiGi\.GIS\.Classes\.OpeningGenerationOptions')

<a name='DiGi.GIS.Classes.OpeningGenerationInput.PanelSystem'></a>

## OpeningGenerationInput\.PanelSystem Property

Gets the large\-panel system of a 1967\-1985 apartment block, or null for the default W\-70\.

```csharp
public string? PanelSystem { get; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.GIS.Classes.OpeningGenerationInput.Roads'></a>

## OpeningGenerationInput\.Roads Property

Gets CLONES of the road polylines near the building, or null when no road context was given \(DiGi\-Organization/DiGi\.GIS\.Analytical\#10\)\.

```csharp
public System.Collections.Generic.List<DiGi.Geometry.Planar.Classes.Polyline2D>? Roads { get; }
```

#### Property Value
[System\.Collections\.Generic\.List&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[DiGi\.Geometry\.Planar\.Classes\.Polyline2D](https://learn.microsoft.com/en-us/dotnet/api/digi.geometry.planar.classes.polyline2d 'DiGi\.Geometry\.Planar\.Classes\.Polyline2D')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')

<a name='DiGi.GIS.Classes.OpeningGenerationInput.YearBuilt'></a>

## OpeningGenerationInput\.YearBuilt Property

Gets the year the building was completed, or null when unknown\.

```csharp
public System.Nullable<short> YearBuilt { get; }
```

#### Property Value
[System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Int16](https://learn.microsoft.com/en-us/dotnet/api/system.int16 'System\.Int16')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

<a name='DiGi.GIS.Classes.OpeningGenerationInput.YearBuiltSource'></a>

## OpeningGenerationInput\.YearBuiltSource Property

Gets where the year built comes from, or null when no year is known\.

```csharp
public System.Nullable<DiGi.GIS.Enums.YearBuiltSource> YearBuiltSource { get; }
```

#### Property Value
[System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[DiGi\.GIS\.Enums\.YearBuiltSource](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.enums.yearbuiltsource 'DiGi\.GIS\.Enums\.YearBuiltSource')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

<a name='DiGi.GIS.Classes.OpeningGenerationOptions'></a>

## OpeningGenerationOptions Class

Holds every numeric rule `Modify.GenerateOpenings` applies, so nothing is hard\-coded in the generator \(DiGi\-Organization/DiGi\.GIS\.Analytical\#2\)\.

`Create.OpeningGenerationOptions(BuildingRegulation)` fills them per regime, and the wiki page Opening Generation lists each value with its source and status. Values with no cited source are decided defaults to be calibrated.

```csharp
public class OpeningGenerationOptions : DiGi.Core.Classes.SerializableOptions, DiGi.GIS.Interfaces.IGISSerializableObject, DiGi.GIS.Interfaces.IGISObject, DiGi.Core.Interfaces.IObject, DiGi.Core.Interfaces.ISerializableObject, DiGi.Core.Interfaces.ICloneableObject<DiGi.Core.Interfaces.ISerializableObject>, DiGi.Core.Interfaces.ICloneableObject
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [DiGi\.Core\.Classes\.Object](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.object 'DiGi\.Core\.Classes\.Object') → [DiGi\.Core\.Classes\.SerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.serializableobject 'DiGi\.Core\.Classes\.SerializableObject') → [DiGi\.Core\.Classes\.SerializableOptions](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.serializableoptions 'DiGi\.Core\.Classes\.SerializableOptions') → OpeningGenerationOptions

Implements [DiGi\.GIS\.Interfaces\.IGISSerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.interfaces.igisserializableobject 'DiGi\.GIS\.Interfaces\.IGISSerializableObject'), [DiGi\.GIS\.Interfaces\.IGISObject](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.interfaces.igisobject 'DiGi\.GIS\.Interfaces\.IGISObject'), [DiGi\.Core\.Interfaces\.IObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iobject 'DiGi\.Core\.Interfaces\.IObject'), [DiGi\.Core\.Interfaces\.ISerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iserializableobject 'DiGi\.Core\.Interfaces\.ISerializableObject'), [DiGi\.Core\.Interfaces\.ICloneableObject&lt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject-1 'DiGi\.Core\.Interfaces\.ICloneableObject\`1')[DiGi\.Core\.Interfaces\.ISerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iserializableobject 'DiGi\.Core\.Interfaces\.ISerializableObject')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject-1 'DiGi\.Core\.Interfaces\.ICloneableObject\`1'), [DiGi\.Core\.Interfaces\.ICloneableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject 'DiGi\.Core\.Interfaces\.ICloneableObject')
### Constructors

<a name='DiGi.GIS.Classes.OpeningGenerationOptions.OpeningGenerationOptions()'></a>

## OpeningGenerationOptions\(\) Constructor

Initializes a new instance of the [OpeningGenerationOptions](DiGi.GIS.Classes.md#DiGi.GIS.Classes.OpeningGenerationOptions 'DiGi\.GIS\.Classes\.OpeningGenerationOptions') class with the values of the current regime\.

```csharp
public OpeningGenerationOptions();
```

<a name='DiGi.GIS.Classes.OpeningGenerationOptions.OpeningGenerationOptions(DiGi.GIS.Classes.OpeningGenerationOptions)'></a>

## OpeningGenerationOptions\(OpeningGenerationOptions\) Constructor

Initializes a new instance of the [OpeningGenerationOptions](DiGi.GIS.Classes.md#DiGi.GIS.Classes.OpeningGenerationOptions 'DiGi\.GIS\.Classes\.OpeningGenerationOptions') class by copying another instance\.

```csharp
public OpeningGenerationOptions(DiGi.GIS.Classes.OpeningGenerationOptions? openingGenerationOptions);
```
#### Parameters

<a name='DiGi.GIS.Classes.OpeningGenerationOptions.OpeningGenerationOptions(DiGi.GIS.Classes.OpeningGenerationOptions).openingGenerationOptions'></a>

`openingGenerationOptions` [OpeningGenerationOptions](DiGi.GIS.Classes.md#DiGi.GIS.Classes.OpeningGenerationOptions 'DiGi\.GIS\.Classes\.OpeningGenerationOptions')

The options to copy\. This value can be null\.

<a name='DiGi.GIS.Classes.OpeningGenerationOptions.OpeningGenerationOptions(System.Text.Json.Nodes.JsonObject)'></a>

## OpeningGenerationOptions\(JsonObject\) Constructor

Initializes a new instance of the [OpeningGenerationOptions](DiGi.GIS.Classes.md#DiGi.GIS.Classes.OpeningGenerationOptions 'DiGi\.GIS\.Classes\.OpeningGenerationOptions') class from a JSON object\.

```csharp
public OpeningGenerationOptions(System.Text.Json.Nodes.JsonObject? jsonObject);
```
#### Parameters

<a name='DiGi.GIS.Classes.OpeningGenerationOptions.OpeningGenerationOptions(System.Text.Json.Nodes.JsonObject).jsonObject'></a>

`jsonObject` [System\.Text\.Json\.Nodes\.JsonObject](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.nodes.jsonobject 'System\.Text\.Json\.Nodes\.JsonObject')

The JSON object containing the data\. This value can be null\.
### Properties

<a name='DiGi.GIS.Classes.OpeningGenerationOptions.AssignEnvelopeConstructions'></a>

## OpeningGenerationOptions\.AssignEnvelopeConstructions Property

Gets or sets a value indicating whether the envelope components of the model take the constructions of the same construction set as the openings \(DiGi\-Organization/DiGi\.GIS\.Analytical\#11\)\.

When true, a wall carrying [DiGi\.Analytical\.Building\.Enums\.ComponentParameter\.PartyWall](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.enums.componentparameter.partywall 'DiGi\.Analytical\.Building\.Enums\.ComponentParameter\.PartyWall') takes `PartyWall`, a wall of the external shell takes `ExternalWall` and any other wall `InternalWall`; a roof takes `FlatRoof` below a tilt of 5 degrees of its shell face against the world up axis, otherwise `Roof`; the lowest floor takes `FloorOverUnheated` when the construction set's `TypologyData.FloorBoundary` is `Cellar`, otherwise `GroundFloor`, and every other floor `IntermediateFloor`. A role the library has no construction for leaves the component untouched and is reported in [MissingConstructionRoles](DiGi.GIS.Classes.md#DiGi.GIS.Classes.OpeningGenerationResult.MissingConstructionRoles 'DiGi\.GIS\.Classes\.OpeningGenerationResult\.MissingConstructionRoles'). When false, no component construction is touched.

```csharp
public bool AssignEnvelopeConstructions { get; set; }
```

#### Property Value
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

<a name='DiGi.GIS.Classes.OpeningGenerationOptions.ConstructionFlavour'></a>

## OpeningGenerationOptions\.ConstructionFlavour Property

Gets or sets the construction flavour the thermal values of window and door constructions are copied from: [DiGi\.Analytical\.Building\.Regulation\.Enums\.ConstructionFlavour\.TypicalAsBuilt](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.regulation.enums.constructionflavour.typicalasbuilt 'DiGi\.Analytical\.Building\.Regulation\.Enums\.ConstructionFlavour\.TypicalAsBuilt') \(TABULA, looked up by year built\) for stock modelling, or [DiGi\.Analytical\.Building\.Regulation\.Enums\.ConstructionFlavour\.Regulation](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.regulation.enums.constructionflavour.regulation 'DiGi\.Analytical\.Building\.Regulation\.Enums\.ConstructionFlavour\.Regulation') \(U\(max\) of the stage, looked up by design date\)\. A role the chosen flavour lacks falls back to TypicalAsBuilt\.

```csharp
public DiGi.Analytical.Building.Regulation.Enums.ConstructionFlavour ConstructionFlavour { get; set; }
```

#### Property Value
[DiGi\.Analytical\.Building\.Regulation\.Enums\.ConstructionFlavour](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.regulation.enums.constructionflavour 'DiGi\.Analytical\.Building\.Regulation\.Enums\.ConstructionFlavour')

<a name='DiGi.GIS.Classes.OpeningGenerationOptions.CornerMargin'></a>

## OpeningGenerationOptions\.CornerMargin Property

Gets or sets the smallest distance from a wall end to a window or door \[m\]\. A decided default\.

```csharp
public double CornerMargin { get; set; }
```

#### Property Value
[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

<a name='DiGi.GIS.Classes.OpeningGenerationOptions.DaylightRatio'></a>

## OpeningGenerationOptions\.DaylightRatio Property

Gets or sets the minimum ratio of glazed area, in the clear of the frames, to floor area of rooms for people \[\-\]\.

1:8 in § 57 ust. 2 of the technical conditions of 2002 (Dz.U. 2022 poz. 1225) and of 1994 (Dz.U. 1995 nr 10 poz. 46), both read in ISAP on 2026-11-01. 1:10 ("one tenth of the floor area of the dwelling") in the 1928 regulation (Dz.U. 1928 nr 23 poz. 202), read on the same date. A decided 1:8 for the 1961 and 1980 regimes, whose texts give no ratio.

```csharp
public double DaylightRatio { get; set; }
```

#### Property Value
[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

<a name='DiGi.GIS.Classes.OpeningGenerationOptions.DesignLag'></a>

## OpeningGenerationOptions\.DesignLag Property

Gets or sets the number of years between design and completion: the regime is selected for the year built minus this lag\.

```csharp
public int DesignLag { get; set; }
```

#### Property Value
[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

<a name='DiGi.GIS.Classes.OpeningGenerationOptions.DoorMinimumHeight'></a>

## OpeningGenerationOptions\.DoorMinimumHeight Property

Gets or sets the minimum clear height of an entrance door \[m\]: § 62 ust\. 1 of the technical conditions of 2002, read in ISAP on 2026\-11\-01\. A door below it is reported, not resized\.

```csharp
public double DoorMinimumHeight { get; set; }
```

#### Property Value
[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

<a name='DiGi.GIS.Classes.OpeningGenerationOptions.DoorMinimumWidth'></a>

## OpeningGenerationOptions\.DoorMinimumWidth Property

Gets or sets the minimum clear width of an entrance door, or of the main leaf of a two\-leaf door \[m\]: § 62 ust\. 1 of the technical conditions of 2002, read in ISAP on 2026\-11\-01\.

```csharp
public double DoorMinimumWidth { get; set; }
```

#### Property Value
[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

<a name='DiGi.GIS.Classes.OpeningGenerationOptions.FireSeparationDistancePMHigh'></a>

## OpeningGenerationOptions\.FireSeparationDistancePMHigh Property

Gets or sets the fire\-separation distance when a building of kind PM has a fuel\-load density Q above 4000 MJ/m2 \[m\] \(DiGi\-Organization/DiGi\.GIS\.Analytical\#9\)\.

§ 271 ust. 1 table of the technical conditions of 2002 (Dz.U. 2022 poz. 1225), read in ISAP on 2026-11-01.

```csharp
public double FireSeparationDistancePMHigh { get; set; }
```

#### Property Value
[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

<a name='DiGi.GIS.Classes.OpeningGenerationOptions.FireSeparationDistancePMMid'></a>

## OpeningGenerationOptions\.FireSeparationDistancePMMid Property

Gets or sets the fire\-separation distance when a building of kind PM has a fuel\-load density Q above 1000 and at most 4000 MJ/m2 \[m\] \(DiGi\-Organization/DiGi\.GIS\.Analytical\#9\)\.

§ 271 ust. 1 table of the technical conditions of 2002 (Dz.U. 2022 poz. 1225), read in ISAP on 2026-11-01.

```csharp
public double FireSeparationDistancePMMid { get; set; }
```

#### Property Value
[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

<a name='DiGi.GIS.Classes.OpeningGenerationOptions.FireSeparationDistances'></a>

## OpeningGenerationOptions\.FireSeparationDistances Property

Gets or sets the fire\-separation distance per kind of building when the fuel\-load density Q of both fire compartments is at most 1000 MJ/m2 \[m\]; a kind missing from the dictionary falls back to the largest value present, an empty dictionary switches § 271 off \(DiGi\-Organization/DiGi\.GIS\.Analytical\#9\)\.

§ 271 ust. 1 table of the technical conditions of 2002 (Dz.U. 2022 poz. 1225), read in ISAP on 2026-11-01: the required distance between two buildings is the larger of their row values, so ZL, IN and PM at Q <= 1000 all give 8 m against each other and the ZL row already carries the 15 m and 20 m the PM rows of higher fuel loads demand. The kinds are [FireClass](DiGi.GIS.Analytical.Enums.md#DiGi.GIS.Analytical.Enums.FireClass 'DiGi\.GIS\.Analytical\.Enums\.FireClass').

```csharp
public System.Collections.Generic.Dictionary<DiGi.GIS.Analytical.Enums.FireClass,double>? FireSeparationDistances { get; set; }
```

#### Property Value
[System\.Collections\.Generic\.Dictionary&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2 'System\.Collections\.Generic\.Dictionary\`2')[FireClass](DiGi.GIS.Analytical.Enums.md#DiGi.GIS.Analytical.Enums.FireClass 'DiGi\.GIS\.Analytical\.Enums\.FireClass')[,](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2 'System\.Collections\.Generic\.Dictionary\`2')[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2 'System\.Collections\.Generic\.Dictionary\`2')

<a name='DiGi.GIS.Classes.OpeningGenerationOptions.FireSeparationHalfStripAngle'></a>

## OpeningGenerationOptions\.FireSeparationHalfStripAngle Property

Gets or sets the smallest angle between two external walls \[deg\] from which the strip of § 271 is taken at half the distance \(DiGi\-Organization/DiGi\.GIS\.Analytical\#9\)\.

§ 271 ust. 11 of the technical conditions of 2002 (Dz.U. 2022 poz. 1225), read in ISAP on 2026-11-01: for walls forming an angle of 60 deg or more but less than 120 deg the strip is reduced by 50 %. The angle is measured between the wall planes on the side of the gap between the two buildings, so parallel facing walls give 0 deg and take the full strip; since no fire-resistance data exists to evaluate the strip requirement of ust. 10 itself, the clause is applied to the distance here as specified by DiGi-Organization/DiGi.GIS.Analytical#9.

```csharp
public double FireSeparationHalfStripAngle { get; set; }
```

#### Property Value
[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

<a name='DiGi.GIS.Classes.OpeningGenerationOptions.FireSeparationHeatRelease'></a>

## OpeningGenerationOptions\.FireSeparationHeatRelease Property

Gets or sets the maximum fuel\-load density Q of the fire compartment \[MJ/m2\], or null when unknown \(DiGi\-Organization/DiGi\.GIS\.Analytical\#9\)\.

§ 271 ust. 1 of the technical conditions of 2002 (Dz.U. 2022 poz. 1225), read in ISAP on 2026-11-01: a building of kind PM takes its row of the table by Q, so with Q null a PM building stays at Q <= 1000 MJ/m2. A building whose function does not say whether it is PM takes the row of a stated Q as well, since the table works by the larger requirement of the two buildings.

```csharp
public System.Nullable<double> FireSeparationHeatRelease { get; set; }
```

#### Property Value
[System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

<a name='DiGi.GIS.Classes.OpeningGenerationOptions.FireSeparationNoApplyAngle'></a>

## OpeningGenerationOptions\.FireSeparationNoApplyAngle Property

Gets or sets the angle between two external walls \[deg\] from which § 271 does not apply between them \(DiGi\-Organization/DiGi\.GIS\.Analytical\#9\)\.

§ 271 ust. 12 pkt 2 of the technical conditions of 2002 (Dz.U. 2022 poz. 1225), read in ISAP on 2026-11-01: the requirement does not concern buildings whose external walls form an angle of at least 120 deg, measured as in [FireSeparationHalfStripAngle](DiGi.GIS.Classes.md#DiGi.GIS.Classes.OpeningGenerationOptions.FireSeparationHalfStripAngle 'DiGi\.GIS\.Classes\.OpeningGenerationOptions\.FireSeparationHalfStripAngle').

```csharp
public double FireSeparationNoApplyAngle { get; set; }
```

#### Property Value
[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

<a name='DiGi.GIS.Classes.OpeningGenerationOptions.FireSeparationNoOpeningsFactor'></a>

## OpeningGenerationOptions\.FireSeparationNoOpeningsFactor Property

Gets or sets the factor applied to the § 271 distance when the two facing walls carry no openings and neither building spreads fire \[\-\] \(DiGi\-Organization/DiGi\.GIS\.Analytical\#9\)\.

§ 271 ust. 9 of the technical conditions of 2002 (Dz.U. 2022 poz. 1225), read in ISAP on 2026-11-01: a reduction of 25 %. The further conditions of that clause - buildings listed in § 213 (which include single-family, farm and individual-recreation buildings of up to three storeys), roofs with non-spreading coverings and no explosion-hazard room - are only partly reachable from the stock data: the roof condition rides on [FireSpreading](DiGi.GIS.Analytical.Enums.md#DiGi.GIS.Analytical.Enums.BuildingModelParameter.FireSpreading 'DiGi\.GIS\.Analytical\.Enums\.BuildingModelParameter\.FireSpreading'), while § 213 membership and explosion-hazard rooms are not modelled and the clause is taken to hold when the walls are opening-free. The walls are read as they are given, before the subject's own openings are placed.

```csharp
public double FireSeparationNoOpeningsFactor { get; set; }
```

#### Property Value
[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

<a name='DiGi.GIS.Classes.OpeningGenerationOptions.FireSeparationSpreadFactor_BothSides'></a>

## OpeningGenerationOptions\.FireSeparationSpreadFactor\_BothSides Property

Gets or sets the factor applied to the § 271 distance when both buildings \- their external walls facing each other or their roof coverings \- spread fire \[\-\] \(DiGi\-Organization/DiGi\.GIS\.Analytical\#9\)\.

§ 271 ust. 2 of the technical conditions of 2002 (Dz.U. 2022 poz. 1225), read in ISAP on 2026-11-01: an increase of 100 %.

```csharp
public double FireSeparationSpreadFactor_BothSides { get; set; }
```

#### Property Value
[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

<a name='DiGi.GIS.Classes.OpeningGenerationOptions.FireSeparationSpreadFactor_OneSide'></a>

## OpeningGenerationOptions\.FireSeparationSpreadFactor\_OneSide Property

Gets or sets the factor applied to the § 271 distance when one of the two buildings \- its external wall facing the neighbour or its roof covering \- spreads fire \[\-\] \(DiGi\-Organization/DiGi\.GIS\.Analytical\#9\)\.

§ 271 ust. 2 of the technical conditions of 2002 (Dz.U. 2022 poz. 1225), read in ISAP on 2026-11-01: an increase of 50 %. Whether a building spreads fire comes from [FireSpreading](DiGi.GIS.Analytical.Enums.md#DiGi.GIS.Analytical.Enums.BuildingModelParameter.FireSpreading 'DiGi\.GIS\.Analytical\.Enums\.BuildingModelParameter\.FireSpreading'), as no construction data reaches the library.

```csharp
public double FireSeparationSpreadFactor_OneSide { get; set; }
```

#### Property Value
[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

<a name='DiGi.GIS.Classes.OpeningGenerationOptions.FrontageLineMinimumFronts'></a>

## OpeningGenerationOptions\.FrontageLineMinimumFronts Property

Gets or sets the number of building fronts that must align along one road before their walls are reported as a frontage line \(pierzeja\); the walls of the storeys of one building count as its single front \(DiGi\-Organization/DiGi\.GIS\.Analytical\#10\)\.

A decided default: three fronts - the subject building plus at least two aligned neighbours. Reported only; a frontage line does not change placement.

```csharp
public int FrontageLineMinimumFronts { get; set; }
```

#### Property Value
[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

<a name='DiGi.GIS.Classes.OpeningGenerationOptions.FrontageLineSetbackTolerance'></a>

## OpeningGenerationOptions\.FrontageLineSetbackTolerance Property

Gets or sets the largest difference in the setback of two aligned fronts from the same road at which they are still reported as one frontage line \[m\] \(DiGi\-Organization/DiGi\.GIS\.Analytical\#10\)\.

A decided default.

```csharp
public double FrontageLineSetbackTolerance { get; set; }
```

#### Property Value
[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

<a name='DiGi.GIS.Classes.OpeningGenerationOptions.HabitableFloorFractions'></a>

## OpeningGenerationOptions\.HabitableFloorFractions Property

Gets or sets the share of floor area in rooms that need daylight, per building type \[\-\]; a type missing from the dictionary takes 0\.6\. A decided default: single\-family 0\.60, multi\-family 0\.65, non\-residential \([DiGi\.Analytical\.Building\.Regulation\.Enums\.BuildingType\.Undefined](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.regulation.enums.buildingtype.undefined 'DiGi\.Analytical\.Building\.Regulation\.Enums\.BuildingType\.Undefined')\) 0\.50\.

```csharp
public System.Collections.Generic.Dictionary<DiGi.Analytical.Building.Regulation.Enums.BuildingType,double>? HabitableFloorFractions { get; set; }
```

#### Property Value
[System\.Collections\.Generic\.Dictionary&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2 'System\.Collections\.Generic\.Dictionary\`2')[DiGi\.Analytical\.Building\.Regulation\.Enums\.BuildingType](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.regulation.enums.buildingtype 'DiGi\.Analytical\.Building\.Regulation\.Enums\.BuildingType')[,](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2 'System\.Collections\.Generic\.Dictionary\`2')[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2 'System\.Collections\.Generic\.Dictionary\`2')

<a name='DiGi.GIS.Classes.OpeningGenerationOptions.HeadClearance'></a>

## OpeningGenerationOptions\.HeadClearance Property

Gets or sets the smallest distance between a window head and the top of its storey band \[m\]\. A decided default\.

```csharp
public double HeadClearance { get; set; }
```

#### Property Value
[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

<a name='DiGi.GIS.Classes.OpeningGenerationOptions.HighSillElevation'></a>

## OpeningGenerationOptions\.HighSillElevation Property

Gets or sets the height above the ground storey from which [HighSillHeight](DiGi.GIS.Classes.md#DiGi.GIS.Classes.OpeningGenerationOptions.HighSillHeight 'DiGi\.GIS\.Classes\.OpeningGenerationOptions\.HighSillHeight') applies \[m\]: § 301 of the technical conditions of 2002 \(25 m\), read in ISAP on 2026\-11\-01\.

```csharp
public double HighSillElevation { get; set; }
```

#### Property Value
[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

<a name='DiGi.GIS.Classes.OpeningGenerationOptions.HighSillHeight'></a>

## OpeningGenerationOptions\.HighSillHeight Property

Gets or sets the minimum sill height on storeys more than [HighSillElevation](DiGi.GIS.Classes.md#DiGi.GIS.Classes.OpeningGenerationOptions.HighSillElevation 'DiGi\.GIS\.Classes\.OpeningGenerationOptions\.HighSillElevation') above the ground \[m\]: § 301 ust\. 2 of the technical conditions of 2002 \(1\.1 m\), read in ISAP on 2026\-11\-01; the 1980 conditions \(§ 64, Dz\.U\. 1980 nr 17 poz\. 62\) asked for a guard to 1\.1 m\.

```csharp
public double HighSillHeight { get; set; }
```

#### Property Value
[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

<a name='DiGi.GIS.Classes.OpeningGenerationOptions.InterstoreyStrip'></a>

## OpeningGenerationOptions\.InterstoreyStrip Property

Gets or sets the minimum distance between the head of a window and the sill of the window above it \[m\]: § 223 ust\. 1 of the technical conditions of 2002 \(0\.8 m\), read in ISAP on 2026\-11\-01; assumed for earlier regimes\.

```csharp
public double InterstoreyStrip { get; set; }
```

#### Property Value
[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

<a name='DiGi.GIS.Classes.OpeningGenerationOptions.MaximumGlazedAreaSingleFamilyOnly'></a>

## OpeningGenerationOptions\.MaximumGlazedAreaSingleFamilyOnly Property

Gets or sets a value indicating whether the maximum glazed area applies to single\-family buildings only: so in the original technical conditions of 2002 \(annex 2 pt 2\.1\.1\), read in ISAP on 2026\-11\-01\.

```csharp
public bool MaximumGlazedAreaSingleFamilyOnly { get; set; }
```

#### Property Value
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

<a name='DiGi.GIS.Classes.OpeningGenerationOptions.MaximumGlazedAreaThermalTransmittance'></a>

## OpeningGenerationOptions\.MaximumGlazedAreaThermalTransmittance Property

Gets or sets the window U\-value from which the maximum glazed area A0max = 0\.15 · Az \+ 0\.03 · Aw applies \[W/\(m2K\)\], or null when the regime has no such limit\.

Annex 2 pt 2.1.1 of the technical conditions, read in ISAP on 2026-11-01: 2.0 from 2002 for single-family buildings (Dz.U. 2002 nr 75 poz. 690); 1.5 from 2009 for residential buildings (Dz.U. 2008 nr 201 poz. 1238); 0.9 from 2014 (Dz.U. 2013 poz. 926). The annex that replaced it from 1 January 2018 (Dz.U. 2017 poz. 2285) has no such limit.

```csharp
public System.Nullable<double> MaximumGlazedAreaThermalTransmittance { get; set; }
```

#### Property Value
[System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

<a name='DiGi.GIS.Classes.OpeningGenerationOptions.MaximumStoreyHeightFactor'></a>

## OpeningGenerationOptions\.MaximumStoreyHeightFactor Property

Gets or sets the multiple of the stock's typical storey height above which a storey band is reported as a height mismatch \[\-\]\. A decided default\.

```csharp
public double MaximumStoreyHeightFactor { get; set; }
```

#### Property Value
[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

<a name='DiGi.GIS.Classes.OpeningGenerationOptions.MinimumPier'></a>

## OpeningGenerationOptions\.MinimumPier Property

Gets or sets the smallest wall between two windows \[m\]\. A decided default\.

```csharp
public double MinimumPier { get; set; }
```

#### Property Value
[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

<a name='DiGi.GIS.Classes.OpeningGenerationOptions.MinimumStoreyHeight'></a>

## OpeningGenerationOptions\.MinimumStoreyHeight Property

Gets or sets the storey band height below which a band is reported as a height mismatch \[m\]\. A decided default\.

```csharp
public double MinimumStoreyHeight { get; set; }
```

#### Property Value
[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

<a name='DiGi.GIS.Classes.OpeningGenerationOptions.ObstructionInnerCityFactor'></a>

## OpeningGenerationOptions\.ObstructionInnerCityFactor Property

Gets or sets the factor the § 13 distances are multiplied by in inner\-city development, or null when the building stands outside it \[\-\] \(DiGi\-Organization/DiGi\.GIS\.Analytical\#9\)\.

§ 13 ust. 4 of the technical conditions of 2002 (Dz.U. 2022 poz. 1225), read in ISAP on 2026-11-01: the distances may be reduced by no more than half in zabudowa srodmiejska as defined in § 3 pkt 1, so 0.5 is the largest reduction. Whether the building stands in such development is decided by the caller, from the local plan; a null value applies no factor.

```csharp
public System.Nullable<double> ObstructionInnerCityFactor { get; set; }
```

#### Property Value
[System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

<a name='DiGi.GIS.Classes.OpeningGenerationOptions.ObstructionMaxDistance'></a>

## OpeningGenerationOptions\.ObstructionMaxDistance Property

Gets or sets the largest height of shading an obstructing object may demand \[m\]; above it the required distance stops growing \(DiGi\-Organization/DiGi\.GIS\.Analytical\#9\)\.

§ 13 ust. 1 pkt 1 of the technical conditions of 2002 (Dz.U. 2022 poz. 1225), read in ISAP on 2026-11-01: 35 m for obstructing objects taller than 35 m. This value also caps which neighbours are looked at, the § 271 distances never exceeding it once their factors are read with [FireSeparationSpreadFactor\_BothSides](DiGi.GIS.Classes.md#DiGi.GIS.Classes.OpeningGenerationOptions.FireSeparationSpreadFactor_BothSides 'DiGi\.GIS\.Classes\.OpeningGenerationOptions\.FireSeparationSpreadFactor\_BothSides').

```csharp
public double ObstructionMaxDistance { get; set; }
```

#### Property Value
[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

<a name='DiGi.GIS.Classes.OpeningGenerationOptions.ObstructionSectorAngle'></a>

## OpeningGenerationOptions\.ObstructionSectorAngle Property

Gets or sets the angle of the horizontal daylight sector measured at the inner wall face on the window axis \[deg\] \(DiGi\-Organization/DiGi\.GIS\.Analytical\#9\)\.

§ 13 ust. 1 pkt 1 of the technical conditions of 2002 (Dz.U. 2022 poz. 1225), read in ISAP on 2026-11-01: no obstructing part of the same building or other obstructing object may lie between the arms of a 60 degree angle closer than its height of shading.

```csharp
public double ObstructionSectorAngle { get; set; }
```

#### Property Value
[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

<a name='DiGi.GIS.Classes.OpeningGenerationOptions.ObstructionSlenderDistance'></a>

## OpeningGenerationOptions\.ObstructionSlenderDistance Property

Gets or sets the distance at which a slender obstructing object of [ObstructionSlenderWidth](DiGi.GIS.Classes.md#DiGi.GIS.Classes.OpeningGenerationOptions.ObstructionSlenderWidth 'DiGi\.GIS\.Classes\.OpeningGenerationOptions\.ObstructionSlenderWidth') or less is permitted regardless of its height \[m\] \(DiGi\-Organization/DiGi\.GIS\.Analytical\#9\)\.

§ 13 ust. 3 of the technical conditions of 2002 (Dz.U. 2022 poz. 1225), read in ISAP on 2026-11-01: not less than 10 m from the window, without limit on the object's height. A slender object shorter than this distance still answers to the height of shading, so its required distance is the smaller of the two.

```csharp
public double ObstructionSlenderDistance { get; set; }
```

#### Property Value
[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

<a name='DiGi.GIS.Classes.OpeningGenerationOptions.ObstructionSlenderWidth'></a>

## OpeningGenerationOptions\.ObstructionSlenderWidth Property

Gets or sets the largest obstructing width of an object measured parallel to the window plane at which § 13 ust\. 3 gives it the fixed distance of [ObstructionSlenderDistance](DiGi.GIS.Classes.md#DiGi.GIS.Classes.OpeningGenerationOptions.ObstructionSlenderDistance 'DiGi\.GIS\.Classes\.OpeningGenerationOptions\.ObstructionSlenderDistance') instead of its height \[m\] \(DiGi\-Organization/DiGi\.GIS\.Analytical\#9\)\.

§ 13 ust. 3 of the technical conditions of 2002 (Dz.U. 2022 poz. 1225), read in ISAP on 2026-11-01: a mast, chimney, tower or other building object of obstructing width not greater than 3 m.

```csharp
public double ObstructionSlenderWidth { get; set; }
```

#### Property Value
[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

<a name='DiGi.GIS.Classes.OpeningGenerationOptions.RoadFrontageDistance'></a>

## OpeningGenerationOptions\.RoadFrontageDistance Property

Gets or sets the depth of the strip facing a wall within which a road polyline marks the wall as road frontage \[m\] \(DiGi\-Organization/DiGi\.GIS\.Analytical\#10\)\.

§ 12 ust. 1 pkt 1 and ust. 10 of the technical conditions of 2002 (Dz.U. 2002 nr 75 poz. 690, t.j. Dz.U. 2022 poz. 1225), ust. 10 in the wording added by the amendment of 27 October 2023 (Dz.U. 2023 poz. 2442), read on 2026-11-01 in the Dziennik Ustaw text (ISAP directs machine access to eli.gov.pl): the distances of ust. 1-9 are not required when the neighbouring plot is a road plot or a publicly accessible square, and 4 m is the distance of ust. 1 pkt 1 for a wall turned towards that boundary with windows or doors. The road polyline standing in for the neighbouring plot is a proxy: no parcel data reaches the generator.

```csharp
public double RoadFrontageDistance { get; set; }
```

#### Property Value
[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

<a name='DiGi.GIS.Classes.OpeningGenerationOptions.RoomMixes'></a>

## OpeningGenerationOptions\.RoomMixes Property

Gets or sets the shares of a storey's glazing target by room use, per building type \[\-\]; a type missing from the dictionary takes the multi\-family shares\. A decided default \(the model has one space per storey and no rooms\): single\-family living 0\.60, kitchen 0\.25, bathroom 0\.15; multi\-family living 0\.65, kitchen 0\.25, bathroom 0\.10\.

```csharp
public System.Collections.Generic.Dictionary<DiGi.Analytical.Building.Regulation.Enums.BuildingType,System.Collections.Generic.Dictionary<DiGi.Analytical.Building.Regulation.Enums.RoomUse,double>>? RoomMixes { get; set; }
```

#### Property Value
[System\.Collections\.Generic\.Dictionary&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2 'System\.Collections\.Generic\.Dictionary\`2')[DiGi\.Analytical\.Building\.Regulation\.Enums\.BuildingType](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.regulation.enums.buildingtype 'DiGi\.Analytical\.Building\.Regulation\.Enums\.BuildingType')[,](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2 'System\.Collections\.Generic\.Dictionary\`2')[System\.Collections\.Generic\.Dictionary&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2 'System\.Collections\.Generic\.Dictionary\`2')[DiGi\.Analytical\.Building\.Regulation\.Enums\.RoomUse](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.regulation.enums.roomuse 'DiGi\.Analytical\.Building\.Regulation\.Enums\.RoomUse')[,](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2 'System\.Collections\.Generic\.Dictionary\`2')[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2 'System\.Collections\.Generic\.Dictionary\`2')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2 'System\.Collections\.Generic\.Dictionary\`2')

<a name='DiGi.GIS.Classes.OpeningGenerationOptions.SillHeight'></a>

## OpeningGenerationOptions\.SillHeight Property

Gets or sets the minimum sill height above the floor of storeys other than the ground storey \[m\]: § 301 ust\. 1 of the technical conditions of 2002 \(0\.85 m, the ground storey exempt\) and the conditions of 1994 and 1980 \(§ 63\), read in ISAP on 2026\-11\-01; assumed for earlier regimes\.

```csharp
public double SillHeight { get; set; }
```

#### Property Value
[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

<a name='DiGi.GIS.Classes.OpeningGenerationOptions.StaircaseSpacing'></a>

## OpeningGenerationOptions\.StaircaseSpacing Property

Gets or sets the façade length per staircase of a multi\-family building \[m\], which sets the number of staircase entrance doors\. A decided default\.

```csharp
public double StaircaseSpacing { get; set; }
```

#### Property Value
[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

<a name='DiGi.GIS.Classes.OpeningGenerationOptions.StreetFacadeWeights'></a>

## OpeningGenerationOptions\.StreetFacadeWeights Property

Gets or sets the weight of the front wall when windows are distributed over the walls, per building type \[\-\]; a type missing from the dictionary takes 1\.0\. A decided default, set per regime by `Create.OpeningGenerationOptions`\.

```csharp
public System.Collections.Generic.Dictionary<DiGi.Analytical.Building.Regulation.Enums.BuildingType,double>? StreetFacadeWeights { get; set; }
```

#### Property Value
[System\.Collections\.Generic\.Dictionary&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2 'System\.Collections\.Generic\.Dictionary\`2')[DiGi\.Analytical\.Building\.Regulation\.Enums\.BuildingType](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.regulation.enums.buildingtype 'DiGi\.Analytical\.Building\.Regulation\.Enums\.BuildingType')[,](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2 'System\.Collections\.Generic\.Dictionary\`2')[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2 'System\.Collections\.Generic\.Dictionary\`2')

<a name='DiGi.GIS.Classes.OpeningGenerationResult'></a>

## OpeningGenerationResult Class

Holds what `Modify.GenerateOpenings` did to one building model and what it could not do: the keys it looked the sizes and constructions up by, the storey bands, the restriction of each wall, the frontage lines it found, the front wall, the doors and the envelope roles the library had no construction for \(DiGi\-Organization/DiGi\.GIS\.Analytical\#2, DiGi\-Organization/DiGi\.GIS\.Analytical\#11\)\.

A shortfall against the daylight target is a finding, not an error: in a dense historic block the rules can make 1:8 impossible.

```csharp
public class OpeningGenerationResult : DiGi.Core.Classes.SerializableObject, DiGi.GIS.Interfaces.IGISSerializableObject, DiGi.GIS.Interfaces.IGISObject, DiGi.Core.Interfaces.IObject, DiGi.Core.Interfaces.ISerializableObject, DiGi.Core.Interfaces.ICloneableObject<DiGi.Core.Interfaces.ISerializableObject>, DiGi.Core.Interfaces.ICloneableObject
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [DiGi\.Core\.Classes\.Object](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.object 'DiGi\.Core\.Classes\.Object') → [DiGi\.Core\.Classes\.SerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.serializableobject 'DiGi\.Core\.Classes\.SerializableObject') → OpeningGenerationResult

Implements [DiGi\.GIS\.Interfaces\.IGISSerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.interfaces.igisserializableobject 'DiGi\.GIS\.Interfaces\.IGISSerializableObject'), [DiGi\.GIS\.Interfaces\.IGISObject](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.interfaces.igisobject 'DiGi\.GIS\.Interfaces\.IGISObject'), [DiGi\.Core\.Interfaces\.IObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iobject 'DiGi\.Core\.Interfaces\.IObject'), [DiGi\.Core\.Interfaces\.ISerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iserializableobject 'DiGi\.Core\.Interfaces\.ISerializableObject'), [DiGi\.Core\.Interfaces\.ICloneableObject&lt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject-1 'DiGi\.Core\.Interfaces\.ICloneableObject\`1')[DiGi\.Core\.Interfaces\.ISerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iserializableobject 'DiGi\.Core\.Interfaces\.ISerializableObject')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject-1 'DiGi\.Core\.Interfaces\.ICloneableObject\`1'), [DiGi\.Core\.Interfaces\.ICloneableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject 'DiGi\.Core\.Interfaces\.ICloneableObject')
### Constructors

<a name='DiGi.GIS.Classes.OpeningGenerationResult.OpeningGenerationResult(DiGi.GIS.Classes.OpeningGenerationResult)'></a>

## OpeningGenerationResult\(OpeningGenerationResult\) Constructor

Initializes a new instance of the [OpeningGenerationResult](DiGi.GIS.Classes.md#DiGi.GIS.Classes.OpeningGenerationResult 'DiGi\.GIS\.Classes\.OpeningGenerationResult') class by copying another instance\.

```csharp
public OpeningGenerationResult(DiGi.GIS.Classes.OpeningGenerationResult? openingGenerationResult);
```
#### Parameters

<a name='DiGi.GIS.Classes.OpeningGenerationResult.OpeningGenerationResult(DiGi.GIS.Classes.OpeningGenerationResult).openingGenerationResult'></a>

`openingGenerationResult` [OpeningGenerationResult](DiGi.GIS.Classes.md#DiGi.GIS.Classes.OpeningGenerationResult 'DiGi\.GIS\.Classes\.OpeningGenerationResult')

The instance to copy\. This value can be null\.

<a name='DiGi.GIS.Classes.OpeningGenerationResult.OpeningGenerationResult(string,DiGi.Analytical.Building.Regulation.Enums.BuildingRegulation,System.Nullable_short_,System.Nullable_DiGi.GIS.Enums.YearBuiltSource_,DiGi.Analytical.Building.Regulation.Enums.ConstructionFlavour,DiGi.Analytical.Building.Regulation.Enums.BuildingType,string,string,DiGi.GIS.Analytical.Enums.StoreySource,double,System.Nullable_System.Guid_,DiGi.GIS.Analytical.Enums.FrontWallRule,System.Collections.Generic.List_DiGi.GIS.Classes.OpeningGenerationStorey_,System.Collections.Generic.Dictionary_System.Guid,DiGi.GIS.Analytical.Enums.WallOpeningRestriction_,int,int,int,System.Collections.Generic.Dictionary_System.Guid,string_,System.Collections.Generic.Dictionary_System.Guid,DiGi.Analytical.Building.Regulation.Enums.ConstructionRole_)'></a>

## OpeningGenerationResult\(string, BuildingRegulation, Nullable\<short\>, Nullable\<YearBuiltSource\>, ConstructionFlavour, BuildingType, string, string, StoreySource, double, Nullable\<Guid\>, FrontWallRule, List\<OpeningGenerationStorey\>, Dictionary\<Guid,WallOpeningRestriction\>, int, int, int, Dictionary\<Guid,string\>, Dictionary\<Guid,ConstructionRole\>\) Constructor

Initializes a new instance of the [OpeningGenerationResult](DiGi.GIS.Classes.md#DiGi.GIS.Classes.OpeningGenerationResult 'DiGi\.GIS\.Classes\.OpeningGenerationResult') class\.

```csharp
public OpeningGenerationResult(string? reference, DiGi.Analytical.Building.Regulation.Enums.BuildingRegulation buildingRegulation, System.Nullable<short> yearBuilt, System.Nullable<DiGi.GIS.Enums.YearBuiltSource> yearBuiltSource, DiGi.Analytical.Building.Regulation.Enums.ConstructionFlavour constructionFlavour, DiGi.Analytical.Building.Regulation.Enums.BuildingType buildingType, string? openingSizeSetSource, string? constructionSetSource, DiGi.GIS.Analytical.Enums.StoreySource storeySource, double maximumGlazedArea, System.Nullable<System.Guid> frontWall, DiGi.GIS.Analytical.Enums.FrontWallRule frontWallRule, System.Collections.Generic.List<DiGi.GIS.Classes.OpeningGenerationStorey>? storeys, System.Collections.Generic.Dictionary<System.Guid,DiGi.GIS.Analytical.Enums.WallOpeningRestriction>? wallOpeningRestrictions, int doorCount, int doorsBelowMinimumCount, int droppedOpeningCount, System.Collections.Generic.Dictionary<System.Guid,string>? frontageLines=null, System.Collections.Generic.Dictionary<System.Guid,DiGi.Analytical.Building.Regulation.Enums.ConstructionRole>? missingConstructionRoles=null);
```
#### Parameters

<a name='DiGi.GIS.Classes.OpeningGenerationResult.OpeningGenerationResult(string,DiGi.Analytical.Building.Regulation.Enums.BuildingRegulation,System.Nullable_short_,System.Nullable_DiGi.GIS.Enums.YearBuiltSource_,DiGi.Analytical.Building.Regulation.Enums.ConstructionFlavour,DiGi.Analytical.Building.Regulation.Enums.BuildingType,string,string,DiGi.GIS.Analytical.Enums.StoreySource,double,System.Nullable_System.Guid_,DiGi.GIS.Analytical.Enums.FrontWallRule,System.Collections.Generic.List_DiGi.GIS.Classes.OpeningGenerationStorey_,System.Collections.Generic.Dictionary_System.Guid,DiGi.GIS.Analytical.Enums.WallOpeningRestriction_,int,int,int,System.Collections.Generic.Dictionary_System.Guid,string_,System.Collections.Generic.Dictionary_System.Guid,DiGi.Analytical.Building.Regulation.Enums.ConstructionRole_).reference'></a>

`reference` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The reference of the 2D building the model belongs to\. This value can be null\.

<a name='DiGi.GIS.Classes.OpeningGenerationResult.OpeningGenerationResult(string,DiGi.Analytical.Building.Regulation.Enums.BuildingRegulation,System.Nullable_short_,System.Nullable_DiGi.GIS.Enums.YearBuiltSource_,DiGi.Analytical.Building.Regulation.Enums.ConstructionFlavour,DiGi.Analytical.Building.Regulation.Enums.BuildingType,string,string,DiGi.GIS.Analytical.Enums.StoreySource,double,System.Nullable_System.Guid_,DiGi.GIS.Analytical.Enums.FrontWallRule,System.Collections.Generic.List_DiGi.GIS.Classes.OpeningGenerationStorey_,System.Collections.Generic.Dictionary_System.Guid,DiGi.GIS.Analytical.Enums.WallOpeningRestriction_,int,int,int,System.Collections.Generic.Dictionary_System.Guid,string_,System.Collections.Generic.Dictionary_System.Guid,DiGi.Analytical.Building.Regulation.Enums.ConstructionRole_).buildingRegulation'></a>

`buildingRegulation` [DiGi\.Analytical\.Building\.Regulation\.Enums\.BuildingRegulation](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.regulation.enums.buildingregulation 'DiGi\.Analytical\.Building\.Regulation\.Enums\.BuildingRegulation')

The building regulation regime the openings were generated under\.

<a name='DiGi.GIS.Classes.OpeningGenerationResult.OpeningGenerationResult(string,DiGi.Analytical.Building.Regulation.Enums.BuildingRegulation,System.Nullable_short_,System.Nullable_DiGi.GIS.Enums.YearBuiltSource_,DiGi.Analytical.Building.Regulation.Enums.ConstructionFlavour,DiGi.Analytical.Building.Regulation.Enums.BuildingType,string,string,DiGi.GIS.Analytical.Enums.StoreySource,double,System.Nullable_System.Guid_,DiGi.GIS.Analytical.Enums.FrontWallRule,System.Collections.Generic.List_DiGi.GIS.Classes.OpeningGenerationStorey_,System.Collections.Generic.Dictionary_System.Guid,DiGi.GIS.Analytical.Enums.WallOpeningRestriction_,int,int,int,System.Collections.Generic.Dictionary_System.Guid,string_,System.Collections.Generic.Dictionary_System.Guid,DiGi.Analytical.Building.Regulation.Enums.ConstructionRole_).yearBuilt'></a>

`yearBuilt` [System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Int16](https://learn.microsoft.com/en-us/dotnet/api/system.int16 'System\.Int16')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

The year built the regime was selected from, or null when unknown\.

<a name='DiGi.GIS.Classes.OpeningGenerationResult.OpeningGenerationResult(string,DiGi.Analytical.Building.Regulation.Enums.BuildingRegulation,System.Nullable_short_,System.Nullable_DiGi.GIS.Enums.YearBuiltSource_,DiGi.Analytical.Building.Regulation.Enums.ConstructionFlavour,DiGi.Analytical.Building.Regulation.Enums.BuildingType,string,string,DiGi.GIS.Analytical.Enums.StoreySource,double,System.Nullable_System.Guid_,DiGi.GIS.Analytical.Enums.FrontWallRule,System.Collections.Generic.List_DiGi.GIS.Classes.OpeningGenerationStorey_,System.Collections.Generic.Dictionary_System.Guid,DiGi.GIS.Analytical.Enums.WallOpeningRestriction_,int,int,int,System.Collections.Generic.Dictionary_System.Guid,string_,System.Collections.Generic.Dictionary_System.Guid,DiGi.Analytical.Building.Regulation.Enums.ConstructionRole_).yearBuiltSource'></a>

`yearBuiltSource` [System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[DiGi\.GIS\.Enums\.YearBuiltSource](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.enums.yearbuiltsource 'DiGi\.GIS\.Enums\.YearBuiltSource')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

Where the year built comes from, or null when no year is known\.

<a name='DiGi.GIS.Classes.OpeningGenerationResult.OpeningGenerationResult(string,DiGi.Analytical.Building.Regulation.Enums.BuildingRegulation,System.Nullable_short_,System.Nullable_DiGi.GIS.Enums.YearBuiltSource_,DiGi.Analytical.Building.Regulation.Enums.ConstructionFlavour,DiGi.Analytical.Building.Regulation.Enums.BuildingType,string,string,DiGi.GIS.Analytical.Enums.StoreySource,double,System.Nullable_System.Guid_,DiGi.GIS.Analytical.Enums.FrontWallRule,System.Collections.Generic.List_DiGi.GIS.Classes.OpeningGenerationStorey_,System.Collections.Generic.Dictionary_System.Guid,DiGi.GIS.Analytical.Enums.WallOpeningRestriction_,int,int,int,System.Collections.Generic.Dictionary_System.Guid,string_,System.Collections.Generic.Dictionary_System.Guid,DiGi.Analytical.Building.Regulation.Enums.ConstructionRole_).constructionFlavour'></a>

`constructionFlavour` [DiGi\.Analytical\.Building\.Regulation\.Enums\.ConstructionFlavour](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.regulation.enums.constructionflavour 'DiGi\.Analytical\.Building\.Regulation\.Enums\.ConstructionFlavour')

The construction flavour the thermal values were copied from\.

<a name='DiGi.GIS.Classes.OpeningGenerationResult.OpeningGenerationResult(string,DiGi.Analytical.Building.Regulation.Enums.BuildingRegulation,System.Nullable_short_,System.Nullable_DiGi.GIS.Enums.YearBuiltSource_,DiGi.Analytical.Building.Regulation.Enums.ConstructionFlavour,DiGi.Analytical.Building.Regulation.Enums.BuildingType,string,string,DiGi.GIS.Analytical.Enums.StoreySource,double,System.Nullable_System.Guid_,DiGi.GIS.Analytical.Enums.FrontWallRule,System.Collections.Generic.List_DiGi.GIS.Classes.OpeningGenerationStorey_,System.Collections.Generic.Dictionary_System.Guid,DiGi.GIS.Analytical.Enums.WallOpeningRestriction_,int,int,int,System.Collections.Generic.Dictionary_System.Guid,string_,System.Collections.Generic.Dictionary_System.Guid,DiGi.Analytical.Building.Regulation.Enums.ConstructionRole_).buildingType'></a>

`buildingType` [DiGi\.Analytical\.Building\.Regulation\.Enums\.BuildingType](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.regulation.enums.buildingtype 'DiGi\.Analytical\.Building\.Regulation\.Enums\.BuildingType')

The building type the sizes and constructions were looked up for\.

<a name='DiGi.GIS.Classes.OpeningGenerationResult.OpeningGenerationResult(string,DiGi.Analytical.Building.Regulation.Enums.BuildingRegulation,System.Nullable_short_,System.Nullable_DiGi.GIS.Enums.YearBuiltSource_,DiGi.Analytical.Building.Regulation.Enums.ConstructionFlavour,DiGi.Analytical.Building.Regulation.Enums.BuildingType,string,string,DiGi.GIS.Analytical.Enums.StoreySource,double,System.Nullable_System.Guid_,DiGi.GIS.Analytical.Enums.FrontWallRule,System.Collections.Generic.List_DiGi.GIS.Classes.OpeningGenerationStorey_,System.Collections.Generic.Dictionary_System.Guid,DiGi.GIS.Analytical.Enums.WallOpeningRestriction_,int,int,int,System.Collections.Generic.Dictionary_System.Guid,string_,System.Collections.Generic.Dictionary_System.Guid,DiGi.Analytical.Building.Regulation.Enums.ConstructionRole_).openingSizeSetSource'></a>

`openingSizeSetSource` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The source text of the opening\-size set used\. This value can be null\.

<a name='DiGi.GIS.Classes.OpeningGenerationResult.OpeningGenerationResult(string,DiGi.Analytical.Building.Regulation.Enums.BuildingRegulation,System.Nullable_short_,System.Nullable_DiGi.GIS.Enums.YearBuiltSource_,DiGi.Analytical.Building.Regulation.Enums.ConstructionFlavour,DiGi.Analytical.Building.Regulation.Enums.BuildingType,string,string,DiGi.GIS.Analytical.Enums.StoreySource,double,System.Nullable_System.Guid_,DiGi.GIS.Analytical.Enums.FrontWallRule,System.Collections.Generic.List_DiGi.GIS.Classes.OpeningGenerationStorey_,System.Collections.Generic.Dictionary_System.Guid,DiGi.GIS.Analytical.Enums.WallOpeningRestriction_,int,int,int,System.Collections.Generic.Dictionary_System.Guid,string_,System.Collections.Generic.Dictionary_System.Guid,DiGi.Analytical.Building.Regulation.Enums.ConstructionRole_).constructionSetSource'></a>

`constructionSetSource` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The source text of the construction set used\. This value can be null\.

<a name='DiGi.GIS.Classes.OpeningGenerationResult.OpeningGenerationResult(string,DiGi.Analytical.Building.Regulation.Enums.BuildingRegulation,System.Nullable_short_,System.Nullable_DiGi.GIS.Enums.YearBuiltSource_,DiGi.Analytical.Building.Regulation.Enums.ConstructionFlavour,DiGi.Analytical.Building.Regulation.Enums.BuildingType,string,string,DiGi.GIS.Analytical.Enums.StoreySource,double,System.Nullable_System.Guid_,DiGi.GIS.Analytical.Enums.FrontWallRule,System.Collections.Generic.List_DiGi.GIS.Classes.OpeningGenerationStorey_,System.Collections.Generic.Dictionary_System.Guid,DiGi.GIS.Analytical.Enums.WallOpeningRestriction_,int,int,int,System.Collections.Generic.Dictionary_System.Guid,string_,System.Collections.Generic.Dictionary_System.Guid,DiGi.Analytical.Building.Regulation.Enums.ConstructionRole_).storeySource'></a>

`storeySource` [StoreySource](DiGi.GIS.Analytical.Enums.md#DiGi.GIS.Analytical.Enums.StoreySource 'DiGi\.GIS\.Analytical\.Enums\.StoreySource')

Where the storey bands come from\.

<a name='DiGi.GIS.Classes.OpeningGenerationResult.OpeningGenerationResult(string,DiGi.Analytical.Building.Regulation.Enums.BuildingRegulation,System.Nullable_short_,System.Nullable_DiGi.GIS.Enums.YearBuiltSource_,DiGi.Analytical.Building.Regulation.Enums.ConstructionFlavour,DiGi.Analytical.Building.Regulation.Enums.BuildingType,string,string,DiGi.GIS.Analytical.Enums.StoreySource,double,System.Nullable_System.Guid_,DiGi.GIS.Analytical.Enums.FrontWallRule,System.Collections.Generic.List_DiGi.GIS.Classes.OpeningGenerationStorey_,System.Collections.Generic.Dictionary_System.Guid,DiGi.GIS.Analytical.Enums.WallOpeningRestriction_,int,int,int,System.Collections.Generic.Dictionary_System.Guid,string_,System.Collections.Generic.Dictionary_System.Guid,DiGi.Analytical.Building.Regulation.Enums.ConstructionRole_).maximumGlazedArea'></a>

`maximumGlazedArea` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The maximum glazed area A0max of the building by modular window dimensions \[m2\], or not a number when the regime or the window U\-value sets no such limit\.

<a name='DiGi.GIS.Classes.OpeningGenerationResult.OpeningGenerationResult(string,DiGi.Analytical.Building.Regulation.Enums.BuildingRegulation,System.Nullable_short_,System.Nullable_DiGi.GIS.Enums.YearBuiltSource_,DiGi.Analytical.Building.Regulation.Enums.ConstructionFlavour,DiGi.Analytical.Building.Regulation.Enums.BuildingType,string,string,DiGi.GIS.Analytical.Enums.StoreySource,double,System.Nullable_System.Guid_,DiGi.GIS.Analytical.Enums.FrontWallRule,System.Collections.Generic.List_DiGi.GIS.Classes.OpeningGenerationStorey_,System.Collections.Generic.Dictionary_System.Guid,DiGi.GIS.Analytical.Enums.WallOpeningRestriction_,int,int,int,System.Collections.Generic.Dictionary_System.Guid,string_,System.Collections.Generic.Dictionary_System.Guid,DiGi.Analytical.Building.Regulation.Enums.ConstructionRole_).frontWall'></a>

`frontWall` [System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Guid](https://learn.microsoft.com/en-us/dotnet/api/system.guid 'System\.Guid')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

The identifier of the ground\-storey wall chosen as the front, which holds the entrance doors, or null\.

<a name='DiGi.GIS.Classes.OpeningGenerationResult.OpeningGenerationResult(string,DiGi.Analytical.Building.Regulation.Enums.BuildingRegulation,System.Nullable_short_,System.Nullable_DiGi.GIS.Enums.YearBuiltSource_,DiGi.Analytical.Building.Regulation.Enums.ConstructionFlavour,DiGi.Analytical.Building.Regulation.Enums.BuildingType,string,string,DiGi.GIS.Analytical.Enums.StoreySource,double,System.Nullable_System.Guid_,DiGi.GIS.Analytical.Enums.FrontWallRule,System.Collections.Generic.List_DiGi.GIS.Classes.OpeningGenerationStorey_,System.Collections.Generic.Dictionary_System.Guid,DiGi.GIS.Analytical.Enums.WallOpeningRestriction_,int,int,int,System.Collections.Generic.Dictionary_System.Guid,string_,System.Collections.Generic.Dictionary_System.Guid,DiGi.Analytical.Building.Regulation.Enums.ConstructionRole_).frontWallRule'></a>

`frontWallRule` [FrontWallRule](DiGi.GIS.Analytical.Enums.md#DiGi.GIS.Analytical.Enums.FrontWallRule 'DiGi\.GIS\.Analytical\.Enums\.FrontWallRule')

The rule that chose the front wall\.

<a name='DiGi.GIS.Classes.OpeningGenerationResult.OpeningGenerationResult(string,DiGi.Analytical.Building.Regulation.Enums.BuildingRegulation,System.Nullable_short_,System.Nullable_DiGi.GIS.Enums.YearBuiltSource_,DiGi.Analytical.Building.Regulation.Enums.ConstructionFlavour,DiGi.Analytical.Building.Regulation.Enums.BuildingType,string,string,DiGi.GIS.Analytical.Enums.StoreySource,double,System.Nullable_System.Guid_,DiGi.GIS.Analytical.Enums.FrontWallRule,System.Collections.Generic.List_DiGi.GIS.Classes.OpeningGenerationStorey_,System.Collections.Generic.Dictionary_System.Guid,DiGi.GIS.Analytical.Enums.WallOpeningRestriction_,int,int,int,System.Collections.Generic.Dictionary_System.Guid,string_,System.Collections.Generic.Dictionary_System.Guid,DiGi.Analytical.Building.Regulation.Enums.ConstructionRole_).storeys'></a>

`storeys` [System\.Collections\.Generic\.List&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[OpeningGenerationStorey](DiGi.GIS.Classes.md#DiGi.GIS.Classes.OpeningGenerationStorey 'DiGi\.GIS\.Classes\.OpeningGenerationStorey')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')

What was achieved per storey band, from the ground band up\. This value can be null\.

<a name='DiGi.GIS.Classes.OpeningGenerationResult.OpeningGenerationResult(string,DiGi.Analytical.Building.Regulation.Enums.BuildingRegulation,System.Nullable_short_,System.Nullable_DiGi.GIS.Enums.YearBuiltSource_,DiGi.Analytical.Building.Regulation.Enums.ConstructionFlavour,DiGi.Analytical.Building.Regulation.Enums.BuildingType,string,string,DiGi.GIS.Analytical.Enums.StoreySource,double,System.Nullable_System.Guid_,DiGi.GIS.Analytical.Enums.FrontWallRule,System.Collections.Generic.List_DiGi.GIS.Classes.OpeningGenerationStorey_,System.Collections.Generic.Dictionary_System.Guid,DiGi.GIS.Analytical.Enums.WallOpeningRestriction_,int,int,int,System.Collections.Generic.Dictionary_System.Guid,string_,System.Collections.Generic.Dictionary_System.Guid,DiGi.Analytical.Building.Regulation.Enums.ConstructionRole_).wallOpeningRestrictions'></a>

`wallOpeningRestrictions` [System\.Collections\.Generic\.Dictionary&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2 'System\.Collections\.Generic\.Dictionary\`2')[System\.Guid](https://learn.microsoft.com/en-us/dotnet/api/system.guid 'System\.Guid')[,](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2 'System\.Collections\.Generic\.Dictionary\`2')[WallOpeningRestriction](DiGi.GIS.Analytical.Enums.md#DiGi.GIS.Analytical.Enums.WallOpeningRestriction 'DiGi\.GIS\.Analytical\.Enums\.WallOpeningRestriction')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2 'System\.Collections\.Generic\.Dictionary\`2')

The restriction of each wall of the model, keyed by its identifier\. This value can be null\.

<a name='DiGi.GIS.Classes.OpeningGenerationResult.OpeningGenerationResult(string,DiGi.Analytical.Building.Regulation.Enums.BuildingRegulation,System.Nullable_short_,System.Nullable_DiGi.GIS.Enums.YearBuiltSource_,DiGi.Analytical.Building.Regulation.Enums.ConstructionFlavour,DiGi.Analytical.Building.Regulation.Enums.BuildingType,string,string,DiGi.GIS.Analytical.Enums.StoreySource,double,System.Nullable_System.Guid_,DiGi.GIS.Analytical.Enums.FrontWallRule,System.Collections.Generic.List_DiGi.GIS.Classes.OpeningGenerationStorey_,System.Collections.Generic.Dictionary_System.Guid,DiGi.GIS.Analytical.Enums.WallOpeningRestriction_,int,int,int,System.Collections.Generic.Dictionary_System.Guid,string_,System.Collections.Generic.Dictionary_System.Guid,DiGi.Analytical.Building.Regulation.Enums.ConstructionRole_).doorCount'></a>

`doorCount` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of doors placed\.

<a name='DiGi.GIS.Classes.OpeningGenerationResult.OpeningGenerationResult(string,DiGi.Analytical.Building.Regulation.Enums.BuildingRegulation,System.Nullable_short_,System.Nullable_DiGi.GIS.Enums.YearBuiltSource_,DiGi.Analytical.Building.Regulation.Enums.ConstructionFlavour,DiGi.Analytical.Building.Regulation.Enums.BuildingType,string,string,DiGi.GIS.Analytical.Enums.StoreySource,double,System.Nullable_System.Guid_,DiGi.GIS.Analytical.Enums.FrontWallRule,System.Collections.Generic.List_DiGi.GIS.Classes.OpeningGenerationStorey_,System.Collections.Generic.Dictionary_System.Guid,DiGi.GIS.Analytical.Enums.WallOpeningRestriction_,int,int,int,System.Collections.Generic.Dictionary_System.Guid,string_,System.Collections.Generic.Dictionary_System.Guid,DiGi.Analytical.Building.Regulation.Enums.ConstructionRole_).doorsBelowMinimumCount'></a>

`doorsBelowMinimumCount` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of doors placed whose clear size is below the minimum of § 62; they are reported, not resized\.

<a name='DiGi.GIS.Classes.OpeningGenerationResult.OpeningGenerationResult(string,DiGi.Analytical.Building.Regulation.Enums.BuildingRegulation,System.Nullable_short_,System.Nullable_DiGi.GIS.Enums.YearBuiltSource_,DiGi.Analytical.Building.Regulation.Enums.ConstructionFlavour,DiGi.Analytical.Building.Regulation.Enums.BuildingType,string,string,DiGi.GIS.Analytical.Enums.StoreySource,double,System.Nullable_System.Guid_,DiGi.GIS.Analytical.Enums.FrontWallRule,System.Collections.Generic.List_DiGi.GIS.Classes.OpeningGenerationStorey_,System.Collections.Generic.Dictionary_System.Guid,DiGi.GIS.Analytical.Enums.WallOpeningRestriction_,int,int,int,System.Collections.Generic.Dictionary_System.Guid,string_,System.Collections.Generic.Dictionary_System.Guid,DiGi.Analytical.Building.Regulation.Enums.ConstructionRole_).droppedOpeningCount'></a>

`droppedOpeningCount` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of windows and doors not placed because their outline did not lie inside the host wall\.

<a name='DiGi.GIS.Classes.OpeningGenerationResult.OpeningGenerationResult(string,DiGi.Analytical.Building.Regulation.Enums.BuildingRegulation,System.Nullable_short_,System.Nullable_DiGi.GIS.Enums.YearBuiltSource_,DiGi.Analytical.Building.Regulation.Enums.ConstructionFlavour,DiGi.Analytical.Building.Regulation.Enums.BuildingType,string,string,DiGi.GIS.Analytical.Enums.StoreySource,double,System.Nullable_System.Guid_,DiGi.GIS.Analytical.Enums.FrontWallRule,System.Collections.Generic.List_DiGi.GIS.Classes.OpeningGenerationStorey_,System.Collections.Generic.Dictionary_System.Guid,DiGi.GIS.Analytical.Enums.WallOpeningRestriction_,int,int,int,System.Collections.Generic.Dictionary_System.Guid,string_,System.Collections.Generic.Dictionary_System.Guid,DiGi.Analytical.Building.Regulation.Enums.ConstructionRole_).frontageLines'></a>

`frontageLines` [System\.Collections\.Generic\.Dictionary&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2 'System\.Collections\.Generic\.Dictionary\`2')[System\.Guid](https://learn.microsoft.com/en-us/dotnet/api/system.guid 'System\.Guid')[,](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2 'System\.Collections\.Generic\.Dictionary\`2')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2 'System\.Collections\.Generic\.Dictionary\`2')

The frontage\-line key of each wall reported as part of a frontage line \(pierzeja\), keyed by its identifier, or null when none was reported \(DiGi\-Organization/DiGi\.GIS\.Analytical\#10\)\.

<a name='DiGi.GIS.Classes.OpeningGenerationResult.OpeningGenerationResult(string,DiGi.Analytical.Building.Regulation.Enums.BuildingRegulation,System.Nullable_short_,System.Nullable_DiGi.GIS.Enums.YearBuiltSource_,DiGi.Analytical.Building.Regulation.Enums.ConstructionFlavour,DiGi.Analytical.Building.Regulation.Enums.BuildingType,string,string,DiGi.GIS.Analytical.Enums.StoreySource,double,System.Nullable_System.Guid_,DiGi.GIS.Analytical.Enums.FrontWallRule,System.Collections.Generic.List_DiGi.GIS.Classes.OpeningGenerationStorey_,System.Collections.Generic.Dictionary_System.Guid,DiGi.GIS.Analytical.Enums.WallOpeningRestriction_,int,int,int,System.Collections.Generic.Dictionary_System.Guid,string_,System.Collections.Generic.Dictionary_System.Guid,DiGi.Analytical.Building.Regulation.Enums.ConstructionRole_).missingConstructionRoles'></a>

`missingConstructionRoles` [System\.Collections\.Generic\.Dictionary&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2 'System\.Collections\.Generic\.Dictionary\`2')[System\.Guid](https://learn.microsoft.com/en-us/dotnet/api/system.guid 'System\.Guid')[,](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2 'System\.Collections\.Generic\.Dictionary\`2')[DiGi\.Analytical\.Building\.Regulation\.Enums\.ConstructionRole](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.regulation.enums.constructionrole 'DiGi\.Analytical\.Building\.Regulation\.Enums\.ConstructionRole')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2 'System\.Collections\.Generic\.Dictionary\`2')

The envelope components whose role has no construction in the construction set, keyed by the component's identifier with the role, or null when the envelope step did not run \(DiGi\-Organization/DiGi\.GIS\.Analytical\#11\)\.

<a name='DiGi.GIS.Classes.OpeningGenerationResult.OpeningGenerationResult(System.Text.Json.Nodes.JsonObject)'></a>

## OpeningGenerationResult\(JsonObject\) Constructor

Initializes a new instance of the [OpeningGenerationResult](DiGi.GIS.Classes.md#DiGi.GIS.Classes.OpeningGenerationResult 'DiGi\.GIS\.Classes\.OpeningGenerationResult') class from a JSON object\.

```csharp
public OpeningGenerationResult(System.Text.Json.Nodes.JsonObject? jsonObject);
```
#### Parameters

<a name='DiGi.GIS.Classes.OpeningGenerationResult.OpeningGenerationResult(System.Text.Json.Nodes.JsonObject).jsonObject'></a>

`jsonObject` [System\.Text\.Json\.Nodes\.JsonObject](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.nodes.jsonobject 'System\.Text\.Json\.Nodes\.JsonObject')

The JSON object containing the data\. This value can be null\.
### Properties

<a name='DiGi.GIS.Classes.OpeningGenerationResult.BuildingRegulation'></a>

## OpeningGenerationResult\.BuildingRegulation Property

Gets the building regulation regime the openings were generated under\.

```csharp
public DiGi.Analytical.Building.Regulation.Enums.BuildingRegulation BuildingRegulation { get; }
```

#### Property Value
[DiGi\.Analytical\.Building\.Regulation\.Enums\.BuildingRegulation](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.regulation.enums.buildingregulation 'DiGi\.Analytical\.Building\.Regulation\.Enums\.BuildingRegulation')

<a name='DiGi.GIS.Classes.OpeningGenerationResult.BuildingType'></a>

## OpeningGenerationResult\.BuildingType Property

Gets the building type the sizes and constructions were looked up for\.

```csharp
public DiGi.Analytical.Building.Regulation.Enums.BuildingType BuildingType { get; }
```

#### Property Value
[DiGi\.Analytical\.Building\.Regulation\.Enums\.BuildingType](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.regulation.enums.buildingtype 'DiGi\.Analytical\.Building\.Regulation\.Enums\.BuildingType')

<a name='DiGi.GIS.Classes.OpeningGenerationResult.ConstructionFlavour'></a>

## OpeningGenerationResult\.ConstructionFlavour Property

Gets the construction flavour the thermal values were copied from\.

```csharp
public DiGi.Analytical.Building.Regulation.Enums.ConstructionFlavour ConstructionFlavour { get; }
```

#### Property Value
[DiGi\.Analytical\.Building\.Regulation\.Enums\.ConstructionFlavour](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.regulation.enums.constructionflavour 'DiGi\.Analytical\.Building\.Regulation\.Enums\.ConstructionFlavour')

<a name='DiGi.GIS.Classes.OpeningGenerationResult.ConstructionSetSource'></a>

## OpeningGenerationResult\.ConstructionSetSource Property

Gets the source text of the construction set used\.

```csharp
public string? ConstructionSetSource { get; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.GIS.Classes.OpeningGenerationResult.DoorCount'></a>

## OpeningGenerationResult\.DoorCount Property

Gets the number of doors placed\.

```csharp
public int DoorCount { get; }
```

#### Property Value
[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

<a name='DiGi.GIS.Classes.OpeningGenerationResult.DoorsBelowMinimumCount'></a>

## OpeningGenerationResult\.DoorsBelowMinimumCount Property

Gets the number of doors placed whose clear size is below the minimum of § 62\.

```csharp
public int DoorsBelowMinimumCount { get; }
```

#### Property Value
[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

<a name='DiGi.GIS.Classes.OpeningGenerationResult.DroppedOpeningCount'></a>

## OpeningGenerationResult\.DroppedOpeningCount Property

Gets the number of windows and doors not placed because their outline did not lie inside the host wall\.

```csharp
public int DroppedOpeningCount { get; }
```

#### Property Value
[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

<a name='DiGi.GIS.Classes.OpeningGenerationResult.FrontageLines'></a>

## OpeningGenerationResult\.FrontageLines Property

Gets the frontage\-line key of each wall reported as part of a frontage line \(pierzeja\), keyed by its identifier, or null when none was reported \(DiGi\-Organization/DiGi\.GIS\.Analytical\#10\)\.

```csharp
public System.Collections.Generic.Dictionary<System.Guid,string>? FrontageLines { get; }
```

#### Property Value
[System\.Collections\.Generic\.Dictionary&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2 'System\.Collections\.Generic\.Dictionary\`2')[System\.Guid](https://learn.microsoft.com/en-us/dotnet/api/system.guid 'System\.Guid')[,](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2 'System\.Collections\.Generic\.Dictionary\`2')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2 'System\.Collections\.Generic\.Dictionary\`2')

<a name='DiGi.GIS.Classes.OpeningGenerationResult.FrontWall'></a>

## OpeningGenerationResult\.FrontWall Property

Gets the identifier of the ground\-storey wall chosen as the front, or null\.

```csharp
public System.Nullable<System.Guid> FrontWall { get; }
```

#### Property Value
[System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Guid](https://learn.microsoft.com/en-us/dotnet/api/system.guid 'System\.Guid')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

<a name='DiGi.GIS.Classes.OpeningGenerationResult.FrontWallRule'></a>

## OpeningGenerationResult\.FrontWallRule Property

Gets the rule that chose the front wall\.

```csharp
public DiGi.GIS.Analytical.Enums.FrontWallRule FrontWallRule { get; }
```

#### Property Value
[FrontWallRule](DiGi.GIS.Analytical.Enums.md#DiGi.GIS.Analytical.Enums.FrontWallRule 'DiGi\.GIS\.Analytical\.Enums\.FrontWallRule')

<a name='DiGi.GIS.Classes.OpeningGenerationResult.MaximumGlazedArea'></a>

## OpeningGenerationResult\.MaximumGlazedArea Property

Gets the maximum glazed area A0max of the building \[m2\], or not a number when no such limit applies\.

```csharp
public double MaximumGlazedArea { get; }
```

#### Property Value
[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

<a name='DiGi.GIS.Classes.OpeningGenerationResult.MissingConstructionRoles'></a>

## OpeningGenerationResult\.MissingConstructionRoles Property

Gets a copy of the envelope components whose role has no construction in the construction set, keyed by the component's identifier with the role, or null when the envelope step did not run \(DiGi\-Organization/DiGi\.GIS\.Analytical\#11\)\.

A component listed here keeps whatever construction it had: a missing role changes nothing (DiGi-Organization/DiGi.GIS.Analytical#11).

```csharp
public System.Collections.Generic.Dictionary<System.Guid,DiGi.Analytical.Building.Regulation.Enums.ConstructionRole>? MissingConstructionRoles { get; }
```

#### Property Value
[System\.Collections\.Generic\.Dictionary&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2 'System\.Collections\.Generic\.Dictionary\`2')[System\.Guid](https://learn.microsoft.com/en-us/dotnet/api/system.guid 'System\.Guid')[,](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2 'System\.Collections\.Generic\.Dictionary\`2')[DiGi\.Analytical\.Building\.Regulation\.Enums\.ConstructionRole](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.regulation.enums.constructionrole 'DiGi\.Analytical\.Building\.Regulation\.Enums\.ConstructionRole')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2 'System\.Collections\.Generic\.Dictionary\`2')

<a name='DiGi.GIS.Classes.OpeningGenerationResult.OpeningSizeSetSource'></a>

## OpeningGenerationResult\.OpeningSizeSetSource Property

Gets the source text of the opening\-size set used\.

```csharp
public string? OpeningSizeSetSource { get; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.GIS.Classes.OpeningGenerationResult.Reference'></a>

## OpeningGenerationResult\.Reference Property

Gets the reference of the 2D building the model belongs to\.

```csharp
public string? Reference { get; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.GIS.Classes.OpeningGenerationResult.Storeys'></a>

## OpeningGenerationResult\.Storeys Property

Gets CLONES of what was achieved per storey band, from the ground band up\.

```csharp
public System.Collections.Generic.List<DiGi.GIS.Classes.OpeningGenerationStorey>? Storeys { get; }
```

#### Property Value
[System\.Collections\.Generic\.List&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[OpeningGenerationStorey](DiGi.GIS.Classes.md#DiGi.GIS.Classes.OpeningGenerationStorey 'DiGi\.GIS\.Classes\.OpeningGenerationStorey')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')

<a name='DiGi.GIS.Classes.OpeningGenerationResult.StoreySource'></a>

## OpeningGenerationResult\.StoreySource Property

Gets where the storey bands come from\.

```csharp
public DiGi.GIS.Analytical.Enums.StoreySource StoreySource { get; }
```

#### Property Value
[StoreySource](DiGi.GIS.Analytical.Enums.md#DiGi.GIS.Analytical.Enums.StoreySource 'DiGi\.GIS\.Analytical\.Enums\.StoreySource')

<a name='DiGi.GIS.Classes.OpeningGenerationResult.WallOpeningRestrictions'></a>

## OpeningGenerationResult\.WallOpeningRestrictions Property

Gets a copy of the restriction of each wall, keyed by its identifier\.

```csharp
public System.Collections.Generic.Dictionary<System.Guid,DiGi.GIS.Analytical.Enums.WallOpeningRestriction>? WallOpeningRestrictions { get; }
```

#### Property Value
[System\.Collections\.Generic\.Dictionary&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2 'System\.Collections\.Generic\.Dictionary\`2')[System\.Guid](https://learn.microsoft.com/en-us/dotnet/api/system.guid 'System\.Guid')[,](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2 'System\.Collections\.Generic\.Dictionary\`2')[WallOpeningRestriction](DiGi.GIS.Analytical.Enums.md#DiGi.GIS.Analytical.Enums.WallOpeningRestriction 'DiGi\.GIS\.Analytical\.Enums\.WallOpeningRestriction')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2 'System\.Collections\.Generic\.Dictionary\`2')

<a name='DiGi.GIS.Classes.OpeningGenerationResult.YearBuilt'></a>

## OpeningGenerationResult\.YearBuilt Property

Gets the year built the regime was selected from, or null when unknown\.

```csharp
public System.Nullable<short> YearBuilt { get; }
```

#### Property Value
[System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Int16](https://learn.microsoft.com/en-us/dotnet/api/system.int16 'System\.Int16')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

<a name='DiGi.GIS.Classes.OpeningGenerationResult.YearBuiltSource'></a>

## OpeningGenerationResult\.YearBuiltSource Property

Gets where the year built comes from, or null when no year is known\.

```csharp
public System.Nullable<DiGi.GIS.Enums.YearBuiltSource> YearBuiltSource { get; }
```

#### Property Value
[System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[DiGi\.GIS\.Enums\.YearBuiltSource](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.enums.yearbuiltsource 'DiGi\.GIS\.Enums\.YearBuiltSource')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

<a name='DiGi.GIS.Classes.OpeningGenerationStorey'></a>

## OpeningGenerationStorey Class

Holds what `Modify.GenerateOpenings` achieved in one storey band of a building \(DiGi\-Organization/DiGi\.GIS\.Analytical\#2\)\.

```csharp
public class OpeningGenerationStorey : DiGi.Core.Classes.SerializableObject, DiGi.GIS.Interfaces.IGISSerializableObject, DiGi.GIS.Interfaces.IGISObject, DiGi.Core.Interfaces.IObject, DiGi.Core.Interfaces.ISerializableObject, DiGi.Core.Interfaces.ICloneableObject<DiGi.Core.Interfaces.ISerializableObject>, DiGi.Core.Interfaces.ICloneableObject
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [DiGi\.Core\.Classes\.Object](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.object 'DiGi\.Core\.Classes\.Object') → [DiGi\.Core\.Classes\.SerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.serializableobject 'DiGi\.Core\.Classes\.SerializableObject') → OpeningGenerationStorey

Implements [DiGi\.GIS\.Interfaces\.IGISSerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.interfaces.igisserializableobject 'DiGi\.GIS\.Interfaces\.IGISSerializableObject'), [DiGi\.GIS\.Interfaces\.IGISObject](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.interfaces.igisobject 'DiGi\.GIS\.Interfaces\.IGISObject'), [DiGi\.Core\.Interfaces\.IObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iobject 'DiGi\.Core\.Interfaces\.IObject'), [DiGi\.Core\.Interfaces\.ISerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iserializableobject 'DiGi\.Core\.Interfaces\.ISerializableObject'), [DiGi\.Core\.Interfaces\.ICloneableObject&lt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject-1 'DiGi\.Core\.Interfaces\.ICloneableObject\`1')[DiGi\.Core\.Interfaces\.ISerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iserializableobject 'DiGi\.Core\.Interfaces\.ISerializableObject')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject-1 'DiGi\.Core\.Interfaces\.ICloneableObject\`1'), [DiGi\.Core\.Interfaces\.ICloneableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject 'DiGi\.Core\.Interfaces\.ICloneableObject')
### Constructors

<a name='DiGi.GIS.Classes.OpeningGenerationStorey.OpeningGenerationStorey(DiGi.GIS.Classes.OpeningGenerationStorey)'></a>

## OpeningGenerationStorey\(OpeningGenerationStorey\) Constructor

Initializes a new instance of the [OpeningGenerationStorey](DiGi.GIS.Classes.md#DiGi.GIS.Classes.OpeningGenerationStorey 'DiGi\.GIS\.Classes\.OpeningGenerationStorey') class by copying another instance\.

```csharp
public OpeningGenerationStorey(DiGi.GIS.Classes.OpeningGenerationStorey? openingGenerationStorey);
```
#### Parameters

<a name='DiGi.GIS.Classes.OpeningGenerationStorey.OpeningGenerationStorey(DiGi.GIS.Classes.OpeningGenerationStorey).openingGenerationStorey'></a>

`openingGenerationStorey` [OpeningGenerationStorey](DiGi.GIS.Classes.md#DiGi.GIS.Classes.OpeningGenerationStorey 'DiGi\.GIS\.Classes\.OpeningGenerationStorey')

The instance to copy\. This value can be null\.

<a name='DiGi.GIS.Classes.OpeningGenerationStorey.OpeningGenerationStorey(int,double,double,bool,double,double,int)'></a>

## OpeningGenerationStorey\(int, double, double, bool, double, double, int\) Constructor

Initializes a new instance of the [OpeningGenerationStorey](DiGi.GIS.Classes.md#DiGi.GIS.Classes.OpeningGenerationStorey 'DiGi\.GIS\.Classes\.OpeningGenerationStorey') class\.

```csharp
public OpeningGenerationStorey(int index, double bottom, double top, bool heightMismatch, double targetGlazedArea, double achievedGlazedArea, int windowCount);
```
#### Parameters

<a name='DiGi.GIS.Classes.OpeningGenerationStorey.OpeningGenerationStorey(int,double,double,bool,double,double,int).index'></a>

`index` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The index of the band, 0 for the ground band\.

<a name='DiGi.GIS.Classes.OpeningGenerationStorey.OpeningGenerationStorey(int,double,double,bool,double,double,int).bottom'></a>

`bottom` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The elevation of the bottom of the band \[m\]\.

<a name='DiGi.GIS.Classes.OpeningGenerationStorey.OpeningGenerationStorey(int,double,double,bool,double,double,int).top'></a>

`top` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The elevation of the top of the band \[m\]\.

<a name='DiGi.GIS.Classes.OpeningGenerationStorey.OpeningGenerationStorey(int,double,double,bool,double,double,int).heightMismatch'></a>

`heightMismatch` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

True when the band height is below the minimum storey height or above the multiple of the stock's typical storey height in the options\.

<a name='DiGi.GIS.Classes.OpeningGenerationStorey.OpeningGenerationStorey(int,double,double,bool,double,double,int).targetGlazedArea'></a>

`targetGlazedArea` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The glazed area the daylight ratio asks for, in the clear of the frames \[m2\]\.

<a name='DiGi.GIS.Classes.OpeningGenerationStorey.OpeningGenerationStorey(int,double,double,bool,double,double,int).achievedGlazedArea'></a>

`achievedGlazedArea` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The glazed area of the windows placed for rooms, in the clear of the frames \[m2\]; staircase windows are not counted\.

<a name='DiGi.GIS.Classes.OpeningGenerationStorey.OpeningGenerationStorey(int,double,double,bool,double,double,int).windowCount'></a>

`windowCount` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of windows placed for rooms\.

<a name='DiGi.GIS.Classes.OpeningGenerationStorey.OpeningGenerationStorey(System.Text.Json.Nodes.JsonObject)'></a>

## OpeningGenerationStorey\(JsonObject\) Constructor

Initializes a new instance of the [OpeningGenerationStorey](DiGi.GIS.Classes.md#DiGi.GIS.Classes.OpeningGenerationStorey 'DiGi\.GIS\.Classes\.OpeningGenerationStorey') class from a JSON object\.

```csharp
public OpeningGenerationStorey(System.Text.Json.Nodes.JsonObject? jsonObject);
```
#### Parameters

<a name='DiGi.GIS.Classes.OpeningGenerationStorey.OpeningGenerationStorey(System.Text.Json.Nodes.JsonObject).jsonObject'></a>

`jsonObject` [System\.Text\.Json\.Nodes\.JsonObject](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.nodes.jsonobject 'System\.Text\.Json\.Nodes\.JsonObject')

The JSON object containing the data\. This value can be null\.
### Properties

<a name='DiGi.GIS.Classes.OpeningGenerationStorey.AchievedGlazedArea'></a>

## OpeningGenerationStorey\.AchievedGlazedArea Property

Gets the glazed area of the windows placed for rooms, in the clear of the frames \[m2\]\.

```csharp
public double AchievedGlazedArea { get; }
```

#### Property Value
[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

<a name='DiGi.GIS.Classes.OpeningGenerationStorey.Bottom'></a>

## OpeningGenerationStorey\.Bottom Property

Gets the elevation of the bottom of the band \[m\]\.

```csharp
public double Bottom { get; }
```

#### Property Value
[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

<a name='DiGi.GIS.Classes.OpeningGenerationStorey.HeightMismatch'></a>

## OpeningGenerationStorey\.HeightMismatch Property

Gets a value indicating whether the band height is outside the range the options accept\.

```csharp
public bool HeightMismatch { get; }
```

#### Property Value
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

<a name='DiGi.GIS.Classes.OpeningGenerationStorey.Index'></a>

## OpeningGenerationStorey\.Index Property

Gets the index of the band, 0 for the ground band\.

```csharp
public int Index { get; }
```

#### Property Value
[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

<a name='DiGi.GIS.Classes.OpeningGenerationStorey.Shortfall'></a>

## OpeningGenerationStorey\.Shortfall Property

Gets the glazed area the daylight target asks for and the windows placed do not reach \[m2\]; 0 when the target is met\. A shortfall is a finding, not an error\.

```csharp
public double Shortfall { get; }
```

#### Property Value
[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

<a name='DiGi.GIS.Classes.OpeningGenerationStorey.TargetGlazedArea'></a>

## OpeningGenerationStorey\.TargetGlazedArea Property

Gets the glazed area the daylight ratio asks for, in the clear of the frames \[m2\]\.

```csharp
public double TargetGlazedArea { get; }
```

#### Property Value
[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

<a name='DiGi.GIS.Classes.OpeningGenerationStorey.Top'></a>

## OpeningGenerationStorey\.Top Property

Gets the elevation of the top of the band \[m\]\.

```csharp
public double Top { get; }
```

#### Property Value
[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

<a name='DiGi.GIS.Classes.OpeningGenerationStorey.WindowCount'></a>

## OpeningGenerationStorey\.WindowCount Property

Gets the number of windows placed for rooms\.

```csharp
public int WindowCount { get; }
```

#### Property Value
[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

<a name='DiGi.GIS.Classes.RoadFrontage'></a>

## RoadFrontage Class

What `Query.RoadFrontages` measured for one wall that fronts a road \(DiGi\-Organization/DiGi\.GIS\.Analytical\#10\)\.

```csharp
public class RoadFrontage
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → RoadFrontage
### Constructors

<a name='DiGi.GIS.Classes.RoadFrontage.RoadFrontage(int,double,DiGi.Geometry.Planar.Classes.Segment2D,DiGi.Geometry.Planar.Classes.Vector2D)'></a>

## RoadFrontage\(int, double, Segment2D, Vector2D\) Constructor

Initializes a new instance of the [RoadFrontage](DiGi.GIS.Classes.md#DiGi.GIS.Classes.RoadFrontage 'DiGi\.GIS\.Classes\.RoadFrontage') class\.

```csharp
public RoadFrontage(int roadIndex, double setback, DiGi.Geometry.Planar.Classes.Segment2D? segment2D, DiGi.Geometry.Planar.Classes.Vector2D? normal);
```
#### Parameters

<a name='DiGi.GIS.Classes.RoadFrontage.RoadFrontage(int,double,DiGi.Geometry.Planar.Classes.Segment2D,DiGi.Geometry.Planar.Classes.Vector2D).roadIndex'></a>

`roadIndex` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The index of the road polyline in the list as given\.

<a name='DiGi.GIS.Classes.RoadFrontage.RoadFrontage(int,double,DiGi.Geometry.Planar.Classes.Segment2D,DiGi.Geometry.Planar.Classes.Vector2D).setback'></a>

`setback` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The shortest distance from the wall face to that road \[m\]\.

<a name='DiGi.GIS.Classes.RoadFrontage.RoadFrontage(int,double,DiGi.Geometry.Planar.Classes.Segment2D,DiGi.Geometry.Planar.Classes.Vector2D).segment2D'></a>

`segment2D` [DiGi\.Geometry\.Planar\.Classes\.Segment2D](https://learn.microsoft.com/en-us/dotnet/api/digi.geometry.planar.classes.segment2d 'DiGi\.Geometry\.Planar\.Classes\.Segment2D')

The footprint line of the wall\. This value can be null\.

<a name='DiGi.GIS.Classes.RoadFrontage.RoadFrontage(int,double,DiGi.Geometry.Planar.Classes.Segment2D,DiGi.Geometry.Planar.Classes.Vector2D).normal'></a>

`normal` [DiGi\.Geometry\.Planar\.Classes\.Vector2D](https://learn.microsoft.com/en-us/dotnet/api/digi.geometry.planar.classes.vector2d 'DiGi\.Geometry\.Planar\.Classes\.Vector2D')

The outward unit normal of the wall face\. This value can be null\.
### Properties

<a name='DiGi.GIS.Classes.RoadFrontage.Normal'></a>

## RoadFrontage\.Normal Property

Gets a CLONE of the outward unit normal of the wall face\.

```csharp
public DiGi.Geometry.Planar.Classes.Vector2D? Normal { get; }
```

#### Property Value
[DiGi\.Geometry\.Planar\.Classes\.Vector2D](https://learn.microsoft.com/en-us/dotnet/api/digi.geometry.planar.classes.vector2d 'DiGi\.Geometry\.Planar\.Classes\.Vector2D')

<a name='DiGi.GIS.Classes.RoadFrontage.RoadIndex'></a>

## RoadFrontage\.RoadIndex Property

Gets the index of the road polyline in the list as given\.

```csharp
public int RoadIndex { get; }
```

#### Property Value
[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

<a name='DiGi.GIS.Classes.RoadFrontage.Segment2D'></a>

## RoadFrontage\.Segment2D Property

Gets a CLONE of the footprint line of the wall\.

```csharp
public DiGi.Geometry.Planar.Classes.Segment2D? Segment2D { get; }
```

#### Property Value
[DiGi\.Geometry\.Planar\.Classes\.Segment2D](https://learn.microsoft.com/en-us/dotnet/api/digi.geometry.planar.classes.segment2d 'DiGi\.Geometry\.Planar\.Classes\.Segment2D')

<a name='DiGi.GIS.Classes.RoadFrontage.Setback'></a>

## RoadFrontage\.Setback Property

Gets the shortest distance from the wall face to that road \[m\]\.

```csharp
public double Setback { get; }
```

#### Property Value
[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

<a name='DiGi.GIS.Classes.WallOpeningResult'></a>

## WallOpeningResult Class

Holds what `Query.WallOpeningResults` measured for one external wall of a building model: why it is restricted, if at all, and the distances behind that decision \(DiGi\-Organization/DiGi\.GIS\.Analytical\#9\)\.

Created by `Query.WallOpeningResults`, which does the measuring; the constructor only assigns and clones. A wall that passes both rules keeps [None](DiGi.GIS.Analytical.Enums.md#DiGi.GIS.Analytical.Enums.WallOpeningRestriction.None 'DiGi\.GIS\.Analytical\.Enums\.WallOpeningRestriction\.None') and still reports the distances that decided it; a distance with no applicable rule is null.

```csharp
public class WallOpeningResult : DiGi.Core.Classes.SerializableResult, DiGi.GIS.Interfaces.IGISSerializableObject, DiGi.GIS.Interfaces.IGISObject, DiGi.Core.Interfaces.IObject, DiGi.Core.Interfaces.ISerializableObject, DiGi.Core.Interfaces.ICloneableObject<DiGi.Core.Interfaces.ISerializableObject>, DiGi.Core.Interfaces.ICloneableObject
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [DiGi\.Core\.Classes\.Object](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.object 'DiGi\.Core\.Classes\.Object') → [DiGi\.Core\.Classes\.SerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.serializableobject 'DiGi\.Core\.Classes\.SerializableObject') → [DiGi\.Core\.Classes\.SerializableResult](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.serializableresult 'DiGi\.Core\.Classes\.SerializableResult') → WallOpeningResult

Implements [DiGi\.GIS\.Interfaces\.IGISSerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.interfaces.igisserializableobject 'DiGi\.GIS\.Interfaces\.IGISSerializableObject'), [DiGi\.GIS\.Interfaces\.IGISObject](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.interfaces.igisobject 'DiGi\.GIS\.Interfaces\.IGISObject'), [DiGi\.Core\.Interfaces\.IObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iobject 'DiGi\.Core\.Interfaces\.IObject'), [DiGi\.Core\.Interfaces\.ISerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iserializableobject 'DiGi\.Core\.Interfaces\.ISerializableObject'), [DiGi\.Core\.Interfaces\.ICloneableObject&lt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject-1 'DiGi\.Core\.Interfaces\.ICloneableObject\`1')[DiGi\.Core\.Interfaces\.ISerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iserializableobject 'DiGi\.Core\.Interfaces\.ISerializableObject')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject-1 'DiGi\.Core\.Interfaces\.ICloneableObject\`1'), [DiGi\.Core\.Interfaces\.ICloneableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject 'DiGi\.Core\.Interfaces\.ICloneableObject')
### Constructors

<a name='DiGi.GIS.Classes.WallOpeningResult.WallOpeningResult(DiGi.Core.Classes.GuidReference,DiGi.GIS.Analytical.Enums.WallOpeningRestriction,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_)'></a>

## WallOpeningResult\(GuidReference, WallOpeningRestriction, Nullable\<double\>, Nullable\<double\>, Nullable\<double\>, Nullable\<double\>\) Constructor

Initializes a new instance of the [WallOpeningResult](DiGi.GIS.Classes.md#DiGi.GIS.Classes.WallOpeningResult 'DiGi\.GIS\.Classes\.WallOpeningResult') class\.

The values are assigned and the wall reference cloned; the distances are taken as given. `Query.WallOpeningResults` computes them.

```csharp
public WallOpeningResult(DiGi.Core.Classes.GuidReference? wall, DiGi.GIS.Analytical.Enums.WallOpeningRestriction wallOpeningRestriction, System.Nullable<double> fireSeparationDistance, System.Nullable<double> fireSeparationRequired, System.Nullable<double> obstructionDistance, System.Nullable<double> obstructionRequired);
```
#### Parameters

<a name='DiGi.GIS.Classes.WallOpeningResult.WallOpeningResult(DiGi.Core.Classes.GuidReference,DiGi.GIS.Analytical.Enums.WallOpeningRestriction,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_).wall'></a>

`wall` [DiGi\.Core\.Classes\.GuidReference](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.guidreference 'DiGi\.Core\.Classes\.GuidReference')

The reference of the external wall this result describes\. This value can be null\.

<a name='DiGi.GIS.Classes.WallOpeningResult.WallOpeningResult(DiGi.Core.Classes.GuidReference,DiGi.GIS.Analytical.Enums.WallOpeningRestriction,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_).wallOpeningRestriction'></a>

`wallOpeningRestriction` [WallOpeningRestriction](DiGi.GIS.Analytical.Enums.md#DiGi.GIS.Analytical.Enums.WallOpeningRestriction 'DiGi\.GIS\.Analytical\.Enums\.WallOpeningRestriction')

Why the wall may carry no openings: [None](DiGi.GIS.Analytical.Enums.md#DiGi.GIS.Analytical.Enums.WallOpeningRestriction.None 'DiGi\.GIS\.Analytical\.Enums\.WallOpeningRestriction\.None') when neither rule failed, otherwise the governing rule, [FireSeparation](DiGi.GIS.Analytical.Enums.md#DiGi.GIS.Analytical.Enums.WallOpeningRestriction.FireSeparation 'DiGi\.GIS\.Analytical\.Enums\.WallOpeningRestriction\.FireSeparation') winning over [Obstruction](DiGi.GIS.Analytical.Enums.md#DiGi.GIS.Analytical.Enums.WallOpeningRestriction.Obstruction 'DiGi\.GIS\.Analytical\.Enums\.WallOpeningRestriction\.Obstruction')\.

<a name='DiGi.GIS.Classes.WallOpeningResult.WallOpeningResult(DiGi.Core.Classes.GuidReference,DiGi.GIS.Analytical.Enums.WallOpeningRestriction,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_).fireSeparationDistance'></a>

`fireSeparationDistance` [System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

The smallest measured horizontal distance to a facing wall of a neighbour \[m\], or null when no wall faced it or § 271 does not apply between them\.

<a name='DiGi.GIS.Classes.WallOpeningResult.WallOpeningResult(DiGi.Core.Classes.GuidReference,DiGi.GIS.Analytical.Enums.WallOpeningRestriction,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_).fireSeparationRequired'></a>

`fireSeparationRequired` [System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

The distance § 271 required at that measurement \[m\] after the class table, fuel load, spread, no\-openings and wall\-angle factors, or null when no applicable rule was measured\.

<a name='DiGi.GIS.Classes.WallOpeningResult.WallOpeningResult(DiGi.Core.Classes.GuidReference,DiGi.GIS.Analytical.Enums.WallOpeningRestriction,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_).obstructionDistance'></a>

`obstructionDistance` [System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

The smallest measured distance from a window axis inside the 60 degree sector of § 13 to the obstructing object \[m\], or null when no object lay in the sector\.

<a name='DiGi.GIS.Classes.WallOpeningResult.WallOpeningResult(DiGi.Core.Classes.GuidReference,DiGi.GIS.Analytical.Enums.WallOpeningRestriction,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_).obstructionRequired'></a>

`obstructionRequired` [System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

The distance § 13 required at that measurement \[m\], the height of shading capped at 35 m and reduced by the inner\-city factor, or null when no object lay in the sector\.

<a name='DiGi.GIS.Classes.WallOpeningResult.WallOpeningResult(DiGi.GIS.Classes.WallOpeningResult)'></a>

## WallOpeningResult\(WallOpeningResult\) Constructor

Initializes a new instance of the [WallOpeningResult](DiGi.GIS.Classes.md#DiGi.GIS.Classes.WallOpeningResult 'DiGi\.GIS\.Classes\.WallOpeningResult') class by copying another instance\.

```csharp
public WallOpeningResult(DiGi.GIS.Classes.WallOpeningResult? wallOpeningResult);
```
#### Parameters

<a name='DiGi.GIS.Classes.WallOpeningResult.WallOpeningResult(DiGi.GIS.Classes.WallOpeningResult).wallOpeningResult'></a>

`wallOpeningResult` [WallOpeningResult](DiGi.GIS.Classes.md#DiGi.GIS.Classes.WallOpeningResult 'DiGi\.GIS\.Classes\.WallOpeningResult')

The result to copy\. This value can be null\.

<a name='DiGi.GIS.Classes.WallOpeningResult.WallOpeningResult(System.Text.Json.Nodes.JsonObject)'></a>

## WallOpeningResult\(JsonObject\) Constructor

Initializes a new instance of the [WallOpeningResult](DiGi.GIS.Classes.md#DiGi.GIS.Classes.WallOpeningResult 'DiGi\.GIS\.Classes\.WallOpeningResult') class from a JSON object\.

```csharp
public WallOpeningResult(System.Text.Json.Nodes.JsonObject? jsonObject);
```
#### Parameters

<a name='DiGi.GIS.Classes.WallOpeningResult.WallOpeningResult(System.Text.Json.Nodes.JsonObject).jsonObject'></a>

`jsonObject` [System\.Text\.Json\.Nodes\.JsonObject](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.nodes.jsonobject 'System\.Text\.Json\.Nodes\.JsonObject')

The JSON object containing the result data\. This value can be null\.
### Properties

<a name='DiGi.GIS.Classes.WallOpeningResult.FireSeparationDistance'></a>

## WallOpeningResult\.FireSeparationDistance Property

Gets the smallest measured horizontal distance to a facing wall of a neighbour \[m\], or null when no wall faced it or § 271 does not apply between them\.

```csharp
public System.Nullable<double> FireSeparationDistance { get; }
```

#### Property Value
[System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

<a name='DiGi.GIS.Classes.WallOpeningResult.FireSeparationRequired'></a>

## WallOpeningResult\.FireSeparationRequired Property

Gets the distance § 271 required at the reported measurement \[m\], or null when no applicable rule was measured\.

```csharp
public System.Nullable<double> FireSeparationRequired { get; }
```

#### Property Value
[System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

<a name='DiGi.GIS.Classes.WallOpeningResult.ObstructionDistance'></a>

## WallOpeningResult\.ObstructionDistance Property

Gets the smallest measured distance from a window axis inside the 60 degree sector of § 13 to the obstructing object \[m\], or null when no object lay in the sector\.

```csharp
public System.Nullable<double> ObstructionDistance { get; }
```

#### Property Value
[System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

<a name='DiGi.GIS.Classes.WallOpeningResult.ObstructionRequired'></a>

## WallOpeningResult\.ObstructionRequired Property

Gets the distance § 13 required at the reported measurement \[m\], or null when no object lay in the sector\.

```csharp
public System.Nullable<double> ObstructionRequired { get; }
```

#### Property Value
[System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

<a name='DiGi.GIS.Classes.WallOpeningResult.Restriction'></a>

## WallOpeningResult\.Restriction Property

Gets why the wall may carry no openings: [None](DiGi.GIS.Analytical.Enums.md#DiGi.GIS.Analytical.Enums.WallOpeningRestriction.None 'DiGi\.GIS\.Analytical\.Enums\.WallOpeningRestriction\.None') when neither rule failed, otherwise the governing rule\.

```csharp
public DiGi.GIS.Analytical.Enums.WallOpeningRestriction Restriction { get; }
```

#### Property Value
[WallOpeningRestriction](DiGi.GIS.Analytical.Enums.md#DiGi.GIS.Analytical.Enums.WallOpeningRestriction 'DiGi\.GIS\.Analytical\.Enums\.WallOpeningRestriction')

<a name='DiGi.GIS.Classes.WallOpeningResult.Wall'></a>

## WallOpeningResult\.Wall Property

Gets a clone of the reference of the external wall this result describes, or null\.

```csharp
public DiGi.Core.Classes.GuidReference? Wall { get; }
```

#### Property Value
[DiGi\.Core\.Classes\.GuidReference](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.guidreference 'DiGi\.Core\.Classes\.GuidReference')