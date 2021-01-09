using Microsoft.AspNetCore.Mvc;
using MMTTechnicalTest.Models;
using MMTTechnicalTest.Models.Repositories;
using System.Collections.Generic;


namespace MMTTechnicalTest.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _standardProductRepository;

        public ProductController(IProductRepository standardProductRepository)
        {
            _standardProductRepository = standardProductRepository;
        }


        public IEnumerable<StandardProduct>GetFeaturedProducts()
        {
            return _standardProductRepository.GetFeaturedProducts();

        }

        public IEnumerable<StandardProduct>GetProductsByCategory(int categoryId)
        {
            return _standardProductRepository.GetproductsByCategory(categoryId);

        }
      
    }
}
