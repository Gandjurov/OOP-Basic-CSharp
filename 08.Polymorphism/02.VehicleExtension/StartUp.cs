﻿using System;
using VehicleExtension.Core;

namespace VehicleExtension
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Engine engine = new Engine();
            engine.Run();
        }
    }
}
