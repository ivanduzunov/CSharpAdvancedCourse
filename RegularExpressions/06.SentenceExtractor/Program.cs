using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace _06.SentenceExtractor
{
    class Program
    {
        static void Main(string[] args)
        {
            var keyword = Console.ReadLine();
            var pattern = $"[\\s\\w]* ({keyword})[\\s\\w]*[!?.]";
            Regex regex = new Regex(pattern);
            var text = Console.ReadLine();
            MatchCollection collection = regex.Matches(text);

            foreach (Match match in collection)
            {
                Console.WriteLine(match);
            }
        }
    }
}
