using System;

namespace _01.TransportPrice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string time = Console.ReadLine();

            double price = 0;

            if (n >= 100)
            {
                price = 0.06 * n;
            }
            else if(n >= 20)
            {
                price = 0.09 * n;
            }
            else
            {
                if(time == "day")
                {
                    price = 0.79 * n + 0.70;
                }
                else if(time == "night")
                {
                    price = 0.90 * n + 0.70;
                }
            }

            Console.WriteLine(price);
        }
    }
}