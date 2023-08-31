using System;

namespace _05.HotelRoom
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string month = Console.ReadLine();
            int days = int.Parse(Console.ReadLine());

            double rentStudio = 0.0;
            double rentApartment = 0.0;

            if (month == "May" || month == "October")
            {
                rentStudio = days * 50;
                rentApartment = days * 65;
                if (days > 14)
                {
                    rentStudio -= rentStudio * 0.30;
                }
                else if (days > 7)
                {
                    rentStudio -= rentStudio * 0.05;
                }
            }
            else if (month == "June" || month == "September")
            {
                rentStudio = days * 75.20;
                rentApartment = days * 68.70;
                if (days > 14)
                {
                    rentStudio -= rentStudio * 0.20;
                }
            }
            else if (month == "July" || month == "August")
            {
                rentStudio = days * 76;
                rentApartment = days * 77;
            }

            if (days > 14)
            {
                rentApartment -= rentApartment * 0.10;
            }

            Console.WriteLine($"Apartment: {rentApartment:F2} lv.");
            Console.WriteLine($"Studio: {rentStudio:F2} lv.");
        }
    }
}