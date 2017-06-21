using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _03.Cubic_Messages
{
    class Program
    {
        static void Main(string[] args)
        {
            var messageLine = Console.ReadLine().Trim();
            Dictionary<string, string> messagesAndVerCodes = new Dictionary<string, string>();


            while (messageLine != "Over!")
            {
                int m = int.Parse(Console.ReadLine());

                Regex rgx = new Regex(@"^\b([\d]+)([A-Za-z]{" + m + "})([^a-zA-Z]*)$");

                if (rgx.IsMatch(messageLine))
                {
                    Match match = rgx.Match(messageLine);
                    StringBuilder sbDig = new StringBuilder();
                    sbDig.Append(match.Groups[1].Value);
                    sbDig.Append(match.Groups[3].Value);
                    var digits = sbDig.ToString();
                    var originalMessage = match.Groups[2].Value;
                    StringBuilder sb = new StringBuilder();

                    for (int i = 0; i < digits.Length; i++)
                    {
                        Regex regDit = new Regex(@"[0-9]");
                        if (regDit.IsMatch(sbDig[i].ToString()))
                        {
                            int digit = int.Parse(sbDig[i].ToString());
                            if (digit >= 0 && digit < originalMessage.Length)
                            {
                                sb.Append(originalMessage[digit]);
                            }
                            else
                            {
                                sb.Append(" ");
                            }

                        }
                        else
                        {
                            sb.Append(" ");
                        }
                    }

                    var verCode = sb.ToString();
                    messagesAndVerCodes.Add(originalMessage, verCode);
                }
                messageLine = Console.ReadLine();
            }

            foreach (var pair in messagesAndVerCodes)
            {
                Console.WriteLine($"{pair.Key} == {pair.Value}");
            }
        }
    }
}

