using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.RadioactiveBunnies
{
    class Program
    {
        static void Main(string[] args)
        {
            var dimentions = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            int n = int.Parse(dimentions[0]);
            int m = int.Parse(dimentions[1]);
            char[][] liar = new char[n][];
            FillTheLiar(liar);
            var moves = Console.ReadLine().ToCharArray();
            List<int> cordinates = FindThePlayer(liar);
            int plRow = cordinates[0];
            int plCol = cordinates[1];
            bool win = false;
            bool killed = false;


            for (int i = 0; i < moves.Length; i++)
            {
                char move = moves[i];

                switch (move)
                {
                    case 'L':
                        if (plCol == 0)
                        {
                            win = true;
                            liar[plRow][plCol] = '.';
                        }
                        else
                        {
                            if (liar[plRow][plCol - 1] == 'B')
                            {
                                killed = true;
                                liar[plRow][plCol] = '.';
                                plCol -= 1;
                            }
                            else
                            {
                                liar[plRow][plCol - 1] = liar[plRow][plCol];
                                liar[plRow][plCol] = '.';
                                plCol -= 1;
                            }
                        }
                        break;
                    case 'R':
                        if (plCol == liar[0].Length - 1)
                        {
                            win = true;
                            liar[plRow][plCol] = '.';
                        }
                        else
                        {
                            if (liar[plRow][plCol + 1] == 'B')
                            {
                                killed = true;
                                liar[plRow][plCol] = '.';
                                plCol += 1;
                            }
                            else
                            {
                                liar[plRow][plCol + 1] = liar[plRow][plCol];
                                liar[plRow][plCol] = '.';
                                plCol += 1;
                            }
                        }
                        break;
                    case 'U':
                        if (plRow == 0)
                        {
                            win = true;
                            liar[plRow][plCol] = '.';
                        }
                        else
                        {
                            if (liar[plRow - 1][plCol] == 'B')
                            {
                                killed = true;
                                liar[plRow][plCol] = '.';
                                plRow -= 1;
                            }
                            else
                            {
                                liar[plRow - 1][plCol] = liar[plRow][plCol];
                                liar[plRow][plCol] = '.';
                                plRow -= 1;
                            }
                        }
                        break;
                    case 'D':
                        if (plRow == liar.Length - 1)
                        {
                            win = true;
                            liar[plRow][plCol] = '.';
                        }
                        else
                        {
                            if (liar[plRow + 1][plCol] == 'B')
                            {
                                killed = true;
                                liar[plRow][plCol] = '.';
                                plRow += 1;

                            }
                            else
                            {
                                liar[plRow + 1][plCol] = liar[plRow][plCol];
                                liar[plRow][plCol] = '.';
                                plRow += 1;
                            }
                        }
                        break;
                }
                

                SpreadBunnies(liar, killed);
                if (killed)
                {
                    break;
                }
                if (win)
                {
                    break;
                }

            }


            if (win)
            {
                for (int i = 0; i < liar.Length; i++)
                {
                    Console.WriteLine(string.Join("", liar[i]));
                }
                Console.WriteLine($"won: {plRow} {plCol}");
            }
            else
            {
                for (int i = 0; i < liar.Length; i++)
                {
                    Console.WriteLine(string.Join("", liar[i]));
                }
                Console.WriteLine($"dead: {plRow} {plCol}");
            }

        }

        public static void FillTheLiar(char[][] matrix)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                var input = Console.ReadLine().ToCharArray();
                matrix[i] = new char[input.Length];

                for (int j = 0; j < matrix[i].Length; j++)
                {
                    matrix[i][j] = input[j];
                }
            }
        }

        public static List<int> FindThePlayer(char[][] matrix)
        {
            List<int> result = new List<int>();

            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    if (matrix[i][j] == 'P')
                    {
                        int row = i;
                        int col = j;
                        result.Add(i); result.Add(j);

                    }
                }
            }
            return result;
        }

        public static void SpreadBunnies(char[][] matrix, bool kill)
        {
            
            List<int> rows = new List<int>();
            List<int> cols = new List<int>();

            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    if (matrix[i][j] == 'B')
                    {
                        rows.Add(i);
                        cols.Add(j);
                    }
                }
            }

            for (int i = 0; i < rows.Count; i++)
            {
                int row = rows[i];
                int col = cols[i];

                if (col > 0)
                {
                    
                    if (matrix[row][col - 1] == 'P')
                    {

                        kill = true;
                    }
                    else
                    {
                        matrix[row][col - 1] = 'B';
                    }
                }
                if (col < matrix[row].Length - 1)
                {
                    if (matrix[row][col + 1] == 'P')
                    {
                        kill = true;

                    }
                    else
                    {
                        matrix[row][col + 1] = 'B';
                    }
                }
                if (row > 0)
                {
                    if (matrix[row - 1][col] == 'P')
                    {
                        kill = true;

                    }
                    else
                    {
                        matrix[row - 1][col] = 'B';
                    }
                }

                if (row < matrix.Length - 1)
                {
                    if (matrix[row + 1][col] == 'P')
                    {
                        kill = true;

                    }
                    else
                    {
                        matrix[row + 1][col] = 'B';
                        
                    }
                }
               
                
            }

        }
    }
}
