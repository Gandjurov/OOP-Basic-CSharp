using AnimalCentre.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalCentre.Models.Procedures
{
    public abstract class Procedure : IProcedure
    {
        protected Procedure()
        {
            this.ProcedureHistory = new List<IAnimal>();
        }

        protected ICollection<IAnimal> ProcedureHistory { get; set; }

        public string History()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"{this.GetType().Name}");

            foreach (var animal in ProcedureHistory)
            {
                sb.AppendLine($"    - {animal.Name} - Happiness: {animal.Happiness} - Energy: {animal.Energy}");
            }

            string result = sb.ToString().TrimEnd();

            return result;
        }

        public abstract void DoService(IAnimal animal, int procedureTime);


    }
}
