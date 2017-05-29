using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.Сръбско_Unleashed
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, long>> dict = new Dictionary<string, Dictionary<string, long>>();
            string input = Console.ReadLine();
            while (!input.Equals("End"))
            {
                var firstandSecondpart = input.Split('@').ToList();
                var venuePriceFans = firstandSecondpart[1].Split(' ').ToList();

                string singer = firstandSecondpart[0];
                var check = singer.ToCharArray();
                var check2 = firstandSecondpart[1].ToCharArray();
                if (!check[check.Length - 1].Equals(' '))
                {
                    goto End;
                }
                long pricecheck = 0;
                long peoplecheck = 0;
                try
                {
                    peoplecheck = long.Parse(venuePriceFans[venuePriceFans.Count - 1]);
                    pricecheck = long.Parse(venuePriceFans[venuePriceFans.Count - 2]);
                }
                catch (Exception)
                {

                    goto End;
                }

                string venue = "";
                long price = 0;
                long fans = 0;
                if (venuePriceFans.Count == 5)
                {
                    venue = venuePriceFans[0] + " " + venuePriceFans[1] + " " + venuePriceFans[2];
                    price = long.Parse(venuePriceFans[3]);
                    fans = long.Parse(venuePriceFans[4]);
                }
                else if (venuePriceFans.Count == 4)
                {
                    venue = venuePriceFans[0] + " " + venuePriceFans[1];
                    price = long.Parse(venuePriceFans[2]);
                    fans = long.Parse(venuePriceFans[3]);
                }

                else if (venuePriceFans.Count == 3)
                {
                    venue = venuePriceFans[0];
                    price = long.Parse(venuePriceFans[1]);
                    fans = long.Parse(venuePriceFans[2]);
                }
                else { goto End; }
                if (dict.ContainsKey(venue))
                {
                    if (dict[venue].ContainsKey(singer))
                    {
                        dict[venue][singer] += fans * price;
                    }
                    else
                    {
                        dict[venue].Add(singer, fans * price);
                    }
                }
                else
                {
                    dict.Add(venue, new Dictionary<string, long>());
                    long help = fans * price;
                    dict[venue].Add(singer, help);
                }
                End: input = Console.ReadLine();
            }
            foreach (KeyValuePair<string, Dictionary<string, long>> pair in dict)
            {
                Console.WriteLine($"{pair.Key}");
                foreach (KeyValuePair<string, long> innerPair in dict[pair.Key].OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"#  {innerPair.Key}-> {innerPair.Value}");
                }
            }
        }
    }
}
