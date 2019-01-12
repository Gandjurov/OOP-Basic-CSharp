namespace SoftUniRestaurant.Models.Foods.Contracts
{
    public interface IFood
    {
        string Name { get; set; }

        int ServingSize { get; set; }

        decimal Price { get; set; }

    }
}
