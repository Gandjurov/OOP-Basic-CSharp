using AnimalCentre.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace AnimalCentre.Core
{
    public class CommandInterpreter : ICommandInterpreter
    {
        public string Read(IAnimalCentre animalCentre, string[] args)
        {
            string command = args[0];
            string[] commandArgs = args.Skip(1).ToArray();

            var animalCentreType = typeof(AnimalCentre);

            var method = animalCentreType.GetMethod(command);

            if (method == null)
            {
                throw new ArgumentException("Invalid command!");
            }

            List<object> parameters = new List<object>();

            foreach (var commandArg in commandArgs)
            {
                if (int.TryParse(commandArg, out int value))
                {
                    parameters.Add(value);
                }
                else
                {
                    parameters.Add(commandArg);
                }
            }

            string result = string.Empty;

            try
            {
                result = (string)method.Invoke(animalCentre, parameters.ToArray());
            }
            catch (TargetInvocationException tie)
            {
                result = tie.InnerException.Message;
            }

            return result;
        }
    }
}
