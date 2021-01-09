using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace MMTTechnicalTest.Models.Repositories
{
    /// <summary>
    /// The concrete implementation of the standard product repository using an SQL data store
    /// </summary>
    public class SqlStandardProductRepository : IProductRepository
    {
        private string _connectionString;

        /// <summary>
        /// inject the config through the constructor and use it to get the DB connection string
        /// </summary>
        /// <param name="configuration">The application config</param>
        public SqlStandardProductRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("MMTConn");
        }

        /// <summary>
        /// The method for getting all featured products from the database
        /// </summary>
        /// <returns>A List of <see cref="StandardProduct"/></returns>
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

        /// <summary>
        /// The method for getting all products from the database by a selected category id
        /// </summary>
        /// <param name="categoryId">The selected category id</param>
        /// <returns>A list of <see cref="StandardProduct"/></returns>
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
