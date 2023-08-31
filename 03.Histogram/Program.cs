using System;

namespace _03.Histogram
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int countP1 = 0, countP2 = 0, countP3 = 0, countP4 = 0, countP5 = 0;
            for (int i = 0; i < n; i++)
            {
                int number = int.Parse((Console.ReadLine()));
                
                if(number < 200)
                {
                    countP1++;
                }
                else if(number >= 200 && number <= 399)
                {
                    countP2++;
                }
                else if(number >= 400 && number <= 599)
                {
                    countP3++;
                }
                else if(number >= 600 && number <= 799)
                {
                    countP4++;
                }
                else
                {
                    countP5++;
                }
            }

            double p1 = (countP1 / (double)n) * 100.0;
            double p2 = (countP2 / (double)n) * 100.0;
            double p3 = (countP3 / (double)n) * 100.0;
            double p4 = (countP4 / (double)n) * 100.0;
            double p5 = (countP5 / (double)n) * 100.0;

            Console.Write($"{p1:F2}%\n{p2:F2}%\n{p3:F2}%\n{p4:F2}%\n{p5:F2}%");
        }
    }
}