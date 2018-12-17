using ShoppingCart.Common;
using ShoppingCart.DataAccess;
using ShoppingCart.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ShoppingCartAPI.Controllers
{
    [RoutePrefix("api/CategoryApi")]
    public class CategoryApiController : ApiController
    {
        CategoryDAL objCategoryDAL;
        ErrorLogger objErrorLogger;

        public CategoryApiController()
        {
            objCategoryDAL = new CategoryDAL();
            objErrorLogger = new ErrorLogger();
        }

        #region Categories

        /// <summary>
        /// 2018/12/17 - Vaishnavi Soni - 
        /// List Of Categories
        /// </summary>       
        /// <returns>HttpResponseMessage</returns>
        /// Get: CategoriesApi/GetCategories
        [HttpGet]
        [Route("GetCategories")]
        public HttpResponseMessage GetCategories()
        {
            ResponseMessage<List<Category>> objResponseData = new ResponseMessage<List<Category>>();
            try
            {
                List<Category> categories = objCategoryDAL.GetAllCategories().ToList();
                objResponseData = ResponseHandler<Category>.CreateResponse(objResponseData, "List Of Available Product Categories", categories, HttpStatusCode.OK);

            }
            catch (System.Exception ex)
            {
                objErrorLogger.ErrorLog(ex);
                objResponseData = ResponseHandler<Category>.CreateErrorResponse(objResponseData);
            }
            return Request.CreateResponse(objResponseData.StatusCode, objResponseData);
        }

        /// <summary>
        /// 2018/12/17 - Vaishnavi Soni - 
        /// Get Category By Id
        /// </summary>       
        /// <returns>HttpResponseMessage</returns>
        /// Post: CategoriesApi/GetCategoryById
        [HttpPost]
        [Route("GetCategoryById")]
        public HttpResponseMessage GetCategoryById(Category category)
        {
            ResponseMessage<Category> objResponseData = new ResponseMessage<Category>();
            try
            {
                Category categoryDetails = objCategoryDAL.GetCategoryDetails(category);
                objResponseData = ResponseHandler<Category>.CreateResponse(objResponseData, "Category details", categoryDetails, HttpStatusCode.OK);

            }
            catch (System.Exception ex)
            {
                objErrorLogger.ErrorLog(ex);
                objResponseData = ResponseHandler<Category>.CreateErrorResponse(objResponseData);
            }
            return Request.CreateResponse(objResponseData.StatusCode, objResponseData);
        }

        /// <summary>
        /// 2018/12/17 - Vaishnavi Soni - 
        /// Add Category
        /// </summary>       
        /// <returns>HttpResponseMessage</returns>
        /// Post: CategoriesApi/AddCategory
        [HttpPost]
        [Route("AddCategory")]
        public HttpResponseMessage AddCategory(Category category)
        {
            ResponseMessage<Category> objResponseData = new ResponseMessage<Category>();
            try
            {
                Category newCategory = objCategoryDAL.AddCategory(category);
                if (newCategory.CategoryId > 0)
                {
                    objResponseData = ResponseHandler<Category>.CreateResponse(objResponseData, "Successfully Added A New Category.", newCategory, HttpStatusCode.OK);
                }
                else
                {
                    objResponseData = ResponseHandler<Category>.CreateResponse(objResponseData, "Can't Add This Category.", HttpStatusCode.Conflict);
                }
            }
            catch (System.Exception ex)
            {
                objErrorLogger.ErrorLog(ex);
                objResponseData = ResponseHandler<Category>.CreateErrorResponse(objResponseData);
            }
            return Request.CreateResponse(objResponseData.StatusCode, objResponseData);
        }

        /// <summary>
        /// 2018/12/17 - Vaishnavi Soni - 
        /// Update Category
        /// </summary>       
        /// <returns>HttpResponseMessage</returns>
        /// Post: CategoriesApi/UpdateCategory
        [HttpPost]
        [Route("UpdateCategory")]
        public HttpResponseMessage UpdateCategory(Category category)
        {
            ResponseMessage<Category> objResponseData = new ResponseMessage<Category>();
            try
            {
                Category updatedCategory = new Category();
                int isSucceeded = objCategoryDAL.UpdateCategory(category);
                if (isSucceeded > 0)
                {
                    updatedCategory = objCategoryDAL.GetCategoryDetails(category);
                    objResponseData = ResponseHandler<Category>.CreateResponse(objResponseData, "Category Has Been Updated Successfully.", updatedCategory, HttpStatusCode.OK);
                }
                else
                {
                    objResponseData = ResponseHandler<Category>.CreateResponse(objResponseData, "Can't Update Category.", category, HttpStatusCode.Conflict);
                }
            }
            catch (System.Exception ex)
            {
                objErrorLogger.ErrorLog(ex);
                objResponseData = ResponseHandler<Category>.CreateErrorResponse(objResponseData);
            }
            return Request.CreateResponse(objResponseData.StatusCode, objResponseData);
        }

        /// <summary>
        /// 2018/12/17 - Vaishnavi Soni - 
        /// Delete Category
        /// </summary>       
        /// <returns>HttpResponseMessage</returns>
        /// Delete: CategoriesApi/DeleteCategory
        [HttpDelete]
        [Route("DeleteCategory")]
        public HttpResponseMessage DeleteCategory(Category category)
        {
            ResponseMessage<Category> objResponseData = new ResponseMessage<Category>();
            try
            {
                int isDeleted = objCategoryDAL.DeleteCategory(category);

                if (isDeleted > 0)
                {
                    objResponseData = ResponseHandler<Category>.CreateResponse(objResponseData, "Category Has Been Deleted.", HttpStatusCode.OK);
                }
                else
                {
                    objResponseData = ResponseHandler<Category>.CreateResponse(objResponseData, "Can't Delete Category", HttpStatusCode.NoContent);
                }
            }
            catch (System.Exception ex)
            {
                objErrorLogger.ErrorLog(ex);
                objResponseData = ResponseHandler<Category>.CreateErrorResponse(objResponseData);
            }
            return Request.CreateResponse(objResponseData.StatusCode, objResponseData);
        }

        #endregion


    }
}
