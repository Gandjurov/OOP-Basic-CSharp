using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StorageMaster.Core
{
    public class Engine
    {
        private StorageMaster storageMaster;
        private bool isRunning;

        public Engine(StorageMaster storageMaster)
        {
            this.storageMaster = storageMaster;
            this.isRunning = false;
        }

        public void Run()
        {
            this.isRunning = true;

            while (this.isRunning)
            {
                string line = Console.ReadLine();
                string[] tokens = line.Split();

                string command = tokens[0];
                string output = "";

                try
                {

                    string storageName = "";
                    int garageSlot = 0;


                    switch (command)
                    {
                        case "AddProduct":
                            string productType = tokens[1];
                            double productPrice = double.Parse(tokens[2]);
                            output = this.storageMaster.AddProduct(productType, productPrice);
                            break;

                        case "RegisterStorage":
                            string storageType = tokens[1];
                            storageName = tokens[2];
                            output = this.storageMaster.RegisterStorage(storageType, storageName);
                            break;

                        case "SelectVehicle":
                            storageName = tokens[1];
                            garageSlot = int.Parse(tokens[2]);
                            output = this.storageMaster.SelectVehicle(storageName, garageSlot);
                            break;

                        case "LoadVehicle":
                            output = this.storageMaster.LoadVehicle(tokens.Skip(1));
                            break;

                        case "SendVehicleTo":
                            string sourceName = tokens[1];
                            int sourceGarageSlot = int.Parse(tokens[2]);
                            string destinationName = tokens[3];

                            output = this.storageMaster.SendVehicleTo(sourceName, sourceGarageSlot, destinationName);
                            break;

                        case "UnloadVehicle":
                            storageName = tokens[1];
                            garageSlot = int.Parse(tokens[2]);

                            output = this.storageMaster.UnloadVehicle(storageName, garageSlot);
                            break;

                        case "GetStorageStatus":
                            storageName = tokens[1];
                            output = this.storageMaster.GetStorageStatus(storageName);
                            break;

                        case "END":
                            output = this.storageMaster.GetSummary();
                            this.isRunning = false;
                            break;
                    }
                }
                catch (InvalidOperationException ex)
                {
                    output = $"Error: {ex.Message}";
                }

                Console.WriteLine(output);
            }
        }
    }
}
