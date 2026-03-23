using System;
using System.Threading.Tasks;

namespace week6_task1
{
    internal class Program1
    {
        // Asynchronous method to simulate file writing
        public static async Task WriteLogAsync(string message)
        {
            Console.WriteLine($"Started writing log: {message}");

            // Simulate file I/O delay
            await Task.Delay(2000);

            Console.WriteLine($"Finished writing log: {message}");
        }

        static async Task Main(string[] args)
        {
            Console.WriteLine("Application started...");
            Console.WriteLine("Logging events asynchronously...\n");

            // Calling the async method multiple times
            Task log1 = WriteLogAsync("User logged in");
            Task log2 = WriteLogAsync("File uploaded");
            Task log3 = WriteLogAsync("Data saved");

            // Main thread remains responsive
            Console.WriteLine("Main thread is still running while logs are being written...\n");

            // Wait for all logging tasks to complete
            await Task.WhenAll(log1, log2, log3);

            Console.WriteLine("\nAll logs written successfully.");
            Console.WriteLine("Application finished.");
        }
    }
}