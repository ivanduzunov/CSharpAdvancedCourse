using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _05.ExtractTags
{
    class Program
    {
        static void Main(string[] args)
        {
            var text = Console.ReadLine();
            StringBuilder fullText = new StringBuilder();

            while (text != "END")
            {
                fullText.Append(text.Trim());
                text = Console.ReadLine();
            }

            var pattern = @"<.+?>";
            Regex reg = new Regex(pattern);
            MatchCollection collection = reg.Matches(fullText.ToString());

            if (collection.Count > 0)
            {
                foreach (var tag in collection)
                {
                    Console.WriteLine(tag);
                }
            }
        }
    }
}
