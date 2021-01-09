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
    public class ProductControllerTests : ProductControllerTestsSetup
    {
        [TestMethod]
        public void GivenCategoryIdIsCorrect_WhenGetProductsByCategoryCalled_Then200ReponseCodeReturned()
        {
            ///Arrange
            var products = CreateProductList();
            ProductRepository.GetProductsByCategory(1).Returns(products);

            ///Act
            var result = Sut.GetProductsByCategory(1) as ObjectResult;

            ///Assert
            Assert.AreEqual(200, result.StatusCode);

        }

        [TestMethod]
        public void GivenNoProductsExistInSelectedCategory_WhenGetAllCategoryNamesCalled_Then404ReponseCodeReturned()
        {
            ///Arrange
            var products = new List<StandardProduct>();
            ProductRepository.GetProductsByCategory(1).Returns(products);

            ///Act
            var result = Sut.GetProductsByCategory(1) as ObjectResult;

            ///Assert
            Assert.AreEqual(404, result.StatusCode);

        }

    }

    [TestClass]
    public class ProductControllerTestsSetup
    {
        public ProductControllerTestsSetup()
        {
            this.ProductRepository = Substitute.For<IProductRepository>();
            this.Sut = new ProductController(ProductRepository);

        }

        public IProductRepository ProductRepository;

        public ProductController Sut;

        public List<StandardProduct> CreateProductList()
        {
            var products = Substitute.For<List<StandardProduct>>();
            products.Add(new StandardProduct()
            {
                Id = 1,
                Name = "Test product",
                Description = "This is a test",
                StockKeepingUnit = 13592,
                Price = 100,
                CategoryId = 1
            });
            return products;
        }

    }

}

