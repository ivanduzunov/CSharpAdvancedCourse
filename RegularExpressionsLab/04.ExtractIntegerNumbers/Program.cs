using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _04.ExtractIntegerNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var text = Console.ReadLine();
            var pattern = "[0-9]{1,20}";
            Regex regex = new Regex(pattern);
            int count = regex.Matches(text).Count;

            if (count > 0)
            {
                foreach (var num in regex.Matches(text))
                {
                    Console.WriteLine(num);
                }
            }
        }
    }
}
