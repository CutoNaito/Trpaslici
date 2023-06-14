using System.Collections.Generic;

namespace Trpaslici.Pathfind.Edges
{
    class DownDirectionDetectionStrategy : IEdgeDetectionStrategy
    {
        public void DetectEdges(List<string> nodes, string[] position, string[] input, Dictionary<string, List<string>> graph)
        {
            if (position[0] == (input.Length - 1).ToString())
            {
                return;
            }
            
            int i = int.Parse(position[0]);

            while (input[i][int.Parse(position[1])] != '#' && i < input.Length - 1)
            {
                if (nodes.Contains($"{i},{position[1]}") && !graph[$"{position[0]},{position[1]}"].Contains($"{i},{position[1]}") && i != int.Parse(position[0]))
                {
                    graph[$"{position[0]},{position[1]}"].Add($"{i},{position[1]}");
                }

                i++;
            }
        }
    }
}
