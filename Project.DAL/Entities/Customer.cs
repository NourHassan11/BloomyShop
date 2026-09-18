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
        ///
        public Cart Cart { get; set; }


        // 1 : M
        public ICollection<Order> Orders { get; set; }
            = new List<Order>();


        // 1 : M
        public ICollection<CustomizedBouquet> CustomizedBouquets { get; set; }
            = new List<CustomizedBouquet>();


        // 1 : M
        public ICollection<EventRequest> EventRequests { get; set; }
            = new List<EventRequest>();


        // M : N
        public ICollection<CustomerBouquet> CustomerBouquets { get; set; }
            = new List<CustomerBouquet>();
    }
}





