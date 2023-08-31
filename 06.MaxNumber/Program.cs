using System;

namespace _06.MaxNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int max = int.MinValue;

            while(true)
            {
                string input = Console.ReadLine();

                if (input == "Stop")
                {
                    break;
                }

                if (int.TryParse(input, out int number) && max < number)
                {
                    max = number;
                }
            }

            Console.WriteLine(max);
        }
    }
}