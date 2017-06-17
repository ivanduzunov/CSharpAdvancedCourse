using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace _06.ReverseAndExclude
{
    class Program
    {
        static void Main(string[] args)
        {
            var nums = Console.ReadLine().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                .ToArray();
            int n = int.Parse(Console.ReadLine());

            Predicate<int> isDivisible = num => num % n == 0;
            Func<int[], int[]> reversFunc = arr => arr.Reverse().ToArray();
            nums = reversFunc.Invoke(nums);

            foreach (var number in nums)

            {
                if (!isDivisible.Invoke(number))
                {
                    Console.Write(number + " ");
                }
            }
            Console.WriteLine();
        }
    }
}
