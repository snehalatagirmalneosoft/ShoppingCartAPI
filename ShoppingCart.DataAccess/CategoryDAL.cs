using ShoppingCart.Common;
using ShoppingCart.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.DataAccess
{
    public class CategoryDAL
    {
        ErrorLogger objErrorLogger;
        public CategoryDAL()
        {
            objErrorLogger = new ErrorLogger();
        }        

        #region CRUD Operations

        /// <summary>
        /// 2018/12/17 Vaishnavi Soni
        /// Get list of all product categories.
        /// </summary>
        /// <returns>List<Category></returns>
        public List<Category> GetAllCategories()
        {
            try
            {
                using (ShoppingCartEntities db = new ShoppingCartEntities())
                {
                    List<Category> BusinessCategory = db.Category.ToList();
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
        public Category GetCategoryDetails(Category categoryModel)
        {
            try
            {
                using (ShoppingCartEntities db = new ShoppingCartEntities())
                {
                    Category result = db.Category.FirstOrDefault(em => em.CategoryId == categoryModel.CategoryId);
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
        public Category AddCategory(Category categoryModel)
        {
            try
            {
                using (ShoppingCartEntities db = new ShoppingCartEntities())
                {
                    Category newCategory = db.Category.Add(categoryModel);
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
        public int UpdateCategory(Category categoryModel)
        {
            try
            {                
                using (ShoppingCartEntities db = new ShoppingCartEntities())
                {
                    var categoryToUpdate = db.Category.FirstOrDefault(em => em.CategoryId == categoryModel.CategoryId);
                    if (categoryToUpdate != null)
                    {
                        db.Entry(categoryToUpdate).CurrentValues.SetValues(categoryModel);
                        return db.SaveChanges();
                    }
                    else
                    {
                        return -1;
                    }
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
        public int DeleteCategory(Category categoryModel)
        {
            try
            {
                using (ShoppingCartEntities db = new ShoppingCartEntities())
                {
                    var categoryToDelete = db.Category.FirstOrDefault(em => em.CategoryId == categoryModel.CategoryId);
                    if (categoryToDelete != null)
                    {
                        db.Category.Remove(categoryToDelete);
                        return db.SaveChanges();
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
