namespace Ecommerce_mvc.Models
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
    }
}

//        public string Name { get; set; } = string.Empty;
//        public string Description { get; set; } = string.Empty;
//        public decimal Price { get; set; }
//        public string ImageUrl { get; set; } = string.Empty;
//        public string Category { get; set; } = string.Empty;
//        public bool IsAvailable { get; set; } = true;
//    }
//}

