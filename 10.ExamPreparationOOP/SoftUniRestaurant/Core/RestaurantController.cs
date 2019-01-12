namespace SoftUniRestaurant.Core
{
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

        public RestaurantController()
        {
            this.foods = new List<IFood>();
            this.drinks = new List<IDrink>();
            this.tables = new List<ITable>();
        }

        public string AddFood(string type, string name, decimal price)
        {
            if (type == "Dessert")
            {
                food = new Dessert(name, price);
            }
            else if (type == "MainCourse")
            {
                food = new MainCourse(name, price);
            }
            else if (type == "Salad")
            {
                food = new Salad(name, price);
            }
            else if (type == "Soup")
            {
                food = new Soup(name, price);
            }
            
            foods.Add(food);
            return $"Added {name} ({type}) with price {price:f2} to the pool";
        }

        public string AddDrink(string type, string name, int servingSize, string brand)
        {
            if (type == "Alcohol")
            {
                drink = new Alcohol(name, servingSize, brand);
            }
            else if (type == "FuzzyDrink")
            {
                drink = new FuzzyDrink(name, servingSize, brand);
            }
            else if (type == "Juice")
            {
                drink = new Juice(name, servingSize, brand);
            }
            else if (type == "Water")
            {
                drink = new Water(name, servingSize, brand);
            }

            drinks.Add(drink);
            return $"Added {name} ({brand}) to the drink pool";
        }

        public string AddTable(string type, int tableNumber, int capacity)
        {
            if (type == "InsideTable")
            {
                table = new InsideTable(tableNumber, capacity);
            }
            else if (type == "OutsideTable")
            {
                table = new OutsideTable(tableNumber, capacity);
            }

            tables.Add(table);
            return $"Added table number {tableNumber} in the restaurant";
        }

        public string ReserveTable(int numberOfPeople)
        {
            if (tables.FirstOrDefault().Capacity >= numberOfPeople)
            {

                return $"Table {table.TableNumber} has been reserved for {numberOfPeople} people";
            }
            else
            {
                return $"No available table for {numberOfPeople} people";
            }
        }

        public string OrderFood(int tableNumber, string foodName)
        {
            if (!(table.TableNumber == tableNumber))
            {
                return $"Could not find table with {tableNumber}";
            }
            else if (food.Name == foodName)
            {
                return $"No {foodName} in the menu";
            }
            else
            {
                return $"Table {tableNumber} ordered {foodName}";
            }
        }

        public string OrderDrink(int tableNumber, string drinkName, string drinkBrand)
        {
            if (!(table.TableNumber == tableNumber))
            {
                return $"Could not find table with {tableNumber}";
            }
            else if (drink.Name == drinkName && drink.Brand == drinkBrand)
            {
                return $"There is no {drinkName} {drinkBrand} available";
            }
            else
            {
                return $"Table {tableNumber} ordered {drinkName} {drinkBrand}";
            }
        }

        public string LeaveTable(int tableNumber)
        {
            if (tableNumber == table.TableNumber)
            {
                var bill = table.GetBill();
                table.Clear();
            }
            return $"Table: {tableNumber}" + Environment.NewLine + "Bill: {bill:F2}";
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
