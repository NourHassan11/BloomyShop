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

        public int CustomerID { get; set; }
        public virtual ICollection<CartItem> CartItems { get; set; } = new HashSet<CartItem>();
    }
}