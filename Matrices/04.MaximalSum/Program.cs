using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.MaximalSum
{
    class Program
    {
        static void Main(string[] args)
        {
            var dimentions = Console.ReadLine().Split(' ');
            int rows = int.Parse(dimentions[0]);
            int columns = int.Parse(dimentions[1]);
            int[,] matrix = new int[rows, columns];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                var input = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = int.Parse(input[j]);
                }
            }

            int biggestSum = 0;
            int[,] resultMatrix = new int[3, 3];

            for (int i = 2; i < matrix.GetLength(0); i++)
            {
                int currentSum = 0;

                for (int j = 2; j < matrix.GetLength(1); j++)
                {
                    currentSum = matrix[i - 2, j - 2] + matrix[i - 2, j - 1] + matrix[i - 2, j] +
                                 matrix[i - 1, j - 2] + matrix[i - 1, j - 1] + matrix[i - 1, j] +
                                 matrix[i, j - 2] + matrix[i, j - 1] + matrix[i, j];

                    if (currentSum > biggestSum)
                    {
                        biggestSum = currentSum;

                        Array.Clear(resultMatrix, 0, resultMatrix.Length);

                        resultMatrix[0, 0] = matrix[i - 2, j - 2];
                        resultMatrix[0, 1] = matrix[i - 2, j - 1];
                        resultMatrix[0, 2] = matrix[i - 2, j];
                        resultMatrix[1, 0] = matrix[i - 1, j - 2];
                        resultMatrix[1, 1] = matrix[i - 1, j - 1];
                        resultMatrix[1, 2] = matrix[i - 1, j];
                        resultMatrix[2, 0] = matrix[i, j - 2];
                        resultMatrix[2, 1] = matrix[i, j - 1];
                        resultMatrix[2, 2] = matrix[i, j];
                    }
                }
            }

            Console.WriteLine($"Sum = {biggestSum}");

            for (int j = 0; j < resultMatrix.GetLength(0); j++)
            {
                for (int i = 0; i < resultMatrix.GetLength(1); i++)
                {
                    Console.Write(resultMatrix[j, i] + " ");
                }
                Console.WriteLine();
            }

        }
    }
}
