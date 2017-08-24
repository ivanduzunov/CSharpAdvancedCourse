using System.Collections.Generic;
using System;
using System.Linq;
using System.Text;

namespace _14.DragonArmmy
{
    public class StartUp
    {
        private const int defaultHealth = 250;
        private const int defaultDamage = 45;
        private const int defaultArmor = 10;

        public static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, List<int>>> dragonDict
                = new Dictionary<string, Dictionary<string, List<int>>>();

            Dictionary<string, List<double>> totalTypeStats
                = new Dictionary<string, List<double>>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var tokens = Console.ReadLine().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                AddToDragonDictionaryAndTypeToTotalStatsDict(tokens, dragonDict, totalTypeStats);
            }

            ExtractTheTotallData(totalTypeStats, dragonDict);
            Console.WriteLine(Output(dragonDict, totalTypeStats));
        }

        static void AddToDragonDictionaryAndTypeToTotalStatsDict(string[] tokens,
            Dictionary<string, Dictionary<string, List<int>>> dragonDict,
            Dictionary<string, List<double>> totalTypeStats)
        {
            var dragonType = tokens[0];
            var dragonName = tokens[1];
            int damage = tokens[2] == "null" ? defaultDamage : int.Parse(tokens[2]);
            int health = tokens[3] == "null" ? defaultHealth : int.Parse(tokens[3]);
            int armor = tokens[4] == "null" ? defaultArmor : int.Parse(tokens[4]);

            if (!dragonDict.ContainsKey(dragonType))
            {
                dragonDict.Add(dragonType, new Dictionary<string, List<int>>());
                dragonDict[dragonType].Add(dragonName, new List<int>()
                {
                    damage,
                    health,
                    armor
                });
            }
            else
            {
                if (!dragonDict[dragonType].ContainsKey(dragonName))
                {
                    dragonDict[dragonType].Add(dragonName, new List<int>()
                    {
                        damage,
                        health,
                        armor
                    });
                }
                else
                {
                    dragonDict[dragonType][dragonName] = new List<int>()
                    {
                        damage,
                        health,
                        armor
                    };
                }
            }

            if (!totalTypeStats.ContainsKey(dragonType))
            {
                totalTypeStats.Add(dragonType, new List<double>());
            }
        }

        static void ExtractTheTotallData(Dictionary<string, List<double>> totalTypeStats,
            Dictionary<string, Dictionary<string, List<int>>> dragonDict)
        {

            foreach (var typeDragon in dragonDict)
            {
                double totalDamage = 0;
                double totalHealth = 0;
                double totalArmor = 0;

                totalDamage = typeDragon.Value.Values.Average(d => d[0]);
                totalHealth = typeDragon.Value.Values.Average(d => d[1]);
                totalArmor = typeDragon.Value.Values.Average(d => d[2]);

                totalTypeStats[typeDragon.Key].Add(totalDamage);
                totalTypeStats[typeDragon.Key].Add(totalHealth);
                totalTypeStats[typeDragon.Key].Add(totalArmor);
            }
        }

        static string Output(Dictionary<string, Dictionary<string, List<int>>> dragonDict,
            Dictionary<string, List<double>> totalTypeStats)
        {
            StringBuilder sb = new StringBuilder();

            foreach (var pair in totalTypeStats)
            {
                sb.AppendLine
                    ($"{pair.Key}::({pair.Value[0]:f2}/{pair.Value[1]:f2}/{pair.Value[2]:f2})");
                foreach (var innerpair in dragonDict[pair.Key].OrderBy(d => d.Key))
                {
                    sb.AppendLine(
                        $"-{innerpair.Key} -> damage: {innerpair.Value[0]}, health: {innerpair.Value[1]}, armor: {innerpair.Value[2]}");
                }
            }

            return sb.ToString().Trim();
        }
    }
}
