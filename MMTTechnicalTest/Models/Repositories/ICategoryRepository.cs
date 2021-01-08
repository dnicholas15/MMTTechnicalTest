using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MMTTechnicalTest.Models.Repositories
{
    public interface ICategoryRepository
    {
        public IEnumerable<StandardCategory> GetAllCategories();

    }
}
