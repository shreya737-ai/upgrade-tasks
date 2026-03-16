using System;


namespace week5_task1
{
    public class Program2
    {
        public static void Main(string[] args)
        {
            // Base class reference (Polymorphism)
            Product p1 = new Electronics("Laptop", 20000);
            Product p2 = new Clothing("Shirt", 2000);

            Console.WriteLine("Electronics Final Price after 5% discount = " + p1.CalculateDiscount());
            Console.WriteLine("Clothing Final Price after 15% discount = " + p2.CalculateDiscount());
        }
    }
}
