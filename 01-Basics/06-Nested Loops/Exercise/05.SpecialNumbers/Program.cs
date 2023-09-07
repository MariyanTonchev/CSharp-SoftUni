using System;

namespace _05.SpecialNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());

            for(int i = 1111; i <= 9999; i++)
            {
                string num = i.ToString();
                int count = 0;

                for(int j = 0; j < num.Length; j++)
                {
                    int digit = int.Parse(num[j].ToString());

                    if((j == 1 && count == 0) || digit == 0)
                    {
                        break;
                    }

                    if(N % digit == 0)
                    {
                        count++;
                    }
                }

                if (count == 4)
                {
                    Console.Write(i + " ");
                }
            }
        }
    }
}