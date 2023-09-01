using System;

namespace _01.Histogram
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());

            int[] counts = new int[5];
            for (int i = 0; i < n; i++)
            {
                int number = int.Parse((Console.ReadLine()));

                if (number < 200)
                {
                    counts[0]++;
                }
                else if (number >= 200 && number <= 399)
                {
                    counts[1]++;
                }
                else if (number >= 400 && number <= 599)
                {
                    counts[2]++;
                }
                else if (number >= 600 && number <= 799)
                {
                    counts[3]++;
                }
                else
                {
                    counts[4]++;
                }
            }

            for (int i = 0; i < counts.Length; ++i)
            {
                double percentage = (counts[i] / (double)n) * 100.0;
                Console.WriteLine($"{percentage:F2}%");
            }
        }
    }
}