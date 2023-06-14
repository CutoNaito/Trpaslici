using System;
using System.Linq;
using System.IO;
using System.Threading;
using System.Collections.Generic;
using Trpaslici.Pathfind;
using Trpaslici.Pathfind.Edges;

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


        public Dictionary<string, List<string>> GenerateGraph(string[] input)
        {
            List<string> nodes = new List<string>();
            Dictionary<string, List<string>> graph = new Dictionary<string, List<string>>();

            Dictionary<string, IPathfindingStrategy> strategies = new Dictionary<string, IPathfindingStrategy>
            {
                { "left", new LeftEdgeNodePathfinding() },
                { "right", new RightEdgeNodePathfinding() },
                { "top", new TopEdgeNodePathfinding() },
                { "bottom", new BottomEdgeNodePathfinding() },
                { "center", new CenterNodePathfinding() }
            };

            Dictionary<string, IEdgeDetectionStrategy> edgeDetectionStrategies = new Dictionary<string, IEdgeDetectionStrategy>
            {
                { "left", new LeftDirectionDetectionStrategy() },
                { "right", new RightDirectionDetectionStrategy() },
                { "top", new UpDirectionDetectionStrategy() },
                { "bottom", new DownDirectionDetectionStrategy() },
            };
            
            for (int i = 0; i < input.Length; i++)
            {
                for (int j = 0; j < input[i].Length; j++)
                {
                    if (input[i][j] == 'S')
                    {
                        nodes.Add($"{i},{j}");
                    }
                    else if (input[i][j] == 'F')
                    {
                        nodes.Add($"{i},{j}");
                    }
                    else if (input[i][j] == ' ')
                    {
                        if ((i == 0 && j == 0) || (i == 0 && j == input[i].Length - 1) || (i == input.Length - 1 && j == 0) || (i == input.Length - 1 && j == input[i].Length - 1)) // corners
                        {
                            continue;
                        }
                        else if (i == 0)
                        {
                            strategies["top"].DetectEdges(input, new[] {$"{i}",$"{j}"}, nodes);
                        }
                        else if (i == input.Length - 1)
                        {
                            strategies["bottom"].DetectEdges(input, new[] {$"{i}", $"{j}"}, nodes);
                        }
                        else if (j == 0)
                        {
                            strategies["left"].DetectEdges(input, new[] {$"{i}", $"{j}"}, nodes);
                        }
                        else if (j == input[i].Length - 1)
                        {
                            strategies["right"].DetectEdges(input, new[] {$"{i}", $"{j}"}, nodes);
                        }
                        else
                        {
                            strategies["center"].DetectEdges(input, new[] {$"{i}", $"{j}"}, nodes);
                        }
                    }
                }
            }

            foreach (string node in nodes)
            {
                graph.Add(node, new List<string>());

                foreach (string direction in edgeDetectionStrategies.Keys)
                {
                    edgeDetectionStrategies[direction].DetectEdges(nodes, node.Split(','), input, graph);
                }
            }

            return graph;
        }

        public override void Move(string[] input)
        {
            Dictionary<string, List<string>> graph = GenerateGraph(input);

            foreach (string node in graph.Keys)
            {
                Console.WriteLine($"{node}: {string.Join(", ", graph[node])}");
            }
        }
    }
}
