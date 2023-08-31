using System;

namespace _01.USDtoBGN
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            double usd = double.Parse(input);
            double bgn = 1.79549 * usd;
            Console.WriteLine(bgn);
        }
    }
}