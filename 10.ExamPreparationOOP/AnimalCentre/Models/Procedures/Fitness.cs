using AnimalCentre.Models.Contracts;

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
            base.procedureHistory.Add(animal);
        }
    }
}
