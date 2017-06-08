using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace _10.UnicodeCharacters
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            foreach (char symbol in input)
            {
                Console.Write(UnicodeCharLiteral(symbol));
            }
            Console.WriteLine();
        }
        public static string UnicodeCharLiteral(char c)
        {
            return "\\u" + ((int)c).ToString("X4").ToLower();
        }
    }
}
