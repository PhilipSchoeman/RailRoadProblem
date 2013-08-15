using System.Collections.Generic;
using System.Linq;

namespace RailRoadProblem
{
    public class PathCalculator : IPathCalculator
    {
        public List<Route> Calculate(Point topLevelNode, 
                                    Point startPoint, 
                                    Point endPoint)
        {
            var pointsDone = new List<Point>();

            var pathList = new List<Route>();

            var completedPaths = new List<Route>();

            pathList.Add(new Route(){PathNodes = new List<PathNode>(){new PathNode(startPoint,0)}});

            ExecuteMainPathFindingLoop(startPoint, endPoint, pathList, completedPaths, pointsDone);

            return completedPaths;
        }

        #region Private Methods
        private void ExecuteMainPathFindingLoop(Point startPoint,
                                                Point endPoint,
                                                List<Route> pathList, 
                                                List<Route> completedPaths, 
                                                List<Point> pointsDone)
        {
            while (pathList.Count > 0)
            {
                var tempPathList = new List<Route>(pathList);

                HandlePath(startPoint,endPoint, pathList, completedPaths, tempPathList, pointsDone);

                pathList = new List<Route>(tempPathList);
            }
        }


        private void HandlePath(Point startPoint,
                                Point endPoint,
                                List<Route> pathList,
                                List<Route> completedPaths,
                                List<Route> tempPathList, 
                                List<Point> pointsDone)
        {
            foreach (var path in pathList)
            {
                var point = path.PathNodes.Last().ChildPoint;

                foreach (var childPoint in point.Children)
                {
                    HandlePointChild(startPoint,endPoint, childPoint, path, completedPaths, tempPathList, pointsDone);
                }
            }
        }


        private void HandlePointChild(Point startPoint,
                                      Point endPoint,
                                      PathNode childPoint,
                                      Route path,
                                      List<Route> completedPaths,
                                      List<Route> tempPathList,
                                      List<Point> pointsDone)
           
        {
            if (childPoint.ChildPoint.Name == endPoint.Name)
            {
                HandleEndOfLine(path, childPoint, completedPaths, tempPathList);
            }


            else if (childPoint.ChildPoint.Children.Count < 1 || childPoint.ChildPoint.Name == startPoint.Name)
            {
                tempPathList.Remove(path);
            }
            else if (path.PathNodes.All(x => x.ChildPoint.Name != childPoint.ChildPoint.Name))
            {
                HandlePoint(path, childPoint, pointsDone, tempPathList);
            }
        }


        private static void HandlePoint(Route path,
                                        PathNode childPoint, 
                                        List<Point> pointsDone, 
                                        List<Route> tempPathList)
        {
            var newPath = new Route(path.PathNodes);

            newPath.PathNodes.Add(childPoint);

            pointsDone.Add(childPoint.ChildPoint);

            tempPathList.Add(newPath);

            tempPathList.Remove(path);
        }


        private void HandleEndOfLine(Route path,
                                    PathNode childPoint,
                                    List<Route> completedPaths, 
                                    List<Route> tempPathList)
        {
            var completedPath = new Route(path.PathNodes);

            completedPath.PathNodes.Add(childPoint);

            completedPaths.Add(completedPath);

            tempPathList.Remove(path);
        }


       

        #endregion
    }
}
