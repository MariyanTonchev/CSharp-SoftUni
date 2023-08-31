using System;

namespace _09.YardGreening
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double pricePerKm = 7.61;
            double kms = double.Parse(Console.ReadLine());

            double priceForWholeYard = pricePerKm * kms;
            double discount = priceForWholeYard * 0.18;

            Console.WriteLine($"The final price is: {priceForWholeYard - discount} lv.");
            Console.WriteLine($"The discount is: {discount} lv.");
        }
    }
}