using SoftUniRestaurant.Models.Foods.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoftUniRestaurant.Models.Foods
{
    public class MainCourse : Food
    {
        private const int InitialServingSize = 500;

        public MainCourse(string name, decimal price) 
            : base(name, InitialServingSize, price)
        {
        }

        public override string ToString()
        {
            return $"{this.Name}: {this.ServingSize}g - {this.Price:F2}";
        }
    }
}
