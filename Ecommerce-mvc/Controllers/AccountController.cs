using Microsoft.AspNetCore.Mvc;
using Ecommerce_mvc.Models;

namespace Ecommerce_mvc.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Email == "admin@example.com" && model.Password == "123456")
                {
                    HttpContext.Session.SetString("IsLoggedIn", "true");
                    HttpContext.Session.SetString("UserEmail", model.Email);

                    return RedirectToAction("Index", "Product");
                }
                else
                {
                    ModelState.AddModelError("", "Email o contraseña incorrectos");
                }
            }

            return View(model);
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}