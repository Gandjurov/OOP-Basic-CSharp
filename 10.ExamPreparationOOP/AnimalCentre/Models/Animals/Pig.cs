using AnimalCentre.Models.Animals.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalCentre.Models.Animals
{
    public class Pig : Animal, IAnimal
    {
        public Pig(string name, int energy, int happiness, int procedureTime) 
            : base(name, energy, happiness, procedureTime)
        {
        }

        public override string ToString()
        {
            return string.Format(base.ToString(), nameof(Pig), Name, Happiness, Energy);
        }
    }
}
