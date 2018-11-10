using System;
using System.Collections.Generic;
using System.Text;

namespace SpeedRacing
{
    public class Car
    {
        private string model;
        private double fuelAmount;
        private double fuelPerKm;
        private int distanceTraveled;

        public Car(string model, double fuelAmount, double fuelPerKm)
        {
            this.Model = model;
            this.FuelAmount = fuelAmount;
            this.FuelPerKm = fuelPerKm;
            DistanceTraveled = 0;
        }

        public string Model
        {
            get { return model; }
            set { model = value; }
        }
        
        public double FuelAmount
        {
            get { return fuelAmount; }
            set { fuelAmount = value; }
        }
        
        public double FuelPerKm
        {
            get { return fuelPerKm; }
            set { fuelPerKm = value; }
        }
        
        public int DistanceTraveled
        {
            get { return distanceTraveled; }
            set { distanceTraveled = value; }
        }

        public void Drive(int distance)
        {
            if (distance * FuelPerKm <= FuelAmount)
            {
                DistanceTraveled += distance;
                FuelAmount -= distance * FuelPerKm;
            }
            else
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
        }
    }
}
