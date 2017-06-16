using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.FilterByAge
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, int> dict = new Dictionary<string, int>();

            for (int i = 0; i < n; i++)
            {
                var data = Console.ReadLine().Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                dict.Add(data[0], int.Parse(data[1]));
            }
            Console.WriteLine();
            var condition = Console.ReadLine();
            Console.WriteLine();
            int age = int.Parse(Console.ReadLine());
            Console.WriteLine();
            var format = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToArray();

            if (format.Length > 1)
            {
                if (condition == "older")
                {
                    var older = dict.Where(d => d.Value > age).ToList();
                    older.ForEach(d => Console.WriteLine($"{d.Key} - {d.Value}"));
                }
                else if (condition == "younger")
                {
                    var older = dict.Where(d => d.Value < age).ToList();
                    older.ForEach(d => Console.WriteLine($"{d.Key} - {d.Value}"));
                }
            }
            else
            {
                if (format[0] == "name")
                {
                    if (condition == "older")
                    {
                        var older = dict.Where(d => d.Value > age).ToList();
                        older.ForEach(d => Console.WriteLine($"{d.Key}"));
                    }
                    else if (condition == "younger")
                    {
                        var older = dict.Where(d => d.Value < age).ToList();
                        older.ForEach(d => Console.WriteLine($"{d.Key}"));
                    }
                }
                else if (format[0] == "age")
                {
                    if (condition == "older")
                    {
                        var older = dict.Where(d => d.Value > age).ToList();
                        older.ForEach(d => Console.WriteLine($"{d.Value}"));
                    }
                    else if (condition == "younger")
                    {
                        var older = dict.Where(d => d.Value < age).ToList();
                        older.ForEach(d => Console.WriteLine($"{d.Value}"));
                    }
                }
            }
        }
    }
}
