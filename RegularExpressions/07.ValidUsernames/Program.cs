using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _07.ValidUsernames
{
    class Program
    {
        static void Main(string[] args)
        {
            // NOT FULL 83/100
            var input = Console.ReadLine();
            var pattern = @"([ \/\\]+)([a-zA-Z][\w]{2,24})";
            Regex regex = new Regex(pattern);
            MatchCollection collection = regex.Matches(" " + input);
            List<string> validUsernames = new List<string>();

            foreach (Match match in collection)
            {
                validUsernames.Add(match.Groups[2].Value);
            }
            int index = 0;
            int sum = 0;
            for (int i = 0; i < validUsernames.Count - 1; i++)
            {
                if (sum < validUsernames[i].Length + validUsernames[i + 1].Length)
                {
                    sum = validUsernames[i].Length + validUsernames[i + 1].Length;
                    index = i;
                }
            }
            Console.WriteLine(validUsernames[index]);
            Console.WriteLine(validUsernames[index + 1]);
        }
    }
}
