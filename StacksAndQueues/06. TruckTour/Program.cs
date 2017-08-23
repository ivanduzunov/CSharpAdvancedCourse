using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.TruckTour
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int numberOfPumps = int.Parse(Console.ReadLine());
            var petrolStations = new Queue<int[]>();

            for (int i = 0; i < numberOfPumps; i++)
            {
                var tokens = Console.ReadLine().Split().Select(int.Parse).ToArray();
                petrolStations.Enqueue(tokens);
            }
            int counterIndex = 0;

            while (TryFullCircle(petrolStations) == false)
            {
                var elemenet = petrolStations.Dequeue();
                petrolStations.Enqueue(elemenet);
                counterIndex++;
            }
            Console.WriteLine(counterIndex);

        }

        public static bool TryFullCircle(Queue<int[]> queue)
        {
            int counter = 1;
            int queueLenght = queue.Count;
            var temporaryQueue =new Queue<int[]>(queue); 
            int totallFuel = 0;

            for (int i = 0; i < queueLenght; i++)
            {
                var tokens = temporaryQueue.Dequeue();
                totallFuel += tokens[0];
                int distance = tokens[1];

                if (totallFuel - distance < 0)
                {
                    return false;
                }
                else
                {
                    if (counter == queueLenght)
                    {
                        break;
                    }
                    counter++;
                    totallFuel -= distance;
                }
            }
            return true;
        }
    }
}
