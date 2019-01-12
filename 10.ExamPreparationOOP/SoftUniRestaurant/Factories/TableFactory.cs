using SoftUniRestaurant.Models.Tables;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoftUniRestaurant.Factories
{
    public class TableFactory
    {
        public Table Createfood(string type, int tableNumber, int capacity, decimal pricePerPerson)
        {
            switch (type)
            {
                case "InsideTable":
                    return new InsideTable(tableNumber, capacity);
                case "OutsideTable":
                    return new OutsideTable(tableNumber, capacity);
                default:
                    throw new ArgumentException($"Invalid table type: \"{type}\"!");
            }
        }
    }
}
