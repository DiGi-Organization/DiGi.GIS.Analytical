using DiGi.Analytical.Building.Regulation.Enums;
using DiGi.Core.Classes;
using DiGi.GIS.Analytical.Enums;
using DiGi.GIS.Enums;
using DiGi.GIS.Interfaces;
using System;
using System.Collections.Generic;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace DiGi.GIS.Classes
{
    /// <summary>
    /// Holds what <c>Modify.GenerateOpenings</c> did to one building model and what it could not do: the keys it looked the sizes and constructions up by, the storey bands, the restriction of each wall, the front wall and the doors (DiGi-Organization/DiGi.GIS.Analytical#2).
    /// <para>A shortfall against the daylight target is a finding, not an error: in a dense historic block the rules can make 1:8 impossible.</para>
    /// </summary>
    public class OpeningGenerationResult : SerializableObject, IGISSerializableObject
    {
        [JsonInclude, JsonPropertyName(nameof(BuildingRegulation))]
        private readonly BuildingRegulation buildingRegulation;

        [JsonInclude, JsonPropertyName(nameof(BuildingType))]
        private readonly BuildingType buildingType;

        [JsonInclude, JsonPropertyName(nameof(ConstructionFlavour))]
        private readonly ConstructionFlavour constructionFlavour;

        [JsonInclude, JsonPropertyName(nameof(ConstructionSetSource))]
        private readonly string? constructionSetSource;

        [JsonInclude, JsonPropertyName(nameof(DoorCount))]
        private readonly int doorCount;

        [JsonInclude, JsonPropertyName(nameof(DoorsBelowMinimumCount))]
        private readonly int doorsBelowMinimumCount;

        [JsonInclude, JsonPropertyName(nameof(DroppedOpeningCount))]
        private readonly int droppedOpeningCount;

        [JsonInclude, JsonPropertyName(nameof(FrontWall))]
        private readonly Guid? frontWall;

        [JsonInclude, JsonPropertyName(nameof(FrontWallRule))]
        private readonly FrontWallRule frontWallRule;

        [JsonInclude, JsonPropertyName(nameof(MaximumGlazedArea))]
        private readonly double maximumGlazedArea;

        [JsonInclude, JsonPropertyName(nameof(OpeningSizeSetSource))]
        private readonly string? openingSizeSetSource;

        [JsonInclude, JsonPropertyName(nameof(Reference))]
        private readonly string? reference;

        [JsonInclude, JsonPropertyName(nameof(StoreySource))]
        private readonly StoreySource storeySource;

        [JsonInclude, JsonPropertyName(nameof(Storeys))]
        private readonly List<OpeningGenerationStorey>? storeys;

        [JsonInclude, JsonPropertyName(nameof(WallOpeningRestrictions))]
        private readonly Dictionary<string, WallOpeningRestriction>? wallOpeningRestrictions;

        [JsonInclude, JsonPropertyName(nameof(YearBuilt))]
        private readonly short? yearBuilt;

        [JsonInclude, JsonPropertyName(nameof(YearBuiltSource))]
        private readonly YearBuiltSource? yearBuiltSource;

        /// <summary>
        /// Initializes a new instance of the <see cref="OpeningGenerationResult"/> class.
        /// </summary>
        /// <param name="reference">The reference of the 2D building the model belongs to. This value can be null.</param>
        /// <param name="buildingRegulation">The building regulation regime the openings were generated under.</param>
        /// <param name="yearBuilt">The year built the regime was selected from, or null when unknown.</param>
        /// <param name="yearBuiltSource">Where the year built comes from, or null when no year is known.</param>
        /// <param name="constructionFlavour">The construction flavour the thermal values were copied from.</param>
        /// <param name="buildingType">The building type the sizes and constructions were looked up for.</param>
        /// <param name="openingSizeSetSource">The source text of the opening-size set used. This value can be null.</param>
        /// <param name="constructionSetSource">The source text of the construction set used. This value can be null.</param>
        /// <param name="storeySource">Where the storey bands come from.</param>
        /// <param name="maximumGlazedArea">The maximum glazed area A0max of the building by modular window dimensions [m2], or not a number when the regime or the window U-value sets no such limit.</param>
        /// <param name="frontWall">The identifier of the ground-storey wall chosen as the front, which holds the entrance doors, or null.</param>
        /// <param name="frontWallRule">The rule that chose the front wall.</param>
        /// <param name="storeys">What was achieved per storey band, from the ground band up. This value can be null.</param>
        /// <param name="wallOpeningRestrictions">The restriction of each wall of the model, keyed by its identifier. This value can be null.</param>
        /// <param name="doorCount">The number of doors placed.</param>
        /// <param name="doorsBelowMinimumCount">The number of doors placed whose clear size is below the minimum of § 62; they are reported, not resized.</param>
        /// <param name="droppedOpeningCount">The number of windows and doors not placed because their outline did not lie inside the host wall.</param>
        public OpeningGenerationResult(
            string? reference,
            BuildingRegulation buildingRegulation,
            short? yearBuilt,
            YearBuiltSource? yearBuiltSource,
            ConstructionFlavour constructionFlavour,
            BuildingType buildingType,
            string? openingSizeSetSource,
            string? constructionSetSource,
            StoreySource storeySource,
            double maximumGlazedArea,
            Guid? frontWall,
            FrontWallRule frontWallRule,
            List<OpeningGenerationStorey>? storeys,
            Dictionary<Guid, WallOpeningRestriction>? wallOpeningRestrictions,
            int doorCount,
            int doorsBelowMinimumCount,
            int droppedOpeningCount)
        {
            this.reference = reference;
            this.buildingRegulation = buildingRegulation;
            this.yearBuilt = yearBuilt;
            this.yearBuiltSource = yearBuiltSource;
            this.constructionFlavour = constructionFlavour;
            this.buildingType = buildingType;
            this.openingSizeSetSource = openingSizeSetSource;
            this.constructionSetSource = constructionSetSource;
            this.storeySource = storeySource;
            this.maximumGlazedArea = maximumGlazedArea;
            this.frontWall = frontWall;
            this.frontWallRule = frontWallRule;
            this.storeys = storeys is null ? null : storeys.ConvertAll(x => new OpeningGenerationStorey(x));
            if (wallOpeningRestrictions is not null)
            {
                // Keyed by the identifier's text: a Guid dictionary key does not deserialize.
                this.wallOpeningRestrictions = [];
                foreach (KeyValuePair<Guid, WallOpeningRestriction> keyValuePair in wallOpeningRestrictions)
                {
                    this.wallOpeningRestrictions[keyValuePair.Key.ToString("D")] = keyValuePair.Value;
                }
            }
            this.doorCount = doorCount;
            this.doorsBelowMinimumCount = doorsBelowMinimumCount;
            this.droppedOpeningCount = droppedOpeningCount;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OpeningGenerationResult"/> class by copying another instance.
        /// </summary>
        /// <param name="openingGenerationResult">The instance to copy. This value can be null.</param>
        public OpeningGenerationResult(OpeningGenerationResult? openingGenerationResult)
            : base(openingGenerationResult)
        {
            if (openingGenerationResult is not null)
            {
                reference = openingGenerationResult.reference;
                buildingRegulation = openingGenerationResult.buildingRegulation;
                yearBuilt = openingGenerationResult.yearBuilt;
                yearBuiltSource = openingGenerationResult.yearBuiltSource;
                constructionFlavour = openingGenerationResult.constructionFlavour;
                buildingType = openingGenerationResult.buildingType;
                openingSizeSetSource = openingGenerationResult.openingSizeSetSource;
                constructionSetSource = openingGenerationResult.constructionSetSource;
                storeySource = openingGenerationResult.storeySource;
                maximumGlazedArea = openingGenerationResult.maximumGlazedArea;
                frontWall = openingGenerationResult.frontWall;
                frontWallRule = openingGenerationResult.frontWallRule;
                storeys = openingGenerationResult.storeys?.ConvertAll(x => new OpeningGenerationStorey(x));
                wallOpeningRestrictions = openingGenerationResult.wallOpeningRestrictions is null ? null : new Dictionary<string, WallOpeningRestriction>(openingGenerationResult.wallOpeningRestrictions);
                doorCount = openingGenerationResult.doorCount;
                doorsBelowMinimumCount = openingGenerationResult.doorsBelowMinimumCount;
                droppedOpeningCount = openingGenerationResult.droppedOpeningCount;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OpeningGenerationResult"/> class from a JSON object.
        /// </summary>
        /// <param name="jsonObject">The JSON object containing the data. This value can be null.</param>
        public OpeningGenerationResult(JsonObject? jsonObject)
            : base(jsonObject)
        {
        }

        /// <summary>
        /// Gets the building regulation regime the openings were generated under.
        /// </summary>
        [JsonIgnore]
        public BuildingRegulation BuildingRegulation
        {
            get
            {
                return buildingRegulation;
            }
        }

        /// <summary>
        /// Gets the building type the sizes and constructions were looked up for.
        /// </summary>
        [JsonIgnore]
        public BuildingType BuildingType
        {
            get
            {
                return buildingType;
            }
        }

        /// <summary>
        /// Gets the construction flavour the thermal values were copied from.
        /// </summary>
        [JsonIgnore]
        public ConstructionFlavour ConstructionFlavour
        {
            get
            {
                return constructionFlavour;
            }
        }

        /// <summary>
        /// Gets the source text of the construction set used.
        /// </summary>
        [JsonIgnore]
        public string? ConstructionSetSource
        {
            get
            {
                return constructionSetSource;
            }
        }

        /// <summary>
        /// Gets the number of doors placed.
        /// </summary>
        [JsonIgnore]
        public int DoorCount
        {
            get
            {
                return doorCount;
            }
        }

        /// <summary>
        /// Gets the number of doors placed whose clear size is below the minimum of § 62.
        /// </summary>
        [JsonIgnore]
        public int DoorsBelowMinimumCount
        {
            get
            {
                return doorsBelowMinimumCount;
            }
        }

        /// <summary>
        /// Gets the number of windows and doors not placed because their outline did not lie inside the host wall.
        /// </summary>
        [JsonIgnore]
        public int DroppedOpeningCount
        {
            get
            {
                return droppedOpeningCount;
            }
        }

        /// <summary>
        /// Gets the identifier of the ground-storey wall chosen as the front, or null.
        /// </summary>
        [JsonIgnore]
        public Guid? FrontWall
        {
            get
            {
                return frontWall;
            }
        }

        /// <summary>
        /// Gets the rule that chose the front wall.
        /// </summary>
        [JsonIgnore]
        public FrontWallRule FrontWallRule
        {
            get
            {
                return frontWallRule;
            }
        }

        /// <summary>
        /// Gets the maximum glazed area A0max of the building [m2], or not a number when no such limit applies.
        /// </summary>
        [JsonIgnore]
        public double MaximumGlazedArea
        {
            get
            {
                return maximumGlazedArea;
            }
        }

        /// <summary>
        /// Gets the source text of the opening-size set used.
        /// </summary>
        [JsonIgnore]
        public string? OpeningSizeSetSource
        {
            get
            {
                return openingSizeSetSource;
            }
        }

        /// <summary>
        /// Gets the reference of the 2D building the model belongs to.
        /// </summary>
        [JsonIgnore]
        public string? Reference
        {
            get
            {
                return reference;
            }
        }

        /// <summary>
        /// Gets where the storey bands come from.
        /// </summary>
        [JsonIgnore]
        public StoreySource StoreySource
        {
            get
            {
                return storeySource;
            }
        }

        /// <summary>
        /// Gets CLONES of what was achieved per storey band, from the ground band up.
        /// </summary>
        [JsonIgnore]
        public List<OpeningGenerationStorey>? Storeys
        {
            get
            {
                return storeys?.ConvertAll(x => new OpeningGenerationStorey(x));
            }
        }

        /// <summary>
        /// Gets a copy of the restriction of each wall, keyed by its identifier.
        /// </summary>
        [JsonIgnore]
        public Dictionary<Guid, WallOpeningRestriction>? WallOpeningRestrictions
        {
            get
            {
                if (wallOpeningRestrictions is null)
                {
                    return null;
                }

                Dictionary<Guid, WallOpeningRestriction> result = [];
                foreach (KeyValuePair<string, WallOpeningRestriction> keyValuePair in wallOpeningRestrictions)
                {
                    if (Guid.TryParse(keyValuePair.Key, out Guid guid))
                    {
                        result[guid] = keyValuePair.Value;
                    }
                }

                return result;
            }
        }

        /// <summary>
        /// Gets the year built the regime was selected from, or null when unknown.
        /// </summary>
        [JsonIgnore]
        public short? YearBuilt
        {
            get
            {
                return yearBuilt;
            }
        }

        /// <summary>
        /// Gets where the year built comes from, or null when no year is known.
        /// </summary>
        [JsonIgnore]
        public YearBuiltSource? YearBuiltSource
        {
            get
            {
                return yearBuiltSource;
            }
        }
    }
}
