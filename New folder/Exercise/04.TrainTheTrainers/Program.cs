using System;

namespace _04.TrainTheTrainers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int peopleInJury = int.Parse(Console.ReadLine());
            double courseGrade = 0;
            int presentions = 0;

            while (true)
            {
                string nameOfPresentation = Console.ReadLine();
                if(nameOfPresentation == "Finish")
                {
                    break;
                }
                presentions++;
                double averageGrade = 0;

                for(int i = 0; i < peopleInJury; i++)
                {
                    double grade = double.Parse(Console.ReadLine());
                    averageGrade += grade;
                }

                averageGrade /= peopleInJury;
                courseGrade += averageGrade;
                Console.WriteLine($"{nameOfPresentation} - {averageGrade:F2}.");
            }

            Console.WriteLine($"Student's final assessment is {courseGrade / presentions:F2}.");
        }
    }
}