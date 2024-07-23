using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebprojectCK.Models;
using System.IO;

namespace WebprojectCK.Areas.Admin.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin/Admin
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult viewproduct()
        {
            DBContext db = new DBContext();
            List<Product> pros = db.products.ToList();
            return View(pros);
        }
        public ActionResult viewuser()
        {
            DBContext db = new DBContext();
            List<User> user = db.User.ToList();
            return View(user);
        }
        public ActionResult viewcategory()
        {
            DBContext db = new DBContext();
            List<Category> category = db.categories.ToList();
            return View(category);
        }
        public ActionResult searchcate(int categoryID, int page=1)
        {
            DBContext db = new DBContext();
            List<Product> pd = db.products.Where(row => row.categoryID == categoryID).ToList();
            List<Brands> ctr = db.brands.ToList();
            int recordperpage = 12;
            int noofpage = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(pd.Count) / Convert.ToDouble(recordperpage)));
            int recordtoskip = (page - 1) * recordperpage;
            ViewBag.Page = page;
            ViewBag.Noofpage = noofpage;
            ViewBag.categoryid = categoryID;
            pd = pd.Skip(recordtoskip).Take(recordperpage).ToList();
            return View(pd);
        }
        public ActionResult AddProduct()
        {
            DBContext db = new DBContext();
            ViewBag.Brand = db.brands.ToList();
            ViewBag.Category = db.categories.ToList();
            return View();
        }

        [HttpPost]
        public ActionResult AddProduct(Product product, HttpPostedFileBase imageFile)
        {
           
            if (ModelState.IsValid)
            {
                DBContext db = new DBContext();
                if (imageFile != null && imageFile.ContentLength > 0)
                {
                    if (imageFile.ContentLength > 2000000)
                    {
                        ModelState.AddModelError("Image", "Kích thước file phải nhỏ hơn 2MB.");
                        return View();
                    }

                    var allowEx = new[] { ".jpg", ".png" };
                    var fileEx = Path.GetExtension(imageFile.FileName).ToLower();
                    if (!allowEx.Contains(fileEx))
                    {
                        ModelState.AddModelError("Image", "Chỉ chấp nhận file ảnh jpg hoặc png.");
                        return View();
                    }

                    product.img = "";
                    db.products.Add(product);
                    db.SaveChanges();

                    Product pro = db.products.ToList().Last();

                    var fileName = pro.productID.ToString() + fileEx;
                    var path = Path.Combine(Server.MapPath("~/img"), fileName);
                    imageFile.SaveAs(path);

                    pro.img = fileName;
                    db.SaveChanges();
                    return RedirectToAction("viewproduct");
                }
                else
                {
                    product.img = "noimage.png";
                    db.products.Add(product);
                    db.SaveChanges();
                    return RedirectToAction("viewproduct");
                }
            }
            else
            {
                return View();
            }
        }
        public ActionResult DeleteProduct(int id)
        {
            DBContext db = new DBContext();
            Product product = db.products.Where(row => row.productID == id).FirstOrDefault();
            return View(product);
        }
        [HttpPost]
        public ActionResult DeleteProduct(int id, Product p)
        {
            DBContext db = new DBContext();
            Product product = db.products.Where(row => row.productID == id).FirstOrDefault();
            db.products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("viewproduct");
        }
        public ActionResult DeleteUser(int id)
        {
            DBContext db = new DBContext();
            User user = db.User.Where(row => row.UserId == id).FirstOrDefault();
            return View(user);
        }
        [HttpPost]
        public ActionResult DeleteUser(int id, User u)
        {
            DBContext db = new DBContext();
            User user = db.User.Where(row => row.UserId == id).FirstOrDefault();
            db.User.Remove(user);
            db.SaveChanges();
            return RedirectToAction("viewuser");
        }
    }
}