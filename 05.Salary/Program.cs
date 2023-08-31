using System;

namespace _05.Salary
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int openedTabs = int.Parse(Console.ReadLine());
            int salary = int.Parse(Console.ReadLine());

            for (int i = 0; i <= openedTabs; i++)
            {
                string tab = Console.ReadLine();

                switch (tab)
                {
                    case "Facebook":
                        salary -= 150;
                        break;
                    case "Instagram":
                        salary -= 100;
                        break;
                    case "Reddit":
                        salary -= 60;
                        break;
                }

                if (salary <= 0)
                {
                    Console.WriteLine($"You have lost your salary.");
                    break;
                }
            }

            if (salary > 0)
            {
                Console.WriteLine(salary);
            }

        }
    }
}