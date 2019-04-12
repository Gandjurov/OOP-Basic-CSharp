namespace AnimalCentre.Models.Contracts
{
    public interface IAnimal
    {
        string Name { get; }

        int Happiness { get; }

        int Energy { get; }

        int ProcedureTime { get; }

        string Owner { get; }

        bool IsAdopt { get; }

        bool IsChipped { get; }

        bool IsVaccinated { get; }

        //•	Name – string
        //•	Happiness – int (can’t be less than 0 or more than 100. In these cases throw ArgumentException with message "Invalid happiness")
        //•	Energy – int (can’t be less than 0 or more than 100. In these cases throw ArgumentException with message "Invalid energy")
        //•	ProcedureTime – int
        //•	Owner – string (by default: "Centre")
        //•	IsAdopt – bool (by default: false)
        //•	IsChipped – bool (by default: false)
        //•	IsVaccinated – bool (by default: false)

    }
}
