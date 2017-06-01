using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.GroupNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();


            int[] list0 = input.Where(n => Math.Abs(n) % 3 == 0).ToArray();
            int[] list1 = input.Where(n => Math.Abs(n) % 3 == 1).ToArray();
            int[] list2 = input.Where(n => Math.Abs(n) % 3 == 2).ToArray();

            Console.WriteLine(string.Join(" ", list0));
            Console.WriteLine(string.Join(" ", list1));
            Console.WriteLine(string.Join(" ", list2));


        }
    }
}
