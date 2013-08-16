namespace RailRoadProblem
{
    public interface IRouteCalculateCommand
    {
        Point Route { get; set; }

        Point StartPoint { get; set; }

        Point EndPoint { get; set; }

        int ForceLoopingCount { get; set; }

        bool ForceLooping { get; }
    }
}