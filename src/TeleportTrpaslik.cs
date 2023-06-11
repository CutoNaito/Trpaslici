using System;
using System.Threading;
using System.Diagnostics;
using System.IO;

namespace Trpaslici
{
    class TeleportTrpaslik : Trpaslik
    {
        public override void Move(string[] input)
        {
            string position = StartPosition(input);
            
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            Thread.Sleep(new Random().Next(1, 120000)); // the maximum time of the teleportation is 2 minutes
            
            position = EndPostition(input);
            stopwatch.Stop();

            File.AppendAllText("out/teleportation_output.txt", $"Teleportation time: {stopwatch.ElapsedMilliseconds} ms");
        }
    }
}
