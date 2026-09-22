using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Project.DAL.Entities
{
    public class Cart
    {
        [Key]
        public int CartID { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        // 1 : 1 Relation with Customer
        public int CustomerID { get; set; }
        public virtual Customer Customer { get; set; } = null!;
        // 1 : M Relation with CartItem
        public virtual ICollection<CartItem> CartItems { get; set; } = new HashSet<CartItem>();
    }
}