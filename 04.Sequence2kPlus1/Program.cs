using System;

namespace _04.Sequence2kPlus1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int i = 1;

            while(i <= n)
            {
                Console.WriteLine(i);
                i = i * 2 + 1;
            }
        }
    }
}