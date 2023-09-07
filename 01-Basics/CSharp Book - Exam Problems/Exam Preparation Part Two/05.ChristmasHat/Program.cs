using System;

namespace _05.ChristmasHat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int columns = 4 * n + 1;
            int rows = 2 * n + 5;

            Console.WriteLine("{0}{1}{0}", new string('.', columns / 2 - 1), "/|\\");
            Console.WriteLine("{0}{1}{0}", new string('.', columns / 2 - 1), "\\|/");

            for (int i = 0; i < rows - 5; i++)
            {
                Console.WriteLine("{0}*{1}*{1}*{0}", new string('.', (columns / 2) - i - 1), new string('-', i));
            }

            Console.WriteLine("{0}", new string('*', columns));

            for(int i = 0; i < columns;i++)
            {
                if(i % 2 == 0)
                {
                    Console.Write('*');
                }
                else
                {
                    Console.Write('.');
                }
            }
            Console.WriteLine();

            Console.WriteLine("{0}", new string('*', columns));
        }
    }
}