using System;

namespace _07.MinNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int min = int.MaxValue;

            while (true)
            {
                string input = Console.ReadLine();

                if(input == "Stop")
                {
                    break;
                }

                if(int.TryParse(input, out int number) && min > number) 
                {
                    min = number;
                }
            }

            Console.WriteLine(min);
        }
    }
}