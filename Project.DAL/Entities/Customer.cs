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

        ////////////////////////
        // 1-to-1: Customer owns Cart
        public Cart? Cart { get; set; }

        // 1-to-Many: Customer places Orders
        public ICollection<Order> Orders { get; set; } = new List<Order>();

        // 1-to-Many: Customer creates CustomizedBouquets
        public ICollection<CustomizedBouquet> CustomizedBouquets { get; set; }
            = new List<CustomizedBouquet>();

        // 1-to-Many: Customer submits EventRequests
        public ICollection<EventRequest> EventRequests { get; set; }
            = new List<EventRequest>();

        // Many-to-Many: Customer selects Ready-Made Bouquets
        public ICollection<CustomerBouquet> CustomerBouquets { get; set; }
            = new List<CustomerBouquet>();
    }
}


