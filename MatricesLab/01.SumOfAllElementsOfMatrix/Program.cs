using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.SumOfAllElementsOfMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(',');
            int rows = int.Parse(input[0].Trim());
            int columns = int.Parse(input[1].Trim());

            int[,] matrix = new int[rows, columns];

            int sum = 0;

            for (int i = 0; i < rows; i++)
            {
                var numbers = Console.ReadLine().Split(',');
                for (int j = 0; j < columns; j++)
                {
                    matrix[i, j] = int.Parse(numbers[j].Trim());
                    sum += matrix[i, j];
                }
            }

            Console.WriteLine(matrix.GetLength(0));
            Console.WriteLine(matrix.GetLength(1));
            Console.WriteLine(sum);

        }
    }
}
