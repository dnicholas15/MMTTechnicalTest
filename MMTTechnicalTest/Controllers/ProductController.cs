using Microsoft.AspNetCore.Mvc;
using MMTTechnicalTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MMTTechnicalTest.Controllers
{
    public class ProductController : Controller
    {

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
