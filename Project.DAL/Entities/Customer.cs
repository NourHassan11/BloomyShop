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

   
        // Relationships
        public virtual Cart? Cart { get; set; }

        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

        public virtual ICollection<CustomizedBouquet> CustomizedBouquets { get; set; } = new List<CustomizedBouquet>();

        public virtual ICollection<EventRequest> EventRequests { get; set; } = new List<EventRequest>();

        public virtual ICollection<Bouquet> SelectedBouquets { get; set; } = new List<Bouquet>();
    }
}





