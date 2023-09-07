using System;

namespace _05.CalculateTriangleArea
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());
            double area = GetTriangleArea(length, height);
            Console.WriteLine(area);
        }

        static double GetTriangleArea(double length, double height)
        {
            return (length * height) / 2;
        }
    }
}