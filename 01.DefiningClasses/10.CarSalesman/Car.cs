using System;
using System.Collections.Generic;
using System.Text;

namespace CarSalesman
{
    public class Car
    {
        private string model;
        private Engine engine;
        private int weight;
        private string color;

        public Car(string model, Engine engine)
        {
            this.Model = model;
            this.Engine = engine;
            this.Weight = 0;
            this.Color = "n/a";
        }

        
        public string Model
        {
            get { return model; }
            set { model = value; }
        }
        
        public Engine Engine
        {
            get { return engine; }
            set { engine = value; }
        }
        
        public int Weight
        {
            get { return weight; }
            set { weight = value; }
        }
        
        public string Color
        {
            get { return color; }
            set { color = value; }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.Model}:")
                .AppendLine($"  {this.Engine}");
            if (this.Weight == 0)
            {
                sb.AppendLine($"  Weight: n/a");
            }
            else
            {
                sb.AppendLine($"  Weight: {this.Weight}");
            }
            sb.AppendLine($"  Color: {this.Color}");

            return sb.ToString().Trim();
        }
    }
}
