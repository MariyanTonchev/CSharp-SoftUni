using System;

namespace _04.FishingBoat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int budget = int.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            int fishermans = int.Parse(Console.ReadLine());

            double rent = 0;

            if (season == "Summer" || season == "Autumn")
            {
                rent = 4200;
            } else if (season == "Spring")
            {
                rent = 3000;
            } else if (season == "Winter")
            {
                rent = 2600;
            }

            if (fishermans <= 6)
            {
                rent *= 0.9;
            } 
            else if (fishermans >= 7 && fishermans <= 11)
            {
                rent *= 0.85;
            }
            else if (fishermans >= 12)
            {
                rent *= 0.75;
            }

            if (fishermans % 2 == 0 && season != "Autumn")
            {
                rent *= 0.95;
            }

            if(budget >= rent)
            {
                Console.WriteLine($"Yes! You have {budget - rent:F2} leva left.");
            }
            else
            {
                Console.WriteLine($"Not enough money! You need {rent - budget:F2} leva.");
            }
        }
    }
}