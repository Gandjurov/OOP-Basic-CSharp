using AnimalCentre.Models.Animals;
using AnimalCentre.Models.Animals.Contracts;
using AnimalCentre.Models.Procedures.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnimalCentre.Models.Procedures
{
    public abstract class Procedure : IProcedure
    {
        public ICollection<IAnimal> ProcedureHistory { get; }

        public Procedure()
        {
            this.ProcedureHistory = new List<IAnimal>();
        }

        public abstract void DoService(IAnimal animal, int procedureTime);

        public string History()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(this.GetType().Name);

            string[] animalsInfo = ProcedureHistory
                .OrderBy(a => a.Name)
                .Select(a => a.ToString())
                .ToArray();

            sb.AppendLine(string.Join(Environment.NewLine, animalsInfo));

            string result = sb.ToString().TrimEnd();
            return result;
        }

        protected void CheckTime(int time, IAnimal animal)
        {
            if (time <= animal.ProcedureTime)
            {
                animal.ProcedureTime -= time;
            }
            else
            {
                throw new ArgumentException("Animal doesn't have enough procedure time");
            }
        }
    }
}
