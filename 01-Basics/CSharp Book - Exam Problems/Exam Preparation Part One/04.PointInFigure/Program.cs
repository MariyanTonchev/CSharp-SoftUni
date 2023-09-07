using System;

namespace _04.PointInFigure
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int x = int.Parse(Console.ReadLine());
            int y = int.Parse(Console.ReadLine());

            bool pointInRect1 = x >= 2 && x <= 12 && y >= -3 && y <= 1;
            bool pointINRect2 = x >= 4 && x <= 10 && y >= -5 && y <= 3;

            if(pointInRect1 || pointINRect2)
            {
                Console.WriteLine("in");
            }
            else
            {
                Console.WriteLine("out");
            }
        }
    }
}