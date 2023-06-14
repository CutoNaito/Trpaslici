using System;
using System.Collections.Generic;
using System.Linq;

namespace Trpaslici.Pathfind
{
    class CenterNodePathfinding : IPathfindingStrategy
    {
        public void DetectEdges(string[] input, string[] position, List<string> graph)
        {
            int row = int.Parse(position[0]);
            int col = int.Parse(position[1]);

            char[] verticles = new char[] {
                input[row - 1][col],
                input[row][col + 1],
                input[row + 1][col],
                input[row][col - 1]
            };

            if ((verticles.Count(x => x == ' ') >= 2) || verticles.Contains('F') || verticles.Contains('S'))
            {
                Console.WriteLine($"{row},{col}");
                graph.Add($"{row},{col}");
            }
        }
    }
}
