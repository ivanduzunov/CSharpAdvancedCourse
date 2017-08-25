using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.SquaresInMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            var dimentions = Console.ReadLine().Split(' ');
            int rows = int.Parse(dimentions[0]);
            int columns = int.Parse(dimentions[1]);
            string[,] matrix = new string[rows, columns];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                var input = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = input[j];
                }
            }

            int equalSells = 0;

            for (int i = 0; i < matrix.GetLength(0) - 1; i++)
            {
                for (int j = 0; j < matrix.GetLength(1) - 1; j++)
                {
                    if (matrix[i, j].Equals(matrix[i, j + 1])
                        && matrix[i, j].Equals(matrix[i + 1, j])
                        && matrix[i, j].Equals(matrix[i + 1, j + 1]))
                    {
                        equalSells++;
                    }
                }
            }
            Console.WriteLine(equalSells);
        }
    }
}
