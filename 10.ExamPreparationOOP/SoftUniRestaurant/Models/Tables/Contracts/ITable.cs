using SoftUniRestaurant.Models.Drinks.Contracts;
using SoftUniRestaurant.Models.Foods.Contracts;

namespace SoftUniRestaurant.Models.Tables.Contracts
{
    public interface ITable
    {
        int TableNumber { get; set; }

        int Capacity { get; set; }

        int NumberOfPeople { get; set; }

        decimal PricePerPerson { get; set; }

        bool IsReserved { get; set; }

        void Reserve(int numberOfPeople);

        void OrderFood(IFood food);

        void OrderDrink(IDrink drink);

        decimal GetBill();

        void Clear();

        string GetFreeTableInfo();

        string GetOccupiedTableInfo();
    }
}
