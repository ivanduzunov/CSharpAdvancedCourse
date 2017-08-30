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

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (board[i][j] == 'K')
                    {
                        
                    }
                }
            }
        }
    }
}
