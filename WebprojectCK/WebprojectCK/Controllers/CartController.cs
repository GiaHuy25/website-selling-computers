using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebprojectCK.Models;

namespace WebprojectCK.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        public ActionResult Index()
        {
            DBContext db = new DBContext();
            List<Cart> Cart = db.Cart.ToList();
            return View(Cart);
        }
        public ActionResult AddCart(int? id)
        {
            if (id != null)
            {
                DBContext db = new DBContext();
                Cart cartitem = db.Cart.Where(row => row.productID == id).FirstOrDefault();
                if (cartitem != null)
                {
                    cartitem.Quantity += 1;
                }
                else
                {
                    Cart cart = new Cart();
                    cart.productID = (int)id;
                    cart.Quantity = 1;
                    db.Cart.Add(cart);
                }
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        public ActionResult UpdateQuatity(int quan, int proid)
        {
            DBContext db = new DBContext();
            if (quan > 0)
            {
                Cart cartitem = db.Cart.Where(row => row.productID == proid).FirstOrDefault();
                if(cartitem != null)
                {
                    cartitem.Quantity = quan;
                    db.SaveChanges();
                }
            }
            return RedirectToAction("index");
        }
        public ActionResult delete(int id)
        {
            DBContext db = new DBContext();
            Cart cart = db.Cart.Where(row => row.productID == id).FirstOrDefault();
            db.Cart.Remove(cart);
            db.SaveChanges();
            return RedirectToAction("index");
        }
    }
}