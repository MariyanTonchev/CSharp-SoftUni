using System;

namespace _08.OnTimeForTheExam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int examHours = int.Parse(Console.ReadLine());
            int examMinutes = int.Parse(Console.ReadLine());
            int arrivalHours = int.Parse(Console.ReadLine());
            int arrivalMinutes = int.Parse(Console.ReadLine());

            int exanTotalMinutes = examHours * 60 + examMinutes;
            int arrivalTotalMinutes = arrivalHours * 60 + arrivalMinutes;

            int timeDifference = exanTotalMinutes - arrivalTotalMinutes;
            int hours = Math.Abs(timeDifference / 60);
            int minutes = Math.Abs(timeDifference % 60);

            if (arrivalTotalMinutes <= exanTotalMinutes)
            {
                if(exanTotalMinutes - arrivalTotalMinutes <= 30)
                {
                    Console.WriteLine("On time");
                    if(exanTotalMinutes - arrivalTotalMinutes > 0)
                    {
                        Console.WriteLine($"{exanTotalMinutes - arrivalTotalMinutes} minutes before the start");
                    }
                }
                else
                {
                    Console.WriteLine("Early");
                    if (hours == 0)
                    {
                         Console.WriteLine($"{minutes} minutes before the start");
                    }
                    else
                    {
                        if (minutes < 10)
                        {
                            Console.WriteLine($"{hours}:0{minutes} hours before the start");
                        }
                        else
                        {
                            Console.WriteLine($"{hours}:{minutes} hours before the start");
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("Late");
                if (hours == 0)
                {
                    Console.WriteLine($"{minutes} minutes after the start");
                }
                else
                {
                    if (minutes < 10)
                    {
                        Console.WriteLine($"{hours}:0{minutes} hours after the start");
                    }
                    else
                    {
                        Console.WriteLine($"{hours}:{minutes} hours after the start");
                    }
                }
            }
        }
    }
}