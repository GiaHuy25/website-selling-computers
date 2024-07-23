using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebprojectCK.Models;

namespace WebprojectCK.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index( int page = 1)
        {
            DBContext db = new DBContext();
            List<Product> pd = db.products.ToList();
            List<Brands> br = db.brands.ToList();
            int recordperpage = 12;
            int noofpage = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(pd.Count) / Convert.ToDouble(recordperpage)));
            int recordtoskip = (page - 1) * recordperpage;
            ViewBag.Page = page;
            ViewBag.Noofpage = noofpage;
            pd = pd.Skip(recordtoskip).Take(recordperpage).ToList();
            return View(pd);
        }
        public ActionResult searchbrand(int brandid, int page = 1)
        {
            DBContext db = new DBContext();
            List<Product> pd = db.products.Where(row => row.brandID == brandid).ToList();
            List<Brands> br = db.brands.ToList();
            int recordperpage = 12;
            int noofpage = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(pd.Count) / Convert.ToDouble(recordperpage)));
            int recordtoskip = (page - 1) * recordperpage;
            ViewBag.Page = page;
            ViewBag.Noofpage = noofpage;
            ViewBag.brandid = brandid;
            pd = pd.Skip(recordtoskip).Take(recordperpage).ToList();
            return View(pd);

        }
        public ActionResult searchcategory(int categoryid, int page=1)
        {
            DBContext db = new DBContext();
            List<Product> pd = db.products.Where(row => row.categoryID == categoryid).ToList();
            List<Brands> ctr = db.brands.ToList();
            int recordperpage = 12;
            int noofpage = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(pd.Count) / Convert.ToDouble(recordperpage)));
            int recordtoskip = (page - 1) * recordperpage;
            ViewBag.Page = page;
            ViewBag.Noofpage = noofpage;
            ViewBag.categoryid = categoryid;
            pd = pd.Skip(recordtoskip).Take(recordperpage).ToList();
            return View(pd);
        }
    }
}