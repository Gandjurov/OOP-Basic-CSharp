﻿using SoftUniRestaurant.Models.Drinks;
using SoftUniRestaurant.Models.Drinks.Contracts;
using SoftUniRestaurant.Models.Foods;
using SoftUniRestaurant.Models.Foods.Contracts;
using SoftUniRestaurant.Models.Tables.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftUniRestaurant.Models.Tables
{
    public abstract class Table : ITable
    {
        private List<IFood> foodOrders;
        private List<IDrink> drinkOrders;
        private int tableNumber;
        private int capacity;
        private int numberOfPeople;
        private decimal pricePerPerson;
        private bool isReserved;
        private decimal price;

        protected Table(int tableNumber, int capacity, decimal pricePerPerson)
        {
            this.FoodOrders = new List<IFood>();
            this.DrinkOrders = new List<IDrink>();
            this.TableNumber = tableNumber;
            this.Capacity = capacity;
            this.NumberOfPeople = numberOfPeople;
            this.PricePerPerson = pricePerPerson;
            this.isReserved = false;
        }

        public List<IFood> FoodOrders
        {
            get { return foodOrders; }
            set { foodOrders = value; }
        }

        public List<IDrink> DrinkOrders
        {
            get { return drinkOrders; }
            set { drinkOrders = value; }
        }

        public int TableNumber
        {
            get { return tableNumber; }
            private set { tableNumber = value; }
        }

        public int Capacity
        {
            get
            {
                return capacity;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException($"Capacity has to be greater than 0");
                }
                capacity = value;
            }
        }

        public int NumberOfPeople
        {
            get
            {
                return numberOfPeople;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException($"Cannot place zero or less people!");
                }
                numberOfPeople = value;
            }
        }

        public decimal PricePerPerson
        {
            get { return pricePerPerson; }
            private set { pricePerPerson = value; }
        }

        public bool IsReserved { get; set; }

        public decimal Price
        {
            get { return NumberOfPeople * PricePerPerson; }
        }

        public void Reserve(int numberOfPeople)
        {
            this.NumberOfPeople = numberOfPeople;
        }

        public void OrderFood(IFood food)
        {
            FoodOrders.Add(food);
        }

        public void OrderDrink(IDrink drink)
        {
            DrinkOrders.Add(drink);
        }

        public decimal GetBill()
        {
            decimal drinkBill = DrinkOrders.Sum(x => x.Price);
            decimal foodBill = FoodOrders.Sum(x => x.Price);
            decimal totalBill = drinkBill + foodBill;

            return totalBill;
        }

        public void Clear()
        {
            FoodOrders.Clear();
            DrinkOrders.Clear();
            //this.NumberOfPeople = 0;
            IsReserved = false;
        }

        public string GetFreeTableInfo()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Table: {this.TableNumber}");

            if (this.PricePerPerson == 2.50m)
            {
                sb.AppendLine("Type: InsideTable");
            }
            else if (this.PricePerPerson == 3.50m)
            {
                sb.AppendLine("Type: OutsideTable");
            }

            sb.AppendLine($"Capacity: {this.Capacity}");
            sb.AppendLine($"Price per Person: {this.PricePerPerson}");

            return sb.ToString().TrimEnd();
        }

        public string GetOccupiedTableInfo()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Table: {this.TableNumber}");

            if (this.PricePerPerson == 2.50m)
            {
                sb.AppendLine("Type: InsideTable");
            }
            else if (this.PricePerPerson == 3.50m)
            {
                sb.AppendLine("Type: OutsideTable");
            }

            sb.AppendLine($"Number of people: {this.NumberOfPeople}");

            if (FoodOrders.Count == 0)
            {
                sb.AppendLine($"Food orders: None");
            }
            else
            {
                sb.AppendLine($"Food orders: {FoodOrders.Count}");

                foreach (var orders in FoodOrders)
                {
                    sb.AppendLine(orders.ToString());
                }
            }

            if (DrinkOrders.Count == 0)
            {
                sb.AppendLine($"Drink orders: None");
            }
            else
            {
                sb.AppendLine($"Drink orders: {DrinkOrders.Count}");
                foreach (var orders in DrinkOrders)
                {
                    sb.AppendLine(orders.ToString());
                }
            }

            return sb.ToString().TrimEnd();
        }
    }
}
