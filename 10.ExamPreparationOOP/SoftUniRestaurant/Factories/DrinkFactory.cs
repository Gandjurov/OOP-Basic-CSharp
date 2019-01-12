using SoftUniRestaurant.Models.Drinks;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoftUniRestaurant.Factories
{
    public class DrinkFactory
    {
        public Drink CreateDrink(string type, string name, int servingSize, decimal price, string brand)
        {
            switch (type)
            {
                case "Alcohol":
                    return new Alcohol(name, servingSize, brand);
                case "FuzzyDrink":
                    return new FuzzyDrink(name, servingSize, brand);
                case "Juice":
                    return new Juice(name, servingSize, brand);
                case "Water":
                    return new Water(name, servingSize, brand);
                default:
                    throw new ArgumentException($"Invalid drink type \"{type}\"!");
            }
        }
    }
}
