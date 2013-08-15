namespace RailRoadProblem
{
    public class PathNode
    {
        public Point ChildPoint;

        public decimal Weight;

        public PathNode(Point point, decimal weight)
        {
            ChildPoint = point;

            Weight = weight;
        }
    }
}
