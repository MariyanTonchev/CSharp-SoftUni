using System;

namespace _05.SuppliesForSchool
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double priceForPackedPencils = 5.80;
            double priceForPackedMarkers = 7.20;
            double priceForLiterChemcals = 1.20;

            int packetsWithPencils = int.Parse(Console.ReadLine());
            int packetsWithMarkers = int.Parse(Console.ReadLine());
            int litersWithChemicals = int.Parse(Console.ReadLine());
            int percentDiscount = int.Parse(Console.ReadLine());

            double sumForPencils = priceForPackedPencils * packetsWithPencils;
            double sumForMarkers = priceForPackedMarkers * packetsWithMarkers;
            double sumForChemicals = priceForLiterChemcals * litersWithChemicals;

            double sum = sumForChemicals + sumForMarkers + sumForPencils;
            double sumWithDicount = sum - (sum * percentDiscount / 100);
            Console.WriteLine(sumWithDicount);
        }
    }
}