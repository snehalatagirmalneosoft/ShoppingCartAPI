using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using ShoppingCart.Entity;
using ShoppingCart.Common;

namespace ShoppingCart.DataAccess
{
   public class UserDAL
    {
        ErrorLogger objErrorLogger;
        public UserDAL()
        {
            objErrorLogger = new ErrorLogger();
        }

        #region CRUD Operation

        /// <summary>
        /// 2018/12/17 - Deepanjali Yadav - 
        /// To Get List Of Users
        /// </summary>
        /// <returns>List<UserMaster></returns>
        /// Get: UserDAL/GetUserList
        public List<STP_GetUsers_Result> GetUserList()
        {
            try
            {             
                using (ShoppingCartEntities db = new ShoppingCartEntities())
                {
                    var userList = db.STP_GetUsers().ToList();
                    return userList;
                }
            }
            catch (System.Exception ex)
            {
                objErrorLogger.ErrorLog(ex);
                throw ex;
            }
        }

        /// <summary>
        /// 2018/12/17 - Deepanjali Yadav - 
        /// To Get User Detail By Id
        /// </summary>
        /// <returns>List<UserMaster></returns>
        /// Get: UserDAL/GetUserById
        public STP_GetUserDetails_Result GetUserById(int Id)
        {
            try
            {
                using (ShoppingCartEntities db = new ShoppingCartEntities())
                {
                    var UserId = new SqlParameter("@UserId", Id);
                    STP_GetUserDetails_Result userDetail= db.Database.SqlQuery<STP_GetUserDetails_Result>("STP_GetUserDetails @UserId", UserId).FirstOrDefault();
                    if (userDetail != null)
                    {
                        return userDetail;
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
        /// 2018/12/19 Snehalata Girmal
        /// Add new User
        /// </summary>
        /// <returns>int</returns>
        public UserDetail AddUsers(UserDetail objUser)
        {
            try
            {
                using (ShoppingCartEntities db = new ShoppingCartEntities())
                {
                    UserDetail objUsernew = db.UserDetail.Add(objUser);
                    db.SaveChanges();
                    return objUsernew;
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
