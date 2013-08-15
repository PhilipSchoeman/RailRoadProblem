using System.Collections.Generic;

namespace RailRoadProblem
{
    public interface IRailRoadManager
    {
        List<Route> GetRoutes(Point route, Point startPoint, Point endPoint);
        Route GetShortestRoute(List<Route> paths);
        decimal GetRouteDistance(Route path);
        int GetRouteNodeCount(Path path);
        IEnumerable<Route> GetListOfPathsWithPathNodesLower(int numberOfNodes, IEnumerable<Route> routes);
        IEnumerable<Route> GetListOfPathsWithPathNodesDistanceLower(int routeDistance, IEnumerable<Route> routes);
    }
}