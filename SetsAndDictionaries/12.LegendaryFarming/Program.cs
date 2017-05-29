using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.Legendary_Farming
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, long> materialQuantity = new Dictionary<string, long>();
            string input = Console.ReadLine().ToLower();
            string[] keyMaterials = { "shards", "fragments", "motes" };
            string winningMaterial = "";
            while (true)
            {
                bool enough = false;
                bool escape = false;
                List<string> inputList = input.Split(' ').ToList();
                inputList.Reverse();
                for (int i = inputList.Count - 1; i > -1; i -= 2)
                {
                    string material = inputList[i - 1];
                    string quantity = inputList[i];
                    if (materialQuantity.ContainsKey(material))
                    {
                        materialQuantity[material] += long.Parse(quantity);
                    }
                    else
                    {
                        materialQuantity.Add(material, long.Parse(quantity));
                    }
                    if (materialQuantity[material] >= 250)
                    {
                        if (material == "shards" || material == "fragments" || material == "motes")
                        {
                            enough = true;
                            if (material == "shards")
                            {
                                winningMaterial = "Shadowmourne";
                            }
                            else if (material == "fragments")
                            {
                                winningMaterial = "Valanyr";
                                materialQuantity[material] -= 250;
                                break;
                            }
                            else if (material == "motes")
                            {
                                winningMaterial = "Dragonwrath";
                            }
                            materialQuantity[material] -= 250;
                        }

                    }
                    if (enough == true)
                    {
                        break;
                    }

                }
                if (enough == true)
                {
                    break;
                }


                input = Console.ReadLine().ToLower();
            }
            if (!materialQuantity.ContainsKey("fragments"))
            {
                materialQuantity.Add("fragments", 0);
            }
            if (!materialQuantity.ContainsKey("shards"))
            {
                materialQuantity.Add("shards", 0);
            }
            if (!materialQuantity.ContainsKey("motes"))
            {
                materialQuantity.Add("motes", 0);
            }
            Console.WriteLine($"{winningMaterial} obtained!");
            foreach (KeyValuePair<string, long> pair in materialQuantity.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                if (pair.Key == "motes" || pair.Key == "fragments" || pair.Key == "shards")
                {
                    Console.WriteLine($"{pair.Key}: {pair.Value}");
                    materialQuantity.Remove(pair.Key);
                }

            }
            foreach (KeyValuePair<string, long> pair in materialQuantity.OrderBy(x => x.Key))
            {

                Console.WriteLine($"{pair.Key}: {pair.Value}");
            }


        }
    }
}
