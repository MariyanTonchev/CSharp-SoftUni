using System;

namespace _10.StringRepeater
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string str = Console.ReadLine();
            int n = int.Parse(Console.ReadLine());
            string result = RepeatString(str, n);
            Console.WriteLine(result);
        }

        static string RepeatString(string str, int count)
        {
            string newString = "";
            for (int i = 0; i < count; i++)
            {
                newString += str;
            }
            return newString;
        }
    }
}