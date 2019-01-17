namespace SoftUniRestaurant.Core
{
    using SoftUniRestaurant.Factories;
    using SoftUniRestaurant.Models.Drinks;
    using SoftUniRestaurant.Models.Drinks.Contracts;
    using SoftUniRestaurant.Models.Foods;
    using SoftUniRestaurant.Models.Foods.Contracts;
    using SoftUniRestaurant.Models.Tables;
    using SoftUniRestaurant.Models.Tables.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class RestaurantController
    {
        private List<IFood> foods;
        private List<ITable> tables;
        private List<IDrink> drinks;
        private FoodFactory foodFactory;
        private DrinkFactory drinkFactory;
        private TableFactory tableFactory;

        private Table currentTable;
        private Food currentFood;
        private Drink currentDrink;
        private decimal bill;
        private decimal totalIncome = 0.0m;

        public RestaurantController()
        {
            this.foods = new List<IFood>();
            this.drinks = new List<IDrink>();
            this.tables = new List<ITable>();
            this.foodFactory = new FoodFactory();
            this.drinkFactory = new DrinkFactory();
            this.tableFactory = new TableFactory();
        }

        public string AddFood(string type, string name, decimal price)
        {
            this.currentFood = this.foodFactory.CreateFood(type, name, price);
            foods.Add(this.currentFood);
            return $"Added {name} ({type}) with price {price:f2} to the pool";
        }

        public string AddDrink(string type, string name, int servingSize, string brand)
        {
            this.currentDrink = this.drinkFactory.CreateDrink(type, name, servingSize, brand);
            drinks.Add(this.currentDrink);
            return $"Added {name} ({brand}) to the drink pool";
        }

        public string AddTable(string type, int tableNumber, int capacity)
        {
            this.currentTable = this.tableFactory.CreateTable(type, tableNumber, capacity);
            tables.Add(this.currentTable);
            return $"Added table number {tableNumber} in the restaurant";
        }

        public string ReserveTable(int numberOfPeople)
        {
            foreach (var table in tables)
            {
                if (!table.IsReserved && table.Capacity >= numberOfPeople)
                {
                    table.IsReserved = true;
                    table.NumberOfPeople = numberOfPeople;
                    return $"Table {table.TableNumber} has been reserved for {numberOfPeople} people";
                }
            }

            return $"No available table for {numberOfPeople} people";

            //var checkTable = tables.Where(x => x.Capacity >= numberOfPeople).FirstOrDefault(x => x.IsReserved == false);

            //var checkTable = tables.FirstOrDefault(x => x.IsReserved == false);
            //if (checkTable.Capacity >= numberOfPeople) 
            //{
            //    checkTable.Reserve(numberOfPeople);
            //    tables[checkTable.TableNumber - 1].IsReserved = true;
            //    var reservedTable = checkTable.TableNumber;
            //    return $"Table {reservedTable} has been reserved for {numberOfPeople} people";
            //}
            //else
            //{
            //    return $"No available table for {numberOfPeople} people";

            //}
        }

        public string OrderFood(int tableNumber, string foodName)
        {

            foreach (var table in tables)
            {
                if (tableNumber == table.TableNumber)
                {
                    foreach (var food in foods)
                    {
                        if (food.Name == foodName)
                        {
                            table.OrderFood(food);
                            return $"Table {tableNumber} ordered {foodName}";
                        }
                    }

                    return $"No {foodName} in the menu";
                }
            }

            return $"Could not find table with {tableNumber}";

            //var table = tables[tableNumber - 1];

            //if (!tables.Any(x => x.TableNumber == tableNumber)) 
            //{
            //    return $"Could not find table with {tableNumber}";
            //}
            //else if (!foods.Any(x => x.Name == foodName))
            //{
            //    return $"No {foodName} in the menu";
            //}
            //else
            //{
            //    var currentFood = foods.FirstOrDefault(x => x.Name == foodName);
            //    table.OrderFood(currentFood);
            //    string result =  $"Table {tableNumber} ordered {foodName}";
            //    return result;
            //}
        }
        
        public string OrderDrink(int tableNumber, string drinkName, string drinkBrand)
        {
            foreach (var table in tables)
            {
                if (tableNumber == table.TableNumber)
                {
                    foreach (var drink in drinks)
                    {
                        if (drink.Name == drinkName)
                        {
                            table.OrderDrink(drink);
                            return $"Table {tableNumber} ordered {drinkName} {drinkBrand}";
                        }
                    }

                    return $"There is no {drinkName} {drinkBrand} available";
                }
            }
            return $"Could not find table with {tableNumber}";

            //var table = tables[tableNumber - 1];

            //if (!tables.Any(x => x.TableNumber == tableNumber))
            //{
            //    return $"Could not find table with {tableNumber}";
            //}
            //else if (currentDrink.Name != drinkName || currentDrink.Brand != drinkBrand)
            //{
            //    return $"There is no {drinkName} {drinkBrand} available";
            //}
            //else
            //{
            //    var currentDrink = drinks.FirstOrDefault(x => x.Name == drinkName);
            //    table.OrderDrink(currentDrink);
            //    string result = $"Table {tableNumber} ordered {drinkName} {drinkBrand}";
            //    return result;
            //}
        }

        public string LeaveTable(int tableNumber)
        {
            var table = tables.FirstOrDefault(x => x.TableNumber == tableNumber);
            this.bill = table.GetBill() + (table.PricePerPerson * table.NumberOfPeople);
            totalIncome += this.bill;
            table.Clear();

            return $"Table: {tableNumber}" + Environment.NewLine + $"Bill: {this.bill:F2}";
        }

        public string GetFreeTablesInfo()
        {
            var freeTables = tables.Where(x => x.IsReserved == false).ToList();
            StringBuilder sb = new StringBuilder();

            foreach (var table in freeTables)
            {
                sb.AppendLine(table.GetFreeTableInfo());
            }

            return sb.ToString().TrimEnd();
        }

        public string GetOccupiedTablesInfo()
        {
            var occupiedTables = tables.Where(x => x.IsReserved == true).ToList();
            StringBuilder sb = new StringBuilder();


            foreach (var table in occupiedTables)
            {
                sb.AppendLine(table.GetOccupiedTableInfo());
            }

            return sb.ToString().TrimEnd();
        }

        public string GetSummary()
        {
            string result = $"Total income: {this.totalIncome:F2}lv";
            return result;
        }

    }
}
