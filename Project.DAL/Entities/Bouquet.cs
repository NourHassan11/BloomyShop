using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Entities
{
    public class Bouquet
    {
        public int BouquetID { get; set; }

        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        public string Image { get; set; } = null!;

        //public string Size { get; set; } = null!;

        public string PreparationTime { get; set; } = null!;

        public decimal Price { get; set; }

        public bool IsActive { get; set; }

        // FK
        public int SizeID { get; set; }

        public BouquetSize BouquetSize { get; set; } = null!;

        // M:N with Flower
        public ICollection<BouquetFlower> BouquetFlowers { get; set; }
            = new List<BouquetFlower>();

        // M:N with Customer
        public ICollection<CustomerBouquet> CustomerBouquets { get; set; }
            = new List<CustomerBouquet>();

        // OrderItem
        public ICollection<OrderItem> OrderItems { get; set; }
            = new List<OrderItem>();

        // CartItem
        public ICollection<CartItem> CartItems { get; set; }
            = new List<CartItem>();
    }
}
