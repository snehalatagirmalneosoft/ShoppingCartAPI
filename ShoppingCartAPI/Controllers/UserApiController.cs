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
        UserDAL objUserDAL = new UserDAL();
        ErrorLogger objErrorLogger;

        /// <summary>
        /// 2018/12/17 - Deepanjali Yadav - 
        /// List Of Users
        /// </summary>       
        /// <returns>HttpResponseMessage</returns>
        /// Get: UserAPI/GetUserList
        [Authorize]
        [HttpPost]
        [Route("GetUserList")]
        public HttpResponseMessage GetUserList()
        {
            ResponseMessage<List<STP_GetUsers_Result>> objResponseData = new ResponseMessage<List<STP_GetUsers_Result>>();
            try
            {
                List<STP_GetUsers_Result> userList = objUserDAL.GetUserList().Where(com => com.IsActive == true).ToList();

                if (userList.Count > 0)
                {
                    objResponseData = ResponseHandler<STP_GetUsers_Result>.CreateResponse(objResponseData, "List Of Users", userList, HttpStatusCode.OK);
                }
                else
                {
                    objResponseData = ResponseHandler<STP_GetUsers_Result>.CreateResponse(objResponseData, "No Users Available", userList, HttpStatusCode.NoContent);
                }
            }
            catch (System.Exception ex)
            {
                objErrorLogger.ErrorLog(ex);
                objResponseData = ResponseHandler<STP_GetUsers_Result>.CreateErrorResponse(objResponseData);
            }
            return Request.CreateResponse(objResponseData.StatusCode, objResponseData);
        }

        /// <summary>
        /// 2018/12/17 - Deepanjali Yadav - 
        /// Get User By Id
        /// </summary>       
        /// <returns>HttpResponseMessage</returns>
        /// Get: UserAPI/GetUserById
        [HttpPost]
        [Route("GetUserById")]
        public HttpResponseMessage GetUserById(int Id)
        {
            ResponseMessage<STP_GetUserDetails_Result> objResponseData = new ResponseMessage<STP_GetUserDetails_Result>();
            try
            {
                STP_GetUserDetails_Result userDetail = objUserDAL.GetUserById(Id);

                if (userDetail != null)
                {                  
                    objResponseData = ResponseHandler<STP_GetUserDetails_Result>.CreateResponse(objResponseData, "Detail Of Users", userDetail, HttpStatusCode.OK);
                }
                else
                {
                    objResponseData = ResponseHandler<STP_GetUserDetails_Result>.CreateResponse(objResponseData, "No Users Available", userDetail, HttpStatusCode.NoContent);
                }
            }
            catch (System.Exception ex)
            {
                objErrorLogger.ErrorLog(ex);
                objResponseData = ResponseHandler<STP_GetUserDetails_Result>.CreateErrorResponse(objResponseData);
            }
            return Request.CreateResponse(objResponseData.StatusCode, objResponseData);
        }
    }
}
