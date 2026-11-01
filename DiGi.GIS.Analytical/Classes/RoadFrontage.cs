using DiGi.Geometry.Planar.Classes;

namespace DiGi.GIS.Classes
{
    /// <summary>
    /// What <c>Query.RoadFrontages</c> measured for one wall that fronts a road (DiGi-Organization/DiGi.GIS.Analytical#10).
    /// </summary>
    public class RoadFrontage
    {
        private readonly Segment2D? segment2D;

        private readonly Vector2D? normal;

        private readonly int roadIndex;

        private readonly double setback;

        /// <summary>
        /// Initializes a new instance of the <see cref="RoadFrontage"/> class.
        /// </summary>
        /// <param name="roadIndex">The index of the road polyline in the list as given.</param>
        /// <param name="setback">The shortest distance from the wall face to that road [m].</param>
        /// <param name="segment2D">The footprint line of the wall. This value can be null.</param>
        /// <param name="normal">The outward unit normal of the wall face. This value can be null.</param>
        public RoadFrontage(int roadIndex, double setback, Segment2D? segment2D, Vector2D? normal)
        {
            this.roadIndex = roadIndex;
            this.setback = setback;
            this.segment2D = segment2D is null ? null : new Segment2D(segment2D);
            this.normal = normal is null ? null : new Vector2D(normal);
        }

        /// <summary>
        /// Gets the index of the road polyline in the list as given.
        /// </summary>
        public int RoadIndex
        {
            get
            {
                return roadIndex;
            }
        }

        /// <summary>
        /// Gets the shortest distance from the wall face to that road [m].
        /// </summary>
        public double Setback
        {
            get
            {
                return setback;
            }
        }

        /// <summary>
        /// Gets a CLONE of the footprint line of the wall.
        /// </summary>
        public Segment2D? Segment2D
        {
            get
            {
                return segment2D is null ? null : new Segment2D(segment2D);
            }
        }

        /// <summary>
        /// Gets a CLONE of the outward unit normal of the wall face.
        /// </summary>
        public Vector2D? Normal
        {
            get
            {
                return normal is null ? null : new Vector2D(normal);
            }
        }
    }
}
