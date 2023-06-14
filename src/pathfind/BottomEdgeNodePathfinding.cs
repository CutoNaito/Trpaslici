using System;
using System.Collections.Generic;
using System.Linq;

namespace Trpaslici.Pathfind
{
    class BottomEdgeNodePathfinding : IPathfindingStrategy
    {
        public void DetectEdges(string[] input, string[] position, List<string> graph)
        {
            Console.WriteLine(position[0]);
            Console.WriteLine(position[1]);
            int row = int.Parse(position[0]);
            int col = int.Parse(position[1]);

            char[] verticles = new char[] {
                input[row - 1][col],
                input[row][col - 1],
                input[row][col + 1]
            };

            if ((verticles.Count(x => x == ' ') >= 2) || verticles.Contains('F') || verticles.Contains('S'))
            {
                graph.Add($"{row},{col}");
            }
        }
    }
}
