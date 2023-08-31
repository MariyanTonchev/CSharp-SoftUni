using System;

namespace _09.MinMethod
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());
            Console.WriteLine(GetMin(GetMin(a, b), c));
        }

        static int GetMin(int a, int b)
        {
            if(a <= b)
            {
                return a;
            }
            else
            {
                return b;
            }
        }
    }
}