using System.Collections.Generic;

namespace Trpaslici.Pathfind.Edges
{
    public interface IEdgeDetectionStrategy
    {
        void DetectEdges(List<string> nodes, string[] position, string[] input, Dictionary<string, List<string>> graph);
    }
}
