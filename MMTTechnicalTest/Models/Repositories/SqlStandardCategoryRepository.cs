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
      
        public List<string> GetAllCategoryNames()
        {
            try
            {
                var categoryNames = new List<string>();
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("GetCategoryNames", con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            categoryNames.Add(reader.GetString(reader.GetOrdinal("Name")));
                        }
                    }

                };
                return categoryNames;
            }
            catch(Exception ex)
            {
                throw new Exception("Unable to retrieve category names" + ex.Message);
            }
        }
    }
}
