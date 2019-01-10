using AnimalCentre.Models.Animals.Contracts;
using AnimalCentre.Models.Procedures.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalCentre.Models.Procedures
{
    public class Fitness : Procedure
    {
        private const int RemoveHappiness = 3;
        private const int MoreEnergy = 10;

        public override void DoService(IAnimal animal, int procedureTime)
        {
            base.CheckTime(procedureTime, animal);
            animal.Happiness -= RemoveHappiness;
            animal.Energy += MoreEnergy;
            base.ProcedureHistory.Add(animal);
        }
    }
}
