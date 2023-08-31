using System;

namespace _02.Butterfly
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int columns = 2 * n - 1;
            int rows = 2 * (n - 2) + 1;
            int halfRowSize = rows / 2;
            int halfColumnSize = columns / 2;
            for(int i = 1; i <= halfRowSize; i++)
            {
                if(i % 2 != 0)
                {
                    Console.WriteLine("{0}\\ /{0}", new string('*', halfRowSize));
                }
                else
                {
                    Console.WriteLine("{0}\\ /{0}", new string('-', halfRowSize));
                }
            }
            Console.WriteLine("{0}{1}", new string(' ', halfColumnSize), '@');
            for (int i = 1; i <= halfRowSize; i++)
            {
                if (i % 2 != 0)
                {
                    Console.WriteLine("{0}/ \\{0}", new string('*', halfRowSize));
                }
                else
                {
                    Console.WriteLine("{0}/ \\{0}", new string('-', halfRowSize));
                }
            }
        }
    }
}