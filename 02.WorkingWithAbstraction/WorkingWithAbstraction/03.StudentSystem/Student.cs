using System;
using System.Collections.Generic;
using System.Text;

namespace StudentSystem
{
    public class Student
    {
        private string name;
        private int age;
        private double grade;

        public Student(string name, int age, double grade)
        {
            this.Name = name;
            this.Age = age;
            this.Grade = grade;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        public double Grade
        {
            get { return grade; }
            set { grade = value; }
        }

        public override string ToString()
        {
            string gradeComment = GetGradeComment();

            return $"{Name} is {Age} years old. {gradeComment}";
        }

        private string GetGradeComment()
        {
            if (Grade >= 5)
            {
                return "Excellent student.";
            }
            else if (Grade >= 3.50)
            {
                return "Average student.";
            }
            else
            {
                return "Very nice person.";
            }
        }
    }
}
