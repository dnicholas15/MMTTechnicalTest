using MMTTechnicalTest.Models.DTOs;
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
        /// <returns>A list of <see cref="StandardProductDto"/></returns>
        public IEnumerable<StandardProductDto> GetFeaturedProducts();

        /// <summary>
        /// Method for getting all products by the selected category id
        /// </summary>
        /// <param name="Id">The selected category id</param>
        /// <returns>A List of <see cref="StandardProductDto"/> </returns>
        public IEnumerable<StandardProductDto> GetProductsByCategory(int Id);
    }
}
