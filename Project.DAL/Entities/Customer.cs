namespace Project.DAL.Entities
{
    public class Customer
    {
        public int CustomerID { get; set; }

        public string FName { get; set; } = string.Empty;

        public string LName { get; set; } = string.Empty;

        public string FullName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public string Phone { get; set; } = string.Empty;

        public string City { get; set; } = string.Empty;

        public string Street { get; set; } = string.Empty;
    }
}