using System;
using System.Diagnostics;
using System.IO;

namespace OrderProcessingTracingDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Configure trace listener to write logs into a file
            TextWriterTraceListener twtl = new TextWriterTraceListener("OrderProcessingLog.txt");
            Trace.Listeners.Add(twtl);

            // Optional: Automatically flush trace output
            Trace.AutoFlush = true;

            Console.WriteLine("Order Processing Started...\n");
            Trace.WriteLine("Order Processing Started...");
            Trace.TraceInformation("Tracing started for order processing.");

            try
            {
                ValidateOrder();
                ProcessPayment();
                UpdateInventory();
                GenerateInvoice();

                Console.WriteLine("\nOrder processed successfully.");
                Trace.WriteLine("Order processed successfully.");
                Trace.TraceInformation("Order processing completed successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("\nOrder processing failed: " + ex.Message);
                Trace.WriteLine("Order processing failed: " + ex.Message);
                Trace.TraceInformation("Failure occurred during order processing.");
            }

            // Flush and close trace listener
            Trace.Flush();
            Trace.Close();

            Console.WriteLine("\nTrace log saved to OrderProcessingLog.txt");
            Console.ReadLine();
        }

        static void ValidateOrder()
        {
            Console.WriteLine("Step 1: Validating Order...");
            Trace.WriteLine("Step 1: Validate Order started.");
            Trace.TraceInformation("Validating order details...");

            // Simulate validation success
            Trace.WriteLine("Step 1: Validate Order completed.");
        }

        static void ProcessPayment()
        {
            Console.WriteLine("Step 2: Processing Payment...");
            Trace.WriteLine("Step 2: Process Payment started.");
            Trace.TraceInformation("Processing customer payment...");

            // Simulate payment success
            Trace.WriteLine("Step 2: Process Payment completed.");
        }

        static void UpdateInventory()
        {
            Console.WriteLine("Step 3: Updating Inventory...");
            Trace.WriteLine("Step 3: Update Inventory started.");
            Trace.TraceInformation("Updating stock quantity...");

            // Simulate inventory success
            Trace.WriteLine("Step 3: Update Inventory completed.");
        }

        static void GenerateInvoice()
        {
            Console.WriteLine("Step 4: Generating Invoice...");
            Trace.WriteLine("Step 4: Generate Invoice started.");
            Trace.TraceInformation("Generating customer invoice...");

            // Simulate invoice success
            Trace.WriteLine("Step 4: Generate Invoice completed.");
        }
    }
}