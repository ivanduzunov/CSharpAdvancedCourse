using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace _07.ValidUsernames
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var allUsernames = Console.ReadLine().
                Split(new[] { ' ', '\\', '/', '(', ')' }, StringSplitOptions.RemoveEmptyEntries);
            var validUsernames = allUsernames.Where(u => Regex.IsMatch(u, @"^[A-Za-z][\w\d]{2,24}$")).ToArray();
            var result = biggestTwo(validUsernames);

            foreach (var username in result)
            {
                Console.WriteLine(username);
            }
        }

        private static string[] biggestTwo(string[] validUsernames)
        {
            int current = 0;
            int currentBiggest = 0;
            string[] currentBiggestUsernames = new string[2];

            for (int i = 0; i < validUsernames.Length - 1; i++)
            {
                current = validUsernames[i].Length + validUsernames[i + 1].Length;

                if (current > currentBiggest)
                {
                    currentBiggestUsernames =
                        new string[] { validUsernames[i], validUsernames[i + 1] };
                    currentBiggest = current;
                }
            }
            return currentBiggestUsernames;
        }
    }
}
