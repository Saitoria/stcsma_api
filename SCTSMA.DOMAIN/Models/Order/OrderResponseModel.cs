namespace SCTSMA.DOMAIN.Models.Order
{
    public class OrderResponseModel
    {
        public int order_id { get; set; }
        public string seller_phone { get; set; }
        public string customer_phone { get; set; }
        public string? seller_first_name { get; set; }
        public string? seller_last_name { get; set; }
        public string? customer_first_name { get; set; }
        public string? customer_last_name { get; set; }
        public int product_id { get; set; }
        public string? product_name { get; set; }
        public int quantity { get; set; }
        public int status_id { get; set; }
        public DateTime created_at { get; set; }
        public DateTime expires_at { get; set; }
    }
}
