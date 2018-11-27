using System;
using System.Collections.Generic;
using System.Text;

namespace VehicleExtension.Vehicle
{
    public class Truck : Vehicle
    {
        private const double airCondConsumption = 1.6;

        public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
            this.FuelConsumption += airCondConsumption;
        }

        public override void Refuel(double fuel)
        {
            if (fuel <= 0)
            {
                Console.WriteLine($"Fuel must be a positive number");
            }

            if (this.FuelQuantity + fuel > this.TankCapacity)
            {
                Console.WriteLine($"Cannot fit {fuel} fuel in the tank");
            }

            this.FuelQuantity += fuel * 0.95;
        }
    }
}
