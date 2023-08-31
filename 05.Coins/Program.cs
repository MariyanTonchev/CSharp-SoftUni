using System;

namespace _05.Coins
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] coinDenominations = { 200, 100, 50, 20, 10, 5, 2, 1 };
            int change = (int)(double.Parse(Console.ReadLine()) * 100);
            int changeCoinsCount = 0;
            int index = 0;

            while (change > 0)
            {
                int coins = change / coinDenominations[index];
                change -= coinDenominations[index] * coins;
                changeCoinsCount += coins;
                index++;
            }
            Console.WriteLine(changeCoinsCount);
        }
    }
}