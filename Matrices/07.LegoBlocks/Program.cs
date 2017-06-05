using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.LegoBlocks
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[][] firstArray = new int[n][];
            int[][] secondArray = new int[n][];
            int[][] finalArray = new int[n][];
            FillJaggetArray(firstArray, n);
            FillJaggetArray(secondArray, n);
            ReverseJaggetArrayElements(secondArray);
            UniteJaggedArraysElements(firstArray, secondArray, finalArray, n);

            bool isMatrix = true;

            for (int i = 1; i < finalArray.Length; i++)
            {
                if (finalArray[i].Length != finalArray[0].Length)
                {
                    isMatrix = false;
                    break;
                }
            }

            if (isMatrix == true)
            {
                for (int i = 0; i < finalArray.Length; i++)
                {
                    Console.WriteLine($"[{string.Join(", ", finalArray[i])}]");
                }
            }
            else 
            {
                int counter = 0;

                for (int i = 0; i < finalArray.Length; i++)
                {
                    counter += finalArray[i].Length;
                }

                Console.WriteLine($"The total number of cells is: {counter}");
            }



        }

        public static void FillJaggetArray(int[][] jagged, int n)
        {


            for (int i = 0; i < n; i++)
            {
                var row = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();
                jagged[i] = new int[row.Length];
                for (int j = 0; j < row.Count(); j++)
                {
                    jagged[i][j] = row[j];
                }
            }
        }

        public static void ReverseJaggetArrayElements(int[][] jagged)
        {
            foreach (var row in jagged)
            {
                Array.Reverse(row);
            }
        }

        public static void UniteJaggedArraysElements(int[][] firstJagged, int[][] secondJagget, int[][] finalJagged, int n)
        {
            for (int i = 0; i < n; i++)
            {
                finalJagged[i] = new int[firstJagged[i].Length + secondJagget[i].Length];
                firstJagged[i].CopyTo(finalJagged[i], 0);
                secondJagget[i].CopyTo(finalJagged[i], firstJagged[i].Length);
            }
        }
    }
}
