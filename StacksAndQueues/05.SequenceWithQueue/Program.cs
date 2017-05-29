using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.SequenceWithQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            long n = long.Parse(Console.ReadLine());
            List<long> list = new List<long>();
            var queue = new Queue<long>();
            list.Add(n);

            int counter = 0;
            for (int i = 0; i < 40; i++)
            {
                long number;

                if (list.Count > 3)
                {
                    number = list[counter];
                    long number2 = number + 1;
                    long number3 = 2 * number + 1;
                    long number4 = number + 2;
                    list.Add(number2); list.Add(number3); list.Add(number4);
                }
                else
                {
                    number = n;
                    long number2 = number + 1;
                    long number3 = 2 * number + 1;
                    long number4 = number + 2;
                    list.Add(number2); list.Add(number3); list.Add(number4);
                }
                counter++;

            }
            for (int i = 0; i < 50; i++)
            {
                queue.Enqueue(list[i]);
            }
            for (int i = 0; i < 50; i++)
            {
                Console.Write(queue.Dequeue() + " ");
            }
            Console.WriteLine();
        }
    }
}
