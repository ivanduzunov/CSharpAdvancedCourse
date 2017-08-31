using System;

namespace _02.JediGalaxy
{
    // 80/100 The last two tests - "Time Limit"
    public class StartUp
    {
        public static void Main(string[] args)
        {
            long[][] galaxy = CreateTheGalaxy(Console.ReadLine().Split(' '));
            var input = string.Empty;
            long jediPoints = 0;

            while ((input = Console.ReadLine()) != "Let the Force be with you")
            {
                var jediCoordinates = input.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                var sithCoordinates = Console.ReadLine().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);

                int jediInitialRow = int.Parse(jediCoordinates[0]);
                int jediInitialCol = int.Parse(jediCoordinates[1]);
                int sithInitialRow = int.Parse(sithCoordinates[0]);
                int sithInitialCol = int.Parse(sithCoordinates[1]);

                SithDestructionOfPlanets(galaxy, sithInitialRow, sithInitialCol);
                jediPoints += JediCollectingOfPoints(galaxy, jediInitialRow, jediInitialCol);
            }
            Console.WriteLine(jediPoints);
        }

        private static long JediCollectingOfPoints(long[][] galaxy, int row, int col)
        {
            long jediPoints = 0;
            for (long i = row; i >= 0; i--)
            {
                if (PlanetIsInTheGalaxy(i, col, galaxy.Length, galaxy[0].Length))
                {
                    jediPoints += galaxy[i][col];
                }
                col++;
            }
            return jediPoints;
        }

        private static void SithDestructionOfPlanets(long[][] galaxy, int row, int col)
        {
            for (long i = row; i >= 0; i--)
            {
                if (PlanetIsInTheGalaxy(i, col, galaxy.Length, galaxy[0].Length))
                {
                    galaxy[i][col] = 0;
                }
                col--;
            }
        }

        private static bool PlanetIsInTheGalaxy(long i, long j, long galaxyLength, long lenght)
        {
            bool isValidRow = i < galaxyLength && i >= 0;
            bool isValidCol = j < lenght && j >= 0;
            return isValidCol && isValidRow;
        }

        private static long[][] CreateTheGalaxy(string[] longs)
        {
            long rows = long.Parse(longs[0]);
            long cols = long.Parse(longs[1]);
            long[][] toReturn = new long[rows][];
            long counter = 0;

            for (long i = 0; i < rows; i++)
            {
                toReturn[i] = new long[cols];
                for (long j = 0; j < cols; j++)
                {
                    toReturn[i][j] = counter;
                    counter++;
                }
            }
            return toReturn;
        }
    }
}
