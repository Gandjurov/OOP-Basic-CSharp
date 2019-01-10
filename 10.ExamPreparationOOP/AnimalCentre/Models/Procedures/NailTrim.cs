using AnimalCentre.Models.Animals.Contracts;
using AnimalCentre.Models.Procedures.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalCentre.Models.Procedures
{
    public class NailTrim : Procedure
    {
        private const int RemoveHappiness = 7;

        public override void DoService(IAnimal animal, int procedureTime)
        {
            base.CheckTime(procedureTime, animal);
            animal.Happiness -= RemoveHappiness;
            base.ProcedureHistory.Add(animal);
        }
    }
}
