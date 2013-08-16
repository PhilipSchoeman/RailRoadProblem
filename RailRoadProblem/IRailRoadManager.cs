using System.Collections.Generic;

namespace RailRoadProblem
{
    public interface IRailRoadManager
    {
        IEnumerable<Route> GetRoutes(IRouteCalculateCommand command);

        Route GetShortestRoute(IEnumerable<Route> paths);

        decimal GetRouteDistance(Route path);

        int GetRouteNodeCount(Path path);

        IEnumerable<Route> GetListOfPathsWithPathNodesLower(int numberOfNodes, IEnumerable<Route> routes);

        IEnumerable<Route> GetListOfPathsWithPathNodesDistanceLower(int routeDistance, IEnumerable<Route> routes);
    }
}