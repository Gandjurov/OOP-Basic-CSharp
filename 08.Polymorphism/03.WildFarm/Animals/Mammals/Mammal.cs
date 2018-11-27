using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Animals.Mammals.Contracts;
using WildFarm.Foods;

namespace WildFarm.Animals.Mammals
{
    public abstract class Mammal : Animal, IMammal
    {
        private string livingRegion;

        public Mammal(string name, double weight, string livingRegion) 
            : base(name, weight)
        {
            this.LivingRegion = livingRegion;
        }

        public string LivingRegion
        {
            get { return livingRegion; }
            set { livingRegion = value; }
        }


        public override void Eat(Food food)
        {
            throw new NotImplementedException();
        }

        public override void ProduceSound()
        {
            throw new NotImplementedException();
        }

        //public override string ToString()
        //{
        //    return base.ToString() + $"{this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        //}
    }
}
