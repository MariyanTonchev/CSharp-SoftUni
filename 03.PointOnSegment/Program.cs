using System;

namespace _03.PointOnSegment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int first = int.Parse(Console.ReadLine());
            int second = int.Parse(Console.ReadLine());
            int point = int.Parse(Console.ReadLine());

            int left = Math.Min(first, second);
            int right = Math.Max(first, second);

            int distanceLeft = Math.Abs(left - point);
            int distanceRight = Math.Abs(right - point);

            int smallerDistance = Math.Min(distanceLeft, distanceRight);

            if(point >= left && point <= right)
            {
                Console.WriteLine("in");
            }
            else
            {
                Console.WriteLine("out");
            }

            Console.WriteLine(smallerDistance);
        }
    }
}