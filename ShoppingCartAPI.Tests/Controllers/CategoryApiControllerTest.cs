using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShoppingCart.Entity;
using ShoppingCartAPI.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace ShoppingCartAPI.Tests.Controllers
{
    [TestClass]
    public class CategoryApiControllerTest
    {
        #region SuccessTest

        [TestMethod]
        public void GetGetCategoriesSuccessTest()
        {
            // Arrange
            CategoryApiController controller = new CategoryApiController();
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            //Act
            var response = controller.GetCategories();

            // Assert
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Content);
            Assert.AreEqual(200, response.StatusCode);
        }

        [TestMethod]
        public void GetCategoryByIdSuccessTest()
        {
            // Arrange
            CategoryApiController controller = new CategoryApiController
            {
                Request = new System.Net.Http.HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };

            // Act
            Category category = new Category();
            category.CategoryId = 19;
            var response = controller.GetCategoryById(category.CategoryId);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Content);
            Assert.AreEqual(200, response.StatusCode);
        }

        [TestMethod]
        public void AddCategorySuccessTest()
        {
            // Arrange
            CategoryApiController controller = new CategoryApiController
            {
                Request = new System.Net.Http.HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };

            // Act
            Category category = new Category();
            category.CategoryName = "Artworks";
            category.CreatedOn = DateTime.Now;
            category.IsActive = true;

            var response = controller.AddCategory(category);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Content);
            Assert.AreEqual(200, response.StatusCode);
        }

        [TestMethod]
        public void UpdateCategorySuccessTest()
        {
            // Arrange
            CategoryApiController controller = new CategoryApiController
            {
                Request = new System.Net.Http.HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };

            // Act
            Category category = new Category();
            category.CategoryId = 19;
            category.CategoryName = "Clothing";
            category.ModifiedOn = DateTime.Now;
            category.IsActive = true;

            var response = controller.UpdateCategory(category);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Content);
            Assert.AreEqual(200, response.StatusCode);
        }

        public void DeleteCategorySuccessTest()
        {
            // Arrange
            CategoryApiController controller = new CategoryApiController
            {
                Request = new System.Net.Http.HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };

            // Act
            Category category = new Category();
            category.CategoryId = 19;

            var response = controller.DeleteCategory(category.CategoryId);

            // Assert
            Assert.IsNotNull(response);
            Assert.AreEqual(200, response.StatusCode);
        }

        #endregion

        #region FailureTest

        [TestMethod]
        public void GetGetCategoriesFailureTest()
        {
            // Arrange
            CategoryApiController controller = new CategoryApiController();
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            // Act
            var response = controller.GetCategories();

            // Assert
            Assert.IsNotNull(response);
            Assert.IsNull(response.Content);
            Assert.AreEqual(500, response.StatusCode);
        }

        [TestMethod]
        public void GetCategoryByIdFailureTest()
        {
            // Arrange
            CategoryApiController controller = new CategoryApiController
            {
                Request = new System.Net.Http.HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };

            // Act
            Category category = new Category();
            category.CategoryId = 19;
            var response = controller.GetCategoryById(category.CategoryId);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsNull(response.Content);
            Assert.AreEqual(500, response.StatusCode);
        }

        [TestMethod]
        public void AddCategoryFailureTest()
        {
            // Arrange
            CategoryApiController controller = new CategoryApiController
            {
                Request = new System.Net.Http.HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };

            // Act
            Category category = new Category();
            category.CategoryName = "Artworks";
            category.CreatedOn = DateTime.Now;
            category.IsActive = true;

            var response = controller.AddCategory(category);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsNull(response.Content);
            Assert.AreEqual(500, response.StatusCode);
        }

        [TestMethod]
        public void UpdateCategoryFailureTest()
        {
            // Arrange
            CategoryApiController controller = new CategoryApiController
            {
                Request = new System.Net.Http.HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };

            // Act
            Category category = new Category();
            category.CategoryId = 19;
            category.CategoryName = "Clothing";
            category.ModifiedOn = DateTime.Now;
            category.IsActive = true;

            var response = controller.UpdateCategory(category);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsNull(response.Content);
            Assert.AreEqual(500, response.StatusCode);
        }

        public void DeleteCategoryFailureTest()
        {
            // Arrange
            CategoryApiController controller = new CategoryApiController
            {
                Request = new System.Net.Http.HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };

            // Act
            Category category = new Category();
            category.CategoryId = 19;

            var response = controller.DeleteCategory(category.CategoryId);

            // Assert
            Assert.IsNotNull(response);
            Assert.AreEqual(500, response.StatusCode);
        }

        #endregion

        #region ConflictTest

        [TestMethod]
        public void GetGetCategoriesContentTest()
        {
            // Arrange
            CategoryApiController controller = new CategoryApiController();
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            // Act
            var response = controller.GetCategories();

            // Assert
            Assert.IsNotNull(response);
            Assert.AreEqual(204, response.StatusCode);
        }

        [TestMethod]
        public void GetCategoryByIdConflictTest()
        {
            // Arrange
            CategoryApiController controller = new CategoryApiController
            {
                Request = new System.Net.Http.HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };

            // Act
            Category category = new Category();
            category.CategoryId = 1;
            var response = controller.GetCategoryById(category.CategoryId);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsNull(response.Content);
            Assert.AreEqual(409, response.StatusCode);
        }

        [TestMethod]
        public void AddCategoryConflictTest()
        {
            // Arrange
            CategoryApiController controller = new CategoryApiController
            {
                Request = new System.Net.Http.HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };

            // Act
            Category category = new Category();
            category.CategoryName = "Stationary";
            category.CreatedOn = DateTime.Now;
            category.IsActive = true;

            var response = controller.AddCategory(category);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsNull(response.Content);
            Assert.AreEqual(409, response.StatusCode);
        }

        [TestMethod]
        public void UpdateCategoryConflictTest()
        {
            // Arrange
            CategoryApiController controller = new CategoryApiController
            {
                Request = new System.Net.Http.HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };

            // Act
            Category category = new Category();
            category.CategoryId = 1;
            category.CategoryName = "Clothing";
            category.ModifiedOn = DateTime.Now;
            category.IsActive = true;

            var response = controller.UpdateCategory(category);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsNull(response.Content);
            Assert.AreEqual(409, response.StatusCode);
        }

        public void DeleteCategoryConflictTest()
        {
            // Arrange
            CategoryApiController controller = new CategoryApiController
            {
                Request = new System.Net.Http.HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };

            // Act
            Category category = new Category();
            category.CategoryId = 1;

            var response = controller.DeleteCategory(category.CategoryId);

            // Assert
            Assert.IsNotNull(response);
            Assert.AreEqual(409, response.StatusCode);
        }

        #endregion

    }
}
