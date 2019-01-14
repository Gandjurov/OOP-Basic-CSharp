using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftUniRestaurant.Core
{
    public class Engine
    {
        private RestaurantController restaurantController;

        public Engine()
        {
            this.restaurantController = new RestaurantController();
        }

        
        public void Run()
        {
            string input = Console.ReadLine();

            while (input != "END")
            {
                string[] inputArgs = input.Split();
                string command = inputArgs[0];

                string[] args = inputArgs.Skip(1).ToArray();

                string result = string.Empty;

                try
                {
                    switch (command)
                    {
                        case "AddFood":
                            string type = args[0];
                            string name = args[1];
                            decimal price = decimal.Parse(args[2]);

                            result = restaurantController.AddFood(type, name, price);
                            break;

                        case "AddDrink":
                            type = args[0];
                            name = args[1];
                            var servingSize = int.Parse(args[2]);
                            var brand = args[3];

                            result = restaurantController.AddDrink(type, name, servingSize, brand);
                            break;

                        case "AddTable":
                            type = args[0];
                            int tableNumber = int.Parse(args[1]);
                            int capacity = int.Parse(args[2]);

                            result = restaurantController.AddTable(type, tableNumber, capacity);
                            break;

                        case "ReserveTable":
                            int numberOfPeople = int.Parse(args[0]);

                            result = restaurantController.ReserveTable(numberOfPeople);
                            break;

                        case "OrderFood":
                            tableNumber = int.Parse(args[0]);
                            string foodName = args[1];

                            result = restaurantController.OrderFood(tableNumber, foodName);
                            break;

                        case "OrderDrink":
                            tableNumber = int.Parse(args[0]);
                            string drinkName = args[1];
                            string drinkBrand = args[2];

                            result = restaurantController.OrderDrink(tableNumber, drinkName, drinkBrand);
                            break;
                            
                        case "LeaveTable":
                            tableNumber = int.Parse(args[0]);

                            result = restaurantController.LeaveTable(tableNumber);
                            break;

                        case "GetFreeTablesInfo":
                            result = restaurantController.GetFreeTablesInfo();
                            break;
                            
                        case "GetOccupiedTablesInfo":
                            result = restaurantController.GetOccupiedTablesInfo();
                            break;
                    }

                    Console.WriteLine(result);
                }

                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }

                input = Console.ReadLine();
            }
        }
    }
}
