using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.SquareWithMaximumSum
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(',');
            int rows = int.Parse(input[0].Trim());
            int columns = int.Parse(input[1].Trim());

            int[][] matrix = new int[rows][];

            for (int rowIndex = 0; rowIndex < rows; rowIndex++)
            {
                matrix[rowIndex] = new int[columns];

                var arr = Console.ReadLine().Split(',').ToArray();

                for (int i = 0; i < columns; i++)
                {
                    matrix[rowIndex][i] = int.Parse(arr[i].Trim());
                }
            }

            int biggestSum = 0;

            List<int> resultList = new List<int>();

            for (int rowIndex = 0; rowIndex < matrix.Length - 1; rowIndex++)
            {
                for (int colIndex = 0; colIndex < matrix[rowIndex].Length - 1; colIndex++)
                {
                    var newSum = matrix[rowIndex][colIndex] +
                                 matrix[rowIndex + 1][colIndex] +
                                 matrix[rowIndex][colIndex + 1] +
                                 matrix[rowIndex + 1][colIndex + 1];
                    if (newSum > biggestSum)
                    {
                        biggestSum = newSum;
                        resultList.Clear();
                        resultList.Add(matrix[rowIndex][colIndex]);
                        resultList.Add(matrix[rowIndex][colIndex + 1]); resultList.Add(matrix[rowIndex + 1][colIndex]); resultList.Add(matrix[rowIndex + 1][colIndex + 1]);
                    }
                }
            }

            int count = 0;

            for (int i = 0; i < resultList.Count; i++)
            {
                if (i == 2)
                {
                    Console.WriteLine();
                }
                Console.Write(resultList[i] + " ");
            }
            Console.WriteLine();

            Console.WriteLine(biggestSum);
        }
    }
}
