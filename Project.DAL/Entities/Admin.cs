namespace Project.DAL.Entities
{

    public class Admin
    {
        public int AdminID { get; set; }

        public string FullName { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;



        // =========================================================
        // Navigation Properties (Member 5 - Admin Relationships)
        // =========================================================

        public ICollection<EventRequest> EventRequests { get; set; }
        = new List<EventRequest>();

        // Relationship
        public virtual ICollection<EventRequest> ReviewedEventRequests { get; set; }
            = new List<EventRequest>();
    }
}
