using System;

namespace _05.Axe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int width = n * 5;
            int leftDashes = n * 3;
            int middleDashes = 0;
            int rightDashes = width - leftDashes - middleDashes - 2;

            Console.WriteLine("{0}*{1}*{2}", new string('-', leftDashes), new string('-', middleDashes), new string('-', rightDashes));

            for (int i = 1; i < n; i++)
            {
                middleDashes++;
                rightDashes--;
                Console.WriteLine("{0}*{1}*{2}", new string('-', leftDashes), new string('-', middleDashes), new string('-', rightDashes));
            }

            for (int i = 1; i <= n / 2; i++)
            {
                Console.WriteLine("{0}*{1}*{2}", new string('*', leftDashes), new string('-', middleDashes), new string('-', rightDashes));
            }



            if (n != 2)
            {
                Console.WriteLine("{0}*{1}*{2}", new string('-', leftDashes), new string('-', middleDashes), new string('-', rightDashes));

                for (int i = 1; i < n / 2 - 1; i++)
                {
                    leftDashes--;
                    middleDashes += 2;
                    rightDashes--;
                    Console.WriteLine("{0}*{1}*{2}", new string('-', leftDashes), new string('-', middleDashes), new string('-', rightDashes));
                }

                leftDashes--;
                middleDashes += 2;
                rightDashes--;
            }

            Console.WriteLine("{0}*{1}*{2}", new string('-', leftDashes), new string('*', middleDashes), new string('-', rightDashes));
        }
    }
}