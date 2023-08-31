using System;

namespace _03.Stop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int dots = n + 1;
            int underscopes = n * 2 + 1;
            Console.WriteLine("{0}{1}{0}", new string('.', dots), new string('_', underscopes));
            dots--;
            underscopes -= 2;
            for(int i = 0; i < n; i++)
            {
                Console.WriteLine("{0}//{1}\\\\{0}", new string('.', dots), new string('_', underscopes));
                dots--;
                underscopes += 2;
            }
            int mid = (underscopes - 5) / 2;
            Console.WriteLine("//{0}{1}{0}\\\\", new string('_', mid), "STOP!");
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("{0}\\\\{1}//{0}", new string('.', dots), new string('_', underscopes));
                dots++;
                underscopes -= 2;
            }
        }
    }
}