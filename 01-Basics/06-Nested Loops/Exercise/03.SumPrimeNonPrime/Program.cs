using System;

namespace _03.SumPrimeNonPrime
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int primeSum = 0;
            int nonPrimeSum = 0;

            string input = Console.ReadLine();

            while (input != "stop")
            {
                int counter = 0;
                int num = int.Parse(input);

                if (num < 0)
                {
                    Console.WriteLine("Number is negative.");
                    input = Console.ReadLine();
                    continue;
                }

                for (int i = 2; i <= num; i++)
                {
                    if (num % i == 0)
                    {
                        counter++;
                    }
                }

                if (counter == 1)
                {
                    primeSum += num;
                }
                else
                {
                    nonPrimeSum += num;
                }

                input = Console.ReadLine();
            }
            Console.WriteLine($"Sum of all prime numbers is: {primeSum}");
            Console.WriteLine($"Sum of all non prime numbers is: {nonPrimeSum}");
        }
    }
}