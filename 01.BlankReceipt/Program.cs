using System;

namespace _01.BlankReceipt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PrintReceipt();
        }

        static void PrintHeader()
        {
            Console.WriteLine("CASH RECEIPT");
            Console.WriteLine("------------------------------");
        }

        static void PrintContent()
        {
            Console.WriteLine("Charged to____________________");
            Console.WriteLine("Received by___________________");
        }

        static void PrintFooter()
        {
            Console.WriteLine("------------------------------");
            Console.WriteLine("(c) SoftUni");
        }

        static void PrintReceipt()
        {
            PrintHeader();
            PrintContent();
            PrintFooter();
        }
    }
}

