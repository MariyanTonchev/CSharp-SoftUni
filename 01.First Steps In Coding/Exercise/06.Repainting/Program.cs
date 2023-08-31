using System;

namespace _06.Repainting
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double priceNylon = 1.50;
            double pricePaint = 14.50;
            int pricePaintThinner = 5;
            double priceForBags = 0.40;

            int neededNylon = int.Parse(Console.ReadLine());
            int neededPaint = int.Parse(Console.ReadLine());
            int neededPaintThinner = int.Parse(Console.ReadLine());
            int hoursWork = int.Parse(Console.ReadLine());

            double sumNylon = priceNylon * (neededNylon + 2);
            double sumPaint = pricePaint * (neededPaint + neededPaint * 0.10);
            double sumPaintHinner = pricePaintThinner * neededPaintThinner;

            double sumForAllMaterials = sumNylon + sumPaint + sumPaintHinner + priceForBags;
            double sumForWorker = (sumForAllMaterials * 0.30) * hoursWork;
            double finalSum = sumForAllMaterials + sumForWorker;
            Console.WriteLine(finalSum);
        }
    }
}