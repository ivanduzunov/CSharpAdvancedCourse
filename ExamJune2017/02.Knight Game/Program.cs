using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Knight_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            //InitializeTeBoard
            char[][] board = new char[n][];
            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                board[i] = input.ToCharArray();
            }

            int counter = 0;

            while (true)
            {
                var toRemoveCoordinates = HorseThatHitsMostEnemiesCoordinates(board);
                if (toRemoveCoordinates[0] == -1)
                {
                    break;
                }
                board[toRemoveCoordinates[0]][toRemoveCoordinates[1]] = '0';
                counter++;
            }
            Console.WriteLine(counter);
        }

        private static int[] HorseThatHitsMostEnemiesCoordinates(char[][] board)
        {
            int bestHits = 0;
            int[] coordinates = new int []
            {
                -1,
                -1
            };
            int rows = board.Length;
            int cols = board[0].Length;

            for (int i = 0; i < board.Length; i++)
            {
                for (int j = 0; j < board[i].Length; j++)
                {
                    if (board[i][j] == 'K')
                    {
                        int currentHits = 0;
                        if (IsInTheBoard(i - 1, j - 2, rows, cols))
                        {
                            if (board[i - 1][j - 2] == 'K')
                            {
                                currentHits++;
                            }
                        }
                        if (IsInTheBoard(i - 2, j - 1, rows, cols))
                        {
                            if (board[i - 2][j - 1] == 'K')
                            {
                                currentHits++;
                            }
                        }
                        if (IsInTheBoard(i - 2, j + 1, rows, cols))
                        {
                            if (board[i - 2][j + 1] == 'K')
                            {
                                currentHits++;
                            }
                        }
                        if (IsInTheBoard(i - 1, j + 2, rows, cols))
                        {
                            if (board[i - 1][j + 2] == 'K')
                            {
                                currentHits++;
                            }
                        }
                        if (IsInTheBoard(i + 1, j + 2, rows, cols))
                        {
                            if (board[i + 1][j + 2] == 'K')
                            {
                                currentHits++;
                            }
                        }
                        if (IsInTheBoard(i + 2, j + 1, rows, cols))
                        {
                            if (board[i + 2][j + 1] == 'K')
                            {
                                currentHits++;
                            }
                        }
                        if (IsInTheBoard(i + 2, j - 1, rows, cols))
                        {
                            if (board[i + 2][j - 1] == 'K')
                            {
                                currentHits++;
                            }
                        }
                        if (IsInTheBoard(i + 1, j - 2, rows, cols))
                        {
                            if (board[i + 1][j - 2] == 'K')
                            {
                                currentHits++;
                            }
                        }
                        if (currentHits > bestHits)
                        {
                            bestHits = currentHits;
                            coordinates[0] = i;
                            coordinates[1] = j;
                        }
                    }

                }
            }
            return coordinates;
        }

        private static bool IsInTheBoard(int row, int col, int boardLength, int rowLenght)
        {
            bool IsRowValid = row >= 0 && row < boardLength;
            bool IsColValid = col >= 0 && col < rowLenght;

            return IsRowValid && IsColValid;
        }
    }
}
