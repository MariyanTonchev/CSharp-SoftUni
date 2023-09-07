using System;

namespace _03.StopNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            int M = int.Parse(Console.ReadLine());
            int S = int.Parse(Console.ReadLine());

            for(int num = M; num >= N; num--)
            {
                if(num % 2 == 0 && num % 3 == 0)
                {
                    if (num == S)
                    {
                        break;
                    } 
                    Console.Write("{0} ", num);
                }
            }
        }
    }
}