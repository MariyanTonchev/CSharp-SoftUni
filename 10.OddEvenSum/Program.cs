using System;

namespace _10.OddEvenSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int evenSum = 0;
            int oddSum = 0;

            for(int i = 0; i < n; i++)
            {
                int number = int.Parse(Console.ReadLine());
                if(i % 2 == 0)
                {
                    evenSum += number;
                }
                else
                {
                    oddSum += number;
                }
            }

            Console.Write(oddSum == evenSum ? $"Yes\nSum = {oddSum}" : $"No\nDiff = {Math.Abs(evenSum - oddSum)}");
        }
    }
}