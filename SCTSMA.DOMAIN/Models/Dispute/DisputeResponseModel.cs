namespace SCTSMA.DOMAIN.Models.Dispute
{
    public class DisputeResponseModel
    {
        public int dispute_id { get; set; }
        public int order_id { get; set; }
        public string customer_phone { get; set; }
        public string? customer_first_name { get; set; }
        public string? customer_last_name { get; set; }
        public string seller_phone { get; set; }
        public string? seller_first_name { get; set; }
        public string? seller_last_name { get; set; }
        public string description { get; set; }
        public int status_id { get; set; }
        public DateTime filed_at { get; set; }
        public DateTime? resolved_at { get; set; }
    }
}
