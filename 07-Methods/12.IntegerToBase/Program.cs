using System;

namespace _12.IntegerToBase
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int toBase = int.Parse(Console.ReadLine());
            string result = IntegerToBase(number, toBase);
            Console.WriteLine(result);
        }

        static string IntegerToBase(int number, int toBase)
        {
            string result = "";
            while(number != 0)
            {
                int remainder = number % toBase;
                result = remainder + result;
                number /= toBase;
            }
            return result; 
        }
    }
}