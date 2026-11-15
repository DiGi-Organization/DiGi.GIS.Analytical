using DiGi.Analytical.Building.Classes;
using DiGi.Geometry.Planar.Classes;
using DiGi.Geometry.Spatial.Classes;
using System;

namespace DiGi.GIS.Analytical.Solar
{
    public static partial class Query
    {
        /// <summary>
        /// Gets the circle a solar radiation solve takes a building's neighbours from: centred on the centre of the building's bounding box, reaching <paramref name="radius"/> beyond its farthest corner.
        /// <para>Every building whose footprint bounding box lies within or intersects the circle casts shade (<c>gis/buildingmodel/itemsbycircle</c>). The centre is also the point the weather station is chosen for. The viewer (<c>SolarController</c>) and a batch solve (DiGi-Organization/DiGi.GIS.PostgreSQL#136) both take the circle from here, so a stored result does not depend on which of them solved it.</para>
        /// </summary>
        /// <param name="buildingModel">The building model. This value can be null.</param>
        /// <param name="radius">The neighbour radius, in m, measured from the farthest corner of the bounding box.</param>
        /// <returns>The circle, or null when the model is null, has no bounding box or its centre is not finite.</returns>
        public static Circle2D? SolarNeighbourCircle(this BuildingModel? buildingModel, double radius)
        {
            if (buildingModel is null)
            {
                return null;
            }

            BoundingBox3D? boundingBox3D = buildingModel.GetBoundingBox();
            if (boundingBox3D is null)
            {
                return null;
            }

            // double.IsFinite is not available on netstandard2.0.
            Point3D? centroid = boundingBox3D.GetCentroid();
            if (centroid is null || double.IsNaN(centroid.X) || double.IsInfinity(centroid.X) || double.IsNaN(centroid.Y) || double.IsInfinity(centroid.Y))
            {
                return null;
            }

            double halfWidth = boundingBox3D.Width / 2;
            double halfDepth = boundingBox3D.Depth / 2;
            double boundingRadius = Math.Sqrt((halfWidth * halfWidth) + (halfDepth * halfDepth));

            return new Circle2D(new Point2D(centroid.X, centroid.Y), Math.Max(boundingRadius + radius, 0));
        }
    }
}
