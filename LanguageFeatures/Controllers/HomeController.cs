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
            //chtck
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
        public ViewResult UseExtensionEnumerable()
        {
            IEnumerable<Product> products = new ShoppingCart
            {
                Products = new List<Product> {
                new Product {Name = "Kayak", Price = 275M},
                new Product {Name = "Lifejacket", Price = 48.95M},
                new Product {Name = "Soccer ball", Price = 19.50M},
                new Product {Name = "Corner flag", Price = 34.95M}
                }
            };
            // создание и заполнение массива объектов Product
            Product[] productArray = {
            new Product {Name = "Kayak", Price = 275M},
            new Product {Name = "Lifejacket", Price = 48.95M},
            new Product {Name = "Soccer ball", Price = 19.50M},
            new Product {Name = "Corner flag", Price = 34.95M}
            };
            // получение общей стоимости продуктов в корзине
            decimal cartTotal = products.TotalPrices();
            decimal arrayTotal = productArray.TotalPrices();
            return View("Result",
            (object)String.Format("Cart Total: {0}, Array Total: {1}",
            cartTotal, arrayTotal));
        }

        public ViewResult UseFilterExtensionMethod()
        {
            // создаем и заполняем ShoppingCart
            IEnumerable<Product> products = new ShoppingCart {
            Products = new List<Product> {
            new Product {Name = "Kayak", Category = "Watersports", Price = 275M},
            new Product {Name = "Lifejacket", Category = "Watersports", Price = 48.95M},
            new Product {Name = "Soccer ball", Category = "Soccer", Price = 19.50M},
            new Product {Name = "Corner flag", Category = "Soccer", Price = 34.95M}
            }
            };
            Func<Product, bool> categoryFilter = prod => prod.Category == "Soccer";
            decimal total = 0;
            foreach (Product prod in products.Filter(prod=>prod.Category=="Soccer" || prod.Price >20)) {
            total += prod.Price;
            }
            return View("Result", (object)String.Format("Total: {0}", total));
        }
    }
}