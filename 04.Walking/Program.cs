using System;

namespace _04.Walking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int goal = 10000;
            int dayliSteps = 0;

            while (true)
            {
                string input = Console.ReadLine();
                
                try
                {
                    dayliSteps += int.Parse(input);

                    if (dayliSteps >= goal)
                    {
                        Console.WriteLine("Goal reached! Good job!");
                        Console.WriteLine($"{dayliSteps - goal} steps over the goal!");
                        break;
                    }
                }
                catch(FormatException)
                {
                    dayliSteps += int.Parse(Console.ReadLine());
                    if (dayliSteps >= goal)
                    {
                        Console.WriteLine("Goal reached! Good job!");
                        Console.WriteLine($"{dayliSteps - goal} steps over the goal!");
                        break;
                    }
                    else
                    {
                        Console.WriteLine($"{goal - dayliSteps} more steps to reach goal.");
                        break;
                    }
                }
            }
        }
    }
}