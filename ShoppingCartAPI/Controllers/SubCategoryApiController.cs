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
    public class SubCategoryApiController : ApiController
    {
        SubCategoryDAL objCategoryDAL;
        ErrorLogger objErrorLogger;

        public SubCategoryApiController()
        {
            objCategoryDAL = new SubCategoryDAL();
            objErrorLogger = new ErrorLogger();
        }

        #region SubCategories

        /// <summary>
        /// 2018/12/18 - Ranjit - 
        /// List Of Categories
        /// </summary>       
        /// <returns>HttpResponseMessage</returns>
        /// Get: GetSubCategories
        [HttpGet]
        [Route("GetSubCategories")]
        public HttpResponseMessage GetSubCategories()
        {
            ResponseMessage<List<STP_GetAllSubCategories_Result>> objResponseData = new ResponseMessage<List<STP_GetAllSubCategories_Result>>();
            try
            {
                List<STP_GetAllSubCategories_Result> categories = objCategoryDAL.GetAllSubCategories().ToList();


                objResponseData = ResponseHandler<STP_GetAllSubCategories_Result>.CreateResponse(objResponseData, "List Of Available Product Categories", categories, HttpStatusCode.OK);

            }
            catch (System.Exception ex)
            {
                objErrorLogger.ErrorLog(ex);
                objResponseData = ResponseHandler<STP_GetAllSubCategories_Result>.CreateErrorResponse(objResponseData);
            }
            return Request.CreateResponse(objResponseData.StatusCode, objResponseData);
        }

        /// <summary>
        /// 2018/12/18 - Ranjit - 
        /// Get Category By Id
        /// </summary>       
        /// <returns>HttpResponseMessage</returns>
        /// Post: GetSubCategoryById
        [HttpGet]
        [Route("GetSubCategoryById")]
        public HttpResponseMessage GetSubCategoryById(int SubCategoryId)
        {
            ResponseMessage<STP_GetSubCategoryDetails_Result> objResponseData = new ResponseMessage<STP_GetSubCategoryDetails_Result>();
            try
            {
                var categoryDetails = objCategoryDAL.GetSubCategoryDetails(SubCategoryId);
                objResponseData = ResponseHandler<STP_GetSubCategoryDetails_Result>.CreateResponse(objResponseData, "Category details", categoryDetails, HttpStatusCode.OK);

            }
            catch (System.Exception ex)
            {
                objErrorLogger.ErrorLog(ex);
                objResponseData = ResponseHandler<STP_GetSubCategoryDetails_Result>.CreateErrorResponse(objResponseData);
            }
            return Request.CreateResponse(objResponseData.StatusCode, objResponseData);
        }

        /// <summary>
        /// 2018/12/18 - Ranjit - 
        /// Add Category
        /// </summary>       
        /// <returns>HttpResponseMessage</returns>
        /// Post: AddSubCategory
        [HttpPost]
        [Route("AddSubCategory")]
        public HttpResponseMessage AddSubCategory(SubCategory category)
        {
            ResponseMessage<int> objResponseData = new ResponseMessage<int>();
            try
            {
                var newCategory = objCategoryDAL.AddSubCategory(category);
                if (newCategory > 0)
                {
                    objResponseData = ResponseHandler<int>.CreateResponse(objResponseData, "Successfully Added A New Category.", newCategory, HttpStatusCode.OK);
                }
                else
                {
                    objResponseData = ResponseHandler<int>.CreateResponse(objResponseData, "Can't Add This Category.", HttpStatusCode.Conflict);
                }
            }
            catch (System.Exception ex)
            {
                objErrorLogger.ErrorLog(ex);
                objResponseData = ResponseHandler<int>.CreateErrorResponse(objResponseData);
            }
            return Request.CreateResponse(objResponseData.StatusCode, objResponseData);
        }

        /// <summary>
        /// 2018/12/18 - Ranjit - 
        /// Update Category
        /// </summary>       
        /// <returns>HttpResponseMessage</returns>
        /// Post: UpdateSubCategory
        [HttpPost]
        [Route("UpdateSubCategory")]
        public HttpResponseMessage UpdateSubCategory(SubCategory category)
        {
            ResponseMessage<int> objResponseData = new ResponseMessage<int>();
            try
            {
                SubCategory updatedCategory = new SubCategory();
                int isSucceeded = objCategoryDAL.UpdateSubCategory(category);
                if (isSucceeded > 0)
                {
                    objResponseData = ResponseHandler<int>.CreateResponse(objResponseData, "Category Has Been Updated Successfully.", isSucceeded, HttpStatusCode.OK);
                }
                else
                {
                    objResponseData = ResponseHandler<int>.CreateResponse(objResponseData, "Can't Update Category.", isSucceeded, HttpStatusCode.Conflict);
                }
            }
            catch (System.Exception ex)
            {
                objErrorLogger.ErrorLog(ex);
                objResponseData = ResponseHandler<int>.CreateErrorResponse(objResponseData);
            }
            return Request.CreateResponse(objResponseData.StatusCode, objResponseData);
        }

        /// <summary>
        /// 2018/12/18 - Ranjit - 
        /// Delete Category
        /// </summary>       
        /// <returns>HttpResponseMessage</returns>
        /// Delete: DeleteSubCategory
        [HttpDelete]
        [Route("DeleteSubCategory")]
        public HttpResponseMessage DeleteSubCategory(int SubCategoryId)
        {
            ResponseMessage<int> objResponseData = new ResponseMessage<int>();
            try
            {
                int isDeleted = objCategoryDAL.DeleteSubCategory(SubCategoryId);

                if (isDeleted > 0)
                {
                    objResponseData = ResponseHandler<int>.CreateResponse(objResponseData, "Category Has Been Deleted.", isDeleted, HttpStatusCode.OK);
                }
                else
                {
                    objResponseData = ResponseHandler<int>.CreateResponse(objResponseData, "Can't Delete Category", HttpStatusCode.NoContent);
                }
            }
            catch (System.Exception ex)
            {
                objErrorLogger.ErrorLog(ex);
                objResponseData = ResponseHandler<int>.CreateErrorResponse(objResponseData);
            }
            return Request.CreateResponse(objResponseData.StatusCode, objResponseData);
        }

        #endregion

    }
}