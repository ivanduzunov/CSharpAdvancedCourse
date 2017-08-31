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
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < n; i++)
            {
                sb.Append(Console.ReadLine());
            }

            var namePattern = Console.ReadLine().Trim();
            string namePatternLenght = "{" + namePattern.Length + "}";
            Regex nameRgx = new Regex($@"{namePattern.Trim()}([a-zA-Z]{namePatternLenght})(?![A-Za-z])");

            var messagePattern = Console.ReadLine().Trim();
            string messagePatternLenght = "{" + messagePattern.Length + "}";
            Regex messageRgx = new Regex($@"{messagePattern.Trim()}([a-zA-Z0-9]{messagePatternLenght})(?![A-Za-z0-9])");

            MatchCollection nameMatches = nameRgx.Matches(sb.ToString());
            MatchCollection messageMatches = messageRgx.Matches(sb.ToString());

            var indexes = Console.ReadLine().Split().Select(int.Parse).ToArray();
            string output = CreateOutput(nameMatches, messageMatches, indexes);
            Console.WriteLine(output);
        }

        private static string CreateOutput(MatchCollection nameMatches, MatchCollection messageMatches, int[] indexes)
        {
            Queue<int> indexesQueue = new Queue<int>();
            Queue<string> namesQueue = new Queue<string>();
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < indexes.Length; i++)
            {
                indexesQueue.Enqueue(indexes[i]);
            }
            for (int i = 0; i < nameMatches.Count; i++)
            {
                namesQueue.Enqueue(nameMatches[i].Groups[1].Value);
            }

            while (true)
            {
                if (namesQueue.Count == 0)
                {
                    break;
                }

                var name = namesQueue.Dequeue();

                if (indexesQueue.Count == 0)
                {
                    break;
                }
                else
                {
                    while (true)
                    {
                        if (indexesQueue.Count == 0)
                        {
                            break;
                        }
                        int index = indexesQueue.Dequeue();

                        if (index - 1 < messageMatches.Count && index > 0)
                        {
                            sb.AppendLine($"{name} - {messageMatches[index - 1].Groups[1].Value}");
                            break;
                        }
                    }

                }
            }
            return sb.ToString().Trim();
        }
    }
}
