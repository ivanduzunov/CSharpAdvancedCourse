using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.CountSameValuesInArray
{
    class Program
    {
        static void Main(string[] args)
        {
            var dict = new SortedDictionary<float, int>();

            var input = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(float.Parse).ToList();

            foreach (var element in input)
            {
                if (!dict.ContainsKey(element))
                {
                    dict.Add(element, 1);
                }
                else
                {
                    dict[element] += 1;
                }
            }
            foreach (var element in dict)
            {
                Console.WriteLine($"{element.Key} - {element.Value} times");
            }
        }
    }
}
