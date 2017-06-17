using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace _01.ActionPrint
{
    class Program
    {
        static void Main(string[] args)
        {
            var text = Console.ReadLine().Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries).ToList();
            text.ForEach(w => Console.WriteLine(w));
        }
    }
}
