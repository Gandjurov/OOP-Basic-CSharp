using AnimalCentre.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace AnimalCentre.Core
{
    public class Engine : IEngine
    {
        private AnimalCentre animalCentre;
        private ICommandInterpreter commandInterpreter;

        public Engine()
        {
            this.animalCentre = new AnimalCentre();
            this.commandInterpreter = new CommandInterpreter();
        }

        public void Run()
        {

            string input = Console.ReadLine();

            while (input != "End")
            {
                try
                {
                    string[] inputArgs = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    

                    string result = commandInterpreter.Read(animalCentre, inputArgs);

                    Console.WriteLine(result);
                }
                catch (TargetInvocationException tie)
                {
                    Console.WriteLine($"{tie.InnerException.InnerException.GetType().Name}: " + tie.InnerException.InnerException.Message);
                }

                input = Console.ReadLine();
            }

            string adoptedAnimals = animalCentre.AllAdoptedAnimals();
            Console.WriteLine(adoptedAnimals);
        }
        
    }
}
