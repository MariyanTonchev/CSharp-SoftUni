using System;

namespace _01.TrainingLab
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double l = double.Parse(Console.ReadLine());
            double w = double.Parse(Console.ReadLine()) - 1;

            int rows = (int)Math.Floor(l / 1.20);
            int places = (int)Math.Floor(w / 0.70);

            Console.WriteLine(rows * places - 3);
        }
    }
}