using System;
using System.Collections.Generic;
using System.IO;

namespace Trpaslici
{
    class MazeSolving
    {
        public void Start()
        {
            string[] maze = File.ReadAllLines("Maze.dat");
            
            foreach (string line in maze)
            {
                Console.WriteLine(line);
            }

            Trpaslik trpaslik = new TrpaslikFactory().CreateTrpaslik("Pathfinding");
            trpaslik.Move(maze);
        }
    }
}
