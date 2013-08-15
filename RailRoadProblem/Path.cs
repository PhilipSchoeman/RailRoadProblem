using System.Collections.Generic;

namespace RailRoadProblem
{
    public class Path
    {
        public List<Point> Nodes { get; set; }

        public Path()
        {
            
        }

        public Path(IEnumerable<Point> points)
        {
            Nodes = new List<Point>(points);
        }
    }
}
