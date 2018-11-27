using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Foods;

namespace WildFarm.Animals.Mammals.Contracts
{
    public interface IMammal
    {
        string LivingRegion { get; set; }

        void ProduceSound();

        void Eat(Food food);
    }
}
