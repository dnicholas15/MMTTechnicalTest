using Microsoft.AspNetCore.Mvc;
using MMTTechnicalTest.Models;
using MMTTechnicalTest.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MMTTechnicalTest.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public List<string> GetAllCategoryNames()
        {
            var categories = _categoryRepository.GetAllCategories();
            var listOfCategoryNames = new List<string>();
            foreach(var category in categories)
            {
                listOfCategoryNames.Add(category.Name);
            }

            return listOfCategoryNames;
        }

    }
}
