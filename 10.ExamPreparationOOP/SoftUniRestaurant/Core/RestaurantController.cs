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
            return $"Added {name} ({this.currentDrink.Brand}) to the drink pool";
        }

        public string AddTable(string type, int tableNumber, int capacity)
        {
            this.currentTable = this.tableFactory.CreateTable(type, tableNumber, capacity);
            tables.Add(this.currentTable);
            return $"Added table number {tableNumber} in the restaurant";
        }

        public string ReserveTable(int numberOfPeople)
        {
            var checkTable = tables.Where(x => x.Capacity >= numberOfPeople).FirstOrDefault(x => x.IsReserved == false);

            if (checkTable.IsReserved == false) 
            {
                checkTable.Reserve(numberOfPeople);
                tables[checkTable.TableNumber - 1].IsReserved = true;
                var reservedTable = checkTable.TableNumber;
                return $"Table {reservedTable} has been reserved for {numberOfPeople} people";
            }
            else
            {
                return $"No available table for {numberOfPeople} people";

            }
        }

        public string OrderFood(int tableNumber, string foodName)
        {
            var table = tables[tableNumber];

            if (!tables.Any(x => x.TableNumber == tableNumber)) 
            {
                return $"Could not find table with {tableNumber}";
            }
            else if (!foods.Any(x => x.Name == foodName))
            {
                return $"No {foodName} in the menu";
            }
            else
            {
                table.OrderFood(this.currentFood);
                return $"Table {tableNumber} ordered {foodName}";
            }
        }

        public string OrderDrink(int tableNumber, string drinkName, string drinkBrand)
        {
            var table = tables[tableNumber];

            if (!tables.Any(x => x.TableNumber == tableNumber))
            {
                return $"Could not find table with {tableNumber}";
            }
            else if (currentDrink.Name != drinkName || currentDrink.Brand != drinkBrand)
            {
                return $"There is no {drinkName} {drinkBrand} available";
            }
            else
            {
                table.OrderDrink(this.currentDrink);
                return $"Table {tableNumber} ordered {drinkName} {drinkBrand}";
            }
        }

        public string LeaveTable(int tableNumber)
        {
            if (this.currentTable.TableNumber == tableNumber)
            {
                bill = this.currentTable.GetBill();
                this.currentTable.Clear();
            }

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
            var freeTables = tables.Where(x => x.IsReserved == true).ToList();
            StringBuilder sb = new StringBuilder();


            foreach (var table in freeTables)
            {
                sb.AppendLine(table.GetOccupiedTableInfo());
            }

            return sb.ToString().TrimEnd();
        }

        public string GetSummary()
        {
            decimal totalIncome = 0.0m;

            foreach (var table in tables.Where(x => x.IsReserved))
            {
                totalIncome += table.GetBill();
            }

            string result = $"Total income: {totalIncome:F2}lv";
            return result;
        }

    }
}
