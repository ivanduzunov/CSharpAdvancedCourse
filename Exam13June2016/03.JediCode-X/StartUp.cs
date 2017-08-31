using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _03.JediCode_X
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<string> messages = new List<string>();
            List<string> names = new List<string>();
            StringBuilder sb = new StringBuilder();

            sb.Append(" ");
            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine();
                sb.Append(input);
            }
            sb.Append(" ");
            var text = sb.ToString();

            //extract all names that consist of English alphabet letters,
            //with length equal to the length of the pattern given on the first line,
            //    and prefix the given pattern itself
            var namePattern = Console.ReadLine().Trim();
            string namePatternLenght = "{" + namePattern.Length + "}";
            Regex nameRgx = new Regex($@"{namePattern.Trim()}([a-zA-Z]{namePatternLenght})[^a-zA-Z]");

            //extract all messages which consist of English alphabet letters and digits,
            //with length equal to the length of the pattern given on the second line,
            //    and prefix the given pattern itself
            var messagePattern = Console.ReadLine().Trim();
            string messagePatternLenght = "{" + messagePattern.Length + "}";
            Regex messageRgx = new Regex($@"{messagePattern.Trim()}([a-zA-Z]{messagePatternLenght})[^a-zA-Z]");

            MatchCollection nameMatches = nameRgx.Matches(text);
            MatchCollection messageMatches = messageRgx.Matches(text);

            foreach (Match match in nameMatches)
            {
                Console.WriteLine(match.Groups[1].Value);
            }
            foreach (Match match in messageMatches)
            {
                Console.WriteLine(match.Groups[1].Value);
            }
        }
    }
}
