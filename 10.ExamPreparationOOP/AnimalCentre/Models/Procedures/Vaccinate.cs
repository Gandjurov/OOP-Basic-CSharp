using AnimalCentre.Models.Animals.Contracts;
using AnimalCentre.Models.Procedures.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalCentre.Models.Procedures
{
    public class Vaccinate : Procedure
    {
        private const int RemoveEnergy = 8;

        public override void DoService(IAnimal animal, int procedureTime)
        {
            base.CheckTime(procedureTime, animal);
            animal.Energy -= RemoveEnergy;
            animal.IsVaccinated = true;
            base.ProcedureHistory.Add(animal);
        }
    }
}
