using System;

namespace _04.DrawFilledSquare
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            PrintFilledSqure(n);
        }

        static void PrintFirstRow(int n)
        {
            Console.WriteLine(new string('-', n * 2));
        }

        static void PrintRow(int n)
        {
            Console.Write("-");
            for(int i = 1; i <= n * 2 - 2; i++)
            {
                if(i % 2 != 0)
                {
                    Console.Write('\\');
                }
                else
                {
                    Console.Write('/');
                }
            }
            Console.WriteLine("-");
        }

        static void PrintFilledSqure(int n)
        {
            PrintFirstRow(n);
            for(int i = 1; i <= n - 2; i++)
            {
                PrintRow(n);
            }
            PrintFirstRow(n);
        }
    }
}