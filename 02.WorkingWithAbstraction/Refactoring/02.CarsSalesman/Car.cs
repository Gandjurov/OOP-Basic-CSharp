using System.Linq;
using System.Text;

namespace CarsSalesman
{
    public class Car
    {
        private const string offset = "  ";

        private string model;
        private Engine engine;
        private int weight;
        private string color;

        public Car(string model, Engine engine)
        {
            this.Model = model;
            this.Engine = engine;
            this.Weight = -1;
            this.Color = "n/a";
        }

        public Car(string model, Engine engine, int weight) : this(model, engine)
        {
            this.Weight = weight;
        }

        public Car(string model, Engine engine, string color) : this(model, engine)
        {
            this.Model = model;
            this.Engine = engine;
            this.Color = color;
        }

        public Car(string model, Engine engine, int weight, string color) : this(model, engine)
        {
            this.Weight = weight;
            this.Color = color;
        }

        public string Model
        {
            get => model;
            set => model = value;
        }

        public Engine Engine
        {
            get => engine;
            set => engine = value;
        }

        public int Weight
        {
            get => weight;
            set => weight = value;
        }

        public string Color
        {
            get => color;
            set => color = value;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat($"{this.Model}:\n");
            sb.Append(this.Engine.ToString());

            var weight = this.Weight == -1 ? "n/a" : this.Weight.ToString();
            sb.AppendFormat($"{offset}Weight: {weight}\n");
            sb.AppendFormat($"{offset}Color: {this.Color}");

            return sb.ToString();
        }
    }

}
