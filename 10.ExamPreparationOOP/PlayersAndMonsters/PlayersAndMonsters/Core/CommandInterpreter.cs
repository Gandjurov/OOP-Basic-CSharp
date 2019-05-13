using PlayersAndMonsters.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlayersAndMonsters.Core
{
    public class CommandInterpreter : ICommandInterpreter
    {
        private readonly IManagerController managerController;

        public CommandInterpreter(IManagerController managerController)
        {
            this.managerController = managerController;
        }
        
        public string Read(string[] inputArgs)
        {
            string commandName = inputArgs[0];
            string[] commandArgs = inputArgs.Skip(1).ToArray();

            var method = typeof(ManagerController).GetMethod(commandName);

            List<object> requiredParams = new List<object>();

            foreach (var command in commandArgs)
            {
                if (int.TryParse(command, out int parsedParams))
                {
                    requiredParams.Add(parsedParams);

                    continue;
                }

                requiredParams.Add(command);
            }

            string result = (string)method.Invoke(this.managerController, requiredParams.ToArray());

            return result;
        }
    }
}
