using System;
using System.Collections.Generic;

namespace RailRoadProblem
{
    public class Point
    {
        public string Name { get; set; }

        public List<PathNode> Children { get; set; }

        public static Point NewPoint(String name)
        {
            return new Point()
                {
                    Children = new List<PathNode>(),
                    Name = name
                };
        }
    }
}
