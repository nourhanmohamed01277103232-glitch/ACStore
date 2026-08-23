using ACStore.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ACStore.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<Order> Orders { get; set; } = null!;
        public DbSet<Installment> Installments { get; set; } = null!;
        public DbSet<Payment> Payments { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
          

            builder.Entity<Product>().Property(p => p.Price).HasColumnType("decimal(18,2)");
            builder.Entity<Order>().Property(o => o.TotalAmount).HasColumnType("decimal(18,2)");
            builder.Entity<Order>().Property(o => o.DownPayment).HasColumnType("decimal(18,2)");
            builder.Entity<Installment>().Property(i => i.Amount).HasColumnType("decimal(18,2)");
            builder.Entity<Payment>().Property(p => p.AmountPaid).HasColumnType("decimal(18,2)");



            builder.Entity<Product>().HasData(
                new Product { ProductID = 1, Name = "تكييف شارب 1.5 حصان بارد فقط", Type = ProductType.AirConditioner, Description = "تكييف اقتصادي موفر للطاقة، مناسب للغرف المتوسطة.", Price = 14500, StockQuantity = 12, ImageFileName = "ac1.jpg" },
                new Product { ProductID = 2, Name = "تكييف كاريير 2.25 حصان بارد وساخن", Type = ProductType.AirConditioner, Description = "تكييف بقدرة تبريد وتدفئة، مناسب للشتاء والصيف.", Price = 22900, StockQuantity = 7, ImageFileName = "ac2.jpg" },
                new Product { ProductID = 3, Name = "فلتر مياه 5 مراحل", Type = ProductType.WaterFilter, Description = "فلتر منزلي 5 مراحل تنقية، سهل التركيب والصيانة.", Price = 3200, StockQuantity = 25, ImageFileName = "filter1.jpg" },
                new Product { ProductID = 4, Name = "فلتر مياه 7 مراحل مع مضخة", Type = ProductType.WaterFilter, Description = "فلتر متطور 7 مراحل مع مضخة ضغط لتحسين تدفق المياه.", Price = 4800, StockQuantity = 15, ImageFileName = "filter2.jpg" }
            );
        }
    }
}
