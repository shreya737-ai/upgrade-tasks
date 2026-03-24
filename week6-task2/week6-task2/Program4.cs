using System;

namespace week6_task2
{
    // 1. Small interfaces
    public interface IPrinter
    {
        void Print();
    }

    public interface IScanner
    {
        void Scan();
    }

    public interface IFax
    {
        void Fax();
    }

    // 2. BasicPrinter -> only Print
    public class BasicPrinter : IPrinter
    {
        public void Print()
        {
            Console.WriteLine("Basic Printer: Printing document...");
        }
    }

    // 3. AdvancedPrinter -> Print + Scan + Fax
    public class AdvancedPrinter : IPrinter, IScanner, IFax
    {
        public void Print()
        {
            Console.WriteLine("Advanced Printer: Printing document...");
        }

        public void Scan()
        {
            Console.WriteLine("Advanced Printer: Scanning document...");
        }

        public void Fax()
        {
            Console.WriteLine("Advanced Printer: Sending fax...");
        }
    }

    internal class Program4
    {
        static void Main(string[] args)
        {
            // Basic Printer
            IPrinter basicPrinter = new BasicPrinter();
            Console.WriteLine("Using Basic Printer:");
            basicPrinter.Print();

            Console.WriteLine("---------------------------");

            // Advanced Printer
            AdvancedPrinter advancedPrinter = new AdvancedPrinter();
            Console.WriteLine("Using Advanced Printer:");
            advancedPrinter.Print();
            advancedPrinter.Scan();
            advancedPrinter.Fax();

            Console.ReadLine();
        }
    }
}