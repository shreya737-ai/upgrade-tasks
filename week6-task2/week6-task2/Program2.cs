using System;

namespace week6_task2
{
    // 1. Interface - Open for extension
    public interface IDiscountStrategy
    {
        double CalculateDiscount(double amount);
    }

    // 2. Regular Customer Discount
    public class RegularCustomerDiscount : IDiscountStrategy
    {
        public double CalculateDiscount(double amount)
        {
            return amount * 0.05; // 5% discount
        }
    }

    // 3. Premium Customer Discount
    public class PremiumCustomerDiscount : IDiscountStrategy
    {
        public double CalculateDiscount(double amount)
        {
            return amount * 0.10; // 10% discount
        }
    }

    // 4. VIP Customer Discount
    public class VipCustomerDiscount : IDiscountStrategy
    {
        public double CalculateDiscount(double amount)
        {
            return amount * 0.20; // 20% discount
        }
    }

    // 5. Final price calculator
    public class DiscountCalculator
    {
        public double GetFinalPrice(double amount, IDiscountStrategy discountStrategy)
        {
            // Basic validation (secure coding practice)
            if (amount < 0)
            {
                Console.WriteLine("Amount cannot be negative.");
                return 0;
            }

            if (discountStrategy == null)
            {
                Console.WriteLine("Invalid discount strategy.");
                return amount;
            }

            double discount = discountStrategy.CalculateDiscount(amount);
            return amount - discount;
        }
    }

    internal class Program2
    {
        static void Main(string[] args)
        {
            double amount = 1000;

            DiscountCalculator calculator = new DiscountCalculator();

            // Regular Customer
            IDiscountStrategy regular = new RegularCustomerDiscount();
            double regularDiscount = regular.CalculateDiscount(amount);
            double regularFinal = calculator.GetFinalPrice(amount, regular);

            Console.WriteLine("Regular Customer");
            Console.WriteLine($"Original Amount : {amount}");
            Console.WriteLine($"Discount        : {regularDiscount}");
            Console.WriteLine($"Final Price     : {regularFinal}");
            Console.WriteLine("-----------------------------------");

            // Premium Customer
            IDiscountStrategy premium = new PremiumCustomerDiscount();
            double premiumDiscount = premium.CalculateDiscount(amount);
            double premiumFinal = calculator.GetFinalPrice(amount, premium);

            Console.WriteLine("Premium Customer");
            Console.WriteLine($"Original Amount : {amount}");
            Console.WriteLine($"Discount        : {premiumDiscount}");
            Console.WriteLine($"Final Price     : {premiumFinal}");
            Console.WriteLine("-----------------------------------");

            // VIP Customer
            IDiscountStrategy vip = new VipCustomerDiscount();
            double vipDiscount = vip.CalculateDiscount(amount);
            double vipFinal = calculator.GetFinalPrice(amount, vip);

            Console.WriteLine("VIP Customer");
            Console.WriteLine($"Original Amount : {amount}");
            Console.WriteLine($"Discount        : {vipDiscount}");
            Console.WriteLine($"Final Price     : {vipFinal}");

            Console.ReadLine();
        }
    }
}