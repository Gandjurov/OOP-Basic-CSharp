using AnimalCentre.Core;
using AnimalCentre.IO;
using System;

namespace AnimalCentre
{
    public class StartUp
    {
        public static void Main()
        {
            IReader reader = new Reader();
            IWriter writer = new Writer();

            var engine = new Engine(reader, writer);
            engine.Run();
        }
    }
}
