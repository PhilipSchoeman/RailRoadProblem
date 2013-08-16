using System.Collections.Generic;
using System.Linq;

namespace RailRoadProblem
{
    public class PathCalculator : IPathCalculator
    {
      
        public List<Route> Calculate(IRouteCalculateCommand command)
        {
            var pathRoutes = new PathRoutes();

            pathRoutes.PathList.Add(new Route { PathNodes = new List<PathNode> { new PathNode(command.StartPoint, 0) } });

            ExecuteMainPathFindingLoop(command, pathRoutes);

            return pathRoutes.CompletedPaths;
        }


        #region Private Methods
        private void ExecuteMainPathFindingLoop(IRouteCalculateCommand command,
                                                PathRoutes pathRoutes)
        {
            while (pathRoutes.PathList.Count > 0)
            {
                pathRoutes.TempPathList = new List<Route>(pathRoutes.PathList);

                HandlePath(command, pathRoutes);

                pathRoutes.PathList = new List<Route>(pathRoutes.TempPathList);
            }
        }


        private void HandlePath(IRouteCalculateCommand command,
                                PathRoutes pathRoutes)
        {
            foreach (var path in pathRoutes.PathList)
            {
                var point = path.PathNodes.Last().ChildPoint;

                pathRoutes.Path = path;

                foreach (var childPoint in point.Children)
                {
                    pathRoutes.ChildPoint = childPoint;

                    HandlePointChild(command, pathRoutes);
                }
            }
        }


        private void HandlePointChild(IRouteCalculateCommand command,
                                      PathRoutes pathRoutes)
           
        {
            if (command.ForceLoopingCount <= pathRoutes.CompletedPaths.Count && command.ForceLooping)
            {
                pathRoutes.TempPathList.Clear();
                return;
            }

            if (pathRoutes.ChildPoint.ChildPoint.Name == command.EndPoint.Name)
            {
                HandleEndOfLine(command, pathRoutes);

            }
            else if (pathRoutes.ChildPoint.ChildPoint.Children.Count < 1 || pathRoutes.ChildPoint.ChildPoint.Name == command.StartPoint.Name)
            {
                pathRoutes.TempPathList.Remove(pathRoutes.Path);
            }
            else if (pathRoutes.Path.PathNodes.All(x => x.ChildPoint.Name != pathRoutes.ChildPoint.ChildPoint.Name) || command.ForceLooping)
            {
                HandlePoint(pathRoutes);
            }
        }


        private static void HandlePoint(PathRoutes pathRoutes)
        {
            var newPath = new Route(pathRoutes.Path.PathNodes);

            newPath.PathNodes.Add(pathRoutes.ChildPoint);

            pathRoutes.TempPathList.Add(newPath);

            pathRoutes.TempPathList.Remove(pathRoutes.Path);
        }


        private void HandleEndOfLine(IRouteCalculateCommand command,
                                     PathRoutes pathRoutes)
        {
            var completedPath = new Route(pathRoutes.Path.PathNodes);

            completedPath.PathNodes.Add(pathRoutes.ChildPoint);

            pathRoutes.CompletedPaths.Add(completedPath);


            if (!command.ForceLooping)
            {
                pathRoutes.TempPathList.Remove(pathRoutes.Path);
            }
            else
            {
                HandlePoint(pathRoutes);
            }
        }


       

        #endregion

    }

    internal class PathRoutes
    {
        public List<Route> PathList = new List<Route>();

        public List<Route> CompletedPaths = new List<Route>();

        public Route Path = new Route();

        public PathNode ChildPoint;

        public List<Route> TempPathList = new List<Route>();
    }


}
