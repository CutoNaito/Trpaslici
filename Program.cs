using System;
using System.IO;
using System.Threading;

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

            Trpaslik levy_trpaslik = new TrpaslikFactory().CreateTrpaslik("Left");
            Trpaslik pravy_trpaslik= new TrpaslikFactory().CreateTrpaslik("Right");
            Trpaslik teleportujici_trpaslik = new TrpaslikFactory().CreateTrpaslik("Teleport");
            Trpaslik pathfinding_trpaslik = new TrpaslikFactory().CreateTrpaslik("Pathfinding");

            levy_trpaslik.Move(input);    
            Thread.Sleep(5000);
            pravy_trpaslik.Move(input);
            Thread.Sleep(5000);
            teleportujici_trpaslik.Move(input);
            Thread.Sleep(5000);
            pathfinding_trpaslik.Move(input);
        }
    }
}
