using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _04.Ashes_of_Roses
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, long>> dict =
                new Dictionary<string, Dictionary<string, long>>();
            Regex rgx = new Regex(@"\b^Grow <([A-Z][a-z]+)> <([A-Za-z\d]+)> ([\d]+)$");
            var input = Console.ReadLine();

            while (input != "Icarus, Ignite!")
            {
                if (rgx.IsMatch(input))
                {
                    Match match = rgx.Match(input);
                    var region = match.Groups[1].Value;
                    var colour = match.Groups[2].Value;
                    long roseCount = long.Parse(match.Groups[3].Value);
                    AddToDictionary(dict, region, colour, roseCount);
                }
                input = Console.ReadLine();
            }

            Print(dict);
        }

        public static void AddToDictionary(Dictionary<string, Dictionary<string, long>> dic, string reg,
            string col, long count)
        {
            if (!dic.ContainsKey(reg))
            {
                dic.Add(reg, new Dictionary<string, long>());
                dic[reg].Add(col, count);
            }
            else
            {
                if (!dic[reg].ContainsKey(col))
                {
                    dic[reg].Add(col, count);
                }
                else
                {
                    dic[reg][col] += count;
                }
            }
        }

        public static void Print(Dictionary<string, Dictionary<string, long>> dic)
        {
            foreach (var pair in dic.OrderByDescending(d => d.Value.Values.Sum()).ThenBy(d => d.Key))
            {
                Console.WriteLine($"{pair.Key}");
                foreach (var innerpair in dic[pair.Key].OrderBy(ip => ip.Value).ThenBy(ip => ip.Key))
                {
                    Console.WriteLine($"*--{innerpair.Key} | {innerpair.Value}");
                }
            }
        }
    }
}
