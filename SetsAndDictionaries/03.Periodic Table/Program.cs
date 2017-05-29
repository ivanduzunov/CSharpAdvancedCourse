using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Periodic_Table
{
    class Program
    {
        static void Main(string[] args)
        {
            var collection = new SortedSet<string>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split(' ');

                foreach (var element in input)
                {
                    collection.Add(element.Trim());
                }
            }
            Console.WriteLine(string.Join(" ", collection));


        }
    }
}
