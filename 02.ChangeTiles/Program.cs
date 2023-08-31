using System;

namespace _02.ChangeTiles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            decimal money = decimal.Parse(Console.ReadLine());
            decimal floorWidth = decimal.Parse(Console.ReadLine());
            decimal floorLength = decimal.Parse(Console.ReadLine());
            decimal triangleLine = decimal.Parse(Console.ReadLine());
            decimal triangleHeight = decimal.Parse(Console.ReadLine());
            decimal tilePrice = decimal.Parse(Console.ReadLine());
            decimal moneyForWorker = decimal.Parse(Console.ReadLine());

            decimal floorArea = floorWidth * floorLength;
            decimal tileArea = triangleLine * triangleHeight / 2;
            decimal neededTiles = Math.Ceiling(floorArea / tileArea) + 5;
            decimal totalSum = neededTiles * tilePrice + moneyForWorker;

            if(totalSum > money)
            {
                Console.WriteLine("You'll need {0:f2} lv more.", totalSum - money);
            }
            else
            {
                Console.WriteLine("{0:f2} lv left.", money - totalSum); 
            }
        }
    }
}