using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.MaximumElement
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var stack = new Stack<int>();

            if (n > 0)
            {
                for (int i = 0; i < n; i++)
                {
                    var query = Console.ReadLine().Split(' ');

                    switch (query[0])
                    {
                        case "1":
                            stack.Push(int.Parse(query[1]));
                            break;

                        case "2":
                            stack.Pop();
                            break;

                        case "3":
                            Console.WriteLine(stack.Max());
                            break;
                    }
                }
            }
        }
    }
}
