using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace MMTTechnicalTest.Models.Repositories
{
    public class SqlStandardProductRepository : IProductRepository
    {
        private string _connectionString;

        public SqlStandardProductRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("MMTConn");
        }

        public void GetFeaturedProducts()
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                ///Call stored procedure for featured products
            };
          
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
                                    CategoryId = reader.GetInt32(reader.GetOrdinal("CategoryId"))
                                });
                            }
                        }

                    };
                    return products;
                }
                catch (Exception ex)
                {
                    throw new Exception("Unable to retrieve products");
                }
            
        }
    }
}
