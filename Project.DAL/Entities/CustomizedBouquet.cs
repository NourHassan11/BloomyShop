using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Entities
{
    public class CustomizedBouquet
    {
        public int CustomizationID { get; set; }

        public DateTime CreatedAt { get; set; }

        public int PreparationTime { get; set; }

        // M : 1 Customer
        public int CustomerID { get; set; }

        public Customer Customer { get; set; } = null!;

        // M : 1 BouquetSize
        public int SizeID { get; set; }

        public BouquetSize BouquetSize { get; set; } = null!;

        // M : 1 Wrapping
        public int WrappingID { get; set; }

        public Wrapping Wrapping { get; set; } = null!;

        // M : N Flower
        public ICollection<CustomizedBouquetFlower> CustomizedBouquetFlowers { get; set; }
            = new List<CustomizedBouquetFlower>();

        // M : N FlowerColor
        public ICollection<CustomizedBouquetFlowerColor> CustomizedBouquetFlowerColors { get; set; }
            = new List<CustomizedBouquetFlowerColor>();

        // M : N AddOn
        public ICollection<CustomizedBouquetAddOn> CustomizedBouquetAddOns { get; set; }
            = new List<CustomizedBouquetAddOn>();

        // CartItem
        public ICollection<CartItem> CartItems { get; set; }
            = new List<CartItem>();

        // OrderItem
        public ICollection<OrderItem> OrderItems { get; set; }
            = new List<OrderItem>();
    }
}
