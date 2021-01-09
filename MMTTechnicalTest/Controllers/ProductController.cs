using Microsoft.AspNetCore.Mvc;
using MMTTechnicalTest.Models.Repositories;
using System.Linq;

namespace MMTTechnicalTest.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _standardProductRepository;

        /// <summary>
        /// Constructor for the product controller with an injected product repository
        /// </summary>
        /// <param name="standardProductRepository">The injected product repository</param>
        public ProductController(IProductRepository standardProductRepository)
        {
            _standardProductRepository = standardProductRepository;
        }

        /// <summary>
        /// Api controller method for getting featured products
        /// </summary>
        /// <returns>A list of featured products</returns>
        [Route("Product/GetFeaturedProducts")]
        [HttpGet]
        public IActionResult GetFeaturedProducts()
        {
            var featuredProducts = _standardProductRepository.GetFeaturedProducts();

            ///Return a 404 if no featured products are found in the database
            if (!featuredProducts.Any())
            {
                return NotFound("No featured products were found");
            }
            return Ok(_standardProductRepository.GetFeaturedProducts());

        }

        /// <summary>
        /// Api controller method for getting products by their category id
        /// </summary>
        /// <param name="categoryId">The chosen catefory id</param>
        /// <returns></returns>
        [Route("Product/GetProductsByCategory/{categoryId?}")]
        [HttpGet]
        public IActionResult GetProductsByCategory(int categoryId)
        {
            var products = _standardProductRepository.GetproductsByCategory(categoryId);

            ///Return a 404 if no products are found belonging to that category
            if (!products.Any())
            {
                return NotFound("No products were found in the selected category");
            }
            return Ok(products);
        }
      
    }
}
