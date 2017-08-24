using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace _07.FixEmails
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();

            var name = Console.ReadLine().Trim();

            while (!name.Equals("stop"))
            {
                var email = Console.ReadLine().Trim();

                if (!email.Contains(".uk") && !email.Contains(".us"))
                {
                    dict.Add(name, email);
                }
                name = Console.ReadLine().Trim();
            }


            foreach (var pair in dict)
            {
                Console.WriteLine($"{pair.Key} -> {pair.Value}");
            }
        }

    }
}
