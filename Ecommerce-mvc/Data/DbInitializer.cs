using Ecommerce_mvc.Models;
using Microsoft.AspNetCore.Identity;

namespace Ecommerce_mvc.Data
{
    public static class DbInitializer
    {
        public static async Task SeedAsync(IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();

            // Asegurar que la base de datos existe
            context.Database.EnsureCreated();

            // Insertar usuarios de prueba si no existen
            if (!context.Users.Any())
            {
                context.Users.AddRange(
                    new User
                    {
                        Name = "Administrador",
                        Email = "admin@tienda.com",
                        Password = "123456",
                        IsActive = true,
                        CreatedAt = DateTime.Now
                    },
                    new User
                    {
                        Name = "Juan Pérez",
                        Email = "juan@ejemplo.com",
                        Password = "password123",
                        IsActive = true,
                        CreatedAt = DateTime.Now
                    },
                    new User
                    {
                        Name = "María García",
                        Email = "maria@ejemplo.com",
                        Password = "maria2024",
                        IsActive = true,
                        CreatedAt = DateTime.Now
                    }
                );
                context.SaveChanges();
            }

            // Insertar productos si no existen
            if (!context.Products.Any())
            {
                context.Products.AddRange(
                    new Product
                    {
                        Name = "Laptop HP Pavilion",
                        Price = 2500.00m,
                        Description = "Laptop potente para trabajo y gaming con procesador Intel i7",
                        ImageUrl = "https://images.unsplash.com/photo-1496181133206-80ce9b88a853?w=400&h=300&fit=crop"
                    },
                    new Product
                    {
                        Name = "Mouse Logitech MX",
                        Price = 75.50m,
                        Description = "Mouse inalámbrico ergonómico con alta precisión",
                        ImageUrl = "https://images.unsplash.com/photo-1527814050087-3793815479db?w=400&h=300&fit=crop"
                    },
                    new Product
                    {
                        Name = "Teclado Mecánico",
                        Price = 120.00m,
                        Description = "Teclado mecánico RGB con switches Cherry MX",
                        ImageUrl = "https://images.unsplash.com/photo-1541140532154-b024d705b90a?w=400&h=300&fit=crop"
                    }
                );
                context.SaveChanges();
            }

            string email = "admin@tienda.com";
            if (await userManager.FindByEmailAsync(email) == null)
            {
                var user = new IdentityUser
                {
                    UserName = email,
                    Email = email,
                    EmailConfirmed = true
                };

                await userManager.CreateAsync(user, "Admin123!"); // contraseña segura
            }
        }
    }
}