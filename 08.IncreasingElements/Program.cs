using System;

namespace _08.IncreasingElements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int longestStreak = 0;
            int streak = 0;
            int previousNumber = 0;

            for (int i = 0; i < n; i++)
            {
                int a = int.Parse(Console.ReadLine());

               
                if(a > previousNumber)
                {
                    streak++;
                }
                else
                {
                    streak = 1;
                }

                if (longestStreak < streak)
                {
                    longestStreak = streak;
                }

                previousNumber = a;
            }

            Console.WriteLine(longestStreak);
        }
    }
}