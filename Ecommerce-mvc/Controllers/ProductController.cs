using Microsoft.AspNetCore.Mvc;
using Ecommerce_mvc.Models;
using Microsoft.EntityFrameworkCore;
using Ecommerce_mvc.Data;

namespace Ecommerce_mvc.Controllers
{

    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            //var products = new List<Product>();
            //return View(products);
            var products = _context.Products.ToList();
            return View(products);
        }
    }
}