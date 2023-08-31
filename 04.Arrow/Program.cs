using System;

namespace _04.Arrow
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int outerDots = (n - 1) / 2;
            int innerDots = n - 2;
            Console.WriteLine("{0}{1}{0}", new string('.', outerDots), new string('#', n));
            for(int i = 1; i < n - 1; i++)
            {
                Console.WriteLine("{0}#{1}#{0}", new string('.', outerDots), new string('.', innerDots));
            }
            Console.WriteLine("{0}{1}{0}", new string('#', outerDots +1), new string('.', innerDots));
            outerDots = 1;
            innerDots = 2 * n - 5;
            for (int i = 1; i < n - 1; i++)
            {
                Console.WriteLine("{0}#{1}#{0}", new string('.', outerDots), new string('.', innerDots));
                outerDots++;
                innerDots -= 2;
            }
            Console.WriteLine("{0}{1}{0}", new string('.', n - 1), '#');
        }
    }
}