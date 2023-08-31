using System;

namespace _12.TradeCommissions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string town = Console.ReadLine();
            double amount = double.Parse(Console.ReadLine());
            double commission = 0.0;

            if (0 <= amount && amount <= 500)
            {
                if (town == "Sofia")
                {
                    commission = amount * 5 / 100;
                }
                else if (town == "Varna")
                {
                    commission = amount * 4.5 / 100;
                }
                else if (town == "Plovdiv")
                {
                    commission = amount * 5.5 / 100;
                }
            }
            else if (500 < amount && amount <= 1000)
            {
                if (town == "Sofia")
                {
                    commission = amount * 7 / 100;
                }
                else if (town == "Varna")
                {
                    commission = amount * 7.5 / 100;
                }
                else if (town == "Plovdiv")
                {
                    commission = amount * 8 / 100;
                }
            }
            else if (1000 < amount && amount <= 10000)
            {
                if (town == "Sofia")
                {
                    commission = amount * 8 / 100;
                }
                else if (town == "Varna")
                {
                    commission = amount * 10 / 100;
                }
                else if (town == "Plovdiv")
                {
                    commission = amount * 12 / 100;
                }
            }
            else if (amount > 10000)
            {
                if (town == "Sofia")
                {
                    commission = amount * 12 / 100;
                }
                else if (town == "Varna")
                {
                    commission = amount * 13 / 100;
                }
                else if (town == "Plovdiv")
                {
                    commission = amount * 14.5 / 100;
                }
            }


            if(commission != 0.0)
            {
                Console.WriteLine("{0:F2}", commission);
            }
            else
            {
                Console.WriteLine("error");
            }
        }
    }
}