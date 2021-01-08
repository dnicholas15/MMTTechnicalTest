using Microsoft.AspNetCore.Mvc;
using MMTTechnicalTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MMTTechnicalTest.Controllers
{
    public class CategoryController : Controller
    {

        public IEnumerable<StandardCategory>GetAllCategories()
        {
            return new List<StandardCategory>();
        }

    }
}
