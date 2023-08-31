using System;

namespace _02.VegetableMarket
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double lvPerKgVeg = double.Parse(Console.ReadLine());
            double lvPerKgFruits = double.Parse(Console.ReadLine());

            int kgVegatables = int.Parse(Console.ReadLine());
            int kgFruits = int.Parse(Console.ReadLine());

            double euro = 1.94;

            Console.WriteLine($"{(lvPerKgFruits * kgFruits + lvPerKgVeg * kgVegatables) / euro}");
        }
    }
}