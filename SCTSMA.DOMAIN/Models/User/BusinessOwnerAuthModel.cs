namespace SCTSMA.DOMAIN.Models.User
{
    public class BusinessOwnerAuthModel
    {
        public string phone_number { get; set; }
        public string password { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string email { get; set; }

        public string national_id { get; set; }

        public string tin_number { get; set; }

        public string? tin_certificate { get; set; }

        public string? brela_document { get; set; }

        public string? postal_code { get; set; }

        public int status_id { get; set; } = 1;

        public int role_id { get; set; } = 2;
    }
}
