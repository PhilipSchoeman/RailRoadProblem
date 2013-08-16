namespace RailRoadProblem
{
    /// <summary>
    /// Object that contains the instructions for executing a path finding command.
    /// </summary>
    public class RouteCalculateCommand : IRouteCalculateCommand
    {
        public Point Route { get; set; }

        public Point StartPoint { get; set; }

        public Point EndPoint { get; set; }

        public int ForceLoopingCount { get; set; }

        public bool ForceLooping { get { return ForceLoopingCount != 0; } }
    }
}
