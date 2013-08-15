using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RailRoadProblem
{
    public class TestData
    {
        private Point _pointA;
        private Point _pointB;
        private Point _pointC;
        private Point _pointD;
        private Point _pointE;
        private Point _pointF;
        private Point _pointG;
        private Point _pointH;
        private Point _pointI;
        private Point _pointJ;
        private Point _pointK;
        private Point _pointL;
        private Point _pointM;
        private Point _pointN;
        private Point _pointO;

        private PathNode _pathNodeAb;
        private PathNode _pathNodeBc;
        private PathNode _pathNodeCd;
        private PathNode _pathNodeDe;
        private PathNode _pathNodeDc;
        private PathNode _pathNodeCe;
        private PathNode _pathNodeEb;
        private PathNode _pathNodeAe;
        private PathNode _pathNodeAd;

        List<Point> _points;

        private Dictionary<string, PathNode> _pathNodes;

        public TestData()
        {
            _pointA = Point.NewPoint("A");
            _pointB = Point.NewPoint("B");
            _pointC = Point.NewPoint("C");
            _pointD = Point.NewPoint("D");
            _pointE = Point.NewPoint("E");
            _pointF = Point.NewPoint("F");
            _pointG = Point.NewPoint("G");
            _pointI = Point.NewPoint("I");
            _pointH = Point.NewPoint("H");
            _pointJ = Point.NewPoint("J");
            _pointM = Point.NewPoint("M");
            _pointK = Point.NewPoint("K");
            _pointL = Point.NewPoint("L");
            _pointN = Point.NewPoint("N");
            _pointO = Point.NewPoint("O");

            BuildPath();

            BuildPathNodes();

            BuildPointsList();
        }

       

        public Point GetTestRailRoad()
        {
            return _pointA;
        }

        public Point GetPointByName(String name)
        {
            return _points.Single(x => x.Name == name);

        }

        public PathNode GetPathNodeByPoints(string pathName)
        {
            return _pathNodes[pathName];
        }

        private void BuildPathNodes()
        {
            _pathNodes = new Dictionary<string, PathNode>()
                {
                    {"AB", _pathNodeAb},
                    {"BC",  _pathNodeBc},
                    {"CD",  _pathNodeCd},
                    {"DE",  _pathNodeDe},
                    {"DC",  _pathNodeDc},
                    {"CE",  _pathNodeCe},
                    {"EB",  _pathNodeEb},
                    {"AE",  _pathNodeAe},
                    {"AD",  _pathNodeAd}
                   
                };
        }


        private void BuildPointsList()
        {
            _points = new List<Point>
                {
                    _pointA,
                    _pointB,
                    _pointC,
                    _pointD,
                    _pointE,
                    _pointF,
                    _pointG,
                    _pointH,
                    _pointI,
                    _pointJ,
                    _pointK,
                    _pointL,
                    _pointM,
                    _pointN,
                    _pointO
                };
        }

        private void BuildPath()
        {
            _pathNodeAb = new PathNode(_pointB, 5);
            _pointA.Children.Add(_pathNodeAb);

            _pathNodeBc = new PathNode(_pointC, 4);
            _pointB.Children.Add(_pathNodeBc);

            _pathNodeCd = new PathNode(_pointD, 8);
            _pointC.Children.Add(_pathNodeCd);

            _pathNodeDc = new PathNode(_pointC, 8);
            _pointD.Children.Add(_pathNodeDc);

            _pathNodeCe = new PathNode(_pointE, 2);
            _pointC.Children.Add(_pathNodeCe);

            _pathNodeDe = new PathNode(_pointE, 6);
            _pointD.Children.Add(_pathNodeDe);

            _pathNodeEb = new PathNode(_pointB, 3);
            _pointE.Children.Add(_pathNodeEb);

            _pathNodeAe = new PathNode(_pointE, 7);
            _pointA.Children.Add(_pathNodeAe);

            _pathNodeAd = new PathNode(_pointD, 5);
            _pointA.Children.Add(_pathNodeAd);
        }

       
    }
}
