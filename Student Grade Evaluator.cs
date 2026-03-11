using System;


namespace task1
{
    internal class Student_Grade_Evaluator
    {
        static void Main()
        {
            Console.Write("Enter your name: ");
            string name = Console.ReadLine();

            Console.Write("Enter your marks: ");
            int marks = int.Parse(Console.ReadLine());

            if (marks < 0 || marks > 100)
            {
                Console.WriteLine("Invalid marks! Please enter marks between 0 and 100.");
            }
            else
            {
                string grade;


                if (marks >= 90)
                {
                    grade = "A";
                }
                else if (marks >= 75)
                {
                    grade = "B";
                }
                else if (marks >= 60)
                {
                    grade = "C";
                }
                else if (marks >= 50)
                {
                    grade = "D";
                }
                else
                {
                    grade = "Fail";
                }

                Console.WriteLine("Student: " + name);
                Console.WriteLine("Grade: " + grade);
            }
        }
    }
}
