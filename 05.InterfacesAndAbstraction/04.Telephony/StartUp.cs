using System;

namespace Telephony
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Smartphone smartphone = new Smartphone();

            string[] inputNumbers = Console.ReadLine().Split();
            string[] inputUrls = Console.ReadLine().Split();

            for (int i = 0; i < inputNumbers.Length; i++)
            {
                smartphone.Call(inputNumbers[i]);
            }

            for (int i = 0; i < inputUrls.Length; i++)
            {
                smartphone.Browse(inputUrls[i]);
            }
        }
    }
}
