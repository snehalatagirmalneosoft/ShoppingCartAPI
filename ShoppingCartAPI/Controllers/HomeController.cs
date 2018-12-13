using ShoppingCartAPI.ModelEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace ShoppingCartAPI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            // Demo purpose only created database first approach using ShoppingCartEntities
            using (ShoppingCartEntities db = new ShoppingCartEntities())
            {
                List<City> CityName = (from d in db.City where d.CityName == "pune" select d).ToList();
                List<City> AllCities = db.City.ToList();
                ViewBag.Title = "Home Page";

            }


            return View();
        }
    }
}
