using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.DiagonalDifference
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            decimal[,] matrix = new decimal[n, n];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                var input = Console.ReadLine().Split(new string[]{" "}, StringSplitOptions.RemoveEmptyEntries).Select(decimal.Parse).ToArray();

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = input[j];
                }
            }

            decimal firstSum = 0;
            decimal secondSum = 0;
            int firstIndex = 0;
            int secondIndex = n - 1;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                firstSum += matrix[i, firstIndex];
                secondSum += matrix[i, secondIndex];
                firstIndex++;
                secondIndex--;
            }

            Console.WriteLine($"{(int)(Math.Max(firstSum, secondSum) - Math.Min(firstSum, secondSum))}");

        }
    }
}
