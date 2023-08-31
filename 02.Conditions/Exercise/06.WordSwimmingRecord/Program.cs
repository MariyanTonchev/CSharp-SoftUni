using System;

namespace _06.WordSwimmingRecord
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double record = double.Parse(Console.ReadLine());
            double meters = double.Parse(Console.ReadLine());
            double oneMeterInSeconds = double.Parse(Console.ReadLine());

            double slowTime = 12.5;
            double slow = Math.Floor(meters / 15);

            double time = meters * oneMeterInSeconds;
            time += slow * slowTime;

            if(time >= record)
            {
                Console.WriteLine("No, he failed! He was {0:F2} seconds slower.", time - record);
            }
            else
            {
                Console.WriteLine("Yes, he succeeded! The new world record is {0:F2} seconds.", time);
            }
        }
    }
}