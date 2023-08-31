using System;

namespace _04.Grades
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int students = int.Parse(Console.ReadLine());

            int topStudentsCount = 0;
            int goodStudentsCount = 0;
            int averageStudentsCount = 0;
            int failStudentsCount = 0;

            double gradesSum = 0;
            
            for(int i = 0; i < students; i++)
            {
                double grade = double.Parse(Console.ReadLine());
                gradesSum += grade;

                if(grade >= 2.00 && grade <= 2.99)
                {
                    failStudentsCount++;
                }
                else if(grade >= 3.00 && grade <= 3.99)
                {
                    averageStudentsCount++;
                }
                else if(grade >= 4.00 && grade <= 4.99)
                {
                    goodStudentsCount++;
                }
                else
                {
                    topStudentsCount++;
                }
            }

            Console.WriteLine("Top students: {0:f2}%", (double)topStudentsCount * 100 / students);
            Console.WriteLine("Between 4.00 and 4.99: {0:f2}%", (double)goodStudentsCount * 100 / students);
            Console.WriteLine("Between 3.00 and 3.99: {0:f2}%", (double)averageStudentsCount * 100 / students);
            Console.WriteLine("Fail: {0:f2}%", (double)failStudentsCount * 100 / students);
            Console.WriteLine("Average: {0:f2}", gradesSum / students);
        }
    }
}