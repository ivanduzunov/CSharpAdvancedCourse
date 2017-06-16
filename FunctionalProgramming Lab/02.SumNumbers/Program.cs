using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.SumNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<string, int> parser = n => int.Parse(n);
            var nums = Console.ReadLine();
            Console.WriteLine(nums.Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(parser)
                .ToList().Count());
            Console.WriteLine(nums.Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(parser)
                .ToList().Sum());
        }
    }
}
