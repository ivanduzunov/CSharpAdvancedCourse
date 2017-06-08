using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.TextFilter
{
    class Program
    {
        static void Main(string[] args)
        {
            var bannedWords = Console.ReadLine().Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
            var text = Console.ReadLine();
            foreach (var bannedWord in bannedWords)
            {
                var stars = string.Concat(Enumerable.Repeat("*", bannedWord.Length));
                text = text.Replace(bannedWord.ToLower(), stars);
                text = text.Replace(bannedWord, stars);
            }
            Console.WriteLine(text);
        }
    }
}
