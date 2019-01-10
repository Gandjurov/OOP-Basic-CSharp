using AnimalCentre.Models.Contracts;

namespace AnimalCentre.Models.Animals
{
    public class Cat : Animal, IAnimal
    {
        public Cat(string name, int energy, int happiness, int procedureTime) 
            : base(name, energy, happiness, procedureTime)
        {
        }

        public override string ToString()
        {
            return $"    Animal type: {nameof(Cat)} - {Name} - Happiness: {Happiness} - Energy: {Energy}";
        }
    }
}
