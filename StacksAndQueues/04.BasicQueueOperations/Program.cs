using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.BasicQueueOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(' ');
            var integers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var queue = new Queue<int>();

            int n = int.Parse(input[0]);  //amount of elements to add onto the queue 
            int s = int.Parse(input[1]);  //the amount of elements to dequeue from the queue
            int x = int.Parse(input[2]);  //element that you should check whether is present in the queue

            for (int i = 0; i < n; i++)
            {
                queue.Enqueue(integers[i]);
            }
            for (int i = 0; i < s; i++)
            {
                queue.Dequeue();
            }

            if (queue.Contains(x))
            {
                Console.WriteLine("true");
            }
            else
            {
                if (queue.Count > 0)
                {
                    Console.WriteLine(queue.Min());
                }
                else
                {
                    Console.WriteLine(0);
                }
            }
        }
    }
}
