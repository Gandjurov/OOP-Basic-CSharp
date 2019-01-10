using AnimalCentre.Models.Contracts;

namespace AnimalCentre.Models.Procedures
{
    public class DentalCare : Procedure
    {
        private const int MoreHappiness = 12;
        private const int MoreEnergy = 10;

        public override void DoService(IAnimal animal, int procedureTime)
        {
            base.CheckTime(procedureTime, animal);
            animal.Happiness += MoreHappiness;
            animal.Energy += MoreEnergy;
            base.procedureHistory.Add(animal);
        }
    }
}
