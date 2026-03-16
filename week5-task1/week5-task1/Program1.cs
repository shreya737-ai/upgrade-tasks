using System;


namespace week5_task1
{
    public class Program1
    {
        public static void Main(string[] args)
        {
            // Base class reference (Polymorphism)
            Employee emp1 = new Manager("Rahul", 50000);
            Employee emp2 = new Developer("Anita", 50000);

            Console.WriteLine("Manager Salary = " + emp1.CalculateSalary());
            Console.WriteLine("Developer Salary = " + emp2.CalculateSalary());
        }
    }
}
