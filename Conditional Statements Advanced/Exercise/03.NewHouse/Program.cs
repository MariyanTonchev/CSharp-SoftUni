using System;

namespace _03.NewHouse
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double priceRose = 5.00;
            double priceDahlia = 3.80;
            double priceTulip = 2.80;
            double priceNarciss = 3.00;
            double priceGladiol = 2.50;

            string flower = Console.ReadLine();
            int amount = int.Parse(Console.ReadLine());
            int budget = int.Parse(Console.ReadLine());

            double sum = 0.0;

            switch(flower)
            {
                case "Roses":
                    sum = amount * priceRose;

                    if(amount > 80)
                    {
                        sum *= 0.9;
                    }
                    break;
                case "Dahlias":
                    sum = amount * priceDahlia;
                    
                    if (amount > 90)
                    {
                        sum *= 0.85;
                    }
                    break;
                case "Tulips":
                    sum = amount * priceTulip;
                    
                    if(amount > 80)
                    {
                        sum *= 0.85;
                    }
                    break;
                case "Narcissus":
                    sum = amount * priceNarciss;
                    
                    if (amount < 120)
                    {
                        sum += sum * 0.15;
                    }    
                    break;
                case "Gladiolus":
                    sum = amount * priceGladiol;

                    if (amount < 80)
                    {
                        sum += sum * 0.2;
                    }
                    break;
                default:
                    Console.WriteLine("error");
                    break;
            }

            if (sum != 0.0 && budget >= sum)
            {
                Console.WriteLine($"Hey, you have a great garden with {amount} {flower} and {budget - sum:F2} leva left. ");
            }
            else
            {
                Console.WriteLine($"Not enough money, you need {sum - budget:F2} leva more.");
            }
        }
    }
}