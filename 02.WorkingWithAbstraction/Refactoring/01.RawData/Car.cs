using System.Collections.Generic;

namespace RawData
{
    public class Car
    {
        private string model;
        private Engine engine;
        private Cargo cargo;
        private string cargoType;
        private List<Tire> tires;

        public Car(string model, Engine engine, Cargo cargo, List<Tire> tiers)
        {
            this.Model = model;
            this.Engine = engine;
            this.Cargo = cargo;
            this.Tires = tires;
        }

        public Engine Engine
        {
            get => engine;
            set => engine = value;
        }

        public Cargo Cargo
        {
            get => cargo;
            set => cargo = value;
        }

        public List<Tire> Tires
        {
            get => tires;
            set => tires = value;
        }

        public string Model
        {
            get => model;
            set => model = value;
        }
    }
}

