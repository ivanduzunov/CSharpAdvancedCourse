using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _10.TheHeiganDance
{
    public class StartUp
    {
        //WITHOUT A SINGLE MATRIX, BUT JUST 50/100
        //MISTAKE(S) IN IsInTheRange method

        private const int plagueCloudDamage = 3500;
        private const int eruptionDamage = 6000;

        public static void Main(string[] args)
        {
            var d = double.Parse(Console.ReadLine()); //the damage done to Heigan each turn
            int[] playerPosition = new[] { 7, 7 };
            int playerCurrentRow = playerPosition[0];
            int playerCurrentCol = playerPosition[1];
            Queue<int> damagePointsToBeTaken = new Queue<int>();
            int playerHitPoints = 18500;
            double heiganHitPoints = 3000000;
            bool playerAreAlive = true;
            bool heiganAreAlive = true;
            string typeMagic = string.Empty;

            while (playerAreAlive && heiganAreAlive)
            {
                var tokens = Console.ReadLine().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                int damage = tokens[0] == "Cloud" ? plagueCloudDamage : eruptionDamage;
                var hitCoordinates = tokens.Skip(1).Take(2).Select(int.Parse).ToArray();
                typeMagic = tokens[0];

                heiganHitPoints -= d;
                if (damagePointsToBeTaken.Count > 0)
                {
                    playerHitPoints -= damagePointsToBeTaken.Dequeue();
                }
                if (heiganHitPoints <= 0)
                {
                    heiganAreAlive = false;
                }

                if (heiganAreAlive)
                {
                    if (IsInTheHitRange(hitCoordinates, playerCurrentRow, playerCurrentCol))
                    {
                        if (!IsInTheHitRange(hitCoordinates, playerCurrentRow - 1, playerCurrentCol) || playerCurrentRow - 1 < 0)
                        {
                            playerCurrentRow -= 1;
                        }

                        else if (!IsInTheHitRange(hitCoordinates, playerCurrentRow, playerCurrentCol + 1) || playerCurrentCol + 1 == 15)
                        {
                            playerCurrentCol += 1;
                        }

                        else if (!IsInTheHitRange(hitCoordinates, playerCurrentRow + 1, playerCurrentCol) || playerCurrentRow + 1 == 15)
                        {
                            playerCurrentRow += 1;
                        }

                        else if (!IsInTheHitRange(hitCoordinates, playerCurrentRow, playerCurrentCol - 1) || playerCurrentCol - 1 < 0)
                        {
                            playerCurrentCol -= 1;
                        }
                        else
                        {
                            if (tokens[0] == "Cloud")
                            {
                                damagePointsToBeTaken.Enqueue(damage);
                                damagePointsToBeTaken.Enqueue(damage);
                            }
                            else
                            {
                                damagePointsToBeTaken.Enqueue(damage);
                            }
                        }

                    }
                }
               
                if (damagePointsToBeTaken.Count > 0)
                {
                    playerHitPoints -= damagePointsToBeTaken.Dequeue();
                }
                         
                if (playerHitPoints <= 0)
                {
                    playerAreAlive = false;
                }
            }

            if (!heiganAreAlive)
            {
                Console.WriteLine("Heigan: Defeated!");
            }
            else
            {
                Console.WriteLine($"Heigan: {heiganHitPoints:f2}");
            }
            if (!playerAreAlive)
            {
                if (typeMagic == "Cloud")
                {
                    Console.WriteLine("Player: Killed by Plague Cloud");
                }
                else
                {
                    Console.WriteLine("Player: Killed by Eruption");
                }
            }
            else
            {
                Console.WriteLine($"Player: {playerHitPoints}");
            }
            Console.WriteLine($"Final position: {playerCurrentRow}, {playerCurrentCol}");
        }

        static bool IsInTheHitRange(int[] hitCoordinates, int playerCurrentRow, int playerCurrentCol)
        {

            int hitRow = hitCoordinates[0];
            int hitCol = hitCoordinates[1];

            if (playerCurrentRow <= hitRow + 1 && playerCurrentRow >= hitRow - 1 &&
                playerCurrentCol <= hitCol + 1 && playerCurrentCol >= hitCol - 1)
            {
                return true;
            }

            return false;
        }

    }
}
