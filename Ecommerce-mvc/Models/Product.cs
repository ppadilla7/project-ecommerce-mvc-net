using System.ComponentModel.DataAnnotations;

namespace Ecommerce_mvc.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre del producto es obligatorio")]
        [StringLength(100, ErrorMessage = "El nombre no puede tener más de 100 caracteres")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "La descripción es obligatoria")]
        [StringLength(500, ErrorMessage = "La descripción no puede tener más de 500 caracteres")]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "El precio es obligatorio")]
        [Range(0.01, 999999.99, ErrorMessage = "El precio debe estar entre $0.01 y $999,999.99")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "La URL de la imagen es obligatoria")]
        [Url(ErrorMessage = "Por favor, ingresa una URL válida")]
        public string ImageUrl { get; set; } = string.Empty;
    }
}