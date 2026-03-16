using System;


namespace week5_task1
{
    public class Employee
    {
        public string Name { get; set; }
        public double BaseSalary { get; set; }

        // Constructor
        public Employee(string name, double baseSalary)
        {
            Name = name;
            BaseSalary = baseSalary;
        }

        // Virtual method
        public virtual double CalculateSalary()
        {
            return BaseSalary;
        }
    }

    public class Manager : Employee
    {
        public Manager(string name, double baseSalary) : base(name, baseSalary)
        {
        }

        // Override method for 20% bonus
        public override double CalculateSalary()
        {
            return BaseSalary + (BaseSalary * 0.20);
        }
    }

    public class Developer : Employee
    {
        public Developer(string name, double baseSalary) : base(name, baseSalary)
        {
        }

        // Override method for 10% bonus
        public override double CalculateSalary()
        {
            return BaseSalary + (BaseSalary * 0.10);
        }
    }

   
}
