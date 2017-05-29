using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace _02.SoftUniParty
{
    class Program
    {
        static void Main(string[] args)
        {
            var guestList = new SortedSet<string>();
            var vip = new HashSet<string>();

            var input = Console.ReadLine();

            while (input != "PARTY")
            {
                if (IsVIP(input) == true)
                {
                    vip.Add(input);
                }
                else
                {
                    guestList.Add(input);
                }
                input = Console.ReadLine();
            }

            input = Console.ReadLine();

            while (input != "END")
            {
                if (vip.Contains(input))
                {
                    vip.Remove(input);
                }
                else
                {
                    guestList.Remove(input);
                }
                input = Console.ReadLine();
            }
            Console.WriteLine(guestList.Count + vip.Count);
            //if (vip.Count > 0)
            //{
            //    foreach (var guest in vip)
            //    {
            //        Console.WriteLine(guest);
            //    }
            //}
            //if (guestList.Count > 0)
            //{
            //    foreach (var guest in guestList)
            //    {
            //        Console.WriteLine(guest);
            //    }
            //}
            guestList.UnionWith(vip);
            foreach (var element in guestList)
            {
                Console.WriteLine(element);
            }


        }

        public static bool IsVIP(string guest)
        {
            List<char> digits = new List<char>() { '1', '2', '3', '4', '5', '6', '7', '8', '9' };

            if (digits.Contains(guest[0]))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
