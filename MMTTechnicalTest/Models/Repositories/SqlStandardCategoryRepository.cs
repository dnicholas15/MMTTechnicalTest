using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace MMTTechnicalTest.Models.Repositories
{
    public class SqlStandardCategoryRepository : ICategoryRepository
    {
        private string _connectionString;
        public SqlStandardCategoryRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("MMTConn");
        }
      
        public IEnumerable<StandardCategory>GetAllCategories()
        {
            try
            {
                var categories = new List<StandardCategory>();
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("GetAllCategories", con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            categories.Add(new StandardCategory()
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                Name = reader.GetString(reader.GetOrdinal("Name"))
                            });
                        }
                    }

                };
                return categories;
            }
            catch(Exception ex)
            {
                throw new Exception("Unable to retrieve category names" + ex.Message);
            }
        }
    }
}
