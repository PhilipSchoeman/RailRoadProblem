using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace RailRoadProblem
{
    [TestClass]
    public class RailRoadManagerTest
    {
        [TestMethod]
        public void TestCalculteDistance()
        {
            var railRoadManager = new RailRoadManager();

            var routeData = new TestData();

            var command = new RouteCalculateCommand
                {
                    StartPoint = routeData.GetPointByName("C"),

                    EndPoint = routeData.GetPointByName("C"),

                    Route = routeData.GetTestRailRoad()
                };

            var allRoads = railRoadManager.GetRoutes(command);

            Assert.Equals(3, allRoads.Count());
        }


        [TestMethod]
        public void TestDistanceRouteAbc()
        {
            var railRoadManager = new RailRoadManager();

            var routeData = new TestData();

            var routeAbc = new Route(new List<PathNode> {routeData.GetPathNodeByPoints("AB"), routeData.GetPathNodeByPoints("BC")});

            var distance = railRoadManager.GetRouteDistance(routeAbc);

            Assert.AreEqual(9, distance);

        }

        [TestMethod]
        public void TestDistanceRouteAd()
        {
            var railRoadManager = new RailRoadManager();

            var routeData = new TestData();

            var routeAbc = new Route(new List<PathNode> { routeData.GetPathNodeByPoints("AD") });

            var distance = railRoadManager.GetRouteDistance(routeAbc);

            Assert.AreEqual(5, distance);

        }

        [TestMethod]
        public void TestDistanceRouteAdc()
        {
            var railRoadManager = new RailRoadManager();

            var routeData = new TestData();

            var routeAbc = new Route(new List<PathNode> { routeData.GetPathNodeByPoints("AD"), routeData.GetPathNodeByPoints("DC") });

            var distance = railRoadManager.GetRouteDistance(routeAbc);

            Assert.AreEqual(13, distance);

        }

        [TestMethod]
        public void TestDistanceRouteAebcd()
        {
            var railRoadManager = new RailRoadManager();

            var routeData = new TestData();

            var routeAbc = new Route(new List<PathNode> { routeData.GetPathNodeByPoints("AE"), routeData.GetPathNodeByPoints("EB"), routeData.GetPathNodeByPoints("BC") });

            var distance = railRoadManager.GetRouteDistance(routeAbc);

            Assert.AreEqual(14, distance);

        }

        [TestMethod]
        public void TestGetNumberPathsCtoCWithLessThanThreeNodes()
        {
            var railRoadManager = new RailRoadManager();

            var routeData = new TestData();

            var command = new RouteCalculateCommand
                {
                    StartPoint = routeData.GetPointByName("C"),

                    EndPoint = routeData.GetPointByName("C"),

                    Route = routeData.GetTestRailRoad()
                };

            var allRoads = railRoadManager.GetRoutes(command);

            var smallRoutes = railRoadManager.GetListOfPathsWithPathNodesLower(5, allRoads); //Including start and end nodes

            Assert.AreEqual(2,smallRoutes.Count());
        }

        [TestMethod]
        public void GetDistanceOfShortestRouteAtoC()
        {
            var railRoadManager = new RailRoadManager();

            var routeData = new TestData();

            var command = new RouteCalculateCommand
                {
                    StartPoint = routeData.GetPointByName("A"),

                    EndPoint = routeData.GetPointByName("C"),

                    Route = routeData.GetTestRailRoad()
                };

            var allRoads = railRoadManager.GetRoutes(command);

            var shortesRoute = railRoadManager.GetShortestRoute(allRoads);

            var distance = railRoadManager.GetRouteDistance(shortesRoute);

            Assert.AreEqual(18,distance);

        }

        [TestMethod]
        public void GetDistanceOfShortestRouteBtoB()
        {
            var railRoadManager = new RailRoadManager();

            var routeData = new TestData();

            var command = new RouteCalculateCommand
                {
                    StartPoint = routeData.GetPointByName("B"),

                    EndPoint = routeData.GetPointByName("B"),

                    ForceLoopingCount = 0,

                    Route = routeData.GetTestRailRoad()
                };

            var allRoads = railRoadManager.GetRoutes(command);

            var shortesRoute = railRoadManager.GetShortestRoute(allRoads);

            var distance = railRoadManager.GetRouteDistance(shortesRoute);

            Assert.AreEqual(21, distance);

        }

        [TestMethod]
        public void GetAmountOfNodesCtoC()
        {
            var railRoadManager = new RailRoadManager();

            var routeData = new TestData();

            var command = new RouteCalculateCommand
            {
                StartPoint = routeData.GetPointByName("C"),

                EndPoint = routeData.GetPointByName("C"),

                ForceLoopingCount = 10,

                Route = routeData.GetTestRailRoad()
            };

            var allRoads = railRoadManager.GetRoutes(command);

            var shortRoutes = railRoadManager.GetListOfPathsWithPathNodesDistanceLower(30, allRoads);

            Assert.AreEqual(6, shortRoutes.Count());

        }

    }
}
