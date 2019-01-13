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
            if (this.currentTable.IsReserved == false)
            {
                this.currentTable.Reserve(numberOfPeople);
                return $"Table {this.currentTable.TableNumber} has been reserved for {numberOfPeople} people";
            }
            else
            {
                return $"No available table for {numberOfPeople} people";
            }
        }

        public string OrderFood(int tableNumber, string foodName)
        {
            if (!(this.currentTable.TableNumber == tableNumber))
            {
                return $"Could not find table with {tableNumber}";
            }
            else if (currentFood.Name != foodName)
            {
                return $"No {foodName} in the menu";
            }
            else
            {
                this.currentTable.OrderFood(this.currentFood);
                return $"Table {tableNumber} ordered {foodName}";
            }
        }

        public string OrderDrink(int tableNumber, string drinkName, string drinkBrand)
        {
            if (!(this.currentTable.TableNumber == tableNumber))
            {
                return $"Could not find table with {tableNumber}";
            }
            else if (currentDrink.Name == drinkName && currentDrink.Brand == drinkBrand)
            {
                return $"There is no {drinkName} {drinkBrand} available";
            }
            else
            {
                this.currentTable.OrderDrink(this.currentDrink);
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
            string resultInfo = string.Empty;

            foreach (var table in tables.Where(x => !x.IsReserved))
            {
                resultInfo = table.GetFreeTableInfo();
            }

            return resultInfo;
        }

        public string GetOccupiedTablesInfo()
        {
            string resultInfo = string.Empty;

            foreach (var table in tables.Where(x => x.IsReserved))
            {
                resultInfo = table.GetOccupiedTableInfo();
            }

            return resultInfo;
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
