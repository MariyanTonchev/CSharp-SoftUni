using System;

namespace _05.Travelling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string destination = Console.ReadLine();
                if(destination == "End")
                {
                    break;
                }
                double neededBudget = double.Parse(Console.ReadLine());
                double budget = 0;
                while (true)
                { 
                    budget += double.Parse(Console.ReadLine());
                    if (budget >= neededBudget) 
                    {
                        Console.WriteLine($"Going to {destination}!");
                        break;
                    }
                }
            }
        }
    }
}