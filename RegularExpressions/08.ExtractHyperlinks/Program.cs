using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _08.ExtractHyperlinks //83/100
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            StringBuilder sb = new StringBuilder();
            while (input != "END")
            {
                sb.Append(input).Append(" ");
                input = Console.ReadLine();
            }



            string pattern = @"<a\s+[^>]*?href\s*=(.*?)>.*?<\s*\/\s*a\s*>";

            MatchCollection collection = Regex.Matches(sb.ToString(), pattern);

            foreach (Match match in collection)
            {
                var notClean = (match.Groups[1].Value.ToString().Trim());

                if (notClean[0] == '"')
                {
                    Console.WriteLine(notClean.Split(new[] { '"' }, StringSplitOptions.RemoveEmptyEntries).First());
                }
                else if (notClean[0] == '\'')
                {                  
                    Console.WriteLine(notClean.Split(new[] { '\'' }, StringSplitOptions.RemoveEmptyEntries).First());
                }
                else if (notClean[0] == ' ')
                {
                    Console.WriteLine(notClean.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).First());
                }

            }
        }
    }
}
