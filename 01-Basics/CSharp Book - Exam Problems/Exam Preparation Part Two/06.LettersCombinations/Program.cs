using System;

namespace _06.LettersCombinations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char firstSymbol = char.Parse(Console.ReadLine());
            char secondSymvol = char.Parse(Console.ReadLine());
            char skipSymbol = char.Parse(Console.ReadLine());
            int count = 0;

            for(char i = firstSymbol; i <= secondSymvol; i++)
            {
                if(i == skipSymbol)
                {
                    continue;
                }
                for(char j = firstSymbol; j <= secondSymvol; j++)
                {
                    if(j == skipSymbol)
                    {
                        continue;
                    }
                    for (char k = firstSymbol; k <= secondSymvol; k++)
                    {
                        if(k == skipSymbol)
                        {
                            continue;
                        }
                        Console.Write("{0}{1}{2} ", i, j, k);
                        count++;
                    }
                }
            }

            Console.Write(count);
        }
    }
}