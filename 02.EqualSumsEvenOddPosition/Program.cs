using System;

namespace _02.EqualSumsEvenOddPosition
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());

            for(int num = n; num <= m; num++)
            {
                string currentNumber = num.ToString();
                int oddSum = 0;
                int evenSum = 0;
                for(int j = 0; j < currentNumber.Length; j++)
                {
                    int digit = int.Parse(currentNumber[j].ToString());
                    if(j % 2 == 0)
                    {
                        evenSum += digit;
                    }
                    else
                    {
                        oddSum += digit;
                    }
                }
                if(oddSum == evenSum)
                {
                    Console.Write(num + " ");
                }
            }
        }
    }
}