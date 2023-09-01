using System;

namespace _02.SmartLilly
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double washingMachinePrice = double.Parse(Console.ReadLine());
            int toyPrice = int.Parse(Console.ReadLine());

            int moneyPerYear = 10;
            int sum = 0;
            int toys = 0;

            for (int i = 1; i <= n; i++)
            {
                if (i % 2 == 0)
                {
                    sum += moneyPerYear;
                    sum -= 1;
                    moneyPerYear += 10;
                }
                else
                {
                    toys++;
                }
            }

            int moneyFromToys = toys * toyPrice;
            int totalSavings = moneyFromToys + sum;

            Console.WriteLine(totalSavings >= washingMachinePrice ? $"Yes! {totalSavings - washingMachinePrice:F2}" : $"No! {washingMachinePrice - totalSavings:F2}");
        }
    }
}