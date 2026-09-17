using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.DAL.Entities
{
    public class CartItem
    {
        [Key]
        public int CartItemID { get; set; }

        public int Quantity { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal UnitPrice { get; set; }
        public int CartID { get; set; }

        [ForeignKey("CartID")]
        public virtual Cart? Cart { get; set; }

        public int? BouquetID { get; set; }
        public int? CustomizedBouquetID { get; set; }
    }
}