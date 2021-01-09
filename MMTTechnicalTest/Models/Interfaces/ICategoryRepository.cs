using System.Collections.Generic;

namespace MMTTechnicalTest.Models.Repositories
{
    public interface ICategoryRepository
    {
        public IEnumerable<StandardCategory>GetAllCategories();
    }
}
