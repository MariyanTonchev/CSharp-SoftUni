using System;

namespace _04.VacationBooksList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfPages = int.Parse(Console.ReadLine());
            int pagesPerHour = int.Parse(Console.ReadLine());
            int days = int.Parse(Console.ReadLine());
            int hoursToCompleteBook = numberOfPages / pagesPerHour;
            int neededHoursPerDay = hoursToCompleteBook / days;
            Console.WriteLine(neededHoursPerDay);
        }
    }
}