using System;

namespace _08.Graduation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int grade = 1;
            double sumOfEvaluations = 0;
            int undergGrade = 0;

            while (grade <= 12)
            {
                double evaluation = double.Parse(Console.ReadLine());
                if(evaluation < 4 && undergGrade == 1)
                {
                    Console.WriteLine($"{name} has been excluded at {grade} grade");
                    break;
                }
                else
                {
                    if(evaluation < 4)
                    {
                        undergGrade++;
                    }
                    else
                    {
                        grade++;
                        sumOfEvaluations += evaluation;
                    }
                }
            }

            if (undergGrade != 1)
            {
                Console.WriteLine($"{name} graduated. Average grade: {sumOfEvaluations/12.0:F2}");
            }
        }
    }
}