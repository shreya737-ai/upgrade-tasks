using System;
using System.Threading;
using System.Threading.Tasks;

namespace week6_task1
{
    internal class Program3
    {
        // Method 1: Sales Report
        public static void GenerateSalesReport()
        {
            Console.WriteLine("Sales Report generation started...");
            Thread.Sleep(3000); // Simulate processing time
            Console.WriteLine("Sales Report generation completed.");
        }

        // Method 2: Inventory Report
        public static void GenerateInventoryReport()
        {
            Console.WriteLine("Inventory Report generation started...");
            Thread.Sleep(2000); // Simulate processing time
            Console.WriteLine("Inventory Report generation completed.");
        }

        // Method 3: Customer Report
        public static void GenerateCustomerReport()
        {
            Console.WriteLine("Customer Report generation started...");
            Thread.Sleep(2500); // Simulate processing time
            Console.WriteLine("Customer Report generation completed.");
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Starting report generation...\n");

            // Run all methods concurrently using Task.Run()
            Task task1 = Task.Run(() => GenerateSalesReport());
            Task task2 = Task.Run(() => GenerateInventoryReport());
            Task task3 = Task.Run(() => GenerateCustomerReport());

            // Wait for all tasks to complete
            Task.WaitAll(task1, task2, task3);

            Console.WriteLine("\nAll reports have been generated successfully.");
            Console.ReadLine();
        }
    }
}