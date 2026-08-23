using System.ComponentModel.DataAnnotations;

namespace ACStore.Models
{
    public enum ProductType
    {
        AirConditioner,
        WaterFilter
    }

    public class Product
    {
        public int ProductID { get; set; }

        [Required(ErrorMessage = "اسم المنتج مطلوب")]
        [StringLength(150)]
        public string Name { get; set; } = string.Empty;

        public ProductType Type { get; set; }

        [StringLength(1000)]
        public string? Description { get; set; }

        [Range(0, 1000000, ErrorMessage = "السعر لازم يكون رقم موجب")]
        public decimal Price { get; set; }

        [Range(0, 100000)]
        public int StockQuantity { get; set; }

      
        public string? ImageFileName { get; set; }

        public bool IsAvailable => StockQuantity > 0;
    }
}
