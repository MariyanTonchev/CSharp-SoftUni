using System;

namespace _05.DateAfterFiveDays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int day = int.Parse(Console.ReadLine());
            int month = int.Parse(Console.ReadLine());

            int daysInMonth = 31;
            if (month == 2)
            {
                daysInMonth = 28;
            }
            if (month == 4 || month == 6 || month == 9 || month == 11) 
            {
                daysInMonth = 30;
            }

            day += 5;

            if (daysInMonth < day)
            {
                day -= daysInMonth;
                month++;
                if(month > 12)
                {
                    month = 1;
                }
            }

            Console.WriteLine("{0}.{1:D2}", day, month);
        }
    }
}