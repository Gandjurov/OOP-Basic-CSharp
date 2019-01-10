using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalCentre.IO
{
    public class Reader : IReader
    {
        public string readData()
        {
            return Console.ReadLine();
        }
    }
}
