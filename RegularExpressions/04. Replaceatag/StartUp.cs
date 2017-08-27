using System;
using System.Text.RegularExpressions;

namespace _04.Replaceatag
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var input = string.Empty;

            while ((input = Console.ReadLine()) != "end")
            {
                Console.WriteLine(Regex.Replace(input,
                    @"(<a +href *)(=.+)>(.+)(<\/a>)", 
                    "[URL href$2]$3[/URL]"));
            }
        }
    }
}
