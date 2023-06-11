namespace Trpaslici.Movement.Left
{
    public class DownMovementStrategy : IMovementStrategy
    {
        public string[] Move(string[] input, string direction, string[] position)
        {
            int row = int.Parse(position[0]);
            int col = int.Parse(position[1]);

            if (col + 1 < input[row].Length && input[row][col + 1] != '#')
            {
                position[0] = $"{row}";
                position[1] = $"{col + 1}";
                direction = "right";
            }
            else if (row + 1 < input.Length && input[row + 1][col] != '#')
            {
                position[0] = $"{row + 1}";
                position[1] = $"{col}";
            }
            else if (col - 1 >= 0 && input[row][col - 1] != '#')
            {
                position[0] = $"{row}";
                position[1] = $"{col - 1}";
                direction = "left";
            }
            else
            {
                position[0] = $"{row - 1}";
                position[1] = $"{col}";
                direction = "up";
            }

            return new[] { direction, position[0], position[1] };
        }
    }
}
