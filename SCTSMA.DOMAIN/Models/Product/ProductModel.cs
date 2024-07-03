namespace SCTSMA.DOMAIN.Models.Product
{
    public class ProductModel
    {
        public int product_id { get; set; }
        public string product_name { get; set; }
        public string? seller_phone { get; set; }
        public string product_image { get; set; }
        public decimal product_price { get; set; }
        public DateTime created_at { get; set; }
        public string product_description { get; set; }
        public int status_id { get; set; }
    }
}
