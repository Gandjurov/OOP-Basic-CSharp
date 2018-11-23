using BirthdayCelebrations.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace BirthdayCelebrations.Models
{
    public class Citizen : IIdentifiable, IBirthable
    {
        private string name;
        private int age;
        private string id;
        private string birthdate;

        public Citizen(string name, int age, string id, string birthdate)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.Birthdate = birthdate;
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

        public string Birthdate
        {
            get { return birthdate; }
            private set { birthdate = value; }
        }

    }
}
