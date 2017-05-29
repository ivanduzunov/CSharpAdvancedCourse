using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Phonebook
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();

            var input = Console.ReadLine();

            while (!input.Equals("stop"))
            {
                if (input.Equals("search"))
                {
                    var name = Console.ReadLine().Trim();
                    while (!name.Equals("stop"))
                    {
                        

                        if (dict.ContainsKey(name))
                        {
                            foreach (var pair in dict)
                            {
                                if (pair.Key == name)
                                {
                                    Console.WriteLine($"{pair.Key} -> {pair.Value}");

                                }

                            }
                        }
                        else
                        {
                            Console.WriteLine($"Contact {name} does not exist.");
                        }
                        name = Console.ReadLine().Trim();
                    }
                  break; 
                }
                else
                {
                    var split = input.Split('-');
                    string name = split[0].Trim();
                    string number = split[1];

                    if (!dict.ContainsKey(name))
                    {
                        dict.Add(name, number);
                    }
                    else
                    {
                        dict[name] = number;
                    }
                }

                input = Console.ReadLine();
            }
        }
    }
}
