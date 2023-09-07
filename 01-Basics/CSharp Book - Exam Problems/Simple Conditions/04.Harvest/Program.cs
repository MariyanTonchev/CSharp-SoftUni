using System;

namespace _04.Harvest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int area = int.Parse(Console.ReadLine());
            double grapesPerKm2 = double.Parse(Console.ReadLine());
            int neededWine = int.Parse(Console.ReadLine());
            int workers = int.Parse(Console.ReadLine());

            double areaForWine = area * 0.40;
            double kgGrapesForWine = areaForWine * grapesPerKm2;
            double litersWine = kgGrapesForWine / 2.5;

            if(litersWine < neededWine)
            {
                Console.WriteLine($"It will be a tough winter! More {Math.Floor(neededWine - litersWine)} liters wine needed.");
            }
            else if(litersWine >= neededWine)
            {
                double litersLeft = litersWine - neededWine;
                double litersPerWorker = litersLeft / workers;
                Console.WriteLine($"Good harvest this year! Total wine: {Math.Floor(litersWine)} liters.");
                Console.WriteLine($"{Math.Ceiling(litersLeft)} liters left -> {Math.Ceiling(litersPerWorker)} liters per person.");
            }
        }
    }
}