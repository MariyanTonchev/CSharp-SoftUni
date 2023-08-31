using System;

namespace _15.StringEncryption
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string result = string.Empty;

            for (int i = 0; i < n; i++)
            {
                char letter = char.Parse(Console.ReadLine());
                result += Encrypt(letter);
            }

            Console.WriteLine(result);
        }

        static string Encrypt(char letter)
        {
            int AsciiCode = letter;
            int lastDigit;
            int firstDigit;
            if (AsciiCode > 99)
            {
                firstDigit = (AsciiCode / 100) % 10;
                lastDigit = AsciiCode % 10;
            }
            else
            {
                firstDigit = AsciiCode / 10;
                lastDigit = AsciiCode % 10;
            }

            string result = firstDigit.ToString() + lastDigit.ToString();

            int AsciiCodePlusLastDigit = AsciiCode + lastDigit;
            result = (char)AsciiCodePlusLastDigit + result;

            int AsciiCodeMinusFirstDigit = AsciiCode - firstDigit;
            result += (char)AsciiCodeMinusFirstDigit;

            return result;
        }
    }
}