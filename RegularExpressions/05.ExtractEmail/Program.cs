using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _05.ExtractEmail
{
    class Program
    {
        static void Main(string[] args)
        {
            var pattern = " [a-z][-.\\w]{0,30}[a-z]@[a-z][-.a-z]{0,30}[a-z][.][a-z]{2,10}";
            Regex regex = new Regex(pattern);
            var text = Console.ReadLine();
            MatchCollection collection = regex.Matches(text);

            foreach (Match match in collection)
            {
                Console.WriteLine(match.ToString().Trim());
            }
        }
    }
}
