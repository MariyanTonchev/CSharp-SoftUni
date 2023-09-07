using System;

namespace _07.GreateOfTwoValues
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string type = Console.ReadLine();

            if(type == "int")
            {
                int input1 = int.Parse(Console.ReadLine());
                int input2 = int.Parse(Console.ReadLine());
                GetMax(input1, input2);
            }
            else if(type == "char") 
            { 
                char input1 = char.Parse(Console.ReadLine());
                char input2 = char.Parse(Console.ReadLine());
                GetMax(input1, input2);
            }
            else if(type == "string")
            {
                string input1 = Console.ReadLine();
                string input2 = Console.ReadLine();
                GetMax(input1, input2);
            }
        }

        static void GetMax(string first, string second)
        {
            if(first.CompareTo(second) >= 0)
            {
                Console.WriteLine(first);
            }
            else
            {
                Console.WriteLine(second);
            }
        }

        static void GetMax(char first, char second)
        {
            if(first >= second)
            {
                Console.WriteLine(first);
            }
            else
            {
                Console.WriteLine(second);
            }
        }

        static void GetMax(int first, int second)
        {
            if (first >= second)
            {
                Console.WriteLine(first);
            }
            else
            {
                Console.WriteLine(second);
            }
        }
    }
}