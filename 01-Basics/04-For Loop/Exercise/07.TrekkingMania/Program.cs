using System;

namespace _07.TrekkingMania
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int groups = int.Parse(Console.ReadLine());

            int[] climbCounts = new int[5];

            int allClimbers = 0;

            for(int i = 0; i < groups; i++)
            {
                int people = int.Parse(Console.ReadLine());
                allClimbers += people;
                
                if(people <= 5)
                {
                    climbCounts[0] += people;
                }
                else if(people >= 6 && people <= 12)
                {
                    climbCounts[1] += people;
                }
                else if(people >= 13 && people <= 25)
                {
                    climbCounts[2] += people;
                }
                else if(people >= 26 && people <= 40)
                {
                    climbCounts[3] += people;
                }
                else
                {
                    climbCounts[4] += people;
                }
            }

            for(int i = 0; i < climbCounts.Length; i++)
            {
                double percantage = (climbCounts[i] / (double)allClimbers) * 100.0;
                Console.WriteLine($"{percantage:F2}%");
            }
        }
    }
}