using CoffeStreet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CoffeStreet.Controllers
{
    public class CatalogController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public CatalogController()
        {
            //lista de categorias de productos
            var ptypes = db.ProductTypes.ToList();
            ViewData.Add("categories", ptypes);
        }

        // GET: Catalog
        public ActionResult Index()
        {
            return View();
        }

        // GET: Catalog/Details/Te
        public ActionResult Details(string category)
        {
            
            var list = db.Products.Where(p => p.Type == category && p.Quantity > 0).ToList();
            return View(list);
        }

        // GET: Catalog/Product/1
        public ActionResult Product(int pId)
        {
            var product = db.Products.Find(pId);
            return View(product);
        }

        // POST: Crear orden
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SetOrder([Bind(Include = "ProductId,ClientName,Quantity")] Order order)
        {
            if (ModelState.IsValid)
            {
                order.Date = DateTime.Now;
                db.Orders.Add(order);
                Product p = db.Products.Find(order.ProductId);
                p.Quantity -= order.Quantity;
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            ViewBag.ProductId = new SelectList(db.Products, "Id", "ProductName");
            return View();
        }
    }
}
