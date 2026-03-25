using week6_task3.DataAccess;
using week6_task3.models;


namespace w
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ProductDal productDAL = new ProductDal();
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("\n===== Product Management System =====");
                Console.WriteLine("1. Insert Product");
                Console.WriteLine("2. View All Products");
                Console.WriteLine("3. Update Product");
                Console.WriteLine("4. Delete Product");
                Console.WriteLine("5. Exit");
                Console.Write("Enter your choice: ");

                string? choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        InsertProduct(productDAL);
                        break;

                    case "2":
                        ViewAllProducts(productDAL);
                        break;

                    case "3":
                        UpdateProduct(productDAL);
                        break;

                    case "4":
                        DeleteProduct(productDAL);
                        break;

                    case "5":
                        exit = true;
                        Console.WriteLine("Exiting application...");
                        break;

                    default:
                        Console.WriteLine("Invalid choice! Please try again.");
                        break;
                }
            }
        }

        static void InsertProduct(ProductDal productDAL)
        {
            try
            {
                Product product = new Product();

                Console.Write("Enter Product Name: ");
                product.ProductName = Console.ReadLine() ?? string.Empty;

                Console.Write("Enter Category: ");
                product.Category = Console.ReadLine() ?? string.Empty;

                Console.Write("Enter Price: ");
                product.Price = Convert.ToDecimal(Console.ReadLine());

                bool result = productDAL.InsertProduct(product);

                Console.WriteLine(result
                    ? "Product inserted successfully."
                    : "Failed to insert product.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Invalid input: {ex.Message}");
            }
        }

        static void ViewAllProducts(ProductDal productDAL)
        {
            List<Product> products = productDAL.GetAllProducts();

            if (products.Count == 0)
            {
                Console.WriteLine("No products found.");
                return;
            }

            Console.WriteLine("\n--- Product List ---");
            foreach (var product in products)
            {
                Console.WriteLine($"ID: {product.ProductId}, Name: {product.ProductName}, Category: {product.Category}, Price: {product.Price:C}");
            }
        }

        static void UpdateProduct(ProductDal productDAL)
        {
            try
            {
                Product product = new Product();

                Console.Write("Enter Product ID to Update: ");
                product.ProductId = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter New Product Name: ");
                product.ProductName = Console.ReadLine() ?? string.Empty;

                Console.Write("Enter New Category: ");
                product.Category = Console.ReadLine() ?? string.Empty;

                Console.Write("Enter New Price: ");
                product.Price = Convert.ToDecimal(Console.ReadLine());

                bool result = productDAL.UpdateProduct(product);

                Console.WriteLine(result
                    ? "Product updated successfully."
                    : "Product not found or update failed.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Invalid input: {ex.Message}");
            }
        }

        static void DeleteProduct(ProductDal productDAL)
        {
            try
            {
                Console.Write("Enter Product ID to Delete: ");
                int productId = Convert.ToInt32(Console.ReadLine());

                bool result = productDAL.DeleteProduct(productId);

                Console.WriteLine(result
                    ? "Product deleted successfully."
                    : "Product not found or delete failed.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Invalid input: {ex.Message}");
            }
        }
    }
}