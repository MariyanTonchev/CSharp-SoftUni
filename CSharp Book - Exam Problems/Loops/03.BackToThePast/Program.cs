using System;

namespace _03.BackToThePast
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double legacy = double.Parse(Console.ReadLine());
            int year = int.Parse(Console.ReadLine());
            double spend = 0;
            int ivanchoYears = 18;

            for(int i = 1800; i <= year; i++)
            {
                spend += 12000;

                if (i % 2 != 0)
                {
                    spend += 50 * ivanchoYears;
                }

                ivanchoYears++;
            }

            if(legacy >= spend)
            {
                double moneyLeft = legacy - spend;
                Console.WriteLine($"Yes! He will live a carefree life and will have {moneyLeft:F2} dollars left.");
            }
            else
            {
                double moreMoney = spend - legacy;
                Console.WriteLine($"He will need {moreMoney:F2} dollars to survive.");
            }
        }
    }
}