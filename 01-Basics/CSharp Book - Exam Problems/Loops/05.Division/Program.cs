using System;

namespace _05.Division
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int p1cout = 0;
            int p2cout = 0;
            int p3cout = 0;

            
            for(int i = 0; i < n; i++)
            {
                int num = int.Parse(Console.ReadLine());

                if(num % 2 == 0)
                {
                    p1cout++;
                }

                if(num % 3 == 0)
                {
                    p2cout++;
                }

                if(num % 4 == 0)
                {
                    p3cout++;
                }
            }

            double p1 = p1cout * 1.0 / n * 100;
            double p2 = p2cout * 1.0 / n * 100;
            double p3 = p3cout * 1.0 / n * 100;

            Console.WriteLine($"{p1:F2}%");
            Console.WriteLine($"{p2:F2}%");
            Console.WriteLine($"{p3:F2}%");
        }
    }
}