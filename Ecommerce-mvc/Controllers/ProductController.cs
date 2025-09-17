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

        // GET: Product/Index - Listar productos
        public IActionResult Index()
        {
            var products = _context.Products.ToList();
            return View(products);
        }

        // GET: Product/Create - Mostrar formulario para crear producto
        public IActionResult Create()
        {
            return View();
        }

        // POST: Product/Create - Guardar nuevo producto
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Products.Add(product);
                _context.SaveChanges();

                TempData["Success"] = "Producto creado exitosamente";

                return RedirectToAction(nameof(Index));
            }

            return View(product);
        }
    }
}