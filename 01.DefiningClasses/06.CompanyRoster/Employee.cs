using System;
using System.Collections.Generic;
using System.Text;

namespace CompanyRoster
{
    public class Employee
    {
        //fields:
        private string name;
        private decimal salary;
        private string possition;
        private string department;
        private int age;
        private string email;


        //constructor/s:
        public Employee(string name, decimal salary, string possition, string department)
        {
            this.Name = name;
            this.Salary = salary;
            this.Possition = possition;
            this.Department = department;
            this.Age = -1;
            this.Email = "n/a";
        }

        //properties:
        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public decimal Salary
        {
            get { return this.salary; }
            set { this.salary = value; }
        }
        
        public string Possition
        {
            get { return this.possition; }
            set { this.possition = value; }
        }

        public string Department
        {
            get { return this.department; }
            set { this.department = value; }
        }
        
        public int Age
        {
            get { return this.age; }
            set { this.age = value; }
        }
        
        public string Email
        {
            get { return this.email; }
            set { this.email = value; }
        }

    }
}
