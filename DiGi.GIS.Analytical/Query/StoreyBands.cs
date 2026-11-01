using DiGi.Analytical.Building.Classes;
using DiGi.Analytical.Building.Interfaces;
using DiGi.Core.Classes;
using DiGi.Geometry.Spatial.Classes;
using DiGi.GIS.Analytical.Enums;
using System;
using System.Collections.Generic;

namespace DiGi.GIS.Analytical
{
    public static partial class Query
    {
        /// <summary>
        /// Derives the storey bands of a building model, the elevation range of each storey from the ground up, without assuming that one space is one storey (DiGi-Organization/DiGi.GIS.Analytical#2).
        /// <para>The bands come from the first source that gives them, reported in <paramref name="storeySource"/>:</para>
        /// <list type="bullet">
        /// <item><description><see cref="StoreySource.Spaces"/>: two or more spaces with walls; each band is the elevation range of the walls of one space.</description></item>
        /// <item><description><see cref="StoreySource.Building2D"/>: one space, which the 3D path leaves unsplit when its derived storey height is too low, and <paramref name="storeys"/> &gt; 0; the wall height is divided into that many equal bands.</description></item>
        /// <item><description><see cref="StoreySource.Estimated"/>: one space and no storey count; the count is the wall height over <paramref name="storeyHeight"/>, rounded, at least 1.</description></item>
        /// <item><description><see cref="StoreySource.Single"/>: no storey count and no storey height; one band, the whole wall.</description></item>
        /// </list>
        /// </summary>
        /// <param name="buildingModel">The building model.</param>
        /// <param name="storeys">The storey count of the 2D building, or 0 when unknown.</param>
        /// <param name="storeyHeight">The typical storey height of the building's stock [m], used to estimate the count; not a number when unknown.</param>
        /// <param name="storeySource">Where the bands come from; <see cref="StoreySource.Undefined"/> when the model has no walls.</param>
        /// <param name="tolerance">The distance tolerance.</param>
        /// <returns>The bands from the ground up, or null when the model is null or has no walls.</returns>
        public static List<Range<double>>? StoreyBands(this BuildingModel? buildingModel, ushort storeys, double storeyHeight, out StoreySource storeySource, double tolerance = Core.Constants.Tolerance.Distance)
        {
            storeySource = StoreySource.Undefined;

            List<IWall>? walls = buildingModel?.GetComponents<IWall>();
            if (buildingModel is null || walls is null || walls.Count == 0)
            {
                return null;
            }

            static Range<double>? Extent(IEnumerable<IWall>? walls_Extent)
            {
                double min = double.NaN;
                double max = double.NaN;
                if (walls_Extent is not null)
                {
                    foreach (IWall wall in walls_Extent)
                    {
                        if (wall?.GetBoundingBox() is BoundingBox3D boundingBox3D && boundingBox3D.Min is Point3D point3D_Min && boundingBox3D.Max is Point3D point3D_Max)
                        {
                            min = double.IsNaN(min) ? point3D_Min.Z : Math.Min(min, point3D_Min.Z);
                            max = double.IsNaN(max) ? point3D_Max.Z : Math.Max(max, point3D_Max.Z);
                        }
                    }
                }

                return double.IsNaN(min) || double.IsNaN(max) ? null : new Range<double>(min, max);
            }

            List<Range<double>> result = [];

            List<ISpace>? spaces = buildingModel.GetSpaces<ISpace>();
            if (spaces is not null && spaces.Count > 1)
            {
                foreach (ISpace space in spaces)
                {
                    if (Extent(buildingModel.GetComponents<IWall>(space)) is Range<double> range && range.Max - range.Min > tolerance)
                    {
                        result.Add(range);
                    }
                }

                if (result.Count > 1)
                {
                    result.Sort((x, y) => x.Min.CompareTo(y.Min));
                    storeySource = StoreySource.Spaces;
                    return result;
                }

                result.Clear();
            }

            if (Extent(walls) is not Range<double> range_All)
            {
                return null;
            }

            double height = range_All.Max - range_All.Min;

            int count;
            if (storeys > 0)
            {
                count = storeys;
                storeySource = StoreySource.Building2D;
            }
            else if (!double.IsNaN(storeyHeight) && storeyHeight > 0)
            {
                count = Math.Max(1, (int)Math.Round(height / storeyHeight, MidpointRounding.AwayFromZero));
                storeySource = StoreySource.Estimated;
            }
            else
            {
                count = 1;
                storeySource = StoreySource.Single;
            }

            double height_Band = height / count;
            for (int i = 0; i < count; i++)
            {
                result.Add(new Range<double>(range_All.Min + (i * height_Band), i == count - 1 ? range_All.Max : range_All.Min + ((i + 1) * height_Band)));
            }

            return result;
        }
    }
}
