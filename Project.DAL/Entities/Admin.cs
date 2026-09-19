namespace Project.DAL.Entities
{

    public class Admin
    {
        public int AdminID { get; set; }

        public string FullName { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;




        // Relationship
        public virtual ICollection<EventRequest> ReviewedEventRequests { get; set; }
            = new List<EventRequest>();
    }
}
