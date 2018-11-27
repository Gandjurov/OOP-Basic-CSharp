using System;
using System.Collections.Generic;
using System.Text;
using VehicleExtension.Vehicle;
using VehicleExtension.Vehicle.Contracts;

namespace VehicleExtension.Core
{
    public class Engine
    {
        public void Run()
        {
            string[] carInfo = Console.ReadLine().Split();
            string[] truckInfo = Console.ReadLine().Split();
            string[] busInfo = Console.ReadLine().Split();

            double carFuelQuantity = double.Parse(carInfo[1]);
            double carFuelConsumption = double.Parse(carInfo[2]);
            double carTankCapacity = double.Parse(carInfo[3]);

            double truckFuelQuantity = double.Parse(truckInfo[1]);
            double truckFuelConsumption = double.Parse(truckInfo[2]);
            double truckTankCapacity = double.Parse(truckInfo[3]);

            double busFuelQuantity = double.Parse(busInfo[1]);
            double busFuelConsumption = double.Parse(busInfo[2]);
            double busTankCapacity = double.Parse(busInfo[3]);

            IVehicle car = new Car(carFuelQuantity, carFuelConsumption, carTankCapacity);
            IVehicle truck = new Truck(truckFuelQuantity, truckFuelConsumption, truckTankCapacity);
            IVehicle bus = new Bus(busFuelQuantity, busFuelConsumption, busTankCapacity);

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                try
                {
                    string[] inputArgs = Console.ReadLine().Split();

                    string action = inputArgs[0];
                    string vehicleType = inputArgs[1];
                    double value = double.Parse(inputArgs[2]);

                    if (action == "Refuel")
                    {
                        if (vehicleType == "Car")
                        {
                            car.Refuel(value);
                        }
                        else if (vehicleType == "Truck")
                        {
                            truck.Refuel(value);
                        }
                        else if (vehicleType == "Bus")
                        {
                            bus.Refuel(value);
                        }
                    }
                    else if (action == "Drive")
                    {
                        if (vehicleType == "Car")
                        {
                            car.Drive(value);
                        }
                        else if (vehicleType == "Truck")
                        {
                            truck.Drive(value);
                        }
                        else if (vehicleType == "Bus")
                        {
                            bus.IsVehicleEmpty = false;
                            bus.Drive(value);
                        }
                    }
                    else if (action == "DriveEmpty")
                    {
                        bus.IsVehicleEmpty = true;
                        bus.Drive(value);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }

            Console.WriteLine(car);
            Console.WriteLine(truck);
            Console.WriteLine(bus);

        }
    }
}
