using System;
using System.Collections.Generic;
using System.Text;

namespace Mankind
{
    public class Worker : Human
    {
        private decimal weekSalary;
        private decimal workHoursPerDay;
        
        public Worker(string firstName, string lastName, decimal weekSalary, decimal workHoursPerDay) : base(firstName, lastName)
        {
            this.WeekSalary = weekSalary;
            this.WorkHoursPerDay = workHoursPerDay;

        }

        public decimal WeekSalary
        {
            get { return this.weekSalary; }
            protected set
            {
                if (value <= 10)
                {
                    throw new ArgumentException($"Expected value mismatch! Argument: weekSalary");
                }
                this.weekSalary = value;
            }
        }

        public decimal WorkHoursPerDay
        {
            get { return this.workHoursPerDay; }
            protected set
            {
                if (value < 1 || value > 12)
                {
                    throw new ArgumentException($"Expected value mismatch! Argument: workHoursPerDay");
                }
                this.workHoursPerDay = value;
            }
        }

        private decimal SalaryPerHour()
        {
            decimal result = WeekSalary / (5 * WorkHoursPerDay);

            return result;
        }

        public override string ToString()
        {
            var resultBuilder = new StringBuilder();
            resultBuilder.AppendLine(base.ToString())
                         .AppendLine($"Week Salary: {WeekSalary:F2}")
                         .AppendLine($"Hours per day: {WorkHoursPerDay:F2}")
                         .AppendLine($"Salary per hour: {SalaryPerHour():F2}");

            return resultBuilder.ToString().TrimEnd();
        }
    }
}
