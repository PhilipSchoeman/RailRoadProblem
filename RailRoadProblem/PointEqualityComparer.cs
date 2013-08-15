using System.Collections.Generic;

namespace RailRoadProblem
{
    public class PointEqualityComparer : IEqualityComparer<Point>
    {
        public bool Equals(Point x, Point y)
        {
            return x.Name == y.Name;
        }

        public int GetHashCode(Point obj)
        {
            return obj != null ? obj.Name.GetHashCode() : 0;
        }
    }
}
