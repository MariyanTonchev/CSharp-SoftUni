using System;

namespace _07.FoodDelivery
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double chickenMenu = 10.35;
            double fishMenu = 12.40;
            double vegaterianMenu = 8.15;
            double delivery = 2.50;

            int numberChickenMenus = int.Parse(Console.ReadLine());
            int numberFishMenu = int.Parse(Console.ReadLine());
            int numberVegMenu = int.Parse(Console.ReadLine());

            double sumForOrder = chickenMenu * numberChickenMenus + fishMenu * numberFishMenu + vegaterianMenu * numberVegMenu;
            double priceForDesert = sumForOrder * 0.20;

            double finalSum = sumForOrder + priceForDesert + delivery;

            Console.WriteLine(finalSum);
        }
    }
}