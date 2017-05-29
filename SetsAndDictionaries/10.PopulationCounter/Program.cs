using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.PopulationCounter
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, long>> dict =
                new Dictionary<string, Dictionary<string, long>>();

            var input = Console.ReadLine();

            while (!input.Equals("report"))
            {
                var inputSplitted = input.Split('|');
                var city = inputSplitted[0];
                var country = inputSplitted[1];
                var population = int.Parse(inputSplitted[2]);

                if (!dict.ContainsKey(country))
                {
                    dict.Add(country, new Dictionary<string, long>());
                    dict[country].Add(city, population);
                }
                else
                {
                    dict[country].Add(city, population);
                }

                input = Console.ReadLine();
            }

            foreach (var pair in dict.OrderByDescending(c => c.Value.Values.Sum()))
            {
                Console.WriteLine($"{pair.Key} (total population: {pair.Value.Values.Sum()})");

                foreach (var innerpair in dict[pair.Key].OrderByDescending(city => city.Value))
                {
                    Console.WriteLine($"=>{innerpair.Key}: {innerpair.Value}");     
                }
            }
        }
    }
}
