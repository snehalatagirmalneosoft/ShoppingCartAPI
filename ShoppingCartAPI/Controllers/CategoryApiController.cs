using AutoMapper;
using ShoppingCart.Common;
using ShoppingCart.DataAccess;
using ShoppingCart.Entity;
using ShoppingCartAPI.Models;
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
            ResponseMessage<List<CategoryModel>> objResponseData = new ResponseMessage<List<CategoryModel>>();
            try
            {
                List<CategoryModel> categoryModelList = new List<CategoryModel>();
                List<Category> categories = objCategoryDAL.GetAllCategories().ToList();
                if(categories.Count > 0)
                {
                    foreach(Category cat in categories)
                    {
                        CategoryModel categoryModel = new CategoryModel();
                        categoryModel = Mapper.Map<Category, CategoryModel>(cat, categoryModel);
                        
                        categoryModelList.Add(categoryModel);
                    }
                    objResponseData = ResponseHandler<CategoryModel>.CreateResponse(objResponseData, "List Of Available Product Categories", categoryModelList, HttpStatusCode.OK);
                }
                else  //categories are not available
                {
                    objResponseData = ResponseHandler<CategoryModel>.CreateResponse(objResponseData, "No categories area available.",  HttpStatusCode.NoContent);
                }
            }
            catch (System.Exception ex)
            {
                objErrorLogger.ErrorLog(ex);
                objResponseData = ResponseHandler<CategoryModel>.CreateErrorResponse(objResponseData);
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
        public HttpResponseMessage GetCategoryById(int Id)
        {
            ResponseMessage<CategoryModel> objResponseData = new ResponseMessage<CategoryModel>();
            try
            {
                Category category = new Category();
                category.CategoryId = Id;
                CategoryModel categoryModel = new CategoryModel();
                if (objCategoryDAL.GetAllCategories().ToList().Any(cat => cat.CategoryId == Id))
                {
                    Category categoryDetails = objCategoryDAL.GetCategoryDetails(category);                    
                    //mapping
                    categoryModel = Mapper.Map<Category, CategoryModel>(categoryDetails, categoryModel);
                    objResponseData = ResponseHandler<CategoryModel>.CreateResponse(objResponseData, "Category details", categoryModel, HttpStatusCode.OK);
                }
                else  //category is not available
                {
                    //mapping
                    categoryModel = Mapper.Map<Category, CategoryModel>(category, categoryModel);
                    objResponseData = ResponseHandler<CategoryModel>.CreateResponse(objResponseData, "This category is not available.", categoryModel, HttpStatusCode.Conflict);
                }
            }
            catch (System.Exception ex)
            {
                objErrorLogger.ErrorLog(ex);
                objResponseData = ResponseHandler<CategoryModel>.CreateErrorResponse(objResponseData);
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
            ResponseMessage<CategoryModel> objResponseData = new ResponseMessage<CategoryModel>();
            try
            {
                CategoryModel categoryModel = new CategoryModel();
                if (objCategoryDAL.GetAllCategories().ToList().Any(cat => cat.CategoryName != category.CategoryName))
                {
                    Category newCategory = objCategoryDAL.AddCategory(category);
                    if (newCategory.CategoryId > 0)
                    {
                        //mapping
                        categoryModel = Mapper.Map<Category, CategoryModel>(newCategory, categoryModel);
                        objResponseData = ResponseHandler<CategoryModel>.CreateResponse(objResponseData, "Successfully Added A New Category.", categoryModel, HttpStatusCode.OK);
                    }
                    else
                    {
                        //mapping
                        categoryModel = Mapper.Map<Category, CategoryModel>(category, categoryModel);
                        objResponseData = ResponseHandler<CategoryModel>.CreateResponse(objResponseData, "Can't Add This Category.", HttpStatusCode.Conflict);
                    }
                }
                else  // category name is already present
                {
                    //mapping
                    categoryModel = Mapper.Map<Category, CategoryModel>(category, categoryModel);
                    objResponseData = ResponseHandler<CategoryModel>.CreateResponse(objResponseData, "This category is already available.", categoryModel, HttpStatusCode.Conflict);
                }
               
            }
            catch (System.Exception ex)
            {
                objErrorLogger.ErrorLog(ex);
                objResponseData = ResponseHandler<CategoryModel>.CreateErrorResponse(objResponseData);
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
            ResponseMessage<CategoryModel> objResponseData = new ResponseMessage<CategoryModel>();
            try
            {
                CategoryModel categoryModel = new CategoryModel();
                var AllCategories = objCategoryDAL.GetAllCategories().ToList();
                if (AllCategories.Any(cat => cat.CategoryId == category.CategoryId))
                {
                    Category updatedCategory = new Category();
                    //set created date & time
                    category.CreatedBy = AllCategories.Where(cat => cat.CategoryId == category.CategoryId).FirstOrDefault().CreatedBy;
                    category.CreatedOn = AllCategories.Where(cat => cat.CategoryId == category.CategoryId).FirstOrDefault().CreatedOn;

                    int isSucceeded = objCategoryDAL.UpdateCategory(category);
                    if (isSucceeded > 0)
                    {
                        updatedCategory = objCategoryDAL.GetCategoryDetails(category);
                        //mapping
                        categoryModel = Mapper.Map<Category, CategoryModel>(updatedCategory, categoryModel);
                        objResponseData = ResponseHandler<CategoryModel>.CreateResponse(objResponseData, "Category Has Been Updated Successfully.", categoryModel, HttpStatusCode.OK);
                    }
                    else
                    {
                        //mapping
                        categoryModel = Mapper.Map<Category, CategoryModel>(category, categoryModel);
                        objResponseData = ResponseHandler<CategoryModel>.CreateResponse(objResponseData, "Can't Update Category.", categoryModel, HttpStatusCode.Conflict);
                    }
                }
                else  //category is not available
                {
                    //mapping
                    categoryModel = Mapper.Map<Category, CategoryModel>(category, categoryModel);
                    objResponseData = ResponseHandler<CategoryModel>.CreateResponse(objResponseData, "This category is not available.", categoryModel, HttpStatusCode.Conflict);
                }                    
            }
            catch (System.Exception ex)
            {
                objErrorLogger.ErrorLog(ex);
                objResponseData = ResponseHandler<CategoryModel>.CreateErrorResponse(objResponseData);
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
        public HttpResponseMessage DeleteCategory(int Id)
        {
            ResponseMessage<CategoryModel> objResponseData = new ResponseMessage<CategoryModel>();
            try
            {
                Category category = new Category();
                category.CategoryId = Id;
                CategoryModel categoryModel = new CategoryModel();
                if (objCategoryDAL.GetAllCategories().ToList().Any(cat => cat.CategoryId == Id))
                {                     
                    int isDeleted = objCategoryDAL.DeleteCategory(category);

                    if (isDeleted > 0)
                    {
                        objResponseData = ResponseHandler<CategoryModel>.CreateResponse(objResponseData, "Category Has Been Deleted.", HttpStatusCode.OK);
                    }
                    else
                    {
                        objResponseData = ResponseHandler<CategoryModel>.CreateResponse(objResponseData, "Can't Delete Category", HttpStatusCode.NoContent);
                    }
                }
                else  //category is not available
                {
                    //mapping
                    categoryModel = Mapper.Map<Category, CategoryModel>(category, categoryModel);
                    objResponseData = ResponseHandler<CategoryModel>.CreateResponse(objResponseData, "This category is not available.", categoryModel, HttpStatusCode.Conflict);
                }
            }
            catch (System.Exception ex)
            {
                objErrorLogger.ErrorLog(ex);
                objResponseData = ResponseHandler<CategoryModel>.CreateErrorResponse(objResponseData);
            }
            return Request.CreateResponse(objResponseData.StatusCode, objResponseData);
        }

        #endregion
        
    }
}
