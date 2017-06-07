using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.ParseTags
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var openTag = "<upcase>";
            var closeTag = "</upcase>";
            int startIndex = input.IndexOf(openTag);
            while (input.IndexOf(openTag) != -1)
            {
                int endIndex = input.IndexOf(closeTag);
                if (endIndex == -1)
                {
                    break;
                }
                string upcase = input.Substring(startIndex, endIndex - startIndex + closeTag.Length);
                string replaceUpcase = upcase.Replace(openTag, "").Replace(closeTag, "").ToUpper();
                input = input.Replace(upcase, replaceUpcase);
                startIndex = input.IndexOf(openTag);
            }
            Console.WriteLine(input);
        }
    }
}
