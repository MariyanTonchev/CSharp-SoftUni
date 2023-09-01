using System;

namespace _03.SleepyTomCat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int minutesYearNorm = 30000;
            
            int freeDays = int.Parse(Console.ReadLine());
            int workDays = 365 - freeDays;
            int playTime = minutesYearNorm - (freeDays * 127 + workDays * 63);

            int hours = playTime / 60;
            int minutes = playTime - hours * 60;
            
            if(playTime < 0)
            {
                Console.WriteLine("Tom will run away");
                Console.WriteLine($"{Math.Abs(hours)} hours and {Math.Abs(minutes)} minutes more for play");
            }
            else
            {
                Console.WriteLine("Tom sleeps well");
                Console.WriteLine($"{Math.Abs(hours)} hours and {Math.Abs(minutes)} minutes less for play");
            }
        }
    }
}