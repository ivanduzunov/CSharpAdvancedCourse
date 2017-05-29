using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.BasicStackOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(' ');
            var integers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var stack = new Stack<int>();

            int n = int.Parse(input[0]);  //amount of elements to push onto the stack 
            int s = int.Parse(input[1]);  //the amount of elements to pop from the stack
            int x = int.Parse(input[2]);  //element that you should check whether is present in the stack

            for (int i = 0; i < n; i++)
            {
                stack.Push(integers[i]);
            }
            for (int i = 0; i < s; i++)
            {
                stack.Pop();
            }

            if (stack.Contains(x))
            {
                Console.WriteLine("true");
            }
            else
            {
                if (stack.Count>0)
                {
                    Console.WriteLine(stack.Min());
                }
                else
                {
                    Console.WriteLine(0);
                }
            }
        }
    }
}
