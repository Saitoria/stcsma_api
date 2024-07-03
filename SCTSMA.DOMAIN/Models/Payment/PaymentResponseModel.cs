namespace SCTSMA.DOMAIN.Models.Payment
{
    public class PaymentResponseModel
    {
        public int payment_id { get; set; }
        public int order_id { get; set; }
        public string payment_provider_phone { get; set; }
        public string? payment_first_name { get; set; }
        public string? payment_last_name { get; set; }
        public decimal amount { get; set; }
        public decimal transaction_cost { get; set; } = 0.00M;
        public int status_id { get; set; }
        public DateTime? authorized_at { get; set; }
        public DateTime? held_until { get; set; }
        public DateTime? completed_at { get; set; }
        public string? customer_phone { get; set; }
        public string? seller_phone { get; set; }
        public string? customer_first_name { get; set; }
        public string? customer_last_name { get; set; }
        public string? seller_first_name { get; set; }
        public string? seller_last_name { get; set; }
    }
}
