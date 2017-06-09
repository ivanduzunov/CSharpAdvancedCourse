using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _07.ValidTime
{
    class Program
    {
        static void Main(string[] args)
        {
            var time = Console.ReadLine();
            var pattern = @"^[01]\d:[0-5]\d:[0-5]\d [AP]M$";
            Regex reg = new Regex(pattern);

            while (time != "END")
            {
                if (reg.IsMatch(time))
                {
                    Console.WriteLine("valid");
                }
                else
                {
                    Console.WriteLine("invalid");
                }
                time = Console.ReadLine();
            }
        }
    }
}
