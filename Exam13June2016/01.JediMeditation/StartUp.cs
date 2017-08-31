using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _01.JediMeditation
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Queue<string> masters = new Queue<string>();
            Queue<string> knights = new Queue<string>();
            Queue<string> padwans = new Queue<string>();
            Queue<string> ourGuys = new Queue<string>();
            bool yodaIsPresent = false;
             
            for (int i = 0; i < n; i++)
            {
                var tokens = Console.ReadLine().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToList();
                tokens.ForEach(t =>
                {
                    if (t[0] == 'm') masters.Enqueue(t);
                    else if (t[0] == 'k') knights.Enqueue(t);
                    else if (t[0] == 'p') padwans.Enqueue(t);
                    else if (t[0] == 't' || t[0] == 's') ourGuys.Enqueue(t);
                    else yodaIsPresent = true;
                });
            }
            string output = Output(masters, knights, padwans, ourGuys, yodaIsPresent);
            Console.WriteLine(output);
        }

        private static string Output(
            Queue<string> masters, 
            Queue<string> knights,
            Queue<string> padwans,
            Queue<string> ourGuys,
            bool yodaIsPresent)
        {
            StringBuilder sb = new StringBuilder();
            int counter = 0;

            if (yodaIsPresent)
            {
                counter = masters.Count;
                for (int i = 0; i < counter; i++)
                {
                    sb.Append(masters.Dequeue() + " ");
                }
                counter = knights.Count;
                for (int i = 0; i < counter; i++)
                {
                    sb.Append(knights.Dequeue() + " ");
                }
                counter = ourGuys.Count;
                for (int i = 0; i < counter; i++)
                {
                    sb.Append(ourGuys.Dequeue() + " ");
                }
                
            }
            else
            {
                counter = ourGuys.Count;
                for (int i = 0; i < counter; i++)
                {
                    sb.Append(ourGuys.Dequeue() + " ");
                }
                counter = masters.Count;
                for (int i = 0; i < counter; i++)
                {
                    sb.Append(masters.Dequeue() + " ");
                }
                counter = knights.Count;
                for (int i = 0; i < counter; i++)
                {
                    sb.Append(knights.Dequeue() + " ");
                }
            }
            counter = padwans.Count;
            for (int i = 0; i < counter; i++)
            {
                sb.Append(padwans.Dequeue() + " ");
            }

            return sb.ToString().Trim();
        }
    }
}
