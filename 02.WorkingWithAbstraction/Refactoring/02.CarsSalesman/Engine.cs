using System.Text;

namespace CarsSalesman
{
    public class Engine
    {
        private const string offset = "  ";

        private string model;
        private int power;
        private int displacement;
        private string efficiency;

        public Engine(string model, int power)
        {
            this.Model = model;
            this.Power = power;
            this.Displacement = -1;
            this.Efficiency = "n/a";
        }

        public Engine(string model, int power, int displacement) : this(model, power)
        {
            this.Displacement = displacement;
        }

        public Engine(string model, int power, string efficiency) : this(model, power)
        {
            this.Efficiency = efficiency;
        }

        public Engine(string model, int power, int displacement, string efficiency) : this(model, power)
        {
            this.Efficiency = efficiency;
            this.Displacement = displacement;
        }

        public string Model
        {
            get => model;
            set => model = value;
        }

        public int Power
        {
            get => power;
            set => power = value;
        }

        public int Displacement
        {
            get => displacement;
            set => displacement = value;
        }

        public string Efficiency
        {
            get => efficiency;
            set => efficiency = value;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat($"{offset}{this.Model}:\n");
            sb.AppendFormat($"{offset}Power: {this.Power}\n");

            var displacement = this.Displacement == -1 ? "n/a" : this.Displacement.ToString();
            sb.AppendFormat($"{offset}Displacement: {displacement}\n");

            sb.AppendFormat($"{offset}Efficiency: {this.Efficiency}\n");

            return sb.ToString();
        }
    }

}
