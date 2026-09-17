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

        // =========================================================
        // Navigation Properties (Member 5 - Customer Relationships)
        // =========================================================

        // 1-to-1: Customer owns Cart (Will be un-commented when Nouran adds Cart.cs)
        // public Cart? Cart { get; set; }

        // 1-to-Many: Customer places Orders (Will be un-commented when Nouran adds Order.cs)
        // public ICollection<Order> Orders { get; set; } = new List<Order>();

        // 1-to-Many: Customer creates CustomizedBouquets (Will be un-commented when Shahd adds CustomizedBouquet.cs)
        // public ICollection<CustomizedBouquet> CustomizedBouquets { get; set; } = new List<CustomizedBouquet>();

        // 1-to-Many: Customer submits EventRequests (Will be un-commented when Nour adds EventRequest.cs)
        // public ICollection<EventRequest> EventRequests { get; set; } = new List<EventRequest>();

        // Many-to-Many: Customer selects Ready-Made Bouquets (Will be un-commented when Nada adds Bouquet.cs)
        // public ICollection<Bouquet> SelectedBouquets { get; set; } = new List<Bouquet>();
    }
}