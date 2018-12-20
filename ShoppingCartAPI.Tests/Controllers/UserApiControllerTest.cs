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
    public class UserApiControllerTest
    {
        #region Test method for Success

        //Test method on success of GetUserList
        [TestMethod]
        public void GetUserListSuccessTest()
        {
            // Arrange
            UserApiController controller = new UserApiController();
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            // Act
            var response = controller.GetUserList();

            // Assert
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Content);
            Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode);
        }


        //Test method on success of GetUserById
        [TestMethod]
        public void GetUserByIdSuccessTest()
        {
            // Arrange
            int UserId = 4;
            UserApiController controller = new UserApiController();
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            // Act
            var response = controller.GetUserById(UserId);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Content);
            Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode);
        }
        
        #endregion

        #region Test method for Exception

        //Test method on Failure of GetUserList
        [TestMethod]
        public void GetUserListFailureTest()
        {
            // Arrange
            UserApiController controller = new UserApiController();
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            // Act
            var response = controller.GetUserList();

            // Assert
            Assert.IsNotNull(response);
            Assert.AreEqual(System.Net.HttpStatusCode.InternalServerError, response.StatusCode);
        }


        //Test method on failure of GetUserById
        [TestMethod]
        public void GetUserByIdFailureTest()
        {
            // Arrange
            int UserId = 4;
            UserApiController controller = new UserApiController();
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            // Act
            var response = controller.GetUserById(UserId);

            // Assert
            Assert.IsNotNull(response);
            Assert.AreEqual(System.Net.HttpStatusCode.InternalServerError, response.StatusCode);
        }
        #endregion

        #region Test method for NoContent

        //Test method on No Content of GetUserList
        [TestMethod]
        public void GetUserListNoContentTest()
        {
            // Arrange
            UserApiController controller = new UserApiController();
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            // Act
            var response = controller.GetUserList();

            // Assert
            Assert.IsNotNull(response);
            Assert.AreEqual(System.Net.HttpStatusCode.NoContent, response.StatusCode);
        }


        //Test method on no content of GetUserById
        [TestMethod]
        public void GetUserByIdNoContentTest()
        {
            // Arrange
            int UserId = 4;
            UserApiController controller = new UserApiController();
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            // Act
            var response = controller.GetUserById(UserId);

            // Assert
            Assert.IsNotNull(response);
            Assert.AreEqual(System.Net.HttpStatusCode.NoContent, response.StatusCode);
        }
        #endregion
    }
}
