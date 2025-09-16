using Ecommerce_mvc.Models;
using Microsoft.AspNetCore.Identity;

namespace Ecommerce_mvc
{
    public static class DbInitializer
    {
        public static async Task SeedAsync(IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();

            // Insertar productos si no existen
            if (!context.Products.Any())
            {
                context.Products.AddRange(
                    new Product { Name = "Laptop", Price = 2500, Description = "Laptop potente", ImageUrl = "laptop.jpg" },
                    new Product { Name = "Mouse", Price = 50, Description = "Mouse inalámbrico", ImageUrl = "mouse.jpg" },
                    new Product { Name = "Teclado", Price = 120, Description = "Teclado mecánico", ImageUrl = "teclado.jpg" }
                );
                context.SaveChanges();
            }

            // Insertar usuario si no existe
            string email = "usuario@correo.com";
            if (await userManager.FindByEmailAsync(email) == null)
            {
                var user = new IdentityUser
                {
                    UserName = email,
                    Email = email,
                    EmailConfirmed = true
                };

                await userManager.CreateAsync(user, "Usuario123!"); // contraseña segura
            }
        }
    }


}
