using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.CubicArtillery
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var input = string.Empty;
            List<Bunker> bunkers = new List<Bunker>();

            while ((input = Console.ReadLine()) != "Bunker Revision")
            {
                var tokens = input.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < tokens.Length; i++)
                {
                    if (!char.IsDigit(tokens[i][0]))
                    {
                        bunkers.Add(new Bunker(tokens[i], n));
                    }
                    else
                    {
                        int currentWeapon = int.Parse(tokens[i]);
                        if (bunkers[0].FreeSpace < currentWeapon)
                        {
                            for (int j = 1; j < bunkers.Count; j++)
                            {
                                if (bunkers[j].FreeSpace >= currentWeapon)
                                {
                                    bunkers[j].Weapons.Add(currentWeapon);
                                    break;
                                }
                            }
                        }
                        else
                        {
                            bunkers[0].Weapons.Add(currentWeapon);
                        }

                    }
                    if (bunkers[0].IsFull)
                    {
                        Console.WriteLine($"{bunkers[0].Name} -> {string.Join(", ", bunkers[0].Weapons)}");
                        bunkers.RemoveAt(0);
                    }

                }
                
            }

        }
    }

    class Bunker
    {
        public Bunker(string name, int maxCapacity)
        {
            Name = name;
            Weapons = new List<int>();
            MaxCapacity = maxCapacity;
        }

        public string Name { get; set; }
        public List<int> Weapons { get; set; }
        public int MaxCapacity { get; set; }
        public bool IsFull
        {

            get => this.MaxCapacity == this.Weapons.Sum();
            private set
            {
                var b = this.MaxCapacity == this.Weapons.Sum();
                b = value;
            }
        }
        public int FreeSpace
        {
            get => this.MaxCapacity - this.Weapons.Sum();
            set
            {
                var b = this.MaxCapacity - this.Weapons.Sum();
                b = value;
            }
        }
    }
}
