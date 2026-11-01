using DiGi.Analytical.Building.Classes;
using DiGi.Geometry.Planar.Classes;
using DiGi.GIS.Classes;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace DiGi.GIS.Analytical
{
    public static partial class Query
    {
        /// <summary>
        /// Finds the frontage lines (pierzeja) of a building model: its road-frontage walls that align with the walls of the neighbouring models along the same road at a similar setback (DiGi-Organization/DiGi.GIS.Analytical#10).
        /// <para>Two fronts belong to one line when they front the same road, both ends of the later wall lie on the line of the earlier one within the tolerance, and their setbacks from that road differ by no more than <c>OpeningGenerationOptions.FrontageLineSetbackTolerance</c>. A line qualifies when <c>OpeningGenerationOptions.FrontageLineMinimumFronts</c> distinct buildings stand in it, and it is then reported on the subject model's walls only. Reported only: a frontage line does not change placement.</para>
        /// </summary>
        /// <param name="buildingModel">The building model whose walls are reported.</param>
        /// <param name="buildingModels_Neighbour">The neighbouring building models whose walls take part in the alignment; a model repeating the subject's own identifier is skipped. This value can be null.</param>
        /// <param name="polyline2Ds_Road">The road polylines, in the order the caller gives them. This value can be null.</param>
        /// <param name="options">The rules to apply, or null for the defaults.</param>
        /// <param name="tolerance">The distance tolerance; also the allowed deviation from the line of the earlier front.</param>
        /// <returns>The frontage-line key of each reported wall of the subject model, keyed by the wall identifier; null when the model is null, there is no road context, or no line qualifies.</returns>
        public static Dictionary<Guid, string>? FrontageLines(this BuildingModel? buildingModel, IEnumerable<BuildingModel?>? buildingModels_Neighbour, IEnumerable<Polyline2D>? polyline2Ds_Road, OpeningGenerationOptions? options = null, double tolerance = Core.Constants.Tolerance.Distance)
        {
            if (buildingModel is null || polyline2Ds_Road is null)
            {
                return null;
            }

            OpeningGenerationOptions openingGenerationOptions = options ?? new OpeningGenerationOptions();

            Dictionary<Guid, RoadFrontage>? frontages_Subject = buildingModel.RoadFrontages(polyline2Ds_Road, openingGenerationOptions, tolerance);
            if (frontages_Subject is null || frontages_Subject.Count == 0)
            {
                return null;
            }

            // The stable key of one line: the road, the direction along it and its offset, rendered invariantly.
            static string Key(int roadIndex, double normalX, double normalY, double offset)
            {
                double directionX = -normalY;
                double directionY = normalX;
                if (directionX < 0 || (directionX == 0 && directionY < 0))
                {
                    directionX = -directionX;
                    directionY = -directionY;
                }

                directionX = Math.Round(directionX, 3);
                directionY = Math.Round(directionY, 3);
                offset = Math.Round(offset, 3);

                if (directionX == 0)
                {
                    directionX = 0;
                }

                if (directionY == 0)
                {
                    directionY = 0;
                }

                if (offset == 0)
                {
                    offset = 0;
                }

                return string.Format(CultureInfo.InvariantCulture, "FrontageLine.{0}.{1:0.###}.{2:0.###}.{3:0.###}", roadIndex, directionX, directionY, offset);
            }

            // The candidates in wall order: the subject's walls first (model 0), then each neighbour's, so the grouping below is deterministic.
            List<(int Model, Guid Wall, RoadFrontage RoadFrontage)> candidates = [];
            foreach (KeyValuePair<Guid, RoadFrontage> keyValuePair in frontages_Subject)
            {
                candidates.Add((0, keyValuePair.Key, keyValuePair.Value));
            }

            int model = 0;
            if (buildingModels_Neighbour is not null)
            {
                foreach (BuildingModel? buildingModel_Neighbour in buildingModels_Neighbour)
                {
                    model++;
                    if (buildingModel_Neighbour is null || buildingModel_Neighbour.Guid == buildingModel.Guid)
                    {
                        continue;
                    }

                    Dictionary<Guid, RoadFrontage>? frontages_Neighbour = buildingModel_Neighbour.RoadFrontages(polyline2Ds_Road, openingGenerationOptions, tolerance);
                    if (frontages_Neighbour is null)
                    {
                        continue;
                    }

                    foreach (KeyValuePair<Guid, RoadFrontage> keyValuePair in frontages_Neighbour)
                    {
                        candidates.Add((model, keyValuePair.Key, keyValuePair.Value));
                    }
                }
            }

            candidates.Sort((x, y) => x.Model != y.Model ? x.Model.CompareTo(y.Model) : x.Wall.CompareTo(y.Wall));

            // One line: the road it runs along, the setback and the line (normal and offset) of its first front, and its fronts.
            List<(int RoadIndex, double Setback, double NormalX, double NormalY, double Offset, List<(int Model, Guid Wall)> Fronts)> lines = [];

            double setbackTolerance = openingGenerationOptions.FrontageLineSetbackTolerance;
            foreach ((int Model, Guid Wall, RoadFrontage RoadFrontage) candidate in candidates)
            {
                if (candidate.RoadFrontage.Segment2D is not Segment2D segment2D || segment2D.Start is not Point2D point2D_Start || segment2D.End is not Point2D point2D_End || candidate.RoadFrontage.Normal is not Vector2D vector2D_Normal)
                {
                    continue;
                }

                int index_Line = -1;
                for (int i = 0; i < lines.Count; i++)
                {
                    if (lines[i].RoadIndex != candidate.RoadFrontage.RoadIndex || Math.Abs(lines[i].Setback - candidate.RoadFrontage.Setback) > setbackTolerance)
                    {
                        continue;
                    }

                    double distance_Start = Math.Abs(((lines[i].NormalX * point2D_Start.X) + (lines[i].NormalY * point2D_Start.Y)) - lines[i].Offset);
                    double distance_End = Math.Abs(((lines[i].NormalX * point2D_End.X) + (lines[i].NormalY * point2D_End.Y)) - lines[i].Offset);
                    if (distance_Start > tolerance || distance_End > tolerance)
                    {
                        continue;
                    }

                    index_Line = i;
                    break;
                }

                if (index_Line == -1)
                {
                    lines.Add((candidate.RoadFrontage.RoadIndex, candidate.RoadFrontage.Setback, vector2D_Normal.X, vector2D_Normal.Y, ((vector2D_Normal.X * point2D_Start.X) + (vector2D_Normal.Y * point2D_Start.Y)), []));
                    index_Line = lines.Count - 1;
                }

                lines[index_Line].Fronts.Add((candidate.Model, candidate.Wall));
            }

            int minimumFronts = openingGenerationOptions.FrontageLineMinimumFronts;
            Dictionary<Guid, string> result = [];
            foreach ((int RoadIndex, double Setback, double NormalX, double NormalY, double Offset, List<(int Model, Guid Wall)> Fronts) line in lines)
            {
                HashSet<int> models = [];
                bool subject = false;
                foreach ((int Model, Guid Wall) front in line.Fronts)
                {
                    models.Add(front.Model);
                    if (front.Model == 0)
                    {
                        subject = true;
                    }
                }

                if (!subject || models.Count < minimumFronts)
                {
                    continue;
                }

                string key = Key(line.RoadIndex, line.NormalX, line.NormalY, line.Offset);
                foreach ((int Model, Guid Wall) front in line.Fronts)
                {
                    if (front.Model == 0)
                    {
                        result[front.Wall] = key;
                    }
                }
            }

            return result.Count == 0 ? null : result;
        }
    }
}
