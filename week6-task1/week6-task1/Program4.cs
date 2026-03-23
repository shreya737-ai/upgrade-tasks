using System;
using System.Threading.Tasks;

namespace week6_task1
{
    internal class Program4
    {
        // Step 1: Verify Payment
        public static async Task VerifyPaymentAsync()
        {
            Console.WriteLine("Payment verification started...");
            await Task.Delay(2000); // Simulate delay
            Console.WriteLine("Payment verified successfully.");
        }

        // Step 2: Check Inventory
        public static async Task CheckInventoryAsync()
        {
            Console.WriteLine("Inventory check started...");
            await Task.Delay(1500); // Simulate delay
            Console.WriteLine("Inventory available.");
        }

        // Step 3: Confirm Order
        public static async Task ConfirmOrderAsync()
        {
            Console.WriteLine("Order confirmation started...");
            await Task.Delay(1000); // Simulate delay
            Console.WriteLine("Order confirmed successfully.");
        }

        static async Task Main(string[] args)
        {
            Console.WriteLine("Order processing started...\n");

            // Execute steps in logical order
            await VerifyPaymentAsync();
            await CheckInventoryAsync();
            await ConfirmOrderAsync();

            Console.WriteLine("\nOrder processing completed successfully.");
            Console.ReadLine();
        }
    }
}