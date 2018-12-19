using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using ShoppingCart.Entity;
using ShoppingCart.Common;
using System.Data;

namespace ShoppingCart.DataAccess
{
   public class ProductDAL
    {
        ErrorLogger objErrorLogger;
        public ProductDAL()
        {
            objErrorLogger = new ErrorLogger();
        }

        #region CRUD Operations

        /// <summary>
        /// 2018/12/18 Deepanjali Yadav
        /// Get list of all product.
        /// </summary>
        /// <returns>List<STP_ShowAllProductList_Result></returns>
        public List<STP_ShowAllProductList_Result> GetProductList()
        {
            try
            {
                using (ShoppingCartEntities db = new ShoppingCartEntities())
                {
                    List<STP_ShowAllProductList_Result> productList = db.STP_ShowAllProductList().ToList();
                    return productList;
                }
            }
            catch (System.Exception ex)
            {
                objErrorLogger.ErrorLog(ex);
                throw ex;
            }
        }

        /// <summary>
        /// 2018/12/18 Deepanjali Yadav
        /// Get product category details.
        /// </summary>
        /// <returns>List<Category></returns>
        public STP_ProductDetails_Result GetProductDetails(Product product)
        {
            try
            {
                using (ShoppingCartEntities db = new ShoppingCartEntities())
                {
                    var ProductId = new SqlParameter("@ProductId", product.ProductId);
                    STP_ProductDetails_Result productDetails = db.Database.SqlQuery<STP_ProductDetails_Result>("STP_ProductDetails @ProductId", ProductId).FirstOrDefault();
                    if (productDetails != null)
                    {
                        return productDetails;
                    }
                    return null;
                }
            }
            catch (System.Exception ex)
            {
                objErrorLogger.ErrorLog(ex);
                throw ex;
            }
        }


        /// <summary>
        /// 2018/12/18 Deepanjali Yadav
        /// Add new product
        /// </summary>
        /// <returns>int</returns>
        public int AddProduct(Product product, DataTable tempProductImages)
        {
            try
            {
                using (ShoppingCartEntities db = new ShoppingCartEntities())
                {
                    var SubCategoryId = new SqlParameter("@SubCategoryId", product.SubCategoryId);
                    var ProductName = new SqlParameter("@ProductName", product.ProductName);
                    var CreatedOn = new SqlParameter("@CreatedOn", product.CreatedOn);
                    var CreatedBy = new SqlParameter("@CreatedBy", product.CreatedBy);
                    var Price = new SqlParameter("@Price", product.Price);
                    var ProductDescription = new SqlParameter("@ProductDescription", product.ProductDescription);
                    var IsActive = new SqlParameter("@IsActive", product.IsActive);
                    var Quantity = new SqlParameter("@Quantity", product.Quantity);   

                    //there is diffrent way to mention user defined table type in sql query

                    var TempProductImages = new SqlParameter("@TempProductImages", SqlDbType.Structured);
                    TempProductImages.Value = tempProductImages;
                    TempProductImages.TypeName = "dbo.ImageTable";


                    var result = db.Database
                        .ExecuteSqlCommand("STP_AddNewProduct @SubCategoryId, @ProductName, @CreatedOn, @CreatedBy, @Price, @ProductDescription, @IsActive, @Quantity, @TempProductImages ",
                        SubCategoryId, ProductName, CreatedOn, CreatedBy, Price, ProductDescription, IsActive, Quantity, TempProductImages);
                    db.SaveChanges();

                    return Convert.ToInt32(result);
                }
            }
            catch (System.Exception ex)
            {
                objErrorLogger.ErrorLog(ex);
                throw ex;
            }
        }

        /// <summary>
        /// 2018/12/18 Deepanjali Yadav
        /// Update an existing product
        /// </summary>
        /// <returns>int</returns>
        public int UpdateProduct(Product product, DataTable tempProductImages)
        {
            try
            {
                using (ShoppingCartEntities db = new ShoppingCartEntities())
                {
                    var ProductId = new SqlParameter("@ProductId", product.ProductId);
                    var SubCategoryId = new SqlParameter("@SubCategoryId", product.SubCategoryId);
                    var ProductName = new SqlParameter("@ProductName", product.ProductName);
                    var ModifiedOn = new SqlParameter("@ModifiedOn", product.ModifiedOn);
                    var ModifiedBy = new SqlParameter("@ModifiedBy", product.ModifiedBy);
                    var Price = new SqlParameter("@Price", product.Price);
                    var ProductDescription = new SqlParameter("@ProductDescription", product.ProductDescription);
                    var IsActive = new SqlParameter("@IsActive", product.IsActive);
                    var Quantity = new SqlParameter("@Quantity", product.Quantity);

                    //there is diffrent way to mention user defined table type in sql query

                    var TempProductImages = new SqlParameter("@TempProductImages", SqlDbType.Structured);
                    TempProductImages.Value = tempProductImages;
                    TempProductImages.TypeName = "dbo.ImageTable";


                    var result = db.Database
                        .ExecuteSqlCommand("STP_UpdateProduct @ProductId, @SubCategoryId, @ProductName, @ModifiedOn, @ModifiedBy, @Price, @ProductDescription, @IsActive, @Quantity, @TempProductImages ",
                        ProductId, SubCategoryId, ProductName, ModifiedOn, ModifiedBy, Price, ProductDescription, IsActive, Quantity, TempProductImages);
                    db.SaveChanges();

                    return Convert.ToInt32(result);
                }
            }
            catch (System.Exception ex)
            {
                objErrorLogger.ErrorLog(ex);
                throw ex;
            }
        }

        /// <summary>
        /// 2018/12/18 Deepanjali Yadav
        /// Delete an existing product
        /// </summary>
        /// <returns>int</returns>
        public int DeleteProduct(Product product)
        {
            try
            {
                using (ShoppingCartEntities db = new ShoppingCartEntities())
                {
                    var ProductId = new SqlParameter("@ProductId", product.ProductId);
                    var ProductToDelete = db.Product.FirstOrDefault(em => em.ProductId == product.ProductId);
                    if (ProductToDelete != null)
                    {
                        //ExecuteSqlCommand returns int value i.e no of rows affected
                        int flag = db.Database.ExecuteSqlCommand("STP_DeleteProduct @ProductId", ProductId);
                        return flag;
                    }
                    else
                    {
                        //if not available to be deleted
                        return (-1);
                    }
                }
            }
            catch (System.Exception ex)
            {
                objErrorLogger.ErrorLog(ex);
                throw ex;
            }
        }

        #endregion
    }
}
