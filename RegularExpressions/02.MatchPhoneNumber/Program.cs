using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _02.MatchPhoneNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            var pattern = "^\\+359( |-)(2)\\1([0-9]{3})\\1([0-9]{4})$";
            Regex regex = new Regex(pattern);

            var input = Console.ReadLine();

            while (input != "end")
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
