using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.StudentsResults
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Console.WriteLine(string.Format("{0,-10}|{1,7}|{2,7}|{3,7}|{4,7}|", "Name", "CAdv", "COOP", "AdvOOP", "Average"));

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split(new string[] { "-" }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                var name = input[0];
                var grades = input[1].Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries).
                    ToArray();
                decimal cAdv = decimal.Parse(grades[0]);
                decimal coop = decimal.Parse(grades[1]);
                decimal advOop = decimal.Parse(grades[2]);
                decimal[] arr = new[] { cAdv, coop, advOop };
                decimal average = arr.Average();

                Console.WriteLine(string.Format
                    ("{0,-10}|{1,7:f2}|{2,7:f2}|{3,7:f2}|{4,7:f4}|", name, cAdv, coop, advOop, average));

            }
        }
    }
}
