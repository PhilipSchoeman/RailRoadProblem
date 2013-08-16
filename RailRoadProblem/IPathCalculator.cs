using System.Collections.Generic;

namespace RailRoadProblem
{
    public interface IPathCalculator
    {
        List<Route> Calculate(IRouteCalculateCommand command);
    }
}