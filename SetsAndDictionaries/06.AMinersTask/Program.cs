using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.AMinersTask
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> resources = new Dictionary<string, int>();
            var resourse = Console.ReadLine();

            while (!resourse.Equals("stop"))
            {
                if (!resources.ContainsKey(resourse))
                {
                    var quantity = Console.ReadLine().Trim();
                    resources.Add(resourse, int.Parse(quantity));
                }
                else
                {
                    var quantity = Console.ReadLine().Trim();
                    resources[resourse] += int.Parse(quantity);
                }

                resourse = Console.ReadLine();
            }

            foreach (var pair in resources)
            {
                Console.WriteLine($"{pair.Key} -> {pair.Value}");
            }
        }
    }
}
