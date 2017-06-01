using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.MatrixOfPalindromes
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(' ');
            int r = int.Parse(input[0]);
            int c = int.Parse(input[1]);

            char[] alphabet = "abcdefghijklmnopqrstuvwxyz".ToCharArray();

            string[,] palindromes = new string[r, c];

            for (int i = 0; i < palindromes.GetLength(0); i++)
            {
                for (int j = 0; j < palindromes.GetLength(1); j++)
                {
                    palindromes[i, j] = (alphabet[i].ToString() + alphabet[i + j].ToString() + alphabet[i].ToString());
                }
            }

            for (int i = 0; i < palindromes.GetLength(0);i++)
            {
                for (int j = 0; j < palindromes.GetLength(1); j++)
                {
                    Console.Write(palindromes[i,j] + " ");
                }
                Console.WriteLine();
            }
            

        }
    }
}
