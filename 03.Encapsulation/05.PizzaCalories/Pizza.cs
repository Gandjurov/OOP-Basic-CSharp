using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PizzaCalories
{
    public class Pizza
    {
        private string name;
        private Dough dough;
        private List<Topping> toppings;

        public Pizza(string name)
        {
            this.Name = name;
            this.toppings = new List<Topping>();
        }

        public string Name
        {
            get { return name; }
            set
            {
                if (value.Length < 1 || value.Length > 15)
                {
                    Exception ex = new ArgumentException($"Pizza name should be between 1 and 15 symbols.");
                    Console.WriteLine(ex.Message);
                    Environment.Exit(0);
                }
                this.name = value;
            }
        }
        
        internal Dough Dough
        {
            get { return dough; }
            set { dough = value; }
        }

        //internal List<Topping> Toppings
        //{
        //    get { return toppings; }
        //    set
        //    {
        //        if (toppings.Count > 10)
        //        {
        //            Exception ex = new ArgumentException($"Number of toppings should be in range [0..10].");
        //            Console.WriteLine(ex.Message);
        //            Environment.Exit(0);
        //        }
        //        this.toppings = value;
        //    }
        //}

        //public void Add(Topping topping)
        //{
        //    this.Toppings.Add(topping);
        //}

        public void AddTopping(Topping topping)
        {
            if (this.toppings.Count > 10)
            {
                throw new ArgumentException("Number of toppings should be in range [0..10].");
            }

            this.toppings.Add(topping);
        }

        public double GetCalories()
        {
            //double sum = 0;
            //double doughCalories = this.Dough.DoughCalories;
            //double toppingCalories = this.toppings.Sum(c => c.ToppingCalories);

            //return doughCalories + toppingCalories;

            //double doughCalories = this.Dough.DoughCalories;
            //double toppingsCalories = this.toppings.Sum(t => t.ToppingCalories);

            //return doughCalories + toppingsCalories;
            
            double sum = 0;
            sum += this.Dough.DoughCalories;
            this.toppings.ForEach(t => sum += t.ToppingCalories);

            return sum;
        }

        public override string ToString()
        {
            return $"{this.Name} - {GetCalories():F2} Calories.";
        }

    }
}
