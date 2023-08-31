using System;

namespace _03.Vacation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double neededMoney = double.Parse(Console.ReadLine());
            double availableMoney = double.Parse(Console.ReadLine());
            int countDaysWichSpent = 0;
            int countDays = 0;

            while (true)
            {
                string action = Console.ReadLine();
                double money = double.Parse(Console.ReadLine());

                countDays++;

                if (action == "spend")
                {
                    countDaysWichSpent++;

                    if (countDaysWichSpent == 5)
                    {
                        Console.WriteLine("You can't save the money.");
                        Console.WriteLine($"{countDays}");
                        break;
                    }

                    if (money > availableMoney)
                    {
                        availableMoney = 0;
                    }
                    else
                    {
                        availableMoney -= money;
                    }
                }
                else if(action == "save")
                {
                    availableMoney += money;
                    countDaysWichSpent = 0;

                    if(neededMoney <= availableMoney)
                    {
                        Console.WriteLine($"You saved the money for {countDays} days.");
                        break;
                    }
                }
            }
        }
    }
}