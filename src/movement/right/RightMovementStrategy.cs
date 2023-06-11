namespace Trpaslici.Movement.Right
{
    class RightMovementStrategy : IMovementStrategy
    {
        public string[] Move(string[] input, string direction, string[] position)
        {
            int row = int.Parse(position[0]);
            int col = int.Parse(position[1]);
            
            if (row + 1 < input.Length && input[row + 1][col] != '#')
            {
                position[0] = $"{row + 1}";
                position[1] = $"{col}";
                direction = "down";
            }
            else if (col + 1 < input[row].Length && input[row][col + 1] != '#')
            {
                position[0] = $"{row}";
                position[1] = $"{col + 1}";
            }
            else if (row - 1 >= 0 && input[row - 1][col] != '#')
            {
                position[0] = $"{row - 1}";
                position[1] = $"{col}";
                direction = "up";
            }
            else
            {
                position[0] = $"{row}";
                position[1] = $"{col - 1}";
                direction = "left";
            }

            return new[] { direction, position[0], position[1] };
        }
    }
}
