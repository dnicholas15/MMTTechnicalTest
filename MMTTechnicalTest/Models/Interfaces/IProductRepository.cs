using System.Collections.Generic;

namespace MMTTechnicalTest.Models.Repositories
{
    /// <summary>
    /// Interface for the product repository
    /// </summary>
    public interface IProductRepository
    {
        /// <summary>
        /// Method for getting all featured products
        /// </summary>
        /// <returns>A list of <see cref="StandardProduct"/></returns>
        public IEnumerable<StandardProduct> GetFeaturedProducts();

        /// <summary>
        /// Method for getting all products by the selected category id
        /// </summary>
        /// <param name="Id">The selected category id</param>
        /// <returns>A List of Standard Product </returns>
        public IEnumerable<StandardProduct> GetproductsByCategory(int Id);
    }
}
