﻿using System;

namespace _04.EvenPowersOf2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            /*
            for (int i = 0; i <= n; i++)
            {
                if (i % 2 == 0)
                {
                    Console.WriteLine(Math.Pow(2, i));
                }
            } 
            */

            int powerOfTwo = 1;

            for(int i = 0; i <= n; i += 2)
            {
                Console.WriteLine(powerOfTwo);
                powerOfTwo *= 4;
            }
        }
    }
}