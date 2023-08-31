using System;

namespace _13.Notifications
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for(int i = 0; i < n; i++)
            {
                string messageType = Console.ReadLine();
                if(messageType == "error")
                {
                    string operation = Console.ReadLine();
                    string message = Console.ReadLine();
                    int errorCode = int.Parse(Console.ReadLine());
                    ShowErrorMessage(operation, message, errorCode);
                }
                else if(messageType == "warning")
                {
                    string message = Console.ReadLine();
                    ShowWarningMessage(message);
                }
                else if(messageType == "success")
                {
                    string operation = Console.ReadLine();
                    string message = Console.ReadLine();
                    ShowSuccessMessage(operation, message);
                }
                Console.WriteLine();
            }
        }

        static void ShowSuccessMessage(string operation, string message)
        {
            string successMessage = "Successfully executed " + operation + ".";
            Console.WriteLine(successMessage);
            Console.WriteLine("{0}", new string('=', successMessage.Length));
            Console.WriteLine(message + ".");
        }

        static void ShowWarningMessage(string message)
        {
            string warningMessage = "Warning: " + message + ".";
            Console.WriteLine(warningMessage);
            Console.WriteLine("{0}", new string('=', warningMessage.Length));
        }

        static void ShowErrorMessage(string operation, string message, int errorCode)
        {
            string errorMessage = "Error: Failed to execute " + operation + ".";
            Console.WriteLine(errorMessage);
            Console.WriteLine("{0}", new string('=', errorMessage.Length));
            Console.WriteLine("Reason: " + message + ".");
            Console.WriteLine("Error code: " + errorCode + ".");
        }
    }
}