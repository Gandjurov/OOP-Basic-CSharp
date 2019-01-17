using SoftUniRestaurant.Models.Drinks.Contracts;
using SoftUniRestaurant.Models.Foods.Contracts;
using System.Collections.Generic;

namespace SoftUniRestaurant.Models.Tables.Contracts
{
    public interface ITable
    {
        int TableNumber { get; }

        int Capacity { get; }

        int NumberOfPeople { get; set; }

        decimal PricePerPerson { get; }

        decimal Price { get; }

        bool IsReserved { get; set; }

        List<IFood> FoodOrders { get; set; }

        List<IDrink> DrinkOrders { get; set; }

        void Reserve(int numberOfPeople);

        void OrderFood(IFood food);

        void OrderDrink(IDrink drink);

        decimal GetBill();

        void Clear();

        string GetFreeTableInfo();

        string GetOccupiedTableInfo();
    }
}
