using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.ParseURLs
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            var evr = input.Split(new[] { "://" }, StringSplitOptions.RemoveEmptyEntries).ToArray();

            if (input.IndexOf("://") == input.LastIndexOf("://") && evr.Length > 1 && evr[1].IndexOf('/') > 0)
            {
                var endProtocolIndex = input.IndexOf("://");
                var protocol = input.Substring(0, endProtocolIndex);
                var endServerIndex = evr[1].IndexOf('/');
                var server = evr[1].Substring(0, endServerIndex);
                var resources = evr[1].Substring(endServerIndex + 1);
                Console.WriteLine($"Protocol = {protocol}");
                Console.WriteLine($"Server = {server}");
                Console.WriteLine($"Resources = {resources}");
            }
            else
            {
                Console.WriteLine("Invalid URL");
            }
        }
    }
}
