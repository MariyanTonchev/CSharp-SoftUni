using System;

namespace _03.Flowers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int boughtChrysanthemums = int.Parse(Console.ReadLine());
            int boughtRoses = int.Parse(Console.ReadLine());
            int boughtLilies = int.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            char isHoliday = char.Parse(Console.ReadLine());

            decimal chrysanthenumPrice = 0;
            decimal rosesPrice = 0;
            decimal liliesPrice = 0;

            if(season == "Spring" || season == "Summer")
            {
                chrysanthenumPrice = 2.00m;
                rosesPrice = 4.10m;
                liliesPrice = 2.50m;
            }
            else if (season == "Autumn" || season == "Winter")
            {
                chrysanthenumPrice = 3.75m;
                rosesPrice = 4.50m;
                liliesPrice = 4.15m;
            }

            decimal totalCost = chrysanthenumPrice * boughtChrysanthemums + 
                boughtRoses * rosesPrice + 
                liliesPrice * boughtLilies;

            if(isHoliday == 'Y')
            {
                totalCost += totalCost * 0.15m;
            }

            if(boughtLilies >= 7 && season == "Spring")
            {
                totalCost -= totalCost * 0.05m;
            }

            if(boughtRoses >= 10 && season == "Winter")
            {
                totalCost -= totalCost * 0.1m;
            }

            int totalFlowers = boughtChrysanthemums + boughtRoses + boughtLilies;

            if (totalFlowers >= 20)
            {
                totalCost -= totalCost * 0.20m;
            }

            Console.WriteLine("{0:f2}", totalCost + 2);
        }
    }
}