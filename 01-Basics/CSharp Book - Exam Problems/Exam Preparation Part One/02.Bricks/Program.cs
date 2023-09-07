using System;

namespace _02.Bricks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int allBricks = int.Parse(Console.ReadLine());
            int workers = int.Parse(Console.ReadLine());
            int cartCapacity = int.Parse(Console.ReadLine());

            int brickPerCourse = workers * cartCapacity;
            double courses = Math.Ceiling((double)allBricks / brickPerCourse);

            Console.WriteLine(courses);
        }
    }
}