using AnimalCentre.Models.Animals.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalCentre.Models.Hotel.Contracts
{
    public interface IHotel
    {
        IReadOnlyDictionary<string, IAnimal> Animals { get; }
        void Accommodate(IAnimal animal);
        void Adopt(string animalName, string owner);
    }
}
