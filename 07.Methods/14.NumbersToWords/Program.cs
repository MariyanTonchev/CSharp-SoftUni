using System;

namespace _14.NumbersToWords
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for(int i = 0; i < n; i++)
            {
                int number = int.Parse(Console.ReadLine());
                Console.WriteLine(Letterize(number));
            }
        }

        static string Letterize(int number)
        {
            string[] ones = { "", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            string[] tens = { "", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };
            string[] teens = { "", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };

            string result = "";

            if (number > 999)
            {
                return "too large";
            }

            if(number < -999) 
            {
                return "too small";
            }

            if (number < 0)
            {
                result = "minus ";
                number = Math.Abs(number);
            }

            int hundreds = (number / 100) % 10;
            int tensDigit = (number / 10) % 10;
            int onesDigit = number % 10;

            if (hundreds > 0)
            {
                result += ones[hundreds] + "-hundred";
                if (tensDigit > 0 || onesDigit > 0)
                {
                    result += " and ";
                }
            }

            if (tensDigit > 1)
            {
                result += tens[tensDigit];
                if (onesDigit > 0)
                {
                    result += " " + ones[onesDigit];
                }    
            }
            else if (tensDigit == 1)
            {
                result += teens[onesDigit];
            }
            else if (onesDigit > 0)
            {
                result += ones[onesDigit];
            }

            return result;
        }
    }
}