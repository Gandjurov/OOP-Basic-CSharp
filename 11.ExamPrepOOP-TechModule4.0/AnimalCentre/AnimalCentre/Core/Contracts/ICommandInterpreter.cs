using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalCentre.Core.Contracts
{
    public interface ICommandInterpreter
    {
        string Read(IAnimalCentre animalCentre, string[] args);
    }
}
