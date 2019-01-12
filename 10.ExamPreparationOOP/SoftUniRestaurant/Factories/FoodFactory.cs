using SoftUniRestaurant.Models.Foods;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoftUniRestaurant.Factories
{
    public class FoodFactory
    {
        public Food Createfood(string type, string name, int servingSize, decimal price)
        {
            switch (type)
            {
                case "Dessert":
                    return new Dessert(name, price);
                case "MainCourse":
                    return new MainCourse(name, price);
                case "Salad":
                    return new Salad(name, price);
                case "Soup":
                    return new Soup(name, price);
                default:
                    throw new ArgumentException($"Invalid food type \"{type}\"!");
            }
        }
    }
}
