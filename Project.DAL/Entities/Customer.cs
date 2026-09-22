namespace Project.DAL.Entities
{
    public class Customer
    {
        public int CustomerID { get; set; }

        public string FName { get; set; } = string.Empty;

        public string Lname { get; set; } = string.Empty;

        public string FullName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public string Phone { get; set; } = string.Empty;

        public string City { get; set; } = string.Empty;

        public string street { get; set; } = string.Empty;

        // 1:1 with Cart
        public Cart? Cart { get; set; }

        // 1:M with Order
        public ICollection<Order> Orders { get; set; }
            = new List<Order>();

        // 1:M with CustomizedBouquet
        public ICollection<CustomizedBouquet> CustomizedBouquets { get; set; }
            = new List<CustomizedBouquet>();

        // 1:M with EventRequest
        public ICollection<EventRequest> EventRequests { get; set; }
            = new List<EventRequest>();

        // M:N with Bouquet
        public ICollection<CustomerBouquet> CustomerBouquets { get; set; }
            = new List<CustomerBouquet>();
    }
}


