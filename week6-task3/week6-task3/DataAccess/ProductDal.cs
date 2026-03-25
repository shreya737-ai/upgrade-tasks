using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using week6_task3.Helper;
using week6_task3.models;
using System.Data;


namespace week6_task3.DataAccess
{
    public class ProductDal
    {
        private readonly string _connectionString;

        public ProductDal()
        {
            _connectionString = DataBaseHelper.GetConnectionString();
        }

        // 1. Insert Product
        public bool InsertProduct(Product product)
        {
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(_connectionString))
                using (SqlCommand cmd = new SqlCommand("sp_InsertProduct", sqlCon))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ProductName", SqlDbType.VarChar, 100).Value = product.ProductName;
                    cmd.Parameters.Add("@Category", SqlDbType.VarChar, 50).Value = product.Category;
                    cmd.Parameters.Add("@Price", SqlDbType.Decimal).Value = product.Price;

                    sqlCon.Open();
                    int rows = cmd.ExecuteNonQuery();

                    return rows > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while inserting product: {ex.Message}");
                return false;
            }
        }

        // 2. View All Products
        public List<Product> GetAllProducts()
        {
            List<Product> products = new List<Product>();

            try
            {
                using (SqlConnection sqlCon = new SqlConnection(_connectionString))
                using (SqlCommand cmd = new SqlCommand("sp_GetAllProducts", sqlCon))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    sqlCon.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Product product = new Product
                            {
                                ProductId = Convert.ToInt32(reader["ProductId"]),
                                ProductName = reader["ProductName"].ToString() ?? string.Empty,
                                Category = reader["Category"].ToString() ?? string.Empty,
                                Price = Convert.ToDecimal(reader["Price"])
                            };

                            products.Add(product);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while fetching products: {ex.Message}");
            }

            return products;
        }

        // 3. Update Product
        public bool UpdateProduct(Product product)
        {
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(_connectionString))
                using (SqlCommand cmd = new SqlCommand("sp_UpdateProduct", sqlCon))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ProductId", SqlDbType.Int).Value = product.ProductId;
                    cmd.Parameters.Add("@ProductName", SqlDbType.VarChar, 100).Value = product.ProductName;
                    cmd.Parameters.Add("@Category", SqlDbType.VarChar, 50).Value = product.Category;
                    cmd.Parameters.Add("@Price", SqlDbType.Decimal).Value = product.Price;

                    sqlCon.Open();
                    int rows = cmd.ExecuteNonQuery();

                    return rows > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while updating product: {ex.Message}");
                return false;
            }
        }

        // 4. Delete Product
        public bool DeleteProduct(int productId)
        {
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(_connectionString))
                using (SqlCommand cmd = new SqlCommand("sp_DeleteProduct", sqlCon))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ProductId", SqlDbType.Int).Value = productId;

                    sqlCon.Open();
                    int rows = cmd.ExecuteNonQuery();

                    return rows > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while deleting product: {ex.Message}");
                return false;
            }
        }
    }
}
