using System.Collections.Generic;

namespace Trpaslici.Pathfind.Edges
{
    public class LeftDirectionDetectionStrategy : IEdgeDetectionStrategy
    {
        public void DetectEdges(List<string> nodes, string[] position, string[] input, Dictionary<string, List<string>> graph)
        {
            if (position[1] == "0")
            {
                return;
            }
            
            int i = int.Parse(position[1]);

            while (input[int.Parse(position[0])][i] != '#' && i > 0)
            {
                if (nodes.Contains($"{position[0]},{i}") && !graph[$"{position[0]},{position[1]}"].Contains($"{position[0]},{i}") && i != int.Parse(position[1]))
                {
                    graph[$"{position[0]},{position[1]}"].Add($"{position[0]},{i}");
                }

                i--;
            }
        }
    }
}
