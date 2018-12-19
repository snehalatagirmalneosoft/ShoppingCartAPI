using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ShoppingCart.Common;
using ShoppingCart.DataAccess;
using ShoppingCart.Entity;
using System.Data;

namespace ShoppingCartAPI.Controllers
{
    [RoutePrefix("api/ProductAPI")]
    public class ProductApiController : ApiController
    {
        ProductDAL objProductDAL;
        ErrorLogger objErrorLogger;

        public ProductApiController()
        {
            objProductDAL = new ProductDAL();
            objErrorLogger = new ErrorLogger();
        }

        #region Product

        /// <summary>
        /// 2018/12/18 - Deepanjali Yadav - 
        /// List Of Products
        /// </summary>       
        /// <returns>HttpResponseMessage</returns>
        /// Get: ProductAPI/GetProductList
        [HttpGet]
        [Route("GetProductList")]
        public HttpResponseMessage GetProductList()
        {
            ResponseMessage<List<STP_ShowAllProductList_Result>> objResponseData = new ResponseMessage<List<STP_ShowAllProductList_Result>>();
            try
            {
                List<STP_ShowAllProductList_Result> products = objProductDAL.GetProductList().ToList();
                objResponseData = ResponseHandler<STP_ShowAllProductList_Result>.CreateResponse(objResponseData, "List Of Available Product", products, HttpStatusCode.OK);

            }
            catch (System.Exception ex)
            {
                objErrorLogger.ErrorLog(ex);
                objResponseData = ResponseHandler<STP_ShowAllProductList_Result>.CreateErrorResponse(objResponseData);
            }
            return Request.CreateResponse(objResponseData.StatusCode, objResponseData);
        }

        /// <summary>
        /// 2018/12/18 - Deepanjali Yadav - 
        /// Get Product by id
        /// </summary>       
        /// <returns>HttpResponseMessage</returns>
        /// Get: ProductAPI/GetProductById
        [HttpGet]
        [Route("GetProductById")]
        public HttpResponseMessage GetProductById(int Id)
        {
            ResponseMessage<STP_ProductDetails_Result> objResponseData = new ResponseMessage<STP_ProductDetails_Result>();
            try
            {
                Product product = new Product();
                product.ProductId = Id;
                STP_ProductDetails_Result productDetails = objProductDAL.GetProductDetails(product);
                objResponseData = ResponseHandler<STP_ProductDetails_Result>.CreateResponse(objResponseData, "Product details", productDetails, HttpStatusCode.OK);

            }
            catch (System.Exception ex)
            {
                objErrorLogger.ErrorLog(ex);
                objResponseData = ResponseHandler<STP_ProductDetails_Result>.CreateErrorResponse(objResponseData);
            }
            return Request.CreateResponse(objResponseData.StatusCode, objResponseData);
        }

        /// <summary>
        /// 2018/12/18 - Deepanjali Yadav - 
        /// Add Product
        /// </summary>       
        /// <returns>HttpResponseMessage</returns>
        /// Get: ProductAPI/AddProduct
        [HttpPost]
        [Route("AddProduct")]
        public HttpResponseMessage AddProduct(Product product)
        {
            ResponseMessage<Product> objResponseData = new ResponseMessage<Product>();
            try
            {
                DataTable tempProductImages = new DataTable();
                DataColumn dc = new DataColumn("TempId", typeof(int));   //creating first column of datatable
                tempProductImages.Columns.Add(dc);
                dc = new DataColumn("ImageUrl", typeof(String));         //creating second column of datatable 
                tempProductImages.Columns.Add(dc);
               
                int result = objProductDAL.AddProduct(product, tempProductImages);
                if (result != 0)
                {
                    objResponseData = ResponseHandler<Product>.CreateResponse(objResponseData, "Successfully Added A New Product.", product, HttpStatusCode.OK);
                }
                else
                {
                    objResponseData = ResponseHandler<Product>.CreateResponse(objResponseData, "Can't Add This Product.", HttpStatusCode.Conflict);
                }
            }
            catch (System.Exception ex)
            {
                objErrorLogger.ErrorLog(ex);
                objResponseData = ResponseHandler<Product>.CreateErrorResponse(objResponseData);
            }
            return Request.CreateResponse(objResponseData.StatusCode, objResponseData);
        }

        /// <summary>
        /// 2018/12/18 - Deepanjali Yadav - 
        /// Update Product
        /// </summary>       
        /// <returns>HttpResponseMessage</returns>
        /// Get: ProductAPI/UpdateProduct
        [HttpPost]
        [Route("UpdateProduct")]
        public HttpResponseMessage UpdateProduct(Product product)
        {
            ResponseMessage<STP_ProductDetails_Result> objResponseData = new ResponseMessage<STP_ProductDetails_Result>();
            try
            {
                DataTable tempProductImages = new DataTable();
                DataColumn dc = new DataColumn("TempId", typeof(int));   //creating first column of datatable
                tempProductImages.Columns.Add(dc);
                dc = new DataColumn("ImageUrl", typeof(String));         //creating second column of datatable 
                tempProductImages.Columns.Add(dc);

                int isSucceeded = objProductDAL.UpdateProduct(product, tempProductImages);
                if (isSucceeded > 0)
                {
                    STP_ProductDetails_Result updatedProduct = objProductDAL.GetProductDetails(product);
                    objResponseData = ResponseHandler<STP_ProductDetails_Result>.CreateResponse(objResponseData, "Product Has Been Updated Successfully.", updatedProduct, HttpStatusCode.OK);
                }
                else
                {
                    objResponseData = ResponseHandler<STP_ProductDetails_Result>.CreateResponse(objResponseData, "Can't Update Product.", HttpStatusCode.Conflict);
                }
            }
            catch (System.Exception ex)
            {
                objErrorLogger.ErrorLog(ex);
                objResponseData = ResponseHandler<STP_ProductDetails_Result>.CreateErrorResponse(objResponseData);
            }
            return Request.CreateResponse(objResponseData.StatusCode, objResponseData);
        }

        /// <summary>
        /// 2018/12/18 - Deepanjali Yadav - 
        /// Delete Product
        /// </summary>       
        /// <returns>HttpResponseMessage</returns>
        /// Get: ProductAPI/DeleteProduct
        [HttpDelete]
        [Route("DeleteProduct")]
        public HttpResponseMessage DeleteProduct(Product product)
        {
            ResponseMessage<Product> objResponseData = new ResponseMessage<Product>();
            try
            {
                int isDeleted = objProductDAL.DeleteProduct(product);

                if (isDeleted > 0)
                {
                    objResponseData = ResponseHandler<Product>.CreateResponse(objResponseData, "Product Has Been Deleted.", HttpStatusCode.OK);
                }
                else
                {
                    objResponseData = ResponseHandler<Product>.CreateResponse(objResponseData, "Can't Delete Product", HttpStatusCode.NoContent);
                }
            }
            catch (System.Exception ex)
            {
                objErrorLogger.ErrorLog(ex);
                objResponseData = ResponseHandler<Product>.CreateErrorResponse(objResponseData);
            }
            return Request.CreateResponse(objResponseData.StatusCode, objResponseData);
        }

        #endregion
    }
}
