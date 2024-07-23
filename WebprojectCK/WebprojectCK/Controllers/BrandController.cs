using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebprojectCK.Models;

namespace WebprojectCK.Controllers
{
    public class BrandController : Controller
    {
        // GET: Brand
        public ActionResult Index()
        {
            DBContext db = new DBContext();
            List<Brands> brands = db.brands.ToList();
            return View(brands);
        }
    }
}