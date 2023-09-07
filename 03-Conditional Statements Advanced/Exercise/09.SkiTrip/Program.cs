using System;

namespace _09.SkiTrip
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine()) - 1;
            string roomType = Console.ReadLine();
            string grade = Console.ReadLine();

            double roomForOnePersonPrice = 18.00;
            double apartmentPrice = 25.00;
            double presidentApartmentPrice = 35.00;

            double priceForTrip = 0.0;

            if(roomType == "room for one person")
            {
                priceForTrip = days * roomForOnePersonPrice;
            }
            else if(roomType == "apartment")
            {
                priceForTrip = days * apartmentPrice;
                if (days < 10)
                {
                    priceForTrip -= priceForTrip * 0.30;
                }
                else if (days >= 10 && days <= 15)
                {
                    priceForTrip -= priceForTrip * 0.35;
                }
                else if (days > 15)
                {
                    priceForTrip -= priceForTrip * 0.50;
                }
            }
            else if(roomType == "president apartment")
            {
                priceForTrip = days * presidentApartmentPrice;

                if (days < 10)
                {
                    priceForTrip -= priceForTrip * 0.10;
                }
                if (days >= 10 && days <= 15)
                {
                    priceForTrip -= priceForTrip * 0.15;
                }
                else if (days > 15)
                {
                    priceForTrip -= priceForTrip * 0.20;
                }
            }

            if(grade == "positive")
            {
                priceForTrip += priceForTrip * 0.25;
            }
            else if(grade == "negative")
            {
                priceForTrip -= priceForTrip * 0.10;
            }

            Console.WriteLine($"{priceForTrip:F2}");
        }
    }
}