using System;

namespace _04.Hospital
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int doctors = 7;

            int period = int.Parse(Console.ReadLine());
            int untreated = 0;
            int treated = 0;

            for(int day = 1; day <= period; day++)
            {
                int patients = int.Parse(Console.ReadLine());

                if (day % 3 == 0)
                {
                    if (untreated > treated)
                    {
                        doctors++;
                    }
                }

                if (patients <= doctors)
                {
                    treated += patients;
                }
                else if(patients > doctors)
                {
                    treated += doctors;
                    untreated += patients - doctors;
                }


            }

            Console.WriteLine($"Treated patients: {treated}.");
            Console.WriteLine($"Untreated patients: {untreated}.");
        }
    }
}