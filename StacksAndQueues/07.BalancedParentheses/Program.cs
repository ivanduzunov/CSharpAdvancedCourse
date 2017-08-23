using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.BalancedParentheses
{
    class Program
    {
        public static void Main(string[] args)
        {

            var input = Console.ReadLine().ToCharArray();

            if (IsCorrect(input))
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }

        }

        public static bool IsCorrect(char[] sequence)
        {
            if (sequence.Length % 2 != 0 || sequence.Length == 0)
            {
                return false;
            }
            Stack<char> openBrackets = new Stack<char>();
            char[] openingBrackets = new char[] { '{', '(', '[' };

            for (int i = 0; i < sequence.Length; i++)
            {
                char currentBracket = sequence[i];

                if (openingBrackets.Contains(currentBracket))
                {
                    openBrackets.Push(currentBracket);
                }
                else
                {
                    switch (currentBracket)
                    {
                        case ']':
                            if (openBrackets.Pop() != '[')
                            {
                                return false;
                                break;
                            }
                            break;




                        case '}':
                            if (openBrackets.Pop() != '{')
                            {
                                return false;
                            }
                            break;



                        case ')':
                            if (openBrackets.Pop() != '(')
                            {
                                return false;
                            }
                            break;
                    }
                }
            }
            return true;
        }
    }
}
