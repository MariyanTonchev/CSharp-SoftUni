using System;

namespace _10.RectangleWithStars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int rows = n;
            if (rows % 2 == 0)
            {
                rows--;
            }


            Console.WriteLine("{0}", new string('%', n * 2));
            for(int i = 0; i < rows; i++)
            {
                if(i == rows / 2)
                {
                    Console.WriteLine("{0}{1}{2}{1}{0}", "%", new string(' ', n - 2), "**");
                }
                else
                {
                    Console.WriteLine("{0}{1}{0}", "%", new string(' ', n * 2 - 2));
                }
            }
            Console.WriteLine("{0}", new string('%', n * 2));
        }
    }
}