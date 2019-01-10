using AnimalCentre.Models.Animals.Contracts;
using AnimalCentre.Models.Procedures.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalCentre.Models.Procedures
{
    public class Play : Procedure
    {
        private const int MoreHappiness = 12;
        private const int RemoveEnergy = 6;

        public override void DoService(IAnimal animal, int procedureTime)
        {
            base.CheckTime(procedureTime, animal);
            animal.Happiness += MoreHappiness;
            animal.Energy -= RemoveEnergy;
            base.ProcedureHistory.Add(animal);
        }
    }
}
