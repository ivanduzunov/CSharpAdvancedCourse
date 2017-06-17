using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.Predicate_For_Names
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var input = Console.ReadLine().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            Predicate<string> isSmallerOrEqual = name => name.Length <= n;

            foreach (var element in input)
            {
                if (isSmallerOrEqual.Invoke(element))
                {
                    Console.WriteLine(element);
                }
            }
        }
    }
}
