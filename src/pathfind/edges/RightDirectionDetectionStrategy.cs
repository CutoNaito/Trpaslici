using System.Collections.Generic;

namespace Trpaslici.Pathfind.Edges
{
    class RightDirectionDetectionStrategy : IEdgeDetectionStrategy
    {
        public void DetectEdges(List<string> nodes, string[] position, string[] input, Dictionary<string, List<string>> graph)
        {
            if (position[1] == (input[int.Parse(position[0])].Length - 1).ToString())
            {
                return;
            }
            
            int i = int.Parse(position[1]);

            while (input[int.Parse(position[0])][i] != '#' && i < input[int.Parse(position[0])].Length - 1)
            {
                if (nodes.Contains($"{position[0]},{i}") && !graph[$"{position[0]},{position[1]}"].Contains($"{position[0]},{i}") && i != int.Parse(position[1]))
                {
                    graph[$"{position[0]},{position[1]}"].Add($"{position[0]},{i}");
                }

                i++;
            }
        }
    }
}
