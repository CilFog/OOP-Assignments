using System;
namespace Lecture2.Classes
{
    public class Employee
    {
        public Employee(string name, string jobTitle, double salary)
        {
            Name = name;
            JobTitle = jobTitle;
            Salary = salary;
            SeneniorityLevel = 0.1;
        }

        public string Name { get; set; }
        public string JobTitle { get; set; }
        public double Salary { get; set; }
        public virtual double SeneniorityLevel { get; set; }

        public virtual double CalculateYearlySalary()
        {
            return 12 * Salary + (12 * (Salary * SeneniorityLevel));
        }

    }
}
