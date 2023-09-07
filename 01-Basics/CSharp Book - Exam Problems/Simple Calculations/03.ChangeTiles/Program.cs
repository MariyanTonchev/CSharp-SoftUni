using System;

namespace _03.ChangeTiles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            
            double tileWidth = double.Parse(Console.ReadLine());
            double tileLength = double.Parse(Console.ReadLine());

            int benchWidth = int.Parse(Console.ReadLine());
            int benchLength = int.Parse(Console.ReadLine());

            double setTileTime = 0.2;

            int area = N * N;
            int benchArea = benchWidth * benchLength;
            double tileArea = tileWidth * tileLength;

            int areaToCover = area - benchArea;
            double tilesNeed = areaToCover / tileArea;
            double timeNeed = tilesNeed * setTileTime;

            Console.WriteLine($"{tilesNeed}");
            Console.WriteLine($"{timeNeed}");
        }
    }
}