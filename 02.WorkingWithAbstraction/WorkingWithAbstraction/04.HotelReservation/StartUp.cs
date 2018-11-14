using System;

namespace HotelReservation
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var input = Console.ReadLine()
            .Split();
            var priceCalculator = new PriceCalculator(input);

            Console.WriteLine(priceCalculator.GetTotalPrice().ToString("F2"));
        }
    }
}
