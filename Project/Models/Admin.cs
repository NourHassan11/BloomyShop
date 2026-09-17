namespace BloomyShop.Models
{
    public class Admin
    {
        // Primary Key
        public int AdminID { get; set; }

        // Attributes from ERD
        public string FullName { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        // =========================================================================
        // Navigation Properties (Relationships with Team Members)
        // متنعقلة مؤقتاً عشان متجيبش Error لحد ما نور تعمل الكلاس بتاعها
        // =========================================================================

        // Member 4 (Nour) - Admin reviews EventRequests (1-to-Many)
        // public ICollection<EventRequest> EventRequests { get; set; } = new List<EventRequest>();
        // =========================================================================
    }
}