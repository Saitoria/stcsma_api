namespace SCTSMA.DOMAIN.Models.User
{
    public class UserLoginResModel
    {
        
        public string phone_number { get; set; }
        public string password { get; set; }
        public int role_id { get; set; }
        public string? first_name { get; set; }
        public string? last_name { get; set; }
        public string email { get; set; }
        public string national_id { get; set; }
        public string? tin_number { get; set; }
        public string? tin_certificate { get; set; }
        public string? tax_clearance { get; set; }
        public string? brela_document { get; set; }
        public string? postal_code { get; set; }
        public string? address { get; set; }
        public string? location { get; set; }
        public string? otp { get; set; }
        public int status_id { get; set; } = 1;
        public string role_name { get; set; }
    }
}
