using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.CustomComparator
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                .ToArray();
            Array.Sort(numbers);
            Console.Write(string.Join(" ", numbers.Where(n => n % 2 == 0)));
            Console.WriteLine(" " + string.Join(" ", numbers.Where(n => n % 2 != 0)));
        }
    }
}
