using ShoppingCart.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace ShoppingCartAPI.Models
{
    public class ApplicationDbContexts
    {
        // Created Shopping Cart Entity Object
        ShoppingCartEntities db = new ShoppingCartEntities();
        public ShoppingCartEntities ApplicationDbContext { get { return db; } }
    }

    public class Account : ApplicationDbContexts
    {
        public bool Login(string userName, string password)
        {
            try
            {
                var userInfo = ApplicationDbContext.UserMaster.Where(x => x.EmailId == userName).FirstOrDefault();
                if (userInfo != null)
                {
                    // Encoding.ASCII.GetString(
                    string stringPwd = userInfo.UserPassWord;
                    return stringPwd == password;
                }
                else
                {
                    return false;
                }
            }
            catch (System.Exception ex)
            {
                return false;
            }
        }
    }
}