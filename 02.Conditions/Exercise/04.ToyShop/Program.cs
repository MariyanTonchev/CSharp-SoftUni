using System;

namespace ToyShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double tripPrice = double.Parse(Console.ReadLine());
            int puzzlesNumber = int.Parse(Console.ReadLine());
            int dollsNumber = int.Parse(Console.ReadLine());
            int bearsNumber = int.Parse(Console.ReadLine());
            int minionsNumber = int.Parse(Console.ReadLine());
            int trucksNumber = int.Parse(Console.ReadLine());

            double puzzlePrice = 2.60;
            double dollPrice = 3.0;
            double bearPrice = 4.10;
            double minionPrice = 8.20;
            double truckPrice = 2.0;

            int numberOfPurchasedToys = puzzlesNumber + dollsNumber + bearsNumber + minionsNumber + trucksNumber;
            double sumForAllToys = puzzlesNumber * puzzlePrice + dollsNumber * dollPrice + bearsNumber * bearPrice + minionPrice * minionsNumber + truckPrice * trucksNumber;

            double discount = 0.0;
            if(numberOfPurchasedToys >= 50)
            {
                discount = sumForAllToys * 0.25;
            }

            double finalSum = sumForAllToys - discount;
            double rent = finalSum * 0.10;
            double profit = finalSum - rent;

            if(profit >= tripPrice)
            {
                Console.WriteLine("Yes! {0:F2} lv left.", profit - tripPrice);
            }
            else
            {
                Console.WriteLine("Not enough money! {0:F2} lv needed.", tripPrice - profit);
            }
        }
    }
}