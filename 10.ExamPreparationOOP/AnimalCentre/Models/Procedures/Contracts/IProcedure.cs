using AnimalCentre.Models.Animals.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalCentre.Models.Procedures.Contracts
{
    public interface IProcedure
    {
        string History();
        void DoService(IAnimal animal, int procedureTime);
    }
}
