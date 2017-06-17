﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Find_Evens_or_Odds
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] range = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            List<int> nums = new List<int>();
            for (int i = range[0]; i <= range[1]; i++)
            {
                nums.Add(i);
            }

            string evenOrOdd = Console.ReadLine();

            Predicate<int> isEven = n => n % 2 == 0;
            Predicate<int> isOdd = n => n % 2 != 0;

            foreach (var number in nums)
            {
                if (evenOrOdd.Equals("even"))
                {
                    if (isEven.Invoke(number))
                    {
                        Console.Write(number + " ");
                    }
                }
                else
                {
                    if (isOdd.Invoke(number))
                    {
                        Console.Write(number + " ");
                    }
                }
            }
            Console.WriteLine();
        }
    }
}
