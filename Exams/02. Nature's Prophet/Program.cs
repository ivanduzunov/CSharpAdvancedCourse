using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Nature_s_Prophet
{
    class Program
    {
        static void Main(string[] args)
        {
            var dementions = Console.ReadLine().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            int rows = int.Parse(dementions[0]);
            int columns = int.Parse(dementions[1]);
            int[][] matrix = new int[rows][];
            CreatingTheGarden(rows, columns, matrix);

            var input = Console.ReadLine();

            while (input != "Bloom Bloom Plow")
            {
                var tokens = input.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                var row = int.Parse(tokens[0]);
                var col = int.Parse(tokens[1]);

                for (int i = 0; i < matrix.Length; i++)
                {
                    for (int j = 0; j < matrix[i].Length; j++)
                    {

                        if (j == col)
                        {
                            matrix[i][j] += 1;
                        }
                        else if (i == row)
                        {
                            matrix[i][j] += 1;
                        }
                    }

                }
                input = Console.ReadLine();
            }

            foreach (var item in matrix)
            {
                Console.WriteLine(string.Join(" ", item));
            }


        }

        public static void CreatingTheGarden(int rows, int columns, int[][] matrix)
        {
            for (int i = 0; i < rows; i++)
            {
                matrix[i] = new int[columns];
                for (int j = 0; j < columns; j++)
                {
                    matrix[i][j] = 0;
                }
            }
        }
    }
}
