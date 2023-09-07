using System;

namespace _06.Cake
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int cakeHeight = int.Parse(Console.ReadLine());
            int cakeWidth = int.Parse(Console.ReadLine());
            int pieces = cakeHeight * cakeWidth;


            while(true)
            {
                string input = Console.ReadLine();

                if(input == "STOP")
                {
                    Console.WriteLine($"{pieces} pieces are left.");
                    break;
                }

                if(int.TryParse(input, out int takenPieces))
                {
                    pieces -= takenPieces;
                    if (pieces < 0)
                    {
                        Console.WriteLine($"No more cake left! You need {Math.Abs(pieces)} pieces more.");
                        break;
                    }
                }
            }
        }
    }
}