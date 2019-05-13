namespace PlayersAndMonsters.IO
{
    using PlayersAndMonsters.IO.Contracts;
    using System;

    public class Writer : IWriter
    {
        public void WriteLine(string message)
        {
            Console.WriteLine(message);
        }

        public void Write(string message)
        {
            Console.Write(message);
        }
    }
}
