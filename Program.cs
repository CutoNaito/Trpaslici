using System;
using System.IO;

namespace Trpaslici
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = File.ReadAllLines("Maze.dat");

            Trpaslik levy_trpaslik = new TrpaslikFactory().CreateTrpaslik("Left");
            
            levy_trpaslik.Move(input);
        }
    }
}
