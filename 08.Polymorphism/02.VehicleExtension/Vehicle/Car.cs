using System;
using System.Collections.Generic;
using System.Text;

namespace VehicleExtension.Vehicle
{
    public class Car : Vehicle
    {
        private const double airCondConsumption = 0.9;

        public Car(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
            this.FuelConsumption += airCondConsumption;
        }
    }
}
