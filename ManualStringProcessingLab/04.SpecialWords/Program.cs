using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.SpecialWords
{
    class Program
    {
        static void Main(string[] args)
        {
            var specialWords = Console.ReadLine().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            var text = Console.ReadLine().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            var dict = new Dictionary<string, int>();

            foreach (var word in specialWords)
            {
                dict.Add(word, 0);
            }
            foreach (var word in text)
            {
                if (dict.ContainsKey(word))
                {
                    dict[word] += 1;
                }     
            }
            foreach (var pair in dict)
            {
                Console.WriteLine($"{pair.Key} - {pair.Value}");
            }
        }
    }
}
