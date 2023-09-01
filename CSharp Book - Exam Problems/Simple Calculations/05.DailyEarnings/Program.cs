using System;

namespace _05.DailyEarnings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int workingDays = int.Parse(Console.ReadLine());
            double earnings = double.Parse(Console.ReadLine());
            double taxes = 0.25;

            double lev = double.Parse(Console.ReadLine());

            double earningsPerMonth = workingDays * earnings;
            double earningsPerYear = earningsPerMonth * 12 + earningsPerMonth * 2.5;
            double tax = earningsPerYear * 0.25;
            double pureProfit = earningsPerYear - tax;
            double earningsInLeva = pureProfit * lev;
            double averageEarningPerDay = earningsInLeva / 365;

            Console.WriteLine($"{averageEarningPerDay:F2}");
        }
    }
}