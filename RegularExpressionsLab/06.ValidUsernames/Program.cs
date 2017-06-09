using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _06.ValidUsernames
{
    class Program
    {
        static void Main(string[] args)
        {
            var username = Console.ReadLine();
            var pattern = @"^[\w-]{3,16}$";
            Regex reg = new Regex(pattern);

            while (username != "END")
            {
                if (reg.IsMatch(username))
                {
                    Console.WriteLine("valid");
                }
                else
                {
                    Console.WriteLine("invalid");
                }
                username = Console.ReadLine();
            }
        }
    }
}
