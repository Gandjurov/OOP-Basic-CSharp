using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl.Models
{
    public class Citizen : IIdentifiable
    {
        private string name;
        private int age;
        private string id;

        public Citizen(string name, int age, string id)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
        }

        public string Name
        {
            get { return name; }
            private set { name = value; }
        }
        
        public int Age
        {
            get { return age; }
            private set { age = value; }
        }
        
        public string Id
        {
            get { return id; }
            private set { id = value; }
        }


    }
}
