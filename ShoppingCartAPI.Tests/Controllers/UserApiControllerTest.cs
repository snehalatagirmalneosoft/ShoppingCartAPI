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
        [TestMethod]
        public void GetUserListTest()
        {
            // Arrange
            UserApiController controller = new UserApiController();
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            // Act
            var response = controller.GetUserList();

            // Assert
            Assert.IsNotNull(response);
            //Assert.AreEqual(200, response.StatusCode);
        }

        [TestMethod]
        public void GetUserByIdTest()
        {
            // Arrange
            UserApiController controller = new UserApiController();
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            // Act
            var response = controller.GetUserById(1);

            // Assert
            Assert.IsNotNull(response);
        }
    }
}
