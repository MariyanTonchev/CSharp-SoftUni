using System;

namespace _07.Shopping
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int videocardsNumber = int.Parse(Console.ReadLine());
            int processorsNumber = int.Parse(Console.ReadLine());
            int ramNumber = int.Parse(Console.ReadLine());

            double videoCardPrice = 250.0;
        
            double moneyForVideoCards = videocardsNumber * videoCardPrice;
            double moneyForProcessors = processorsNumber * (moneyForVideoCards * 0.35);
            double moneyForRam = ramNumber * (moneyForVideoCards * 0.10);

            double totalSum = moneyForVideoCards + moneyForProcessors + moneyForRam;

            if(videocardsNumber > processorsNumber)
            {
                totalSum -= totalSum * 0.15;
            }

            if(totalSum > budget)
            {
                Console.WriteLine("Not enough money! You need {0:F2} leva more!", totalSum - budget);
            }
            else
            {
                Console.WriteLine("You have {0:F2} leva left!", budget - totalSum);
            }
        }
    }
}