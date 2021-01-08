using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MMTTechnicalTest.Models.Repositories
{
    public class SqlStandardCategoryRepository : ICategoryRepository
    {
        public IEnumerable<StandardCategory> GetAllCategories()
        {

            return new List<StandardCategory>();
            ///Call stored procedure to return all categories
        }
    }
}
