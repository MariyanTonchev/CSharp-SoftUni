using System;

namespace BasketBallEquipment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int taxForYear = int.Parse(Console.ReadLine());
            double basketballShoes = taxForYear - (taxForYear * 0.40);
            double basketballKit = basketballShoes - (basketballShoes * 0.20);
            double basketball = basketballKit / 4;
            double basketballAccesories = basketball / 5;

            double sum = basketballShoes + basketballKit + basketball + basketballAccesories + taxForYear;

            Console.WriteLine(sum);
        }
    }
}