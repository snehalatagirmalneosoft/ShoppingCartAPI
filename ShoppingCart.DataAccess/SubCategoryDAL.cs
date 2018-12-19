using ShoppingCart.Common;
using ShoppingCart.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.DataAccess
{
   public class SubCategoryDAL
    {
        ErrorLogger objErrorLogger;
        public SubCategoryDAL()
        {
            objErrorLogger = new ErrorLogger();
        }

        #region CRUD Operations

        /// <summary>
        /// 2018/12/17 Vaishnavi Soni
        /// Get list of all product categories.
        /// </summary>
        /// <returns>List<Category></returns>
        public List<STP_GetAllSubCategories_Result> GetAllSubCategories()
        {
            try
            {
                using (ShoppingCartEntities db = new ShoppingCartEntities())
                {
                    List<STP_GetAllSubCategories_Result> BusinessCategory = db.STP_GetAllSubCategories().ToList();
                    return BusinessCategory;
                }
            }
            catch (System.Exception ex)
            {
                objErrorLogger.ErrorLog(ex);
                throw ex;
            }
        }

        /// <summary>
        /// 2018/12/17 Vaishnavi Soni
        /// Get list of all product categories.
        /// </summary>
        /// <returns>List<Category></returns>
        public STP_GetSubCategoryDetails_Result GetSubCategoryDetails(int SubCategoryId)
        {
            try
            {
                using (ShoppingCartEntities db = new ShoppingCartEntities())
                {
                    STP_GetSubCategoryDetails_Result result = db.STP_GetSubCategoryDetails(SubCategoryId).FirstOrDefault();
                    if (result != null)
                    {
                        return result;
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
        /// 2018/12/17 Vaishnavi Soni
        /// Add new product category
        /// </summary>
        /// <returns>int</returns>
        public int AddSubCategory(SubCategory categoryModel)
        {
            try
            {
                using (ShoppingCartEntities db = new ShoppingCartEntities())
                {
                    var newCategory = db.STP_InsertSubCategories(categoryModel.CategoryId, categoryModel.SubCategoryName, DateTime.Now, categoryModel.CreatedBy, null, 0, true);
                    db.SaveChanges();
                    return newCategory;
                }
            }
            catch (System.Exception ex)
            {
                objErrorLogger.ErrorLog(ex);
                throw ex;
            }
        }

        /// <summary>
        /// 2018/12/17 Vaishnavi Soni
        /// Update an existing product category
        /// </summary>
        /// <returns>int</returns>
        public int UpdateSubCategory(SubCategory categoryModel)
        {
            try
            {
                using (ShoppingCartEntities db = new ShoppingCartEntities())
                {
                    var categoryToUpdate = db.STP_UpdateSubCategories(categoryModel.SubCategoryId, categoryModel.CategoryId, categoryModel.SubCategoryName, DateTime.Now, categoryModel.ModifiedBy, true);
                    db.SaveChanges();
                    return categoryToUpdate;
                }
            }
            catch (System.Exception ex)
            {
                objErrorLogger.ErrorLog(ex);
                throw ex;
            }
        }

        /// <summary>
        /// 2018/12/17 Vaishnavi Soni
        /// Delete an existing product category
        /// </summary>
        /// <returns>int</returns>
        public int DeleteSubCategory(int SubCategoryId)
        {
            try
            {
                using (ShoppingCartEntities db = new ShoppingCartEntities())
                {
                    var categoryToDelete = db.STP_DeleteSubCategory(SubCategoryId);
                    db.SaveChanges();
                    return categoryToDelete;
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
