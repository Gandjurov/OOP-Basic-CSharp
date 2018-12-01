using StorageMaster.Factories;
using StorageMaster.Models.Products;
using StorageMaster.Models.Storages;
using StorageMaster.Models.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StorageMaster.Core
{
    public class StorageMaster
    {
        private Dictionary<string, Stack<Product>> products;
        private Dictionary<string, Storage> storages;

        private Vehicle currentVehicle;

        private ProductFactory productFactory;
        private StorageFactory storageFactory;

        public StorageMaster()
        {
            this.products = new Dictionary<string, Stack<Product>>();
            this.storages = new Dictionary<string, Storage>();
            this.productFactory = new ProductFactory();
            this.storageFactory = new StorageFactory();
        }

        public string AddProduct(string type, double price)
        {
            Product product = this.productFactory.CreateProduct(type, price);

            if (!this.products.ContainsKey(type))
            {
                this.products.Add(type, new Stack<Product>());
            }
            
            this.products[type].Push(product);

            string result = $"Added {type} to pool";
            return result;
        }

        public string RegisterStorage(string type, string name)
        {
            Storage storage = this.storageFactory.CreateStorage(type, name);

            this.storages.Add(name, storage);

            string result = $"Registered {name}";

            return result;
        }

        public string SelectVehicle(string storageName, int garageSlot)
        {
            Storage storage = this.storages[storageName];

            this.currentVehicle = storage.GetVehicle(garageSlot);

            string result = $"Selected {this.currentVehicle.GetType().Name}";
            return result;
        }

        public string LoadVehicle(IEnumerable<string> productNames)
        {
            int loadedProductsCount = 0;
            foreach (string productName in productNames)
            {
                if (this.currentVehicle.IsFull)
                {
                    break;
                }

                if (!this.products.ContainsKey(productName) || this.products[productName].Count == 0)
                {
                    throw new InvalidOperationException($"{productName} is out of stock!");
                }

                Product product = this.products[productName].Pop();

                this.currentVehicle.LoadProduct(product);
                loadedProductsCount++;
            }

            string result = $"Loaded {loadedProductsCount}/{productNames.Count()} products into {this.currentVehicle.GetType().Name}";
            return result;
        }

        public string SendVehicleTo(string sourceName, int sourceGarageSlot, string destinationName)
        {
            if (!this.storages.ContainsKey(sourceName))
            {
                throw new InvalidOperationException("Invalid source storage!");
            }

            if (!this.storages.ContainsKey(destinationName))
            {
                throw new InvalidOperationException("Invalid destination storage!");
            }

            Storage sourceStorage = this.storages[sourceName];
            Storage destinationStorage = this.storages[destinationName];
            Vehicle vehicle = sourceStorage.GetVehicle(sourceGarageSlot);

            int destinationGarageSlot = sourceStorage.SendVehicleTo(sourceGarageSlot, destinationStorage);

            string result = $"Sent {vehicle.GetType().Name} to {destinationName} (slot {destinationGarageSlot})";
            return result;
        }

        public string UnloadVehicle(string storageName, int garageSlot)
        {
            Storage storage = this.storages[storageName];
            int countProductsInVehicle = storage.GetVehicle(garageSlot).Trunk.Count;
            int unloadedProductsCount = storage.UnloadVehicle(garageSlot);

            string result = $"Unloaded {unloadedProductsCount}/{countProductsInVehicle} products at {storageName}";
            return result;
        }

        public string GetStorageStatus(string storageName)
        {
            Storage storage = this.storages[storageName];

            Dictionary<string, int> productsAndCount = new Dictionary<string, int>();

            foreach (Product product in storage.Products)
            {
                string productTypeName = product.GetType().Name;

                if (!productsAndCount.ContainsKey(productTypeName))
                {
                    productsAndCount.Add(productTypeName, 1);
                }
                else
                {
                    productsAndCount[productTypeName]++;
                }
            }

            double productsSum = storage.Products.Sum(p => p.Weight);
            int storageCapacity = storage.Capacity;

            string[] productsAsStrings = productsAndCount
                                                        .OrderByDescending(p => p.Value)
                                                        .ThenBy(p => p.Key)
                                                        .Select(kvp => $"{kvp.Key} ({kvp.Value})")
                                                        .ToArray();

            string stockLine = $"Stock ({productsSum}/{storageCapacity}): [{string.Join(", ", productsAsStrings)}]";

            string[] storageStringRepresentation = storage
                                                    .Garage
                                                    .Select(g => g == null ? "empty" : g.GetType().Name)
                                                    .ToArray();

            string garageLine = $"Garage: [{string.Join("|", storageStringRepresentation)}]";

            string result = stockLine +
                            Environment.NewLine +
                            garageLine;

            return result;
        }

        public string GetSummary()
        {
            Storage[] sortedStorages = this.storages
                                            .Select(s => s.Value)
                                            .OrderByDescending(s => s.Products.Sum(p => p.Price))
                                            .ToArray();

            StringBuilder sb = new StringBuilder();

            foreach (Storage storage in sortedStorages)
            {
                double totalMoney = storage.Products.Sum(p => p.Price);

                sb.AppendLine($"{storage.Name}:");
                sb.AppendLine($"Storage worth: ${totalMoney:F2}");
            }

            string result = sb.ToString().TrimEnd();
            return result;
        }

    }
}
