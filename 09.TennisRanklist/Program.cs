using System;

namespace _09.TennisRanklist
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] pointsFromTournamets = { 2000, 1200, 720 };

            int tournamets = int.Parse(Console.ReadLine());
            int startPoints = int.Parse(Console.ReadLine());
            int pointsWin = 0;
            int countWins = 0;

            for(int i = 0; i < tournamets; i++)
            {
                string positon = Console.ReadLine();
                switch (positon)
                {
                    case "W":
                        countWins++;
                        pointsWin += pointsFromTournamets[0];
                        break;
                    case "F":
                        pointsWin += pointsFromTournamets[1];
                        break;
                    case "SF":
                        pointsWin += pointsFromTournamets[2];
                        break;
                }
            }

            Console.WriteLine($"Final points: {startPoints + pointsWin}");
            Console.WriteLine($"Average points: {Math.Floor((double)pointsWin / tournamets)}");
            Console.WriteLine($"{(countWins / (double)tournamets) * 100:F2}%");
        }
    }
}