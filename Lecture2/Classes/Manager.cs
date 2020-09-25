using System;
namespace Lecture2.Classes
{
    public class Manager : Employee
    {
        public Manager(string name, string jobTitle, double salary, double bonus) : base(name, jobTitle, salary)
        {
            Bonus = bonus;
            SeneniorityLevel = 0.2;
        }

        public double Bonus { get; set; }

        public override double CalculateYearlySalary()
        {
            return (12 * Salary) + (12 * Bonus) + (12 * Salary * SeneniorityLevel);
        }
    }
}
