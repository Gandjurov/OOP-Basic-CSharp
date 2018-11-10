namespace SimpleSnake
{
    using SimpleSnake.GameObjects;
    using Utilities;
    using System;

    public class StartUp
    {
        public static void Main()
        {
            Wall wall = new Wall(60, 20);
            Console.ReadLine();

            ConsoleWindow.CustomizeConsole();
        }
    }
}
