using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MMTTechnicalTest.Models.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace MMTTechnicalTest.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;

        /// <summary>
        /// constructore for the controller with injected category repository
        /// </summary>
        /// <param name="categoryRepository">The injected instance of the repository</param>
        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        /// <summary>
        /// Api controller method for getting category names
        /// </summary>
        /// <returns>A list of category names</returns>
        [Route("Category/GetAllCategoryNames")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetAllCategoryNames()
        {
            var categories = _categoryRepository.GetAllCategories();

            ///Return a 404 if there are no categories in the database
            if(!categories.Any())
            {
                return NotFound("No categories were found");
            }

            var listOfCategoryNames = new List<string>();
            foreach(var category in categories)
            {
                listOfCategoryNames.Add(category.Name);
            }

            return Ok(listOfCategoryNames);
        }

    }
}
