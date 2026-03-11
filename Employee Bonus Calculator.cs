using System;


namespace task1
{
    internal class Employee_Bonus_Calculator
    {
        static void Main()
        {
            Console.Write("Enter Name: ");
            string name = Console.ReadLine();

            // Accept salary
            Console.Write("Enter Salary: ");
            double salary = double.Parse(Console.ReadLine());

            // Accept years of experience
            Console.Write("Enter Experience: ");
            int experience = int.Parse(Console.ReadLine());

            double bonusRate;

            // Determine bonus percentage using if-else
            if (experience < 2)
            {
                bonusRate = 0.05;
            }
            else if (experience >= 2 && experience <= 5)
            {
                bonusRate = 0.10;
            }
            else
            {
                bonusRate = 0.15;
            }

            // Calculate bonus using ternary operator
            double bonus = (salary > 0) ? salary * bonusRate : 0;

            double finalSalary = salary + bonus;

            // Display result with formatting
            Console.WriteLine("Employee: " + name);
            Console.WriteLine("Bonus: " + bonus.ToString("F2"));
            Console.WriteLine("Final Salary: " + finalSalary.ToString("F2"));
        }
    }
