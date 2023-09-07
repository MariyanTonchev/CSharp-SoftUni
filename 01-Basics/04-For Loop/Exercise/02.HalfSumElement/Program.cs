using System;

namespace _02.HalfSumElement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int sum = 0;

            int max = int.MinValue;

            for(int i = 0; i < n; i++)
            {
                int num = int.Parse(Console.ReadLine());
                sum += num;
                max = Math.Max(max, num);
            }

            int sumWithoutMaxNumber = sum - max;
            Console.Write(sumWithoutMaxNumber == max ? $"Yes\nSum = {max}" : $"No\nDiff = {Math.Abs(max - sumWithoutMaxNumber)}");
        }
    }
}