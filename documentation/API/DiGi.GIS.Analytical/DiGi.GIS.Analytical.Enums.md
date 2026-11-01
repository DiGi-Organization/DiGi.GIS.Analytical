#### [DiGi\.GIS\.Analytical](DiGi.GIS.Analytical.Overview.md 'DiGi\.GIS\.Analytical\.Overview')

## DiGi\.GIS\.Analytical\.Enums Namespace
### Enums

<a name='DiGi.GIS.Analytical.Enums.BuildingModelParameter'></a>

## BuildingModelParameter Enum

Defines the available parameters for a building model\.

```csharp
public enum BuildingModelParameter
```
### Fields

<a name='DiGi.GIS.Analytical.Enums.BuildingModelParameter.Source'></a>

`Source` 0

Gets the data source information associated with the building model\.

<a name='DiGi.GIS.Analytical.Enums.BuildingModelParameter.Reference'></a>

`Reference` 1

Gets the reference identifier associated with the building model\.

<a name='DiGi.GIS.Analytical.Enums.BuildingModelParameter.Code'></a>

`Code` 2

Gets the administrative area code associated with the building model\.

<a name='DiGi.GIS.Analytical.Enums.BuildingModelParameter.FireSpreading'></a>

`FireSpreading` 3

Gets whether an external wall facing the neighbouring building, or the roof covering, spreads fire \(DiGi\-Organization/DiGi\.GIS\.Analytical\#9\)\. A building carrying this flag raises the § 271 distance by the one\-side or both\-sides factor of `OpeningGenerationOptions` and loses the § 271 ust\. 9 no\-openings reduction\. Not derivable from the stock data, so the flag is absent \- the wall and roof do not spread fire \- until a caller or the database sets it\.

<a name='DiGi.GIS.Analytical.Enums.BuildingModelValidationCode'></a>

## BuildingModelValidationCode Enum

Identifies a way in which a building model fails validation\.

A model can carry several of these at once, so they are collected into a list rather than reduced to a single verdict - which of them a model carries is what says whether the data, the conversion or the upload is at fault.

```csharp
public enum BuildingModelValidationCode
```
### Fields

<a name='DiGi.GIS.Analytical.Enums.BuildingModelValidationCode.MissingReference'></a>

`MissingReference` 0

The model carries no reference, so it cannot be traced back to the 2D building it belongs to\.

<a name='DiGi.GIS.Analytical.Enums.BuildingModelValidationCode.MissingCode'></a>

`MissingCode` 1

The model carries no administrative area code, so the county it belongs to cannot be resolved from the model itself\.

<a name='DiGi.GIS.Analytical.Enums.BuildingModelValidationCode.InvalidComponent'></a>

`InvalidComponent` 2

At least one component sits on a plane whose normal is not finite, which is what the last gate before the database rejects\.

<a name='DiGi.GIS.Analytical.Enums.BuildingModelValidationCode.NoSpace'></a>

`NoSpace` 3

The model holds no space at all\.

<a name='DiGi.GIS.Analytical.Enums.BuildingModelValidationCode.NoComponent'></a>

`NoComponent` 4

The model holds no component, or one of its spaces is bounded by none\.

<a name='DiGi.GIS.Analytical.Enums.BuildingModelValidationCode.NotEnclosed'></a>

`NotEnclosed` 5

At least one space is not enclosed by its components at the requested tolerance\.

<a name='DiGi.GIS.Analytical.Enums.BuildingModelValidationCode.NonManifold'></a>

`NonManifold` 6

A space closes, but at least one of its edges is shared by more than two faces, so the shell is not a 2\-manifold surface\.

<a name='DiGi.GIS.Analytical.Enums.BuildingModelValidationCode.SpacePointOutsideShell'></a>

`SpacePointOutsideShell` 7

The internal point of a space lies outside the shell that bounds it, so anything classifying by that point resolves to the wrong space or to none\.

<a name='DiGi.GIS.Analytical.Enums.BuildingModelValidationCode.SeaLevel'></a>

`SeaLevel` 8

The model sits at an elevation of zero, meaning the terrain elevation was never resolved and the building was placed at sea level\.

<a name='DiGi.GIS.Analytical.Enums.BuildingModelValidationCode.DegenerateExtent'></a>

`DegenerateExtent` 9

The extents of the model are unusable \- no height, or a coordinate that is not finite\.

<a name='DiGi.GIS.Analytical.Enums.BuildingParameter'></a>

## BuildingParameter Enum

Parameters applicable to a Building\.

```csharp
public enum BuildingParameter
```
### Fields

<a name='DiGi.GIS.Analytical.Enums.BuildingParameter.LOD'></a>

`LOD` 0

Level of Detail\.

<a name='DiGi.GIS.Analytical.Enums.BuildingParameter.Year'></a>

`Year` 1

Model year\.

<a name='DiGi.GIS.Analytical.Enums.BuildingParameter.Code'></a>

`Code` 2

Area code\.

<a name='DiGi.GIS.Analytical.Enums.BuildingParameter.Source'></a>

`Source` 3

Source information\.

<a name='DiGi.GIS.Analytical.Enums.FireClass'></a>

## FireClass Enum

Specifies the kind of building for the fire\-separation distances of § 271 \(DiGi\-Organization/DiGi\.GIS\.Analytical\#9\)\.

```csharp
public enum FireClass
```
### Fields

<a name='DiGi.GIS.Analytical.Enums.FireClass.ZL'></a>

`ZL` 0

Residential, collective\-residence and public\-utility buildings, characterised by the human\-hazard category \(§ 209 ust\. 1 pkt 1 of the technical conditions of 2002, Dz\.U\. 2022 poz\. 1225, read in ISAP on 2026\-11\-01\)\.

<a name='DiGi.GIS.Analytical.Enums.FireClass.IN'></a>

`IN` 1

Livestock buildings \(§ 209 ust\. 1 pkt 3 of the technical conditions of 2002, Dz\.U\. 2022 poz\. 1225, read in ISAP on 2026\-11\-01\)\.

<a name='DiGi.GIS.Analytical.Enums.FireClass.PM'></a>

`PM` 2

Production and storage buildings \(§ 209 ust\. 1 pkt 2 of the technical conditions of 2002, Dz\.U\. 2022 poz\. 1225, read in ISAP on 2026\-11\-01\)\. The row of the § 271 table this class takes depends on the fuel\-load density Q of its fire compartment\.

<a name='DiGi.GIS.Analytical.Enums.FrontWallRule'></a>

## FrontWallRule Enum

Specifies how the front wall of a building, which holds the entrance door, was chosen \(DiGi\-Organization/DiGi\.GIS\.Analytical\#2\)\.

```csharp
public enum FrontWallRule
```
### Fields

<a name='DiGi.GIS.Analytical.Enums.FrontWallRule.Undefined'></a>

`Undefined` 0

No front wall was chosen\.

<a name='DiGi.GIS.Analytical.Enums.FrontWallRule.AddressPoint'></a>

`AddressPoint` 1

The external wall nearest the address point of the building\.

<a name='DiGi.GIS.Analytical.Enums.FrontWallRule.LongestEdge'></a>

`LongestEdge` 2

The longest unrestricted external wall of the ground storey, used when no address point is given\.

<a name='DiGi.GIS.Analytical.Enums.LOD'></a>

## LOD Enum

Specifies the Level of Detail \(LOD\) for GIS analytical objects\.

```csharp
public enum LOD
```
### Fields

<a name='DiGi.GIS.Analytical.Enums.LOD.Undefined'></a>

`Undefined` 0

The level of detail is undefined or not specified\.

<a name='DiGi.GIS.Analytical.Enums.LOD.LOD1'></a>

`LOD1` 1

Represents the first level of detail \(LOD1\)\.

<a name='DiGi.GIS.Analytical.Enums.LOD.LOD2'></a>

`LOD2` 2

Represents the second level of detail \(LOD2\)\.

<a name='DiGi.GIS.Analytical.Enums.OpeningParameter'></a>

## OpeningParameter Enum

Defines the parameters `Modify.GenerateOpenings` sets on every window and door it generates, so a run can be traced and redone when a better year built arrives \(DiGi\-Organization/DiGi\.GIS\.Analytical\#2\)\.

```csharp
public enum OpeningParameter
```
### Fields

<a name='DiGi.GIS.Analytical.Enums.OpeningParameter.BuildingRegulation'></a>

`BuildingRegulation` 0

Gets the building regulation regime the opening was generated under, as a `BuildingRegulation` name\.

<a name='DiGi.GIS.Analytical.Enums.OpeningParameter.YearBuiltSource'></a>

`YearBuiltSource` 1

Gets where the year built that selected the regime came from, as a [DiGi\.GIS\.Enums\.YearBuiltSource](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.enums.yearbuiltsource 'DiGi\.GIS\.Enums\.YearBuiltSource') name, or "None" when no year was known\.

<a name='DiGi.GIS.Analytical.Enums.OpeningParameter.ConstructionFlavour'></a>

`ConstructionFlavour` 2

Gets the construction flavour the opening's thermal values were copied from, as a `ConstructionFlavour` name\.

<a name='DiGi.GIS.Analytical.Enums.OpeningParameter.OpeningKind'></a>

`OpeningKind` 3

Gets the kind of opening, as an `OpeningKind` name\.

<a name='DiGi.GIS.Analytical.Enums.OpeningParameter.RoomUse'></a>

`RoomUse` 4

Gets the room use the opening's size was chosen for, as a `RoomUse` name\.

<a name='DiGi.GIS.Analytical.Enums.OpeningParameter.GeneratedBy'></a>

`GeneratedBy` 5

Gets the method that generated the opening\.

<a name='DiGi.GIS.Analytical.Enums.StoreySource'></a>

## StoreySource Enum

Specifies where the storey bands openings are placed in come from \(DiGi\-Organization/DiGi\.GIS\.Analytical\#2\)\.

```csharp
public enum StoreySource
```
### Fields

<a name='DiGi.GIS.Analytical.Enums.StoreySource.Undefined'></a>

`Undefined` 0

No storey band could be derived\.

<a name='DiGi.GIS.Analytical.Enums.StoreySource.Spaces'></a>

`Spaces` 1

The model holds two or more storey spaces, and each band is the extent of one of them\.

<a name='DiGi.GIS.Analytical.Enums.StoreySource.Building2D'></a>

`Building2D` 2

The model holds one space, and its height is divided into the storey count of the 2D building\.

<a name='DiGi.GIS.Analytical.Enums.StoreySource.Estimated'></a>

`Estimated` 3

The model holds one space and no storey count is known, so the count is estimated from the height of its walls and the typical storey height of its stock\.

<a name='DiGi.GIS.Analytical.Enums.StoreySource.Single'></a>

`Single` 4

No height could be read, so the whole wall is one band\.

<a name='DiGi.GIS.Analytical.Enums.WallOpeningRestriction'></a>

## WallOpeningRestriction Enum

Specifies why a wall received no openings from `Modify.GenerateOpenings` \(DiGi\-Organization/DiGi\.GIS\.Analytical\#2\)\.

```csharp
public enum WallOpeningRestriction
```
### Fields

<a name='DiGi.GIS.Analytical.Enums.WallOpeningRestriction.None'></a>

`None` 0

The wall may carry openings\.

<a name='DiGi.GIS.Analytical.Enums.WallOpeningRestriction.PartyWall'></a>

`PartyWall` 1

The wall is shared with an adjacent building \(`ComponentParameter.PartyWall`\), so it carries no openings\.

<a name='DiGi.GIS.Analytical.Enums.WallOpeningRestriction.TooShort'></a>

`TooShort` 2

The wall is too short to hold the narrowest window between its corner margins\.

<a name='DiGi.GIS.Analytical.Enums.WallOpeningRestriction.NotExternal'></a>

`NotExternal` 3

The wall is not part of the external envelope of the model\.

<a name='DiGi.GIS.Analytical.Enums.WallOpeningRestriction.FireSeparation'></a>

`FireSeparation` 4

The distance to a facing neighbouring wall falls short of the fire\-separation requirement of § 271 \(DiGi\-Organization/DiGi\.GIS\.Analytical\#9\), so the wall carries no openings at all, doors included\.

<a name='DiGi.GIS.Analytical.Enums.WallOpeningRestriction.Obstruction'></a>

`Obstruction` 5

An obstructing part of the same building or another object lies inside the 60 degree sector of § 13 closer than its height of shading \(DiGi\-Organization/DiGi\.GIS\.Analytical\#9\), so the wall carries no windows of rooms for people; entrance doors and the staircase window stay allowed\.