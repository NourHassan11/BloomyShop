namespace BloomyShop.Models
{
    public class Customer
    {
        // Primary Key
        public int CustomerID { get; set; }

        // Attributes from ERD
        public string FName { get; set; } = string.Empty;

        public string LName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public string Phone { get; set; } = string.Empty;

        // Composite Address (City & Street)
        public string City { get; set; } = string.Empty;

        public string Street { get; set; } = string.Empty;

        // =========================================================================
        // Navigation Properties (Relationships with Team Members)
        // متنعقلة مؤقتاً عشان متجيبش Error لحد ما زميلاتك يعملوا الكلاسات بتاعتهم
        // =========================================================================

        // Member 3 (Nouran) - Customer owns Cart (1-to-1)
        // public Cart? Cart { get; set; }

        // Member 3 (Nouran) - Customer places Orders (1-to-Many)
        // public ICollection<Order> Orders { get; set; } = new List<Order>();

        // Member 2 (Shahd) - Customer creates CustomizedBouquets (1-to-Many)
        // public ICollection<CustomizedBouquet> CustomizedBouquets { get; set; } = new List<CustomizedBouquet>();

        // Member 4 (Nour) - Customer submits EventRequests (1-to-Many)
        // public ICollection<EventRequest> EventRequests { get; set; } = new List<EventRequest>();

        // Member 1 (Nada) - Customer selects Bouquets (Many-to-Many)
        // public ICollection<Bouquet> SelectedBouquets { get; set; } = new List<Bouquet>();
        // =========================================================================
    }
}