using System.ComponentModel.DataAnnotations;

namespace ACStore.Models
{
    public enum PaymentType
    {
        Cash,
        Installment
    }

    public class Order
    {
        public int OrderID { get; set; }

        [Required(ErrorMessage = "الاسم مطلوب")]
        [StringLength(100)]
        public string CustomerName { get; set; } = string.Empty;

        [Required(ErrorMessage = "رقم التليفون مطلوب")]
        [Phone(ErrorMessage = "رقم تليفون غير صحيح")]
        public string CustomerPhone { get; set; } = string.Empty;

        [EmailAddress(ErrorMessage = "بريد إلكتروني غير صحيح")]
        public string? CustomerEmail { get; set; }

        [StringLength(250)]
        public string? CustomerAddress { get; set; }

        public int ProductID { get; set; }
        public Product? Product { get; set; }

        public DateTime OrderDate { get; set; } = DateTime.Now;

        public PaymentType PaymentType { get; set; }

        public decimal TotalAmount { get; set; }

      
        public decimal? DownPayment { get; set; }
        public int? DurationMonths { get; set; }

        public List<Installment> Installments { get; set; } = new();
    }
}
