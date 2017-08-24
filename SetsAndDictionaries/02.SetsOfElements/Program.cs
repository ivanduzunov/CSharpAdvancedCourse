using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.SetsOfElements
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(' ');
            int n = int.Parse(input[0]);
            int m = int.Parse(input[1]);
            var first = new HashSet<string>();
            var second = new HashSet<string>();

            for (int i = 0; i < n; i++)
            {
                string element = Console.ReadLine().Trim();
                first.Add(element);
            }
            for (int i = 0; i < m; i++)
            {
                string element = Console.ReadLine().Trim();
                second.Add(element);
            }

            var result = new HashSet<int>();

            if (first.Count > second.Count)
            {
                foreach (var element in second)
                {
                    if (first.Contains(element))
                    {
                        result.Add(int.Parse(element));
                    }
                }
            }
            else
            {
                foreach (var element in first)
                {
                    if (second.Contains(element))
                    {
                        result.Add(int.Parse(element));
                    }
                }
            }

            Console.WriteLine($"{string.Join(" ", result)}");
        }
    }
}
