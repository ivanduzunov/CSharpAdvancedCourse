using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _04.JediDreams
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            StringBuilder sb = new StringBuilder();
            List<Method> methods = new List<Method>();

            for (int i = 0; i < n; i++)
            {
                sb.Append(Console.ReadLine());
            }

            var splittedText = sb.ToString().Split(new[] { "static" }, StringSplitOptions.RemoveEmptyEntries).ToArray();

            for (int i = 0; i < splittedText.Length; i++)
            {
                MatchCollection matches = Regex.Matches(splittedText[i], @"([A-Za-z]+)(?=\(.*\))");
                if (matches.Count > 0)
                {
                    Method method = new Method(matches[0].ToString());

                    for (int j = 1; j < matches.Count; j++)
                    {
                        method.Methods.Add(matches[j].ToString());
                    }
                    methods.Add(method);
                }
            }

            foreach (var method in methods.OrderByDescending(m => m.Methods.Count).ThenBy(m => m.Name))
            {
                if (method.Methods.Count == 0)
                {
                    Console.WriteLine($"{method.Name} -> None");
                }
                else
                {

                    method.Methods.Sort();
                    Console.WriteLine
                        ($"{method.Name} -> {method.Methods.Count} -> {string.Join(", ", method.Methods)}");
                }
            }
        }
    }

    public class Method
    {
        public Method(string name)
        {
            this.Name = name;
            this.Methods = new List<string>();
        }

        public string Name { get; set; }
        public List<string> Methods { get; set; }
    }
}
