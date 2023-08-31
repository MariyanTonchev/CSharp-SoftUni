using System;

namespace _01.Distance
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int initialSpeed = int.Parse(Console.ReadLine());
            int firstTime = int.Parse(Console.ReadLine());
            int secondTime = int.Parse(Console.ReadLine());
            int thirdTime = int.Parse(Console.ReadLine());

            decimal minutesPerHour = 60m;

            decimal firstTimeIntervalHours = firstTime / minutesPerHour;
            decimal firstDistance = initialSpeed * firstTimeIntervalHours;

            decimal speedAfterIncrease = initialSpeed + ((initialSpeed * 10) / 100m);
            decimal secondIntervalHours = secondTime / minutesPerHour;
            decimal secondDistance = speedAfterIncrease * secondIntervalHours;

            decimal speedAfterDecrease = speedAfterIncrease - ((speedAfterIncrease * 5) / 100m);
            decimal thirdIntervalHours = thirdTime / minutesPerHour;
            decimal thirdDistance = speedAfterDecrease * thirdIntervalHours;

            decimal finalDistance = firstDistance + secondDistance + thirdDistance;
            string finalResult = string.Format("{0:f2}", finalDistance);

            Console.WriteLine(finalResult);
        }
    }
}