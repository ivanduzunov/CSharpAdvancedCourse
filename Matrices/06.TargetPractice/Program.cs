using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.TargetPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            var dimentions = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            int n = int.Parse(dimentions[0]);
            int m = int.Parse(dimentions[1]);
            char[,] matrix = new Char[n, m];
            string[][] finalMatrix = new string[n][];
            var snake = Console.ReadLine();
            var shotParameters = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            int impactRow = int.Parse(shotParameters[0]);
            int impactColumn = int.Parse(shotParameters[1]);
            int impactRadius = int.Parse(shotParameters[2]);

            FillTheStairs(matrix, n, m, snake);

            CleanAlgoritm(matrix, n, impactRow, impactColumn, impactRadius);
            Console.WriteLine();
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }


        }

        public static void FillTheStairs(char[,] matrix, int n, int m, string snake)
        {
            Queue<char> snakeQueue = new Queue<char>(snake);
            int counterRow = 1;

            for (int i = matrix.GetLength(0) - 1; i >= 0; i--)
            {
                if (counterRow % 2 != 0)
                {
                    for (int j = matrix.GetLength(1) - 1; j >= 0; j--)
                    {
                        matrix[i, j] = snakeQueue.Dequeue();

                        if (snakeQueue.Count == 0)
                        {
                            snakeQueue = new Queue<char>(snake);
                        }
                    }
                }
                else
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        matrix[i, j] = snakeQueue.Dequeue();

                        if (snakeQueue.Count == 0)
                        {
                            snakeQueue = new Queue<char>(snake);
                        }
                    }
                }
                counterRow++;
            }

        }

        public static void CleanAlgoritm(char[,] matrix, int n, int row, int column, int radius)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (i <= matrix.GetLength(0) / 2)
                    {
                        if ((i == row && (j > matrix.GetLength(1) - (2 * radius + 2) && j < column + radius + 1)) ||
                            ((i > matrix.GetLength(0) - (2 * radius + 2) && (j > matrix.GetLength(1) - ((radius * 2) + i)) && ((i < row + radius + 1 && (j < row + radius + i))))))
                        {
                            matrix[i, j] = '*';
                        }
                    }
                    else
                    {
                        int counter = 1;
                        if (i < row + radius + 1 && ((j <= matrix.GetLength(1) - (radius * 2 - counter * 2))))
                        {
                            matrix[i, j] = '*';
                        }
                        counter++;
                    }

                }
            }
        }
    }
}
