using FoodShortage.Contracts;
using FoodShortage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FoodShortage.Core
{
    public class Engine
    {
        private List<IBuyer> buyers = new List<IBuyer>();

        public void Run()
        {
            int input = int.Parse(Console.ReadLine());

            for (int i = 0; i < input; i++)
            {
                var inputArgs = Console.ReadLine().Split();

                if (inputArgs.Length == 4)
                {
                    var name = inputArgs[0];
                    var age = int.Parse(inputArgs[1]);
                    var id = inputArgs[2];
                    var birthdate = inputArgs[3];

                    var citizen = new Citizen(name, age, id, birthdate);
                    buyers.Add(citizen);
                }
                else if (inputArgs.Length == 3)
                {
                    var name = inputArgs[0];
                    var age = int.Parse(inputArgs[1]);
                    var group = inputArgs[2];

                    var rebel = new Rebel(name, age, group);
                    buyers.Add(rebel);
                }
            }

            string command;

            while ((command = Console.ReadLine()) != "End")
            {
                var buyer = buyers.SingleOrDefault(b => b.Name == command);

                if (buyer != null)
                {
                    buyer.BuyFood();
                }
            }

            Console.WriteLine(buyers.Sum(b => b.Food));
        }
    }
}
