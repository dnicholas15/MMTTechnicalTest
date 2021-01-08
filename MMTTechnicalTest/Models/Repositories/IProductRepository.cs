using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MMTTechnicalTest.Models.Repositories
{
    public interface IProductRepository
    {
        public void GetFeaturedProducts();

        public void GetproductsByCategory(int Id);
    }
}
