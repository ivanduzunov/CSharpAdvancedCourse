using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12.CharacterMultiplier
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);

            int count = Math.Max(input[0].Length, input[1].Length);
            int sum = 0;

            for (int i = 0; i < count; i++)
            {
                int a = 0;
                int b = 0;

                if (i > input[0].Length - 1)
                {
                    a = 1;
                }
                else
                {
                    a = (int) input[0][i];
                }
                if (i > input[1].Length - 1)
                {
                    b = 1;
                }
                else
                {
                    b = (int)input[1][i];
                }
                sum += a * b;
            }
            Console.WriteLine(sum);
        }
    }
}
