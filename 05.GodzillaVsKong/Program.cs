using System;

namespace _05.GodzillaVsKong
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double movieBudget = double.Parse(Console.ReadLine());
            int people = int.Parse(Console.ReadLine());
            double clothesPrice = double.Parse(Console.ReadLine());

            double movieDecor = movieBudget * 0.10;
            double sumPeopleClothes = clothesPrice * people;
            if (people > 150)
            {
                sumPeopleClothes -= sumPeopleClothes * 0.10;
            }

            double neededMoneyForMovie = sumPeopleClothes + movieDecor;

            if(neededMoneyForMovie > movieBudget)
            {
                Console.WriteLine("Not enough money!");
                Console.WriteLine("Wingard needs {0:F2} leva more.", neededMoneyForMovie - movieBudget);
            }
            else
            {
                Console.WriteLine("Action!");
                Console.WriteLine("Wingard starts filming with {0:F2} leva left.", movieBudget - neededMoneyForMovie);
            }
        }
    }
}