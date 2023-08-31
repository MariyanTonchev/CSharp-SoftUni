using System;

namespace _04.Money
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int bitcoin = 1168;
            double chinaYan = 0.15;
            double dolar = 1.76;
            double euro = 1.95;

            int bitcoinNumber = int.Parse(Console.ReadLine());
            double chinaYansNumber = double.Parse(Console.ReadLine());
            double comission = double.Parse(Console.ReadLine());

            double yansToLev = chinaYan * chinaYansNumber * dolar;
            double bitcoinToEuro = (bitcoinNumber * bitcoin + yansToLev) / euro;

            Console.WriteLine($"{bitcoinToEuro - bitcoinToEuro * comission / 100}");
        }
    }
}