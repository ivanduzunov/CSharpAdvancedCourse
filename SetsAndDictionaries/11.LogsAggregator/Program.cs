using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.Logs_Aggregator
{
    class Program
    {
        static void Main(string[] args)
        {
            long logs = long.Parse(Console.ReadLine());
            Dictionary<string, long> usernamesDuration = new Dictionary<string, long>();
            Dictionary<string, List<string>> usernamesIps = new Dictionary<string, List<string>>();
            for (int log = 0; log < logs; log++)
            {
                List<string> input = Console.ReadLine().Split(' ').ToList();
                string ip = input[0];
                string username = input[1];
                long duration = long.Parse(input[2]);
                if (usernamesDuration.ContainsKey(username))
                {
                    usernamesDuration[username] += duration;
                }
                else
                {
                    usernamesDuration.Add(username, duration);
                }
                if (usernamesIps.ContainsKey(username))
                {
                    if (!usernamesIps[username].Contains(ip))
                    {
                        usernamesIps[username].Add(ip);
                        usernamesIps[username].Sort();
                    }
                }
                else
                {
                    usernamesIps.Add(username, new List<string>());
                    usernamesIps[username].Add(ip);
                }
            }
            foreach (KeyValuePair<string, long> pair in usernamesDuration.OrderBy(x => x.Key))
            {
                Console.Write($"{pair.Key}: {pair.Value} "); Console.Write("[");
                Console.Write(string.Join(", ", usernamesIps[pair.Key])); Console.WriteLine("]");
            }
        }
    }
}
