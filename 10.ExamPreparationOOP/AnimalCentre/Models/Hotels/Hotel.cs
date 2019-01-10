namespace AnimalCentre.Models.Hotels
{
    using AnimalCentre.Models.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    public class Hotel : IHotel
    {
        private const int InitialCapacity = 10;

        private Dictionary<string, IAnimal> animals;
        private int capacity;

        public Hotel()
        {
            this.animals = new Dictionary<string, IAnimal>();
            this.Capacity = InitialCapacity;
        }

        public IReadOnlyDictionary<string, IAnimal> Animals
        {
            get => new ReadOnlyDictionary<string, IAnimal>(this.animals);

        }

        public int Capacity
        {
            get { return capacity; }
            set { capacity = value; }
        }

        public void Accommodate(IAnimal animal)
        {
            if (this.Capacity <= 0)
            {
                throw new InvalidOperationException("Not enough capacity");
            }

            if (!animals.ContainsKey(animal.Name))
            {
                this.animals[animal.Name] = animal;
                capacity--;
            }
            else
            {
                throw new ArgumentException($"Animal {animal.Name} already exist");
            }
        }

        public void Adopt(string animalName, string owner)
        {
            if (!animals.ContainsKey(animalName))
            {
                throw new ArgumentException($"Animal {animalName} does not exist");
            }
            else
            {
                IAnimal animal = this.animals[animalName];

                animal.Owner = owner;
                animal.IsAdopt = true;
                this.animals.Remove(animalName);
                capacity++;
            }


        }
    }
}
