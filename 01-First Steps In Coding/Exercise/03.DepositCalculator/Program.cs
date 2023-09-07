using System;

namespace _03.DepositCalculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double deposit = double.Parse(Console.ReadLine());
            int time = int.Parse(Console.ReadLine());
            double interest = double.Parse(Console.ReadLine());
            double interestSum = deposit * interest / 100;
            double interestForOneMonth = interestSum / 12;
            double sum = deposit + time * interestForOneMonth;
            Console.WriteLine(sum);
        }
    }
}