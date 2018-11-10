using System;
using System.Collections.Generic;

namespace SpeedRacing
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                string model = tokens[0];
                double fuel = double.Parse(tokens[1]);
                double perKm = double.Parse(tokens[2]);

                Car car = new Car(model, fuel, perKm);
                cars.Add(car);
            }

            string inputLine = Console.ReadLine();

            while (inputLine != "End")
            {
                string[] tokens = inputLine
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                string model = tokens[1];
                int distance = int.Parse(tokens[2]);

                foreach (var car in cars)
                {
                    if (car.Model == model)
                    {
                        car.Drive(distance);
                    }
                    
                }

                inputLine = Console.ReadLine();
            }

            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:F2} {car.DistanceTraveled}");
            }
        }
    }
}
