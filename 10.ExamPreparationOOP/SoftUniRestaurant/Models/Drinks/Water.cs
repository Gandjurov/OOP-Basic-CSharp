using SoftUniRestaurant.Models.Drinks.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoftUniRestaurant.Models.Drinks
{
    public class Water : Drink
    {
        private const decimal WaterPrice = 1.50m;

        public Water(string name, int servingSize, string brand) 
            : base(name, servingSize, WaterPrice, brand)
        {
        }

        public override string ToString()
        {
            return $"{this.Name} {this.Brand} - {this.ServingSize}ml - {this.Price:F2}lv";
        }
    }
}
