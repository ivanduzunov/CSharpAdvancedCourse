using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _01.MatchFullName
{
    class Program
    {
        static void Main(string[] args)
        {
            
            var pattern = "^[A-Z]{1}[a-z]{1,12} [A-Z]{1}[a-z]{1,20}$";
            Regex regex = new Regex(pattern);
            var input = Console.ReadLine();

            while (input!="end")
            {
                if (regex.IsMatch(input))
                {
                    Console.WriteLine(input);
                }
                input = Console.ReadLine();
            }
        }
    }
}
