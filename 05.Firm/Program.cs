using System;

namespace _05.Firm
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int neededHours = int.Parse(Console.ReadLine());
            int days = int.Parse(Console.ReadLine());
            int workers = int.Parse(Console.ReadLine());

            double daysOff = days * 0.10;
            int workDayHours = 8 + 2;

            double workDays = days - daysOff;
            double workedHours = workDays * workDayHours * workers;

            if (neededHours > workedHours)
            {
                int needMoreHours = (int)Math.Floor(neededHours - workedHours);
                Console.WriteLine($"Not enough time!{needMoreHours} hours needed.");
            }
            else if (workedHours >= neededHours)
            {
                int hoursLeft = (int)Math.Floor(workedHours - neededHours);
                Console.WriteLine($"Yes!{hoursLeft} hours left.");
            }
        }
    }
}