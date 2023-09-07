using System;

namespace _06.Oscars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            double academyPoints = double.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());

            double neededPoints = 1250.5;

            for(int i = 0; i < n; i++)
            {
                string nameOfAppraiser = Console.ReadLine();
                double apraiserPoints = double.Parse(Console.ReadLine());

                double points = (nameOfAppraiser.Length * apraiserPoints) / 2;

                academyPoints += points;

                if(academyPoints > neededPoints)
                {
                    Console.WriteLine($"Congratulations, {name} got a nominee for leading role with {academyPoints:F1}!");
                    break;
                }
            }

            if(academyPoints < neededPoints)
            {
                Console.WriteLine($"Sorry, {name} you need {neededPoints - academyPoints:F1} more!");
            }
        }
    }
}