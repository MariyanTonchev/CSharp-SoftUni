using System;

namespace _11.NthDigit
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int index = int.Parse(Console.ReadLine());
            FindNthDigit(number, index);
           
        }

        static void FindNthDigit(int number, int index)
        {
            int count = 0;
            while(number > 0)
            {
                count++;

                if (count == index)
                {
                    Console.WriteLine(number % 10);
                    break;
                }
                number /= 10;
            }
        }
    }
}