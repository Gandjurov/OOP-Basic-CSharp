using AnimalCentre.Models.Contracts;

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
            base.procedureHistory.Add(animal);
        }
    }
}
