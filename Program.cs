using System;
using System.IO;

namespace Trpaslici
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = File.ReadAllLines("Maze.dat");
            
            foreach (string line in input)
            {
                Console.WriteLine(line);
            };

            Trpaslik levy_trpaslik = new TrpaslikFactory().CreateTrpaslik("Pathfinding");
            
            levy_trpaslik.Move(input);
        }
    }
}
