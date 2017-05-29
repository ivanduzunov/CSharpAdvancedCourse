using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Count_Symbols
{
    class Program
    {
        static void Main(string[] args)
        {
            var dict = new SortedDictionary<char, int>();
            var input = Console.ReadLine();

            for (int i = 0; i < input.Length; i++)
            {
                if (!dict.ContainsKey(input[i]))
                {
                    dict.Add(input[i], 1);
                }
                else
                {
                    dict[input[i]] += 1;
                }
            }

            foreach (var pair in dict)
            {
                Console.WriteLine($"{pair.Key}: {pair.Value} time/s");
            }

        }
    }
}
