using System;

public class Product
{
    // Private fields
    private string name = "";
    private double price;

    // Property for Name
    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    // Property for Price with validation
    public double Price
    {
        get { return price; }
        set
        {
            if (value >= 0)
                price = value;
            else
                price = 0;
        }
    }

    // Constructor
    public Product(string name, double price)
    {
        Name = name;
        Price = price;
    }

    // Virtual method
    public virtual double CalculateDiscount()
    {
        return Price;
    }
}

public class Electronics : Product
{
    public Electronics(string name, double price) : base(name, price)
    {
    }

    public override double CalculateDiscount()
    {
        return Price - (Price * 0.05);
    }
}

public class Clothing : Product
{
    public Clothing(string name, double price) : base(name, price)
    {
    }

    public override double CalculateDiscount()
    {
        return Price - (Price * 0.15);
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Product e = new Electronics("Laptop", 20000);
        Console.WriteLine("Final Price after 5% discount = " + e.CalculateDiscount());
    }
}