using System;

namespace Trpaslici
{
    abstract class Trpaslik
    {
        protected static string StartPosition(string[] input)
        {
            string position = String.Empty;

            for (int i = 0; i < input.Length; i++)
            {
                for (int j = 0; j < input[i].Length; j++)
                {
                    if (input[i][j] == 'S')
                    {
                        position = String.Format("{0},{1}", i, j);
                    }
                }
            }

            return position;
        }

        public abstract void Move(string[] line);
    }
}
