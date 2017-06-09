using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace _03.NonDigitCount
{
    class Program
    {
        static void Main(string[] args)
        {
            var text = Console.ReadLine();
            var pattern = "[^0-9]";
            Regex regex = new Regex(pattern);           
            int count = regex.Matches(text).Count;
            Console.WriteLine($"Non-digits: {count}");
        }
    }
}
