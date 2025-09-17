using Microsoft.AspNetCore.Mvc;
using Ecommerce_mvc.Models;
using Ecommerce_mvc.Data;

namespace Ecommerce_mvc.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AccountController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = _context.Users
                    .FirstOrDefault(u => u.Email == model.Email &&
                                        u.Password == model.Password &&
                                        u.IsActive == true);

                if (user != null)
                {
                    HttpContext.Session.SetString("IsLoggedIn", "true");
                    HttpContext.Session.SetString("UserEmail", user.Email);
                    HttpContext.Session.SetString("UserName", user.Name);
                    HttpContext.Session.SetString("UserId", user.Id.ToString());

                    TempData["Success"] = $"¡Bienvenido/a {user.Name}!";
                    return RedirectToAction("Index", "Product");
                }
                else
                {
                    ModelState.AddModelError("", "Email o contraseña incorrectos, o cuenta inactiva");
                }
            }

            return View(model);
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            TempData["Success"] = "Sesión cerrada exitosamente";
            return RedirectToAction("Index", "Home");
        }
    }
}