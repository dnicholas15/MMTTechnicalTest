using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MMTTechnicalTest.Controllers;
using MMTTechnicalTest.Models;
using MMTTechnicalTest.Models.Repositories;
using NSubstitute;
using System.Collections.Generic;

namespace MMTTechnicalTestTests
{
    [TestClass]
    public class CategoryControllerTests : CategoryControllerTestsSetup
    {
        [TestMethod]
        public void GivenCategoriesExistInDatabase_WhenGetAllCategoryNamesCalled_Then200ReponseCodeReturned()
        {
            ///Arrange
            var categories = CreateCategoryList();
            CategoryRepository.GetAllCategories().Returns(categories);

            ///Act
            var result = Sut.GetAllCategoryNames() as ObjectResult;

            ///Assert
            Assert.AreEqual(200, result.StatusCode);

        }

        [TestMethod]
        public void GivenNoCategoriesExistInDatabase_WhenGetAllCategoryNamesCalled_Then404ReponseCodeReturned()
        {
            ///Arrange
            var categories = new List<StandardCategory>();
            CategoryRepository.GetAllCategories().Returns(categories);

            ///Act
            var result = Sut.GetAllCategoryNames() as ObjectResult;

            ///Assert
            Assert.AreEqual(404, result.StatusCode);

        }

    }

    [TestClass]
    public class CategoryControllerTestsSetup
    {
        public CategoryControllerTestsSetup()
        {
            this.CategoryRepository = Substitute.For<ICategoryRepository>();
            this.Sut = new CategoryController(CategoryRepository);

        }

        public ICategoryRepository CategoryRepository;

        public CategoryController Sut;

        public List<StandardCategory> CreateCategoryList()
        {
            var categories = Substitute.For<List<StandardCategory>>();
            categories.Add(new StandardCategory()
            {
                Id = 1,
                Name = "Test"
            });
            return categories;
        }

    }

}

