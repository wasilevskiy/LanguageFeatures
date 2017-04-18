using System;
using System.Collections.Generic;
using System.Linq;
using LanguageFeatures.Models;
using System.Web;
using System.Web.Mvc;

namespace LanguageFeatures.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public string Index()
        {
            return "Navigate to a URL to show an example";
        }

        public ViewResult AutoProperty()
        {
            Product myProduct = new Product();
            myProduct.Name = "Каяк";
            string productName = myProduct.Name;
            return View("Result", (object)String.Format("Product name: {0}", productName));
        }

        public ViewResult UseExtension()
        {
            ShoppingCart cart = new ShoppingCart
            {
                Products = new List<Product>
                {
                    new Product {Name="Каяк",Price=275M },
                    new Product {Name="Спасательный жилет",Price=48.95M },
                    new Product {Name="Футбольный мяч",Price=19.50M },
                    new Product {Name="Угловой флаг",Price=34.95M }
                }
            };
            decimal cartTotal = cart.TotalPrices();
            return View("Result", (object)String.Format("Total: {0:c}", cartTotal));
        }
    }
}