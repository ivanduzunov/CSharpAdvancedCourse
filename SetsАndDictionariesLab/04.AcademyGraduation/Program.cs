using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.AcademyGraduation
{
    class Program
    {
        static void Main(string[] args)
        {
            var dict = new SortedDictionary<string, List<double>>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string student = Console.ReadLine();
                var grades = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToList();              
                dict.Add(student, grades);  
            }

            foreach (var pair in dict)
            {
                Console.WriteLine($"{pair.Key} is graduated with {pair.Value.Average()}");
            }
        }
    }
}
