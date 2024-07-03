namespace SCTSMA.DOMAIN.Models.Payment
{
    public class PaymentRequestModel
    {
        public int? payment_id { get; set; }
        public int order_id { get; set; }
        public string payment_provider_phone { get; set; }
        public string? customer_phone { get; set; }
        public string? seller_phone { get; set; }
        public decimal amount { get; set; } = 0;
        public decimal transaction_cost { get; set; } = 0.00M;
        public int status_id { get; set; } = 4;
        public DateTime? authorized_at { get; set; }
        public DateTime? held_until { get; set; }
        public DateTime? completed_at { get; set; }
    }
}
