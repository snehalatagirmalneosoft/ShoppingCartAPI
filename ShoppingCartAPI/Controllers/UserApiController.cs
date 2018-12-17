using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ShoppingCart.Common;
using ShoppingCart.DataAccess;
using ShoppingCart.Entity;

namespace ShoppingCartAPI.Controllers
{
    [RoutePrefix("api/UserAPI")]
    public class UserApiController : ApiController
    {

        /// <summary>
        /// 2018/05/24 - Vaishnavi Soni - 
        /// List Of Products for Home Page
        /// </summary>       
        /// <returns>HttpResponseMessage</returns>
        /// Get: ProductsAPI/GetProducts
        [HttpPost]
        [Route("GetUserList")]
        public HttpResponseMessage GetUserList()
        {
            ResponseMessage<List<STP_GetUsers_Result>> objResponseData = new ResponseMessage<List<STP_GetUsers_Result>>();

               
            return Request.CreateResponse(objResponseData.StatusCode, objResponseData);
        }
    }
}
