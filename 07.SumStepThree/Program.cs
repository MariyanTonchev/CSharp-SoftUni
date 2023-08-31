using System;

namespace _07.SumStepThree
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int sum1 = 0;
            int sum2 = 0;
            int sum3 = 0;

            for(int i = 0; i < n; i++)
            {
                int a = int.Parse(Console.ReadLine());

                if (i % 3 == 0)
                {
                    sum1 += a;
                }
                if (i % 3 == 1)
                {
                    sum2 += a;
                }
                if (i % 3 == 2)
                {
                    sum3 += a;
                }
            }

            Console.WriteLine("sum1 = {0}", sum1);
            Console.WriteLine("sum2 = {0}", sum2);
            Console.WriteLine("sum3 = {0}", sum3);
        }
    }
}