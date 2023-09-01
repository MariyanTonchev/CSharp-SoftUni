using System;

namespace _04.SpecialNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            for (int i = 1111; i <= 9999; i++)
            {
                string number = i.ToString();

                int d1 = (int)char.GetNumericValue(number[0]);
                int d2 = (int)char.GetNumericValue(number[1]);
                int d3 = (int)char.GetNumericValue(number[2]);
                int d4 = (int)char.GetNumericValue(number[3]);

                if (d1 == 0 || d2 == 0 || d3 == 0 || d4 == 0)
                {
                    continue;
                }

                if (N % d1 == 0 && 
                    N % d2 == 0 && 
                    N % d3 == 0 && 
                    N % d4 == 0)
                {
                    Console.Write("{0} ", i);
                }
            }
        }
    }
}