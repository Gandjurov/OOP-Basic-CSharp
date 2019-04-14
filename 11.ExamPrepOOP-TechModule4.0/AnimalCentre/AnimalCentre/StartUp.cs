using AnimalCentre.Core;
using AnimalCentre.Core.AnimalFactory;
using AnimalCentre.Core.Contracts;
using AnimalCentre.Models;
using AnimalCentre.Models.Contracts;
using System;

namespace AnimalCentre
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            IEngine engine = new Engine();
            engine.Run();
        }

        //private static IServiceProvider ConfigureService()
        //{
        //    var serviceCollection = new ServiceCollection();

        //    serviceCollection.AddSingleton<IAnimalCentre, Core.AnimalCentre>();
        //    serviceCollection.AddTransient<ICommandInterpreter, CommandInterpreter>();
        //    serviceCollection.AddSingleton<IHotel, Hotel>();
        //    serviceCollection.AddTransient<IAnimalFactory, AnimalFactory>();

        //    var serviceProvider = serviceCollection.BuildServiceProvider();

        //    return serviceProvider;
        //}
    }
}
