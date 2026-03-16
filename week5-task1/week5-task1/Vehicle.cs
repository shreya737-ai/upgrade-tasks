using System;


namespace week5_task1
{
    public class Vehicle
    {
        // Private fields
        private string brand = "";
        private double rentalRatePerDay;

        // Property for Brand
        public string Brand
        {
            get { return brand; }
            set { brand = value; }
        }

        // Property for RentalRatePerDay with validation
        public double RentalRatePerDay
        {
            get { return rentalRatePerDay; }
            set
            {
                if (value >= 0)
                    rentalRatePerDay = value;
                else
                    rentalRatePerDay = 0;
            }
        }

        // Constructor
        public Vehicle(string brand, double rentalRatePerDay)
        {
            Brand = brand;
            RentalRatePerDay = rentalRatePerDay;
        }

        // Virtual method
        public virtual double CalculateRental(int days)
        {
            if (days <= 0)
            {
                Console.WriteLine("Invalid rental days");
                return 0;
            }

            return RentalRatePerDay * days;
        }
    }

    public class Car : Vehicle
    {
        public Car(string brand, double rentalRatePerDay) : base(brand, rentalRatePerDay)
        {
        }

        // Override method: add insurance charge of 500
        public override double CalculateRental(int days)
        {
            if (days <= 0)
            {
                Console.WriteLine("Invalid rental days");
                return 0;
            }

            return (RentalRatePerDay * days) + 500;
        }
    }

    public class Bike : Vehicle
    {
        public Bike(string brand, double rentalRatePerDay) : base(brand, rentalRatePerDay)
        {
        }

        // Override method: 5% discount
        public override double CalculateRental(int days)
        {
            if (days <= 0)
            {
                Console.WriteLine("Invalid rental days");
                return 0;
            }

            double total = RentalRatePerDay * days;
            return total - (total * 0.05);
        }
    }

}
