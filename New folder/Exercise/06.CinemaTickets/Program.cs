using System;

namespace CinemaTickets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int countStandardTickets = 0;
            int countStudentTickets = 0;
            int countKidTickets = 0;
            bool finished = false;

            while (true)
            {
                if (finished)
                {
                    break;
                }

                string movie = Console.ReadLine();

                if (movie == "Finish")
                {
                    break;
                }



                int freeSeats = int.Parse(Console.ReadLine());
                int countTickets = 0;

                while (true)
                {
                    string ticketType = Console.ReadLine();

                    if (ticketType == "End")
                    {
                        break;
                    }

                    if (ticketType == "Finish")
                    {
                        finished = true;
                        break;
                    }

                    countTickets++;

                    switch (ticketType)
                    {
                        case "standard":
                            countStandardTickets++;
                            break;
                        case "student":
                            countStudentTickets++;
                            break;
                        case "kid":
                            countKidTickets++;
                            break;
                    }

                    if (countTickets == freeSeats)
                    {
                        break;
                    }
                }

                double occupancyPercentage = countTickets * 100.0 / freeSeats;
                Console.WriteLine($"{movie} - {occupancyPercentage:F2}% full.");
            }

            int allTickets = countStandardTickets + countStudentTickets + countKidTickets;
            double percentageStudentTickets = countStudentTickets * 100.0 / allTickets;
            double percentageStandardTickets = countStandardTickets * 100.0 / allTickets;
            double percentageKidTickets = countKidTickets * 100.0 / allTickets;

            Console.WriteLine($"Total tickets: {allTickets}");
            Console.WriteLine($"{percentageStudentTickets:F2}% student tickets.");
            Console.WriteLine($"{percentageStandardTickets:F2}% standard tickets.");
            Console.WriteLine($"{percentageKidTickets:F2}% kids tickets.");
        }
    }
}