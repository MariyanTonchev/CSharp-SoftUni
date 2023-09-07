using System;

namespace _03._SumNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numnber = int.Parse(Console.ReadLine());
            int sum = 0;

            while (numnber > sum)
            {
                sum += int.Parse(Console.ReadLine());
            }

            Console.WriteLine(sum);
        }
    }
}