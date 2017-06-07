using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.ConcatenateStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < n; i++)
            {
                var word = Console.ReadLine();
                sb.Append(word + " ");
            }
            Console.WriteLine(sb.ToString());
        }
    }
}
