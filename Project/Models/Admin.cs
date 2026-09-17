namespace BloomyShop.Models
{
    public class Admin
    {
        public int AdminID { get; set; }

        public string FullName { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;
    }
}