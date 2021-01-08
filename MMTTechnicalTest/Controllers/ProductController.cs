using Microsoft.AspNetCore.Mvc;
using MMTTechnicalTest.Models;
using MMTTechnicalTest.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MMTTechnicalTest.Controllers
{
    public class ProductController : Controller
    {

        private readonly IProductRepository _standardProductRepository;
        private readonly ICategoryRepository _standardCategoryRepository;

        public ProductController(ICategoryRepository standardCategoryRepository, IProductRepository standardProductRepository)
        {
            _standardCategoryRepository = standardCategoryRepository;
            _standardProductRepository = standardProductRepository;
        }


        public IEnumerable<StandardProduct>GetFeaturedProducts()
        {
             return new List<StandardProduct>();

        }

        public IEnumerable<StandardProduct>GetProductsByCategory()
        {
            return new List<StandardProduct>();

        }

      
    }
}
