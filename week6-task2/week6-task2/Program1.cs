using System;
using System.Collections.Generic;

namespace week6_task2

{
    // 1. Student class -> only stores student details
    public class Student
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public double Marks { get; set; }
    }

    // 2. StudentRepository class -> only manages student data
    public class StudentRepository
    {
        private List<Student> students = new List<Student>();

        public void AddStudent(Student student)
        {
            // Basic validation (secure coding practice)
            if (student == null)
            {
                Console.WriteLine("Invalid student data.");
                return;
            }

            if (string.IsNullOrWhiteSpace(student.StudentName))
            {
                Console.WriteLine("Student name cannot be empty.");
                return;
            }

            if (student.Marks < 0 || student.Marks > 100)
            {
                Console.WriteLine("Marks should be between 0 and 100.");
                return;
            }

            students.Add(student);
        }

        public List<Student> GetAllStudents()
        {
            return students;
        }
    }

    // 3. ReportGenerator class -> only generates student report
    public class ReportGenerator
    {
        public void GenerateReport(List<Student> students)
        {
            if (students == null || students.Count == 0)
            {
                Console.WriteLine("No student records found.");
                return;
            }

            Console.WriteLine("======================================");
            Console.WriteLine("       STUDENT PERFORMANCE REPORT     ");
            Console.WriteLine("======================================");

            foreach (var student in students)
            {
                string result = student.Marks >= 40 ? "Pass" : "Fail";

                Console.WriteLine($"Student ID   : {student.StudentId}");
                Console.WriteLine($"Student Name : {student.StudentName}");
                Console.WriteLine($"Marks        : {student.Marks}");
                Console.WriteLine($"Result       : {result}");
                Console.WriteLine("--------------------------------------");
            }
        }
    }

    // Main program
    internal class Program1
    {
        static void Main(string[] args)
        {
            // Create repository object
            StudentRepository repository = new StudentRepository();

            // Add students
            repository.AddStudent(new Student { StudentId = 101, StudentName = "Shreya", Marks = 85 });
            repository.AddStudent(new Student { StudentId = 102, StudentName = "Rahul", Marks = 35 });
            repository.AddStudent(new Student { StudentId = 103, StudentName = "Ananya", Marks = 72 });

            // Create report generator object
            ReportGenerator reportGenerator = new ReportGenerator();

            // Generate report
            reportGenerator.GenerateReport(repository.GetAllStudents());

            Console.ReadLine();
        }
    }
}
