using System;

namespace _03.PrintingTriangle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            TopSide(n);
            PrintLine(1, n);
            BottomSide(n);
        }

        static void PrintLine(int start, int end)
        {
            for (int i = start; i <= end; i++)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
        }

        static void TopSide(int n)
        {
            for(int i = 0; i < n; i++)
            {
                PrintLine(1, i);
            }
        }

        static void BottomSide(int n)
        {
            for(int i = n - 1; i > 0; i--)
            {
                PrintLine(1, i);
            }
        }
    }
}