using System;

namespace _09.FishTank
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int lenght = int.Parse(Console.ReadLine());
            int width = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());
            double percent = double.Parse(Console.ReadLine());

            int volume = lenght * width * height;
            double volumeInLiters = volume / 1000.0;
            double usedSpace = percent / 100;

            double neededLiters = volumeInLiters * (1 - usedSpace);
            Console.WriteLine(neededLiters);
        }
    }
}