using System;

namespace week5_task4
{
    internal class Program2
    {
        static void Main(string[] args)
        {
            try
            {
                // 1. Accept input from user
                Console.Write("Enter Employee Name: ");
                string empName = Console.ReadLine();

                Console.Write("Enter Monthly Sales Amount: ");
                decimal salesAmount = Convert.ToDecimal(Console.ReadLine());

                Console.Write("Enter Customer Feedback Rating (1-5): ");
                int rating = Convert.ToInt32(Console.ReadLine());

                // Validate rating
                if (rating < 1 || rating > 5)
                {
                    Console.WriteLine("Invalid Rating! Please enter a value between 1 and 5.");
                    return;
                }

                // 2. Call method that returns tuple
                var performanceData = GetPerformanceData(salesAmount, rating);

                // 3. Use pattern matching to classify performance
                string performanceCategory = performanceData switch
                {
                    (decimal sales, int r) when sales >= 100000 && r >= 4 => "High Performer",
                    (decimal sales, int r) when sales >= 50000 && r >= 3 => "Average Performer",
                    _ => "Needs Improvement"
                };

                // 4. Display output
                Console.WriteLine("\nEmployee Performance Details");
                Console.WriteLine("-----------------------------");
                Console.WriteLine("Employee Name        : " + empName);
                Console.WriteLine("Sales Amount         : " + performanceData.SalesAmount);
                Console.WriteLine("Feedback Rating      : " + performanceData.Rating);
                Console.WriteLine("Performance Category : " + performanceCategory);
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input! Please enter numeric values for Sales Amount and Rating.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unexpected error occurred.");
                Console.WriteLine(ex.Message);
            }

            Console.ReadLine();
        }

        // Method returning multiple values using Tuple
        static (decimal SalesAmount, int Rating) GetPerformanceData(decimal salesAmount, int rating)
        {
            return (salesAmount, rating);
        }
    }
}