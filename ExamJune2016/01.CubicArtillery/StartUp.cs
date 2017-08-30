using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.CubicArtillery
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var bunkers = new Queue<string>();
            var weapons = new Queue<int>();
            int freeCapacity = int.Parse(Console.ReadLine());
            string input = string.Empty;

            while ((input = Console.ReadLine()) != "Bunker Revision")
            {
                string[] tokens = input.Split(new [] { " " }, StringSplitOptions.RemoveEmptyEntries);

                foreach (var element in tokens)
                {
                    if (!char.IsDigit(element[0]))
                    {
                        bunkers.Enqueue(element);
                    }
                    else
                    {
                        
                    }
                }
            }
        }
    }
}
