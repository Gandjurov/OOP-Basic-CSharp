using System;
using System.Collections.Generic;
using System.Text;

namespace Ferrari
{
    public class Ferrari : IDriveable
    {
        private string driver;
        private string model;

        public Ferrari(string driver)
        {
            this.Driver = driver;
            this.Model = "488-Spider";
        }

        public Ferrari()
        {
        }

        public string Driver
        {
            get { return driver; }
            set { driver = value; }
        }
        
        public string Model
        {
            get { return model; }
            set { model = value; }
        }
        
        public string PushGas()
        {
            return "Zadu6avam sA!";
        }

        public string UseBrakes()
        {
            return "Brakes!";
        }

        public override string ToString()
        {
            return $"{Model}/{UseBrakes()}/{PushGas()}/{Driver}";
        }
    }
}
