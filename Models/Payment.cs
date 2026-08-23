namespace ACStore.Models
{
    public class Payment
    {
        public int PaymentID { get; set; }

        public int InstallmentID { get; set; }
        public Installment? Installment { get; set; }

        public DateTime PaymentDate { get; set; } = DateTime.Now;
        public decimal AmountPaid { get; set; }
    }
}
