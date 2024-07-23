using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebprojectCK.Models;

namespace WebprojectCK.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index(string search="",int page=1)
        {
            DBContext db = new DBContext();
            List<Product> pd = db.products.Where(row => row.productName.Contains(search)).ToList();
            ViewBag.search = search;
            int recordperpage = 12;
            int noofpage = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(pd.Count) / Convert.ToDouble(recordperpage)));
            int recordtoskip = (page - 1) * recordperpage;
            ViewBag.Page1 = page;
            ViewBag.Noofpage1 = noofpage;
            pd = pd.Skip(recordtoskip).Take(recordperpage).ToList();
            return View(pd);
        }
    }
}