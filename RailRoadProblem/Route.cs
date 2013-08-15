using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RailRoadProblem
{
    public class Route
    {
        public List<PathNode> PathNodes;

        public Route()
        {
            PathNodes = new List<PathNode>();
        }

        public Route(IEnumerable<PathNode> pathNodes)
        {
            PathNodes = new List<PathNode>( pathNodes);
        }
    }
}
