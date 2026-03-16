using System;


namespace week5_task1
{
    public class Program3
    {
        public static void Main(string[] args)
        {
            // Base class reference (Runtime Polymorphism)
            Vehicle v1 = new Car("Toyota", 2000);
            Vehicle v2 = new Bike("Honda", 500);

            Console.WriteLine("Car Total Rental = " + v1.CalculateRental(3));
            Console.WriteLine("Bike Total Rental = " + v2.CalculateRental(3));
        }
    }
}
