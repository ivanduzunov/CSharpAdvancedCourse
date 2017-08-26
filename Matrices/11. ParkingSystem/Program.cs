using System;
using System.Linq;

namespace _11.ParkingSystem
{            //70/100
    public class Program
    {
        public static void Main(string[] args)

        {
            var dementions = Console.ReadLine().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            var parkingLot = GenerateTheMatrix(dementions[0], dementions[1]);

            var input = string.Empty;

            while ((input = Console.ReadLine()) != "stop")
            {
                var tokens = input.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();
                int entryRow = tokens[0];
                int desireRow = tokens[1];
                int desireCol = tokens[2];

                if (DesiredRowIsFull(parkingLot, desireRow))
                {
                    Console.WriteLine($"Row {desireRow} full");
                }
                else
                {
                    Park(parkingLot, entryRow, desireRow, desireCol);
                }

            }
        }

        static int[][] GenerateTheMatrix(int rows, int cols)
        {
            int[][] matrix = new int[rows][];
            for (int i = 0; i < rows; i++)
            {
                matrix[i] = new int[cols];
            }
            return matrix;
        }

        static bool DesiredRowIsFull(int[][] matrix, int row)
        {
            int counter = 1;

            for (int i = 1; i < matrix[row].Length; i++)
            {
                if (matrix[row][i] == 1)
                {
                    counter++;
                }
            }
            if (counter == matrix[row].Length)
            {
                return true;
            }
            return false;
        }

        static void Park(int[][] matrix, int enterRow, int row, int col)
        {
            int counter = Math.Abs(enterRow - row) + 1;

            if (matrix[row][col] == 0)
            {
                counter += col;
                matrix[row][col] = 1;
            }
            else
            {
                int[] freeSpotCoordinates = NearestSpotCoordinates(matrix, row, col);
                int nearestCol = freeSpotCoordinates[1];

                counter += nearestCol;
                matrix[row][nearestCol] = 1;
            }

            Console.WriteLine(counter);

        }

        static int[] NearestSpotCoordinates(int[][] matrix, int row, int col)
        {
            int leftCounter = 0;
            int rightCounter = 0;
            int nearestLeftCol = 0;
            int nearestRightCol = 0;
            int finalCol = 0;

            //searching to the left
            for (int i = col - 1; i > 0; i--)
            {
                if (matrix[row][i] == 0)
                {
                    nearestLeftCol = i;
                    break;
                }
            }
            //searching to the right
            for (int i = col + 1; i < matrix[row].Length; i++)
            {
                if (matrix[row][i] == 0)
                {
                    nearestRightCol = i;
                    break;
                }
            }

            leftCounter = Math.Abs(nearestLeftCol - col);
            rightCounter = Math.Abs(nearestRightCol - col);

            if (nearestLeftCol == 0)
            {
                finalCol = nearestRightCol;
            }
            else if (nearestRightCol == 0)
            {
                finalCol = nearestLeftCol;
            }
            else if (leftCounter == rightCounter)
            {
                finalCol = nearestLeftCol;
            }
            else if (rightCounter < leftCounter)
            {
                finalCol = nearestLeftCol;
            }
            else
            {
                finalCol = nearestLeftCol;
            }

            int[] coordinates = new[] { row, finalCol };
            return coordinates;
        }
    }
}
