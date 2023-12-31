﻿using System;

namespace _01.DrawFort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int colSize = n / 2;
            int midSize = 2 * n - 2 * colSize - 4;
            Console.WriteLine("/{0}\\{1}/{0}\\", new string('^', colSize), new string('_', midSize));
            if (n == 3)
            {
                Console.WriteLine("|{0}|", new string(' ', n * 2 - 2));
            }
            for(int i = 1; i <= n - 3; i++)
            {
                Console.WriteLine("|{0}|", new string(' ', n * 2 - 2));
                if(i == n - 3)
                {
                        Console.WriteLine("|{0}{1}{0}|", new string(' ', colSize + 1), new string('_', midSize));
                }
            }
            Console.WriteLine("\\{0}/{1}\\{0}/", new string('_', colSize), new string(' ', midSize));
        }
    }
}