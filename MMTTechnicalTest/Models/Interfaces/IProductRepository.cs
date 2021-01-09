using System.Collections.Generic;

namespace MMTTechnicalTest.Models.Repositories
{
    public interface IProductRepository
    {
        public IEnumerable<StandardProduct> GetFeaturedProducts();

        public IEnumerable<StandardProduct> GetproductsByCategory(int Id);
    }
}
