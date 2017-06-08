using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace _11.Palindromes
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(new[] { " ", ",", ".", "?", "!" }, StringSplitOptions.RemoveEmptyEntries);
            SortedSet<string> resultSet = new SortedSet<string>();

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == ReverseElement(input[i]))
                {
                    resultSet.Add(input[i]);
                }
            }

            Console.WriteLine($"[{string.Join(", ", resultSet)}]");
        }

        public static string ReverseElement(string str)
        {
            var sb = new StringBuilder();

            for (int i = str.Length - 1; i >= 0; i--)
            {
                sb.Append(str[i]);
            }

            return sb.ToString();
        }
    }
}
