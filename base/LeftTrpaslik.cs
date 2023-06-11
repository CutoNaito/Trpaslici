using System;
using System.IO;
using System.Collections.Generic;
using Trpaslici.Movement;
using Trpaslici.Movement.Left;

namespace Trpaslici
{
    class LeftTrpaslik : Trpaslik
    {
        public override void Move(string[] input)
        {
            string direction = "down";
            char positionValue = ' ';
            string[] position = StartPosition(input).Split(',');
            int row = int.Parse(position[0]);
            int col = int.Parse(position[1]);

            Dictionary<string, IMovementStrategy> strategies = new Dictionary<string, IMovementStrategy>
            {
                { "down", new DownMovementStrategy() },
                { "right", new RightMovementStrategy() },
                { "up", new UpMovementStrategy() },
                { "left", new LeftMovementStrategy() }
            };
            
            while (positionValue != 'F')
            {
                IMovementStrategy strategy = strategies[direction];
                string[] newPosition = strategy.Move(input, direction, position);
                direction = newPosition[0];
                position[0] = newPosition[1];
                position[1] = newPosition[2];

                row = int.Parse(position[0]);
                col = int.Parse(position[1]);
                positionValue = input[row][col];

                File.AppendAllText("output.txt", $"{position[0]}, {position[1]}\n");
            }
        }
    }
}
