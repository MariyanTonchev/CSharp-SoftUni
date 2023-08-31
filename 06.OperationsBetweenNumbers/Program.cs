using System;

namespace _06.OperationsBetweenNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int N1 = int.Parse(Console.ReadLine());
            int N2 = int.Parse(Console.ReadLine());
            char operation = char.Parse(Console.ReadLine());
            string evenOrOdd;
            switch (operation)
            {
                case '+':
                    if ((N1 + N2) % 2 == 0)
                    {
                        evenOrOdd = "even";
                    }
                    else
                    {
                        evenOrOdd = "odd";
                    }
                    Console.WriteLine($"{N1} + {N2} = {N1 + N2} - {evenOrOdd}");
                    break;
                case '-':
                    if ((N1 + N2) % 2 == 0)
                    {
                        evenOrOdd = "even";
                    }
                    else
                    {
                        evenOrOdd = "odd";
                    }
                    Console.WriteLine($"{N1} - {N2} = {N1 - N2} - {evenOrOdd}");
                    break;
                case '*':
                    if ((N1 * N2) % 2 == 0)
                    {
                        evenOrOdd = "even";
                    }
                    else
                    {
                        evenOrOdd = "odd";
                    }
                    Console.WriteLine($"{N1} * {N2} = {N1 * N2} - {evenOrOdd}");
                    break;
                case '/':
                    if(N2 == 0)
                    {
                        Console.WriteLine($"Cannot divide {N1} by zero");
                    }
                    else
                    {
                        Console.WriteLine($"{N1} / {N2} = {(double)N1 / N2:F2}");
                    }
                    break;
                case '%':
                    if (N2 == 0)
                    {
                        Console.WriteLine($"Cannot divide {N1} by zero");
                    }
                    else
                    {
                        Console.WriteLine($"{N1} % {N2} = {N1 % N2}");
                    }
                    break;
            }
        }
    }
}