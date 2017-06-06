using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.Crossfire
{
    public class Program
    {
        static string[][] matrix;

        public static void Main(string[] args)
        {
            // Judge: 70/100

            var input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int row = input[0];
            int col = input[1];
            int[][] matrixInts = new int[row][];
            matrix = new string[row][];
            FillTheMatrix(matrixInts, row, col);
            ParseTheMatrix(matrixInts, matrix);

            var detonationRow = Console.ReadLine().Split(' ').ToArray();

            while (!detonationRow[0].Equals("Nuke"))
            {
                int n = int.Parse(detonationRow[0]);
                int m = int.Parse(detonationRow[1]);
                int r = int.Parse(detonationRow[2]);


                Detonation(matrix, n, m, r);
                CleanTheMatrix(matrix);



                detonationRow = Console.ReadLine().Split(' ').ToArray();
            }

            foreach (var element in matrix)
            {
                if (element.Length == 0)
                {
                    continue;
                }
                else
                {
                    Console.WriteLine(string.Join(" ", element));
                }

            }
        }

        public static void FillTheMatrix(int[][] matrix, int row, int col)
        {
            int counter = 0;

            for (int i = 0; i < row; i++)
            {
                matrix[i] = new int[col];
                for (int j = 0; j < col; j++)
                {
                    counter++;
                    matrix[i][j] = counter;
                }
            }
        }

        public static void ParseTheMatrix(int[][] matrInts, string[][] matrStrings)
        {
            for (int i = 0; i < matrInts.Length; i++)
            {
                matrStrings[i] = new string[matrInts[i].Length];

                for (int j = 0; j < matrInts[i].Length; j++)
                {
                    matrStrings[i][j] = matrInts[i][j].ToString();
                }
            }
        }

        public static void Detonation(string[][] jagged, int row, int col, int radius)
        {

            for (int i = col - radius; i <= col + radius; i++)
            {
                if (IsInMatrix(row, i))
                {
                    matrix[row][i] = " ";
                }
            }
            for (int i = row - radius; i <= row + radius; i++)
            {
                if (IsInMatrix(i, col))
                {
                    matrix[i][col] = " ";
                }
            }
        }

        static bool IsInMatrix(int row, int col)
        {


            if (row < 0 || row >= matrix.Length)
            {
                return false;
            }
            else
            {
                if (col < 0 || col >= matrix[row].Length)
                {
                    return false;
                }
            }
            return true;
        }

        public static void CleanTheMatrix(string[][] jagged)
        {
            for (int i = 0; i < jagged.Length; i++)
            {
                Queue<string> elements = new Queue<string>();

                for (int j = 0; j < jagged[i].Length; j++)
                {
                    if (jagged[i][j] != " ")
                    {
                        elements.Enqueue(jagged[i][j]);
                    }
                }

                jagged[i] = new string[elements.Count];

                for (int j = 0; j < jagged[i].Length; j++)
                {
                    jagged[i][j] = elements.Dequeue();
                }
            }
        }
    }
}
