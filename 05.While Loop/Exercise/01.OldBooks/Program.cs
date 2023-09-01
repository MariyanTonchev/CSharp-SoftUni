using System;

namespace _01.OldBooks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string book = Console.ReadLine();
            int count = 0;

            while (true)
            {
                string currentBook = Console.ReadLine();

                if (currentBook == "No More Books")
                {
                    Console.WriteLine("The book you search is not here!");
                    Console.WriteLine($"You checked {count} books.");
                    break;
                }

                if (book != currentBook)
                {
                    count++;
                }
                else
                {
                    Console.WriteLine($"You checked {count} books and found it.");
                    break;
                }
            }
        }
    }
}