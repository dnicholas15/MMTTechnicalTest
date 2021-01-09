using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace MMTTechnicalTest.Models.Repositories
{
    public class SqlStandardProductRepository : IProductRepository
    {
        private string _connectionString;

        public SqlStandardProductRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("MMTConn");
        }

        public IEnumerable<StandardProduct> GetFeaturedProducts()
        {
            try
            {
                var products = new List<StandardProduct>();
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("GetFeaturedProducts", con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            products.Add(new StandardProduct()
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                Name = reader.GetString(reader.GetOrdinal("Name")),
                                Description = reader.GetString(reader.GetOrdinal("Description")),
                                Price = reader.GetDecimal(reader.GetOrdinal("Price")),
                                StockKeepingUnit = reader.GetInt32(reader.GetOrdinal("StockKeepingUnit")),
                                CategoryId = reader.GetInt32(reader.GetOrdinal("CategoryId")),
                                CategoryName = reader.GetString(reader.GetOrdinal("CategoryName"))
                            });                            
                        }
                    }

                };
                return products;
            }
            catch (Exception)
            {
                throw new Exception("Unable to retrieve featured products");
            }


        }

        public IEnumerable<StandardProduct>GetproductsByCategory(int categoryId)
        {
                try
                {
                    var products = new List<StandardProduct>();
                    using (SqlConnection con = new SqlConnection(_connectionString))
                    {
                        con.Open();
                        SqlCommand cmd = new SqlCommand("GetProductsByCategoryId", con);
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@categoryId", categoryId);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                products.Add(new StandardProduct()
                                {
                                    Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                    Name = reader.GetString(reader.GetOrdinal("Name")),
                                    Description = reader.GetString(reader.GetOrdinal("Description")),
                                    Price = reader.GetDecimal(reader.GetOrdinal("Price")),
                                    StockKeepingUnit = reader.GetInt32(reader.GetOrdinal("StockKeepingUnit")),
                                    CategoryId = reader.GetInt32(reader.GetOrdinal("CategoryId")),
                                    CategoryName = reader.GetString(reader.GetOrdinal("CategoryName"))
                                });
                            }
                        }

                    };
                    return products;
                }
                catch (Exception)
                {
                    throw new Exception("Unable to retrieve products");
                }
            
        }
    }
}
