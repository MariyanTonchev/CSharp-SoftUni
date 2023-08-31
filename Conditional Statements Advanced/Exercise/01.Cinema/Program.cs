using System;

namespace _01.Cinema
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string projection = Console.ReadLine();
            int rows = int.Parse(Console.ReadLine());
            int colums = int.Parse(Console.ReadLine());

            double price = 0.0;

            if (projection == "Premiere")
            {
                price = 12.00;
            }
            else if (projection == "Normal")
            {
                price = 7.50;
            }
            else if (projection == "Discount")
            {
                price = 5.00;
            }

            int spots = rows * colums;

            Console.WriteLine("{0:F2} leva", spots * price);
        }
    }
}