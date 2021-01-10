using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MMTTechnicalTest.Models.DTOs;
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
        ILogger<SqlStandardProductRepository> _logger;
        /// <summary>
        /// inject the config through the constructor and use it to get the DB connection string
        /// </summary>
        /// <param name="configuration">The application config</param>
        public SqlStandardProductRepository(IConfiguration configuration, ILogger<SqlStandardProductRepository> logger)
        {
            _connectionString = configuration.GetConnectionString("MMTCon");
            _logger = logger;
        }

        /// <summary>
        /// The method for getting all featured products from the database
        /// </summary>
        /// <returns>A List of <see cref="StandardProduct"/></returns>
        public IEnumerable<StandardProductDto> GetFeaturedProducts()
        {
            try
            {
                var products = new List<StandardProductDto>();
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("GetFeaturedProducts", con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            products.Add(new StandardProductDto()
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                Name = reader.GetString(reader.GetOrdinal("Name")),
                                Description = reader.GetString(reader.GetOrdinal("Description")),
                                Price = reader.GetDecimal(reader.GetOrdinal("Price")),
                                CategoryName = reader.GetString(reader.GetOrdinal("CategoryName"))
                            });                            
                        }
                    }

                };
                return products;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception("Unable to retrieve featured products");
            }


        }

        /// <summary>
        /// The method for getting all products from the database by a selected category id
        /// </summary>
        /// <param name="categoryId">The selected category id</param>
        /// <returns>A list of <see cref="StandardProduct"/></returns>
        public IEnumerable<StandardProductDto>GetProductsByCategory(int categoryId)
        {
                try
                {
                    var products = new List<StandardProductDto>();
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
                                products.Add(new StandardProductDto()
                                {
                                    Name = reader.GetString(reader.GetOrdinal("Name")),
                                    Description = reader.GetString(reader.GetOrdinal("Description")),
                                    Price = reader.GetDecimal(reader.GetOrdinal("Price")),
                                    CategoryName = reader.GetString(reader.GetOrdinal("CategoryName"))
                                });
                            }
                        }

                    };
                    return products;
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex.Message);
                    throw new Exception("Unable to retrieve products");
                }
            
        }
    }
}
