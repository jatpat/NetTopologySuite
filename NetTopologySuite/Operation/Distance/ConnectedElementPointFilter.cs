using System.Collections;
using GeoAPI.Geometries;

namespace GisSharpBlog.NetTopologySuite.Operation.Distance
{
    /// <summary>
    /// Extracts a single point
    /// from each connected element in a Geometry
    /// (e.g. a polygon, linestring or point)
    /// and returns them in a list
    /// </summary>
    public class ConnectedElementPointFilter : IGeometryFilter
    {
        /// <summary>
        /// Returns a list containing a Coordinate from each Polygon, LineString, and Point
        /// found inside the specified point. Thus, if the specified point is
        /// not a GeometryCollection, an empty list will be returned.
        /// </summary>
        public static IList GetCoordinates(Geometry2D geom)
        {
            IList pts = new ArrayList();
            geom.Apply(new ConnectedElementPointFilter(pts));
            return pts;
        }

        private IList pts = null;

        private ConnectedElementPointFilter(IList pts)
        {
            this.pts = pts;
        }

        public void Filter(IGeometry geom)
        {
            if (geom is Point || geom is LineString || geom is Polygon)
            {
                pts.Add(geom.Coordinate);
            }
        }
    }
}