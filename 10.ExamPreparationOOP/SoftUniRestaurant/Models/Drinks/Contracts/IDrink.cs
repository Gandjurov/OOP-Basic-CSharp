namespace SoftUniRestaurant.Models.Drinks.Contracts
{
    public interface IDrink
    {
        string Name { get; set; }

        int ServingSize { get; set; }

        decimal Price { get; set; }

        string Brand { get; set; }
    }
}
