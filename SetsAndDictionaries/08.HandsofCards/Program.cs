using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace _08.HandsofCards
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> values = new Dictionary<string, int>()
            {
                {"1",1 },
                {"2",2 },
                {"3",3 },
                {"4",4 },
                {"5", 5 },
                {"6", 6 },
                {"7", 7 },
                {"8", 8 },
                {"9", 9},
                {"10", 10},
                {"J", 11},
                {"Q", 12},
                {"K", 13 },
                {"A", 14}
            };
            Dictionary<string, int> types = new Dictionary<string, int>()
            {
                {"S",4 },
                {"H",3 },
                {"D",2 },
                {"C",1 }
            };
            Dictionary<string, List<string>> cardsPlayers = new Dictionary<string, List<string>>();
            Dictionary<string, int> results = new Dictionary<string, int>();

            var firstInput = Console.ReadLine().Trim();

            while (!firstInput.Equals("JOKER"))
            {
                var input = firstInput.Split(':');
                var player = input[0];
                var cards = input[1].Split(',').ToList();

                if (!cardsPlayers.ContainsKey(player))
                {
                    cardsPlayers.Add(player, new List<string>());
                }

                foreach (var card in cards)
                {

                    if (!cardsPlayers[player].Contains(card.Trim()))
                    {
                        cardsPlayers[player].Add(card.Trim());
                    }
                }
                firstInput = Console.ReadLine().Trim();
            }

            foreach (var pair in cardsPlayers)
            {
                results.Add(pair.Key, 0);
                foreach (var card in cardsPlayers[pair.Key])
                {
                    card.Trim();
                    string value = null;
                    string type = null;
                    if (card.Length > 2)
                    {
                        value = "10";
                        type = card[2].ToString();
                    }
                    else
                    {
                        value = card[0].ToString();
                        type = card[1].ToString();
                    }
                    

                    results[pair.Key] += values[value] * types[type];
                }
            }

            foreach (var pair in results)
            {
                Console.WriteLine($"{pair.Key}: {pair.Value}");
            }
        }

    }
}
