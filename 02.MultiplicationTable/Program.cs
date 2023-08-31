using System;

namespace _02.MultiplicationTable
{
    internal class Program
    {
        static void Main(string[] args)
        {
            for(int n = 1; n <= 10; n++)
            {
                for(int m = 1; m <= 10; m++)
                {
                    Console.WriteLine($"{n} * {m} = {n * m}");
                }
            }
        }
    }
}