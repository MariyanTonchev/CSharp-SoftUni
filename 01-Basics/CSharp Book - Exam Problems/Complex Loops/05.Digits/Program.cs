using System;

namespace _05.Digits
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int inputNumber = int.Parse(Console.ReadLine());

            int firstDigit = inputNumber / 100;
            int secondDigit = inputNumber / 10 % 10;
            int thirdDigit = inputNumber % 10;

            int N = firstDigit + secondDigit;
            int M = firstDigit + thirdDigit;

            for(int i = 0; i < N; i++)
            {
                for(int j = 0; j < M; j++)
                {
                    if(inputNumber % 5 == 0)
                    {
                        inputNumber -= firstDigit;
                    } 
                    else if(inputNumber % 3 == 0)
                    {
                        inputNumber -= secondDigit;
                    }
                    else
                    {
                        inputNumber += thirdDigit;
                    }
                    Console.Write("{0} ", inputNumber);
                }
                Console.WriteLine();
            }
        }
    }
}