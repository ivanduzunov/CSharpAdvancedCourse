using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.RubiksMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            var dimentions = Console.ReadLine().Split(' ');
            int r = int.Parse(dimentions[0]);
            int c = int.Parse(dimentions[1]);
            int[,] originalMatrix = new int[r, c];
            int counter = 0;

            for (int i = 0; i < originalMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < originalMatrix.GetLength(1); j++)
                {
                    counter++;
                    originalMatrix[i, j] = counter;
                }
            }

            int n = int.Parse(Console.ReadLine());

            int[,] matrix = new int[r, c];
            Array.Copy(originalMatrix, matrix, originalMatrix.Length);

            for (int i = 0; i < n; i++)
            {
                var command = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

                int index = int.Parse(command[0]);
                var direction = command[1];
                int rolls = int.Parse(command[2]);

                if (direction.Equals("up"))
                {
                    Queue<int> queue = new Queue<int>();

                    for (int j = 0; j < matrix.GetLength(0); j++)
                    {
                        queue.Enqueue(matrix[j, index]);
                    }
                    for (int j = 0; j < rolls; j++)
                    {
                        var num = queue.Dequeue();
                        queue.Enqueue(num);
                    }
                    for (int j = 0; j < matrix.GetLength(0); j++)
                    {
                        matrix[j, index] = queue.Dequeue();
                    }
                }
                else if (direction.Equals("down"))
                {
                    Queue<int> queue = new Queue<int>();

                    for (int j = matrix.GetLength(0) - 1; j >= 0; j--)
                    {
                        queue.Enqueue(matrix[j, index]);
                    }
                    for (int j = 0; j < rolls % matrix.Length; j++)
                    {
                        var num = queue.Dequeue();
                        queue.Enqueue(num);
                    }
                    for (int j = matrix.GetLength(0) - 1; j >= 0; j--)
                    {
                        matrix[j, index] = queue.Dequeue();
                    }
                }
                else if (direction.Equals("left"))
                {
                    Queue<int> queue = new Queue<int>();

                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        queue.Enqueue(matrix[index, j]);
                    }
                    for (int j = 0; j < rolls % matrix.Length; j++)
                    {
                        var num = queue.Dequeue();
                        queue.Enqueue(num);
                    }
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        matrix[index, j] = queue.Dequeue();
                    }
                }
                else if (direction.Equals("right"))
                {
                    Queue<int> queue = new Queue<int>();

                    for (int j = matrix.GetLength(1) - 1; j >= 0; j--)
                    {
                        queue.Enqueue(matrix[index, j]);
                    }
                    for (int j = 0; j < rolls; j++)
                    {
                        var num = queue.Dequeue();
                        queue.Enqueue(num);
                    }
                    for (int j = matrix.GetLength(1) - 1; j >= 0; j--)
                    {
                        matrix[index, j] = queue.Dequeue();
                    }
                }
            }

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    int oldRow = 0;
                    int oldCol = 0;
                    int newRow = 0;
                    int newCol = 0;

                    if (matrix[i, j] != originalMatrix[i, j])
                    {

                        int firstNum = 0;
                        int secondNum = 0;

                        newRow = i;
                        newCol = j;

                        for (int k = 0; k < matrix.GetLength(0); k++)
                        {
                            for (int l = 0; l < matrix.GetLength(1); l++)
                            {
                                if (matrix[k, l] == originalMatrix[i, j])
                                {
                                    oldRow = k;
                                    oldCol = l;
                                    firstNum = matrix[k, l];
                                    secondNum = matrix[i, j];
                                    matrix[i, j] = firstNum;
                                    matrix[k, l] = secondNum;

                                    Console.WriteLine($"Swap ({newRow}, {newCol}) with ({oldRow}, {oldCol})");
                                }
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("No swap required");
                    }
                }
            }

        }

    }
}
