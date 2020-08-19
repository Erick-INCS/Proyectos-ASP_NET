using CoffeStreet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CoffeStreet.Controllers
{
    //[Authorize]
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public HomeController()
        {
            var u = User;
            if (u == null || !u.Identity.IsAuthenticated)
            {
                //lista de categorias de productos
                var ptypes = db.ProductTypes.ToList();
                var top5 = db.Products.OrderByDescending(pr => db.Orders.Count(o => o.ProductId == pr.Id)).Take(5).ToList();
                ViewData.Add("categories", ptypes);
                top5.ForEach(pr =>
                {
                    if (!String.IsNullOrEmpty(pr.ImagePath))
                    {
                        string[] im = System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(pr.ImagePath)).Split(',');
                        byte[] imB = new byte[im.Length];
                        for (int j = 0; j < im.Length; j++)
                        {
                            imB[j] = byte.Parse(im[j]);
                        }
                        pr.ImagePath = Convert.ToBase64String(imB);
                    }
                });
                ViewData.Add("top5", top5);
            }
        }
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Orders");
            }

            
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}