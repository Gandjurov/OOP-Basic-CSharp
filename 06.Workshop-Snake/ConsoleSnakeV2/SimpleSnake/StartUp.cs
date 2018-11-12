namespace SimpleSnake
{
    using SimpleSnake.GameObjects;
    using Utilities;
    using System;
    using SimpleSnake.GameObjects.Foods;
    using System.Collections.Generic;
    using System.Threading;
    using SimpleSnake.Core;

    public class StartUp
    {
        public static void Main()
        {
            ConsoleWindow.CustomizeConsole();

            Wall wall = new Wall(60, 20);
            Snake snake = new Snake(wall);

            Engine engine = new Engine(snake, wall);
            engine.Run();
        }
    }
}
