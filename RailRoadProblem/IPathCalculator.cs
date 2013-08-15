using System.Collections.Generic;

namespace RailRoadProblem
{
    public interface IPathCalculator
    {
        List<Route> Calculate(Point topLevelNode, Point startPoint, Point endPoint);
    }
}