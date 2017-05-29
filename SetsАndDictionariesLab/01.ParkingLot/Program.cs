using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _01.ParkingLot
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var parkingLot = new SortedSet<string>();

            string input = Console.ReadLine();

            while (!input.Equals("END"))
            {
                var inputSplit = Regex.Split(input, ", ");
                var direction = inputSplit[0];
                var carNumber = inputSplit[1];

                if (direction.Equals("IN"))
                {
                    parkingLot.Add(carNumber);
                }
                else if (direction.Equals("OUT"))
                {
                    parkingLot.Remove(carNumber);
                }
                input = Console.ReadLine().ToUpper();
            }

            if (parkingLot.Count > 0)
            {
                foreach (var car in parkingLot)
                {
                    Console.WriteLine(car);
                }
            }
            else
            {
                Console.WriteLine("Parking Lot is Empty");
            }
        }
    }
}