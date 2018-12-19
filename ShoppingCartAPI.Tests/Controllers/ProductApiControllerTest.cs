using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShoppingCartAPI.Controllers;
using System.Net.Http;
using System.Web.Http;
using ShoppingCart.Entity;


namespace ShoppingCartAPI.Tests.Controllers
{
    [TestClass]
    public class ProductApiControllerTest
    {
        #region Test method for Success

        //Test method on success of GetProductList
        [TestMethod]
        public void GetProductListTest()
        {
            // Arrange
            ProductApiController controller = new ProductApiController();
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            // Act
            var response = controller.GetProductList();

            // Assert
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Content);
            Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode);
        }


        //Test method on success of GetProductById
        [TestMethod]
        public void GetProductByIdTest()
        {
            // Arrange
            int ProductId = 1;
            ProductApiController controller = new ProductApiController();
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            // Act
            var response = controller.GetProductById(ProductId);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Content);
            Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode);
        }

        //Test method on success of Addproduct
        [TestMethod]
        public void AddProductTest()
        {
            // Arrange
            Product product = new Product();
            product.SubCategoryId = 1025;
            product.ProductName = "dyd";
            product.CreatedOn = Convert.ToDateTime("12/13/2018");
            product.CreatedBy = 4;
            product.Price = 100;
            product.ProductDescription = "sf";
            product.IsActive = true;
            product.Quantity = 5;

            ProductApiController controller = new ProductApiController();
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            // Act
            var response = controller.AddProduct(product);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Content);
            Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode);
        }

        //Test method on success of UpdateProduct
        [TestMethod]
        public void UpdateProductTest()
        {
            // Arrange
            Product product = new Product();
            product.ProductId = 1;
            product.SubCategoryId = 1025;
            product.ProductName = "dyd";
            product.ModifiedOn = Convert.ToDateTime("12/13/2018");
            product.ModifiedBy = 4;
            product.Price = 100;
            product.ProductDescription = "sf";
            product.IsActive = true;
            product.Quantity = 5;

            ProductApiController controller = new ProductApiController();
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            // Act
            var response = controller.UpdateProduct(product);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Content);
            Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode);
        }

        //Test method on success of DeleteProduct
        [TestMethod]
        public void DeleteProductTest()
        {
            // Arrange
            Product product = new Product();
            product.ProductId = 1;
            ProductApiController controller = new ProductApiController();
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            // Act
            var response = controller.DeleteProduct(product);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Content);
            Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode);
        }

        #endregion

        #region Test method for Exception

        //Test method on Failure of GetProductList
        [TestMethod]
        public void GetProductListFailureTest()
        {
            // Arrange
            ProductApiController controller = new ProductApiController();
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            // Act
            var response = controller.GetProductList();

            // Assert
            Assert.IsNotNull(response);
            Assert.AreEqual(System.Net.HttpStatusCode.InternalServerError, response.StatusCode);
        }

        //Test method on success of GetProductById
        [TestMethod]
        public void GetProductByIdFailureTest()
        {
            // Arrange
            int ProductId = 1;
            ProductApiController controller = new ProductApiController();
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            // Act
            var response = controller.GetProductById(ProductId);

            // Assert
            Assert.IsNotNull(response);
            Assert.AreEqual(System.Net.HttpStatusCode.InternalServerError, response.StatusCode);
        }

        //Test method on success of Addproduct
        [TestMethod]
        public void AddProductFailureTest()
        {
            // Arrange
            Product product = new Product();
            product.SubCategoryId = 1025;
            product.ProductName = "dyd";
            product.CreatedOn = Convert.ToDateTime("12/13/2018");
            product.CreatedBy = 4;
            product.Price = 100;
            product.ProductDescription = "sf";
            product.IsActive = true;
            product.Quantity = 5;

            ProductApiController controller = new ProductApiController();
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            // Act
            var response = controller.AddProduct(product);

            // Assert
            Assert.IsNotNull(response);
            Assert.AreEqual(System.Net.HttpStatusCode.InternalServerError, response.StatusCode);
        }

        //Test method on success of UpdateProduct
        [TestMethod]
        public void UpdateProductFailureTest()
        {
            // Arrange
            Product product = new Product();
            product.ProductId = 1;
            product.SubCategoryId = 1025;
            product.ProductName = "dyd";
            product.ModifiedOn = Convert.ToDateTime("12/13/2018");
            product.ModifiedBy = 4;
            product.Price = 100;
            product.ProductDescription = "sf";
            product.IsActive = true;
            product.Quantity = 5;

            ProductApiController controller = new ProductApiController();
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            // Act
            var response = controller.UpdateProduct(product);

            // Assert
            Assert.IsNotNull(response);
            Assert.AreEqual(System.Net.HttpStatusCode.InternalServerError, response.StatusCode);
        }

        //Test method on success of DeleteProduct
        [TestMethod]
        public void DeleteProductFailureTest()
        {
            // Arrange
            Product product = new Product();
            product.ProductId = 1;
            ProductApiController controller = new ProductApiController();
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            // Act
            var response = controller.DeleteProduct(product);

            // Assert
            Assert.IsNotNull(response);
            Assert.AreEqual(System.Net.HttpStatusCode.InternalServerError, response.StatusCode);
        }

        #endregion

        #region Test method for NoContent

        //Test method on Failure of GetProductList
        [TestMethod]
        public void GetProductListNoContentTest()
        {
            // Arrange
            ProductApiController controller = new ProductApiController();
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            // Act
            var response = controller.GetProductList();

            // Assert
            Assert.IsNotNull(response);
            Assert.AreEqual(System.Net.HttpStatusCode.NoContent, response.StatusCode);
        }

        //Test method on success of GetProductById
        [TestMethod]
        public void GetProductByIdNoContentTest()
        {
            // Arrange
            int ProductId = 1;
            ProductApiController controller = new ProductApiController();
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            // Act
            var response = controller.GetProductById(ProductId);

            // Assert
            Assert.IsNotNull(response);
            Assert.AreEqual(System.Net.HttpStatusCode.NoContent, response.StatusCode);
        }

        //Test method on success of Addproduct
        [TestMethod]
        public void AddProductNoContentTest()
        {
            // Arrange
            Product product = new Product();
            product.SubCategoryId = 1025;
            product.ProductName = "dyd";
            product.CreatedOn = Convert.ToDateTime("12/13/2018");
            product.CreatedBy = 4;
            product.Price = 100;
            product.ProductDescription = "sf";
            product.IsActive = true;
            product.Quantity = 5;

            ProductApiController controller = new ProductApiController();
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            // Act
            var response = controller.AddProduct(product);

            // Assert
            Assert.IsNotNull(response);
            Assert.AreEqual(System.Net.HttpStatusCode.NoContent, response.StatusCode);
        }

        //Test method on success of UpdateProduct
        [TestMethod]
        public void UpdateProductNoContentTest()
        {
            // Arrange
            Product product = new Product();
            product.ProductId = 1;
            product.SubCategoryId = 1025;
            product.ProductName = "dyd";
            product.ModifiedOn = Convert.ToDateTime("12/13/2018");
            product.ModifiedBy = 4;
            product.Price = 100;
            product.ProductDescription = "sf";
            product.IsActive = true;
            product.Quantity = 5;

            ProductApiController controller = new ProductApiController();
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            // Act
            var response = controller.UpdateProduct(product);

            // Assert
            Assert.IsNotNull(response);
            Assert.AreEqual(System.Net.HttpStatusCode.NoContent, response.StatusCode);
        }

        //Test method on success of DeleteProduct
        [TestMethod]
        public void DeleteProductNoContentTest()
        {
            // Arrange
            Product product = new Product();
            product.ProductId = 1;
            ProductApiController controller = new ProductApiController();
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            // Act
            var response = controller.DeleteProduct(product);

            // Assert
            Assert.IsNotNull(response);
            Assert.AreEqual(System.Net.HttpStatusCode.NoContent, response.StatusCode);
        }

        #endregion
    }
}
