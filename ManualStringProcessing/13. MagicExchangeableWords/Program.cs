using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13.MagicExchangeableWords
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            bool result = IsExchangable(input[0], input[1]);

            if (result)
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine("false");
            }
        }

        public static bool IsExchangable(string str1, string str2)
        {
            bool isExchangable = false;

            var firstWord = str1.ToCharArray().Distinct();
            var secondWord = str2.ToCharArray().Distinct();

            if (firstWord.Count() == secondWord.Count())
            {
                isExchangable = true;
            }

            return isExchangable;
        }
    }
}
