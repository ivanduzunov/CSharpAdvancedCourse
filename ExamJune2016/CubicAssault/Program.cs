using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CubicAssault
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = string.Empty;
            Dictionary<string, Dictionary<string, long>> regionsDict
                 = new Dictionary<string, Dictionary<string, long>>();

            while ((input = Console.ReadLine()) != "Count em all")
            {
                AddMeteorValues(input, regionsDict);
            }

            foreach (var pair in regionsDict.OrderByDescending(v => v.Value["Black"]).ThenBy(p => p.Key.Length).ThenBy(p => p.Key))
            {
                Console.WriteLine(pair.Key);

                foreach (var innerpair in regionsDict[pair.Key].OrderByDescending(p => p.Value).ThenBy(p => p.Key))
                {
                    Console.WriteLine($"-> {innerpair.Key} : {innerpair.Value}");
                }
            }
        }

        private static void AddMeteorValues(string input, Dictionary<string, Dictionary<string, long>> regionsDict)
        {

            var tokens = input.Split(new[] { "->" }, StringSplitOptions.RemoveEmptyEntries);
            var regionName = tokens[0].Trim();
            var meteorType = tokens[1].Trim();
            long meteorValue = long.Parse(tokens[2].Trim());

            if (!regionsDict.ContainsKey(regionName))
            {
                regionsDict.Add(regionName, new Dictionary<string, long>()
                {
                    {"Red", 0 },
                    {"Green", 0 },
                    {"Black", 0 }
                });
            }

            regionsDict[regionName][meteorType] += meteorValue;
            RearangeTheValues(regionsDict[regionName]);


        }

        private static void RearangeTheValues(Dictionary<string, long> dictionary)
        {
            if (dictionary["Green"] >= 1000000)
            {
                long value = dictionary["Green"] / 1000000;
                dictionary["Green"] -= value * 1000000;
                dictionary["Red"] += value;
            }
            if (dictionary["Red"] >= 1000000)
            {
                long value = dictionary["Red"] / 1000000;
                dictionary["Red"] -= value * 1000000;
                dictionary["Black"] += value;
            }
        }
    }
}
