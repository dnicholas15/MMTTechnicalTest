using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MMTTechnicalTest.Models.Repositories
{
    public interface IProductRepository
    {
        public IEnumerable<StandardProduct> GetFeaturedProducts();

        public IEnumerable<StandardProduct> GetproductsByCategory(int Id);
    }
}
