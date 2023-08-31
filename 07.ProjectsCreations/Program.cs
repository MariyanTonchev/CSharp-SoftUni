using System;
    
    namespace _07.ProjectsCreations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int numberOfProject = int.Parse(Console.ReadLine());
            int neededHours = numberOfProject * 3;

            Console.WriteLine($"The architect {name} will need {neededHours} hours to complete {numberOfProject} project/s.");
        }
    }
}