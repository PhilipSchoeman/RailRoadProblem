using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RailRoadProblem
{
    public class RailRoadManager : IRailRoadManager
    {
        private readonly IPathCalculator _pathCalculator;

        public RailRoadManager()
        {
            _pathCalculator = new PathCalculator();
        }


        public List<Route> GetRoutes(Point route, Point startPoint, Point endPoint)
        {
            return _pathCalculator.Calculate(route, startPoint, endPoint);
        }


        public Route GetShortestRoute(List<Route> paths)
        {
            var orderedPaths = paths.OrderBy(GetRouteDistance);

            return orderedPaths.Last();
        }


        public decimal GetRouteDistance(Route path)
        {
            return path.PathNodes.Sum(x=>x.Weight);
        }


        public int GetRouteNodeCount(Path path)
        {
            return path.Nodes.Count;
        }

        public IEnumerable<Route> GetListOfPathsWithPathNodesLower(int numberOfNodes, IEnumerable<Route> routes)
        {
            return routes.Where(x => x.PathNodes.Count < numberOfNodes);
        }

        public IEnumerable<Route> GetListOfPathsWithPathNodesEquals(int numberOfNodes, IEnumerable<Route> routes)
        {
            return routes.Where(x => x.PathNodes.Count == numberOfNodes);
        }

        public IEnumerable<Route> GetListOfPathsWithPathNodesDistanceLower(int routeDistance, IEnumerable<Route> routes)
        {
            return routes.Where(x => GetRouteDistance(x) < routeDistance);
        }

    }
}
