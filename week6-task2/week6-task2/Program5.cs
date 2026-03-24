using System;

namespace week6_task2
{
    // Singleton Class
    public sealed class ConfigurationManager
    {
        // Static instance variable
        private static ConfigurationManager instance = null;

        // Lock object for thread safety (basic level)
        private static readonly object lockObj = new object();

        // Properties for configuration values
        public string ApplicationName { get; private set; }
        public string Version { get; private set; }
        public string DatabaseConnectionString { get; private set; }

        // Private constructor to prevent object creation using 'new'
        private ConfigurationManager()
        {
            // Initialize configuration values
            ApplicationName = "Inventory Management System";
            Version = "1.0.0";
            DatabaseConnectionString = "Server=localhost;Database=InventoryDB;Trusted_Connection=True;";
        }

        // Public method to access the single instance
        public static ConfigurationManager GetInstance()
        {
            // Thread-safe singleton
            lock (lockObj)
            {
                if (instance == null)
                {
                    instance = new ConfigurationManager();
                }
            }

            return instance;
        }
    }

    internal class Program5
    {
        // Method 1
        static void ShowConfigFromMethod1()
        {
            ConfigurationManager config1 = ConfigurationManager.GetInstance();

            Console.WriteLine("Configuration from Method 1:");
            Console.WriteLine($"Application Name         : {config1.ApplicationName}");
            Console.WriteLine($"Version                  : {config1.Version}");
            Console.WriteLine($"Database Connection      : {config1.DatabaseConnectionString}");
            Console.WriteLine();
        }

        // Method 2
        static void ShowConfigFromMethod2()
        {
            ConfigurationManager config2 = ConfigurationManager.GetInstance();

            Console.WriteLine("Configuration from Method 2:");
            Console.WriteLine($"Application Name         : {config2.ApplicationName}");
            Console.WriteLine($"Version                  : {config2.Version}");
            Console.WriteLine($"Database Connection      : {config2.DatabaseConnectionString}");
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            // Multiple calls to GetInstance()
            ConfigurationManager configA = ConfigurationManager.GetInstance();
            ConfigurationManager configB = ConfigurationManager.GetInstance();

            // Print configuration details from different methods
            ShowConfigFromMethod1();
            ShowConfigFromMethod2();

            // Verify same instance
            Console.WriteLine("Checking whether both objects are same instance...");
            if (configA == configB)
            {
                Console.WriteLine("Yes, both references point to the SAME Singleton instance.");
            }
            else
            {
                Console.WriteLine("No, different instances exist.");
            }

            Console.ReadLine();
        }
    }
}