using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.UserLogs
{
    class Program
    {
        static void Main(string[] args)
        {
            var dict = new Dictionary<string, Dictionary<string, int>>();

            var input = Console.ReadLine();

            while (!input.Equals("end"))
            {
                var everything = input.Split(' ');
                var ipNotClean = everything[0].Split('=');
                var userNotClean = everything[2].Split('=');
                var ip = ipNotClean[1].Trim();
                var user = userNotClean[1].Trim();

                if (!dict.ContainsKey(user))
                {
                    dict.Add(user, new Dictionary<string, int>());
                    dict[user].Add(ip, 1);
                }
                else
                {
                    if (!dict[user].ContainsKey(ip))
                    {
                        dict[user].Add(ip, 1);
                    }
                    else
                    {
                        dict[user][ip] += 1;
                    }
                }
                input = Console.ReadLine();
            }

            foreach (var pair in dict.OrderBy(d => d.Key))
            {
                Console.WriteLine($"{pair.Key}:");

                foreach (KeyValuePair<string, int> innerpair in dict[pair.Key])
                {
                    if (innerpair.Key != pair.Value.Keys.Last())
                    {
                        Console.Write($"{innerpair.Key} => {innerpair.Value}, ");
                        
                    }
                    else
                    {
                        Console.WriteLine($"{innerpair.Key} => {innerpair.Value}.");
                       
                    }

                }
                
            }
        }
    }
}
