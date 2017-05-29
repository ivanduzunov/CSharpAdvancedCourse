using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.ReverseNumbers
{
    class Program
    {
        static void Main(string[] args)
        {

            var firstLine = Console.ReadLine();
            int[] input = firstLine.Split(' ').Select(int.Parse).ToArray();
            var stack = new Stack<int>();

            for (int i = 0; i < input.Length; i++)
            {
                stack.Push(input[i]);
            }
            for (int i = 0; i < input.Length; i++)
            {
                if (stack.Count>0)
                {
                    Console.Write(stack.Pop() + " ");

                }
                else
                {
                    Console.WriteLine(0);
                }
            }
            Console.WriteLine();
        }
    }
}
