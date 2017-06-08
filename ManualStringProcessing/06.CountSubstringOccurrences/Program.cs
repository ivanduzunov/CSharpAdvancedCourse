using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace _06.CountSubstringOccurrences
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().ToLower();
            var searchStr = Console.ReadLine().ToLower();

            long counter = 0;

            for (int i = 0; i <= input.Length - searchStr.Length; i++)
            {
                var subStr = input.Substring(i, searchStr.Length);

                if (subStr == searchStr)
                {
                    counter++;
                }
            }

            Console.WriteLine(counter);
        }
    }
}
