using System;

namespace _07.Moving
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int width = int.Parse(Console.ReadLine());
            int length = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());

            int space = width * length * height;

            while (true)
            {
                string input = Console.ReadLine();
                if(input == "Done")
                {
                    Console.WriteLine($"{space} Cubic meters left.");
                    break;
                }

                if(int.TryParse(input, out int takenSpace))
                {
                    space -= takenSpace;

                    if(space < 0)
                    {
                        Console.WriteLine($"No more free space! You need {Math.Abs(space)} Cubic meters more.");
                        break;
                    }
                }
            }
        }
    }
}