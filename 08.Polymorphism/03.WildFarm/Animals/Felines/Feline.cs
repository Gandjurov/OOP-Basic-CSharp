using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Animals.Felines.Contracts;
using WildFarm.Animals.Mammals;
using WildFarm.Foods;

namespace WildFarm.Animals.Felines
{
    public abstract class Feline : Mammal, IFeline
    {
        private string breed;
        
        public Feline(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, livingRegion)
        {
            this.Breed = breed;
        }

        public string Breed
        {//TODO add validation
            get { return breed; }
            set { breed = value; }
        }

        public override void Eat(Food food)
        {
            base.Eat(food);
        }

        public override void ProduceSound()
        {
            base.ProduceSound();
        }

        public override string ToString()
        {
            return base.ToString() + $"{this.Breed}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
