using System;

namespace _02.PipesInPool
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int V = int.Parse(Console.ReadLine());
            int p1debit = int.Parse(Console.ReadLine());
            int p2debit = int.Parse(Console.ReadLine());
            double hoursWorkerMissing = double.Parse(Console.ReadLine());

            double litersByPipe1 = p1debit * hoursWorkerMissing;
            double litersByPipe2 = p2debit * hoursWorkerMissing;
            double sumLiters = litersByPipe1 + litersByPipe2;

            if(sumLiters > V)
            {
                Console.WriteLine($"For {hoursWorkerMissing} hours the pool overflows with {sumLiters - V} liters.");
            }
            else
            {
                Console.WriteLine("The pool is {0}% full. Pipe 1: {1}%. Pipe 2: {2}%.",
                    Math.Truncate(sumLiters * 100 / V),
                    Math.Truncate(litersByPipe1 * 100 / sumLiters),
                    Math.Truncate(litersByPipe2 * 100 / sumLiters));
            }
        }
    }
}