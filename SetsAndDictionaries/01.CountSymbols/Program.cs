using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.CountSymbols
{
    class Program
    {
        static void Main(string[] args)
        {
            var collection = new HashSet<string>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine();
                collection.Add(input);
            }
            foreach (var element in collection)
            {
                Console.WriteLine(element);
            }
        }
    }
}
