using System;

namespace DateModifier
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string date1 = Console.ReadLine();
            string date2 = Console.ReadLine();

            DateModifier dateModifier = new DateModifier();

            var dateResult = dateModifier.CalculateDiffence(date1, date2);

            Console.WriteLine(dateResult);
        }
    }
}
