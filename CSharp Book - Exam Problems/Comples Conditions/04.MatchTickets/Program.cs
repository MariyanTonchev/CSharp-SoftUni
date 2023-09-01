using System;

namespace _04.MatchTickets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double vipTicket = 499.99;
            double normalTicket = 249.99;

            double budget = double.Parse(Console.ReadLine());
            string category = Console.ReadLine();
            int people = int.Parse(Console.ReadLine());

            double moneyForTickets = 0;
            double moneyForTrip = 0;

            if(people >= 1 && people <= 4) 
            {
                moneyForTrip = budget * 0.75;
            }
            else if(people >= 5 && people <= 9)
            {
                moneyForTrip = budget * 0.60;
            }
            else if(people >= 10 && people <= 24)
            {
                moneyForTrip = budget * 0.50;
            }
            else if(people >= 25 && people <= 49)
            {
                moneyForTrip = budget * 0.40;
            }
            else if(people >= 50)
            {
                moneyForTrip = budget * 0.25;
            }

            if(category.Equals("Normal"))
            {
                moneyForTickets = people * normalTicket;
            }
            else if (category.Equals("VIP"))
            {
                moneyForTickets = people * vipTicket;
            }

            double neededMoney = moneyForTickets + moneyForTrip;
            
            if(budget >= neededMoney)
            {
                double moneyLeft = budget - neededMoney;
                Console.WriteLine($"Yes! You have {moneyLeft:F2} leva left.");
            }
            else if(budget < neededMoney)
            {
                double moneyMore = neededMoney - budget;
                Console.WriteLine($"Not enough money! You need {moneyMore:F2} leva.");
            }
        }
    }
}