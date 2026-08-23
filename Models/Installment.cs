namespace ACStore.Models
{
    public class Installment
    {
        public int InstallmentID { get; set; }

        public int OrderID { get; set; }
        public Order? Order { get; set; }

        public int InstallmentNumber { get; set; } 
        public DateTime DueDate { get; set; }
        public decimal Amount { get; set; }
        public bool IsPaid { get; set; } = false;
        public DateTime? PaidDate { get; set; }

        public List<Payment> Payments { get; set; } = new();
    }
}
