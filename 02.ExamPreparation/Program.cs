using System;

namespace _02.ExamPreparation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int badEvaluations = int.Parse(Console.ReadLine());
            int sumOfEvaluations = 0;
            int numberOfExercises = 0;
            int countBadEvalutions = 0;
            string lastExercise = "";

            string exercise = Console.ReadLine();
            

            while (exercise != "Enough")
            {
                int evaluation = int.Parse(Console.ReadLine());
                sumOfEvaluations += evaluation;

                if(evaluation <= 4)
                {
                    countBadEvalutions++;
                }

                if(badEvaluations == countBadEvalutions)
                {
                    Console.WriteLine($"You need a break, {countBadEvalutions} poor grades.");
                    break;
                }

                numberOfExercises++;

                lastExercise = exercise;
                exercise = Console.ReadLine();
            }

            if (exercise == "Enough")
            {
                Console.WriteLine($"Average score: {sumOfEvaluations * 1.0 / numberOfExercises * 1.0:F2}");
                Console.WriteLine($"Number of problems: {numberOfExercises}");
                Console.WriteLine($"Last problem: {lastExercise}");
            }
        }
    }
}