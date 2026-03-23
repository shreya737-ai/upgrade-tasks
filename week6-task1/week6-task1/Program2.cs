using System;

namespace week6_task1
{
    internal class Program2
    {
        static void Main(string[] args)
        {
            // Accept product details from user
            Console.Write("Enter Product Name: ");
            string productName = Console.ReadLine();

            Console.Write("Enter Product Price: ");
            double price = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter Discount Percentage: ");
            double discount = Convert.ToDouble(Console.ReadLine());

            // Calculate discount amount
            double discountAmount = price * discount / 100;

            // Calculate final price
            double finalPrice = price - discountAmount;

            // Display result
            Console.WriteLine("\n----- Product Bill -----");
            Console.WriteLine("Product Name      : " + productName);
            Console.WriteLine("Original Price    : " + price);
            Console.WriteLine("Discount (%)      : " + discount);
            Console.WriteLine("Discount Amount   : " + discountAmount);
            Console.WriteLine("Final Price       : " + finalPrice);

            Console.ReadLine();
        }
    }
}