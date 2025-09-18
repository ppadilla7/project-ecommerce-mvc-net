# 🛒 Ecommerce Premium - Sistema MVC

Un sistema de comercio electrónico desarrollado en **ASP.NET Core MVC** que demuestra la implementación del patrón Modelo-Vista-Controlador (MVC) con Entity Framework Core y autenticación personalizada.

## 📋 Tabla de Contenidos

- [Características](#características)
- [Arquitectura MVC](#arquitectura-mvc)
- [Tecnologías Utilizadas](#tecnologías-utilizadas)
- [Prerrequisitos](#prerrequisitos)
- [Instalación](#instalación)
- [Configuración](#configuración)
- [Estructura del Proyecto](#estructura-del-proyecto)
- [Uso](#uso)
- [Componentes del Sistema](#componentes-del-sistema)
- [Base de Datos](#base-de-datos)
- [Middleware](#middleware)
- [Contribuir](#contribuir)

## ✨ Características

- 🔐 **Sistema de autenticación personalizado** con sesiones
- 📦 **Gestión de productos** (crear, listar, visualizar)
- 👤 **Gestión de usuarios** con validaciones
- 🎨 **Interfaz moderna** con Bootstrap 5 y Font Awesome
- 🗄️ **Base de datos SQL Server** con Entity Framework Core
- 🔒 **Middleware de autorización** personalizado
- 📱 **Diseño responsivo** con efectos glassmorphism
- 🌈 **Interfaz con gradientes** y animaciones CSS

## 🏗️ Arquitectura MVC

Este proyecto implementa el patrón **Modelo-Vista-Controlador** de la siguiente manera:

### **Modelo (Model)**
- `Product.cs` - Entidad de productos
- `User.cs` - Entidad de usuarios
- `LoginViewModel.cs` - Modelo para vista de login
- `ErrorViewModel.cs` - Modelo para manejo de errores

### **Vista (View)**
- `Views/Home/` - Vistas del controlador Home
- `Views/Product/` - Vistas del controlador Product
- `Views/Account/` - Vistas del controlador Account
- `Views/Shared/` - Vistas compartidas y layout

### **Controlador (Controller)**
- `HomeController.cs` - Controlador principal
- `ProductController.cs` - Gestión de productos
- `AccountController.cs` - Autenticación y usuarios

## 🛠️ Tecnologías Utilizadas

- **Framework**: ASP.NET Core 8.0
- **Patrón**: MVC (Model-View-Controller)
- **Base de Datos**: SQL Server
- **ORM**: Entity Framework Core 9.0.9
- **Autenticación**: ASP.NET Core Identity + Sistema personalizado
- **Frontend**: Bootstrap 5.3.0, Font Awesome 6.4.0
- **Lenguaje**: C# (.NET 8.0)

## 📋 Prerrequisitos

- **.NET 8.0 SDK** o superior
- **SQL Server** (Local DB, Express, o completo)
- **Visual Studio 2022** o **Visual Studio Code**
- **Git** (opcional)

## 🚀 Instalación

### 1. Clonar el repositorio
```bash
git clone [URL_DEL_REPOSITORIO]
cd Ecommerce-mvc
```

### 2. Restaurar paquetes NuGet
```bash
dotnet restore
```

### 3. Configurar la cadena de conexión
Edita el archivo `appsettings.json`:
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=TU_SERVIDOR;Database=EcommerceMvcDb;Trusted_Connection=True;TrustServerCertificate=true;"
  }
}
```

### 4. Aplicar migraciones
```bash
dotnet ef database update
```

### 5. Ejecutar la aplicación
```bash
dotnet run
```

## ⚙️ Configuración

### Cadena de Conexión
Modifica la cadena de conexión en `appsettings.json` según tu entorno:

- **SQL Server Local**: `Server=(localdb)\\mssqllocaldb;Database=EcommerceMvcDb;Trusted_Connection=True;`
- **SQL Server Express**: `Server=.\\SQLEXPRESS;Database=EcommerceMvcDb;Trusted_Connection=True;TrustServerCertificate=true;`
- **SQL Server Completo**: `Server=localhost;Database=EcommerceMvcDb;Trusted_Connection=True;TrustServerCertificate=true;`

### Datos Iniciales
El sistema incluye un inicializador de datos (`DbInitializer.cs`) que crea:

**Usuarios por defecto:**
- Admin: `admin@tienda.com` / `123456`
- Usuario: `juan@ejemplo.com` / `password123`
- Usuario: `maria@ejemplo.com` / `maria2024`

**Productos de ejemplo:**
- Laptop HP Pavilion ($2,500.00)
- Mouse Logitech MX ($75.50)
- Teclado Mecánico ($120.00)

## 📁 Estructura del Proyecto

```
Ecommerce-mvc/
├── Controllers/
│   ├── AccountController.cs      # Autenticación
│   ├── HomeController.cs         # Página principal
│   └── ProductController.cs      # Gestión de productos
├── Models/
│   ├── Product.cs               # Modelo de producto
│   ├── User.cs                  # Modelo de usuario
│   ├── LoginViewModel.cs        # ViewModel para login
│   └── ErrorViewModel.cs        # ViewModel para errores
├── Views/
│   ├── Account/
│   │   └── Login.cshtml         # Vista de login
│   ├── Home/
│   │   ├── Index.cshtml         # Página principal
│   │   └── Privacy.cshtml       # Política de privacidad
│   ├── Product/
│   │   ├── Index.cshtml         # Lista de productos
│   │   └── Create.cshtml        # Crear producto
│   └── Shared/
│       ├── _Layout.cshtml       # Layout principal
│       └── Error.cshtml         # Vista de error
├── Data/
│   ├── ApplicationDbContext.cs  # Contexto de EF Core
│   └── DbInitializer.cs         # Inicializador de datos
├── Middleware/
│   └── AuthorizationMiddleware.cs # Middleware personalizado
├── Migrations/                  # Migraciones de EF Core
└── Program.cs                   # Punto de entrada
```

## 🎯 Uso

### 1. Acceso al Sistema
- Navega a `https://localhost:7181` (HTTPS) o `http://localhost:5070` (HTTP)
- La página principal muestra información del sistema

### 2. Iniciar Sesión
- Haz clic en "Iniciar Sesión"
- Usa cualquiera de las credenciales por defecto
- Serás redirigido al catálogo de productos

### 3. Gestión de Productos
- **Ver productos**: Accesible después del login
- **Crear producto**: Botón "Agregar Producto"
- **Estadísticas**: Panel con métricas automáticas

### 4. Navegación
- **Inicio**: Página principal con información
- **Productos**: Catálogo (requiere autenticación)
- **Perfil**: Información del usuario logueado

## 🔧 Componentes del Sistema

### Controladores

#### HomeController
- **Index**: Página principal con información del sistema
- **Privacy**: Página de políticas
- **Error**: Manejo de errores

#### AccountController
- **Login (GET)**: Muestra formulario de login
- **Login (POST)**: Procesa autenticación
- **Logout**: Cierra sesión y limpia datos

#### ProductController
- **Index**: Lista todos los productos con estadísticas
- **Create (GET)**: Formulario para nuevo producto
- **Create (POST)**: Procesa creación de producto

### Modelos

#### Product
```csharp
public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }        // Máx. 100 caracteres
    public string Description { get; set; }  // Máx. 500 caracteres
    public decimal Price { get; set; }       // Rango: $0.01 - $999,999.99
    public string ImageUrl { get; set; }     // URL válida
}
```

#### User
```csharp
public class User
{
    public int Id { get; set; }
    public string Name { get; set; }         // Máx. 50 caracteres
    public string Email { get; set; }        // Único, máx. 100 caracteres
    public string Password { get; set; }     // Máx. 255 caracteres
    public DateTime CreatedAt { get; set; }
    public bool IsActive { get; set; }
}
```

## 🗄️ Base de Datos

### Tablas Principales

#### Products
- `Id` (int, PK, Identity)
- `Name` (nvarchar(100), NOT NULL)
- `Description` (nvarchar(500), NOT NULL)
- `Price` (decimal(18,2), NOT NULL)
- `ImageUrl` (nvarchar(max), NOT NULL)

#### Users
- `Id` (int, PK, Identity)
- `Name` (nvarchar(50), NOT NULL)
- `Email` (nvarchar(100), UNIQUE, NOT NULL)
- `Password` (nvarchar(255), NOT NULL)
- `CreatedAt` (datetime2, DEFAULT GETDATE())
- `IsActive` (bit, NOT NULL)

#### Tablas de Identity (ASP.NET Core Identity)
- `AspNetUsers`, `AspNetRoles`, `AspNetUserRoles`, etc.

### Migraciones
- `20250916024349_InitialCreate` - Migración inicial
- `20250916031513_AddDescriptionProduct` - Agregó descripción a productos
- `20250917212517_AddUsersTable` - Agregó tabla de usuarios

## 🔒 Middleware

### AuthorizationMiddleware
Protege rutas específicas requiriendo autenticación:

```csharp
protected routes: ["/product"]
```

- Verifica sesión activa (`IsLoggedIn`)
- Redirige a `/Account/Login` si no autenticado
- Permite acceso libre a rutas públicas

## 🎨 Características de UI

### Diseño
- **Tema**: Gradientes púrpura con efectos glassmorphism
- **Responsive**: Compatible con móviles y tablets
- **Iconos**: Font Awesome 6.4.0
- **Animaciones**: CSS3 con transiciones suaves

### Efectos Visuales
- Tarjetas con efecto de cristal
- Gradientes animados en hero sections
- Hover effects con transformaciones
- Alertas con iconos contextual

## 🧪 Testing

### Datos de Prueba
El sistema incluye datos de prueba automáticos:

```csharp
// En DbInitializer.cs
Usuarios: 3 usuarios predefinidos
Productos: 3 productos de ejemplo
```

### Escenarios de Prueba
1. **Login exitoso** con credenciales válidas
2. **Login fallido** con credenciales inválidas
3. **Acceso no autorizado** a rutas protegidas
4. **Creación de productos** con validaciones
5. **Navegación** entre páginas

## 📝 Notas de Desarrollo

### Patrones Implementados
- **MVC**: Separación clara de responsabilidades
- **Repository Pattern**: A través de Entity Framework
- **Dependency Injection**: Configurado en Program.cs
- **Session State**: Para manejo de autenticación

### Consideraciones de Seguridad
- ✅ Validación de entrada en modelos
- ✅ Protección CSRF con `[ValidateAntiForgeryToken]`
- ✅ Middleware de autorización personalizado
- ⚠️ Contraseñas en texto plano (solo para demo)
- ⚠️ Sesiones no encriptadas (solo para demo)

### Mejoras Futuras
- 🔐 Hash de contraseñas (BCrypt)
- 🛡️ Tokens JWT para autenticación
- 📧 Confirmación de email
- 🔄 CRUD completo para productos
- 📊 Dashboard con gráficas
- 🛒 Carrito de compras
- 💳 Integración de pagos

## 🤝 Contribuir

1. Fork el proyecto
2. Crea una rama para tu feature (`git checkout -b feature/nueva-caracteristica`)
3. Commit tus cambios (`git commit -am 'Agrega nueva característica'`)
4. Push a la rama (`git push origin feature/nueva-caracteristica`)
5. Abre un Pull Request

## 📄 Licencia

Este proyecto es para fines educativos y de demostración del patrón MVC.

## 👥 Autor

Desarrollado como ejemplo de implementación del patrón MVC en ASP.NET Core.

---

**🚀 ¡Gracias por usar Ecommerce Premium!**
