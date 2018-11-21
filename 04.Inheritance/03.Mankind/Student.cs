using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Text.RegularExpressions;

namespace Mankind
{
    public class Student : Human
    {
        private string facultyNum;
        
        public Student(string firstName, string lastName, string facultyNum) : base(firstName, lastName)
        {
            this.FacultyNum = facultyNum;
        }

        public string FacultyNum
        {
            get { return this.facultyNum; }

            protected set
            {
                //if (value.Count() < 5 || value.Count() > 10)
                //{
                //    throw new ArgumentException($"Invalid faculty number!");
                //}
                var pattern = @"^[a-zA-Z0-9]{5,10}$";

                if (!Regex.IsMatch(value, pattern))
                {
                    throw new ArgumentException("Invalid faculty number!");
                }
                this.facultyNum = value;
            }
        }

        public override string ToString()
        {
            var resultBuilder = new StringBuilder();
            resultBuilder.AppendLine(base.ToString())
                         .AppendLine($"Faculty number: {FacultyNum}");

            return resultBuilder.ToString().TrimEnd();

        }
    }
}
