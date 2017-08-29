using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace _01.Regeh
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var input = Console.ReadLine().Trim();
            var pattern = @"\[(\w+)<(\d+)REGEH(\d+)>(\w+)\]";
            MatchCollection collection = Regex.Matches(input, pattern);
            List<int> numbers = ExtractNumbers(collection);

            if (numbers.Count > 0)
            {
                string result = ExtractString(input, numbers);
                Console.WriteLine(result);
            }
        }

        private static string ExtractString(string input, List<int> numbers)
        {
            StringBuilder sb = new StringBuilder();
            int previousIndexesSum = 0;
            int inputLenght = input.Length;

            foreach (int num in numbers)
            {
                previousIndexesSum += num;

                if (previousIndexesSum > inputLenght)
                {
                    int helper = (previousIndexesSum / inputLenght);
                    var index = (previousIndexesSum - (helper * inputLenght)) - 1;
                    sb.Append(input[index]);
                }
                else
                {
                    sb.Append(input[previousIndexesSum]);
                }
            }
            return sb.ToString().Trim();
        }

        private static List<int> ExtractNumbers(MatchCollection collection)
        {
            List<int> result = new List<int>();
            foreach (Match match in collection)
            {
                result.Add(int.Parse(match.Groups[2].Value));
                result.Add(int.Parse(match.Groups[3].Value));
            }
            return result;
        }
    }
}
