using AnimalCentre.Models.Animals.Contracts;
using AnimalCentre.Models.Procedures.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalCentre.Models.Procedures
{
    public class Chip : Procedure
    {
        private const int RemoveHappiness = 5;

        public override void DoService(IAnimal animal, int procedureTime)
        {
            base.CheckTime(procedureTime, animal);
            if (animal.IsChipped)
            {
                throw new ArgumentException($"{animal.Name} is already chipped");
            }

            animal.Happiness -= RemoveHappiness;
            animal.IsChipped = true;
            base.ProcedureHistory.Add(animal);
        }
    }
}
