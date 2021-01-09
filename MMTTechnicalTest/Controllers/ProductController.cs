using Microsoft.AspNetCore.Mvc;
using MMTTechnicalTest.Models.Repositories;
using System.Linq;

namespace MMTTechnicalTest.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _standardProductRepository;

        public ProductController(IProductRepository standardProductRepository)
        {
            _standardProductRepository = standardProductRepository;
        }

        [Route("Product/GetFeaturedProducts")]
        [HttpGet]
        public IActionResult GetFeaturedProducts()
        {
            var featuredProducts = _standardProductRepository.GetFeaturedProducts();
            if (!featuredProducts.Any())
            {
                return NotFound("No featured products were found");
            }
            return Ok(_standardProductRepository.GetFeaturedProducts());

        }

        [Route("Product/GetProductsByCategory/{categoryId?}")]
        [HttpGet]
        public IActionResult GetProductsByCategory(int categoryId)
        {
            var products = _standardProductRepository.GetproductsByCategory(categoryId);
            if (!products.Any())
            {
                return NotFound("No products were found in the selected category");
            }
            return Ok(products);
        }
      
    }
}
