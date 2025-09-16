using Microsoft.AspNetCore.Mvc;
using Ecommerce_mvc.Models;

namespace Ecommerce_mvc.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            var products = new List<Product>();
            return View(products);
        }
    }
}