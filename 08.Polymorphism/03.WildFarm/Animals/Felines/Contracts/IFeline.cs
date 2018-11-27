using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Foods;

namespace WildFarm.Animals.Felines.Contracts
{
    public interface IFeline
    {
        string Breed { get; set; }

        void ProduceSound();

        void Eat(Food food);
    }
}
