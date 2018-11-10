using System;
using System.Collections.Generic;
using System.Text;

namespace CarSalesman
{
    public class Engine
    {
        private string model;
        private int power;
        private int displacement;
        private string efficiency;

        public Engine(string model, int power)
        {
            this.Model = model;
            this.Power = power;
            this.Displacement = 0;
            this.Efficiency = "n/a";
            
        }
        
        public string Model
        {
            get { return model; }
            set { model = value; }
        }
        
        public int Power
        {
            get { return power; }
            set { power = value; }
        }
        
        public int Displacement
        {
            get { return displacement; }
            set { displacement = value; }
        }
        
        public string Efficiency
        {
            get { return efficiency; }
            set { efficiency = value; }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"    {this.Model}:")
                .AppendLine($"    Power: {this.Power}");
            if (this.Displacement == 0)
            {
                sb.AppendLine($"    Displacement: n/a");
            }
            else
            {
                sb.AppendLine($"    Displacement: {this.Displacement}");
            }

            sb.AppendLine($"    Efficiency: {this.Efficiency}");

            return sb.ToString().Trim();
        }
    }
}
