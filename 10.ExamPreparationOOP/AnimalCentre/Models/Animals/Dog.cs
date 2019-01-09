using AnimalCentre.Models.Animals.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalCentre.Models.Animals
{
    public class Dog : Animal, IAnimal
    {
        public Dog(string name, int energy, int happiness, int procedureTime) 
            : base(name, energy, happiness, procedureTime)
        {
        }

        public override string ToString()
        {
            return string.Format(base.ToString(), nameof(Dog), Name, Happiness, Energy);
        }
    }
}
