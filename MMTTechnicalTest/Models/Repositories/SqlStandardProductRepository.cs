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
        private string connectionString = ConfigurationManager.ConnectionStrings["MMTConnString"].ConnectionString;

        public void GetFeaturedProducts()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                ///Call stored procedure for featured products
            };
          
        }

        public void GetproductsByCategory(int Id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                ///Call stored procedure to get products by cat id
            };
            
        }
    }
}
