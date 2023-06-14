using System.Collections.Generic;

namespace Trpaslici.Pathfind
{
    interface IPathfindingStrategy
    {
        void DetectEdges(string[] input, string[] position, List<string> graph);
    }
}
