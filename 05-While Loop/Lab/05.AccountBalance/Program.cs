using System;

namespace _04.AccountBalance
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double account = 0;

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "NoMoreMoney")
                {
                    break;
                }
                

                if (double.TryParse(input, out double money) && money >= 0)
                {
                    Console.WriteLine($"Increase: {money:F2}");
                    account += money;
                }
                else
                {
                    Console.WriteLine("Invalid operation!");
                    break;
                }
            }

            Console.WriteLine($"Total: {account:F2}");
        }
    }
}