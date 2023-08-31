using System;

namespace _08.PetShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double dogFoodPrice = 2.50;
            int catFoodPrice = 4;

            int dogFoodPacks = int.Parse(Console.ReadLine());
            int catFoodPacks = int.Parse(Console.ReadLine());

            double sum = dogFoodPrice * dogFoodPacks + catFoodPrice * catFoodPacks;

            Console.WriteLine($"{sum} lv.");
        }
    }
}