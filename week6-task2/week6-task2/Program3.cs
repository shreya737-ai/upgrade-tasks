using System;

namespace week6_task2
{
    // 1. Base abstract class
    public abstract class Shape
    {
        public abstract double CalculateArea();
    }

    // 2. Rectangle class
    public class Rectangle : Shape
    {
        public double Length { get; set; }
        public double Width { get; set; }

        public Rectangle(double length, double width)
        {
            // Secure coding practice: validate input
            if (length < 0 || width < 0)
            {
                throw new ArgumentException("Length and Width must be non-negative.");
            }

            Length = length;
            Width = width;
        }

        public override double CalculateArea()
        {
            return Length * Width;
        }
    }

    // 3. Circle class
    public class Circle : Shape
    {
        public double Radius { get; set; }

        public Circle(double radius)
        {
            // Secure coding practice: validate input
            if (radius < 0)
            {
                throw new ArgumentException("Radius must be non-negative.");
            }

            Radius = radius;
        }

        public override double CalculateArea()
        {
            return Math.PI * Radius * Radius;
        }
    }

    internal class Program3
    {
        // 4. Method accepting Shape object
        public static void PrintArea(Shape shape)
        {
            if (shape == null)
            {
                Console.WriteLine("Invalid shape object.");
                return;
            }

            Console.WriteLine($"Area = {shape.CalculateArea():F2}");
        }

        static void Main(string[] args)
        {
            try
            {
                // Rectangle object
                Shape rectangle = new Rectangle(10, 5);
                Console.WriteLine("Rectangle:");
                PrintArea(rectangle);

                Console.WriteLine("----------------------");

                // Circle object
                Shape circle = new Circle(7);
                Console.WriteLine("Circle:");
                PrintArea(circle);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            Console.ReadLine();
        }
    }
}