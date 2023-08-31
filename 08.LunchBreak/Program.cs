using System;

namespace _08.LunchBreak
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string serial = Console.ReadLine();
            int seriaLength = int.Parse(Console.ReadLine());
            int breakLength = int.Parse(Console.ReadLine());

            double lunchTime = breakLength / 8.0;
            double breakTime = breakLength / 4.0;

            double totalNeededTime = seriaLength + lunchTime + breakTime;

            if(totalNeededTime <= breakLength)
            {
                Console.WriteLine($"You have enough time to watch {serial} and left with {Math.Ceiling(breakLength - totalNeededTime)} minutes free time.");
            }
            else
            {
                Console.WriteLine($"You don't have enough time to watch {serial}, you need {Math.Ceiling(totalNeededTime - breakLength)} more minutes.");
            }
        }
    }
}