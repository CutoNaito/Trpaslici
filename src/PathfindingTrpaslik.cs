using System;
using System.Linq;
using System.IO;

namespace Trpaslici
{
    class PathfindingTrpaslik : Trpaslik
    {
        string[] visited;

        bool isSafe(string[] input, string[] position)
        {
            int row = int.Parse(position[0]);
            int col = int.Parse(position[1]);

            return (
                row >= 0 && 
                row < input.Length && 
                col >= 0 && 
                col < input[row].Length && 
                input[row][col] != '#' && 
                !visited.Contains($"{row},{col}")
            );
        }

        int FindShortestPath(string[] input, string[] position, string direction, int steps)
        {
            int row = int.Parse(position[0]);
            int col = int.Parse(position[1]);

            if (input[row][col] == 'F')
            {
                return steps;
            }

            visited = visited.Append($"{row},{col}").ToArray();

            int shortestPath = int.MaxValue;

            if (isSafe(input, new[] { $"{row - 1}", $"{col}" }))
            {
                int path = FindShortestPath(input, new[] { $"{row - 1}", $"{col}" }, "up", steps + 1);
                if (path < shortestPath)
                {
                    shortestPath = path;
                }
            }

            if (isSafe(input, new[] { $"{row}", $"{col + 1}" }))
            {
                int path = FindShortestPath(input, new[] { $"{row}", $"{col + 1}" }, "right", steps + 1);
                if (path < shortestPath)
                {
                    shortestPath = path;
                }
            }

            if (isSafe(input, new[] { $"{row + 1}", $"{col}" }))
            {
                int path = FindShortestPath(input, new[] { $"{row + 1}", $"{col}" }, "down", steps + 1);
                if (path < shortestPath)
                {
                    shortestPath = path;
                }
            }

            if (isSafe(input, new[] { $"{row}", $"{col - 1}" }))
            {
                int path = FindShortestPath(input, new[] { $"{row}", $"{col - 1}" }, "left", steps + 1);
                if (path < shortestPath)
                {
                    shortestPath = path;
                }
            }

            visited = visited.Where(x => x != $"{row},{col}").ToArray();

            return shortestPath;
        }

        public override void Move(string[] input)
        {
            string[] position = StartPosition(input).Split(',');

            visited = new string[0];

            int shortestPath = FindShortestPath(input, position, "up", 0);

            Console.WriteLine($"Shortest path: {shortestPath}");
        }
    }
}
