using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.DAL.Entities
{
    public class OrderItem
    {
        [Key]
        public int OrderItemID { get; set; }

        public int Quantity { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal UnitPrice { get; set; }

        // M : 1 Order
        public int OrderID { get; set; }
        [ForeignKey("OrderID")]
        public virtual Order? Order { get; set; }

        // M : 1 Bouquet (Nullable)
        public int? BouquetID { get; set; }
        [ForeignKey("BouquetID")]
        public virtual Bouquet? Bouquet { get; set; }

        // M : 1 CustomizedBouquet (Nullable)
        public int? CustomizedBouquetID { get; set; }
        [ForeignKey("CustomizedBouquetID")]
        public virtual CustomizedBouquet? CustomizedBouquet { get; set; }
    }
}