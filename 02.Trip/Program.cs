using System;

namespace _02.Trip
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();

            string destination = "";
            string type = "";
            double price = 0.0;

            if (budget <= 100)
            {
                destination = "Bulgaria";
                if (season == "winter")
                {
                    price = budget - budget * 0.30;
                }
                else if (season == "summer")
                {
                    price = budget - budget * 0.70;
                }
            }
            else if (budget <= 1000)
            {
                destination = "Balkans";
                if (season == "winter")
                {
                    price = budget - budget * 0.20;
                }
                else if (season == "summer")
                {
                    price = budget - budget * 0.60;
                }
            }
            else if (budget > 1000)
            {
                destination = "Europe";
                price = budget - budget * 0.10;
            }

            if (season == "summer" && destination != "Europe")
            {
                type = "Camp";
            }
            else if (season == "winter" || destination == "Europe")
            {
                type = "Hotel";
            }

            Console.WriteLine($"Somewhere in {destination}");
            Console.WriteLine($"{type} - {price:F2}");
        }
    }
}