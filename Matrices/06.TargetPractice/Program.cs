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

            FallingDown(matrix);

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j]);
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

        public static void CleanAlgoritm(char[,] matrix, int n, int therow, int column, int radius)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    bool isWithinRange = Math.Sqrt(Math.Pow(Math.Abs(therow - row), 2)
                                                   + Math.Pow(Math.Abs(column - col), 2)) <= radius;
                    if (isWithinRange)
                        matrix[row, col] = ' ';
                }

        }

        public static void FallingDown(char[,] matrix)
        {
            for (int i = matrix.GetLength(0) - 1; i >= 0; i--)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == ' ')
                    {
                        for (int k = i - 1; k >= 0; k--)
                        {
                            if (matrix[k, j] != ' ')
                            {
                                matrix[i, j] = matrix[k, j];
                                matrix[k, j] = ' ';
                                break;
                            }
                        }
                    }
                }
            }
        }
    }
}
