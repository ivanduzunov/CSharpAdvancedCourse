using System;
using System.Collections.Generic;
using System.Linq;

namespace PoisonousPlants
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var plants = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var plantsDaysDie = new int[n];
            var previousPlants = new Stack<int>();
            previousPlants.Push(0);

            for (int i = 1; i < n; i++)
            {
                if (plants[previousPlants.Peek()] >= plants[i])
                {

                }
            }




        }
    }
}
