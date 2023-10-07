using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Models;
namespace RepositoryServices
{
    public class RepositoryServiceMSSql : IRepository
    {
        private readonly string _connectionString;

        public RepositoryServiceMSSql(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void AddProduct(Product product)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string sql = "INSERT INTO Products (Name, Price, Quantity) VALUES (@Name, @Price, @Quantity); SELECT SCOPE_IDENTITY();";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Name", product.Name);
                    command.Parameters.AddWithValue("@Price", product.Price);
                    command.Parameters.AddWithValue("@Quantity", product.Quantity);

                    product.ProductId = Convert.ToInt32(command.ExecuteScalar());
                }
            }
        }

        public List<Product> GetAllProducts()
        {
            List<Product> products = new List<Product>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string sqlQuery = "SELECT * FROM Products";
                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int productId = Convert.ToInt32(reader["ProductId"]);
                            string name = reader["Name"].ToString();
                            decimal price = Convert.ToDecimal(reader["Price"]);
                            int quantity = Convert.ToInt32(reader["Quantity"]);

                            var product = new Product
                            {
                                ProductId = productId,
                                Name = name,
                                Price = price,
                                Quantity = quantity
                            };
                            products.Add(product);
                        }
                    }
                }
            }
            return products;
        }

        public bool EditProduct(Product product)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string sqlQuery = "UPDATE Products SET Name = @Name, Price = @Price, Quantity = @Quantity WHERE ProductId = @ProductId";
                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    command.Parameters.AddWithValue("@ProductId", product.ProductId);
                    command.Parameters.AddWithValue("@Name", product.Name);
                    command.Parameters.AddWithValue("@Price", product.Price);
                    command.Parameters.AddWithValue("@Quantity", product.Quantity);

                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }

        public bool DeleteProduct(int productId)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string sqlQuery = "DELETE FROM Products WHERE ProductId = @ProductId";
                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    command.Parameters.AddWithValue("@ProductId", productId);

                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }

        public Product GetProductById(int productId)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string sqlQuery = "SELECT * FROM Products WHERE ProductId = @ProductId";
                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    command.Parameters.AddWithValue("@ProductId", productId);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string name = reader["Name"].ToString();
                            decimal price = Convert.ToDecimal(reader["Price"]);
                            int quantity = Convert.ToInt32(reader["Quantity"]);

                            return new Product
                            {
                                ProductId = productId,
                                Name = name,
                                Price = price,
                                Quantity = quantity
                            };
                        }
                    }
                }
            }
            return null;
        }
    }
}
