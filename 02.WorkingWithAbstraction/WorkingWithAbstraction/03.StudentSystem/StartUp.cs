using System;

namespace StudentSystem
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            StudentSystem system = new StudentSystem();

            while (true)
            {
                string command = Console.ReadLine();
                system.ParseCommand(command);
            }
        }
    }
}
