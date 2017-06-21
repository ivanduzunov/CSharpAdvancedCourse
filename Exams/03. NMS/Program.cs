using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _03.NMS
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder sb = new StringBuilder();
            var input = Console.ReadLine();
            List<string> messages = new List<string>();

            while (input != "---NMS SEND---")
            {
                sb.Append(input.Trim());
                input = Console.ReadLine();
            }
            var message = sb.ToString();
            var delimeter = Console.ReadLine();
            sb.Clear();

            for (int i = 0; i < message.Length - 1; i++)
            {
                sb.Append(message[i]);
                if (char.ToUpperInvariant(message[i]) <= char.ToUpperInvariant(message[i + 1]))
                {
                    continue;
                }
                {
                    messages.Add(sb.ToString());
                    sb.Clear();
                }
            }
            sb.Append(message[message.Length - 1]);
            messages.Add(sb.ToString());

            Console.WriteLine(string.Join(delimeter, messages));
        }
    }
}
