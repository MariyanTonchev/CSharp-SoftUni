using System;

namespace _02.Password
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string username = Console.ReadLine();
            string password = Console.ReadLine();

            string enteredPassword = Console.ReadLine();

            while(password != enteredPassword)
            {
                enteredPassword = Console.ReadLine();
            }

            Console.WriteLine($"Welcome {username}!");
        }
    }
}