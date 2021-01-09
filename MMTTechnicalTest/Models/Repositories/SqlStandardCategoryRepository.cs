using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace MMTTechnicalTest.Models.Repositories
{
    /// <summary>
    /// The concrete implementation of the standard category repository using an SQL data store
    /// </summary>
    public class SqlStandardCategoryRepository : ICategoryRepository
    {
        private string _connectionString;

        /// <summary>
        /// inject the config through the constructor and use it to get the DB connection string
        /// </summary>
        /// <param name="configuration">The application config</param>
        public SqlStandardCategoryRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("MMTConn");
        }
      
        /// <summary>
        /// The method for getting all categories from the database
        /// </summary>
        /// <returns>A List of <see cref="StandardCategory"/></returns>
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
            catch(Exception)
            {
                throw new Exception("Unable to retrieve category names");
            }
        }
    }
}
