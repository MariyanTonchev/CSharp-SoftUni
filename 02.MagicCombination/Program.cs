using System;

namespace _02.MagicCombination
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int magicNumber = int.Parse(Console.ReadLine());

            for(int n1 = 0; n1 <= 9; n1++)
            {
                for(int n2 = 0; n2 <= 9; n2++)
                {
                    for (int n3 = 0;n3 <= 9; n3++)
                    {
                        for(int n4 = 0;n4 <= 9;n4++)
                        {
                            for(int n5=0;n5 <= 9; n5++)
                            {
                                for(int n6=0;n6 <= 9; n6++)
                                {
                                    if(n1 * n2 * n3 * n4 * n5 * n6 == magicNumber)
                                    {
                                        Console.Write("{0}{1}{2}{3}{4}{5} ", n1, n2, n3, n4, n5, n6);
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}