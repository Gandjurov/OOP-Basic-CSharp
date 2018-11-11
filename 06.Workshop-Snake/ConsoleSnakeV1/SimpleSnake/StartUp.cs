namespace SimpleSnake
{
    using SimpleSnake.GameObjects;
    using Utilities;
    using System;
    using SimpleSnake.GameObjects.Foods;
    using System.Collections.Generic;
    using System.Threading;

    public class StartUp
    {
        public static void Main()
        {
            Thread.Sleep(5000);
            Console.WriteLine("Zdrasti");
            Console.ReadLine();

            Wall wall = new Wall(60, 20);
            
            ConsoleWindow.CustomizeConsole();
        }
    }
}
