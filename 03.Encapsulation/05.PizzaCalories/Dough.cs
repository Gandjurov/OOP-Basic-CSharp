using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Dough
    {
        private string flour;
        private string bakingTechnique;
        private double weight;
        
        public Dough(string flour, string bakingTechnique, double weight)
        {
            this.Flour = flour;
            this.BakingTechnique = bakingTechnique;
            this.Weight = weight;
        }

        private string Flour
        {
            get { return flour; }
            set
            {
                if (value.ToLower() != "white" && value.ToLower() != "wholegrain")
                {
                    Exception ex = new ArgumentException("Invalid type of dough.");
                    Console.WriteLine(ex.Message);
                    Environment.Exit(0);
                }
                flour = value.ToLower();
            }
        }
        
        private string BakingTechnique
        {
            get { return bakingTechnique; }
            set
            {
                if (value.ToLower() != "crispy" && value.ToLower() != "chewy" && value.ToLower() != "homemade")
                {
                    Exception ex = new ArgumentException("Invalid type of dough.");
                    Console.WriteLine(ex.Message);
                    Environment.Exit(0);
                }
                bakingTechnique = value.ToLower();
            }
        }

        private double Weight
        {
            get { return weight; }
            set
            {
                if (value < 1 && value > 200)
                {
                    Exception ex = new ArgumentException("Dough weight should be in the range[1..200].");
                    Console.WriteLine(ex.Message);
                    Environment.Exit(0);
                }
                weight = value;
            }
        }

        public double DoughCalories
        {
            get => this.CalcDoughCalories();
        }


        public double CalcDoughCalories()
        {
            double flourModifier = this.Flour == "white" ? 1.5 : 1.0;
            double bakingModifier = this.BakingTechnique == "crispy" ? 0.9 :
                                    this.BakingTechnique == "chewy" ? 1.1 : 1.0;
            return this.Weight * 2 * flourModifier * bakingModifier;
        }
    }
}
