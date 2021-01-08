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

        public void GetproductsByCategory(int Id)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                ///Call stored procedure to get products by cat id
            };
            
        }
    }
}
