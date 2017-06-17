using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.AppliedArithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            var nums = Console.ReadLine().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                .ToList();
            var command = Console.ReadLine();

            Func<List<int>, List<int>> addFunc = n => n.Select(nn => nn + 1).ToList();
            Func<List<int>, List<int>> multiplyFunc = n => n.Select(nn => nn * 2).ToList();
            Func<List<int>, List<int>> subtractFunc = n => n.Select(nn => nn - 1).ToList();
            Action<List<int>> printAction = n => Console.WriteLine(string.Join(" ", n));


            while (!command.Equals("end"))
            {
                switch (command)
                {
                    case "add":
                        nums = addFunc.Invoke(nums);
                        break;
                    case "multiply":
                        nums = multiplyFunc.Invoke(nums);
                        break;
                    case "subtract":
                        nums = subtractFunc.Invoke(nums);
                        break;
                    case "print":
                        printAction(nums);
                        break;
                }

                command = Console.ReadLine();
            }
        }
    }
}
