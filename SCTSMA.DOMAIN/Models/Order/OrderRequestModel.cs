namespace SCTSMA.DOMAIN.Models.Order
{
    public class OrderRequestModel
    {
        public int? order_id { get; set; }
        public string seller_phone { get; set; }
        public string customer_phone { get; set; }
        public string payment_provider_phone { get; set; }
        public int product_id { get; set; }
        public int quantity { get; set; }
        public int status_id { get; set; } = 3;
    }
}
