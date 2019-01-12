using SoftUniRestaurant.Models.Drinks.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoftUniRestaurant.Models.Drinks
{
    public class FuzzyDrink : Drink
    {
        private const decimal FuzzyDrinkPrice = 2.50m;

        public FuzzyDrink(string name, int servingSize, string brand) 
            : base(name, servingSize, FuzzyDrinkPrice, brand)
        {
        }

        public override string ToString()
        {
            return $"{this.Name} {this.Brand} - {this.ServingSize}ml - {this.Price:F2}lv";
        }
    }
}
