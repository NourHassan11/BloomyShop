using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Entities
{
    public class Flower
    {
        public int FlowerID { get; set; }

        public string Name { get; set; } = null!;

        public decimal BasePrice { get; set; }

        public int Quantity { get; set; }

        public string Image { get; set; } = null!;

        // 1:M with FlowerColor
        public ICollection<FlowerColor> FlowerColors { get; set; }
            = new List<FlowerColor>();

        // M:N with Bouquet
        public ICollection<BouquetFlower> BouquetFlowers { get; set; }
            = new List<BouquetFlower>();

        // CustomizedBouquet
        //public ICollection<CustomizedBouquet> CustomizedBouquets { get; set; }
        //    = new List<CustomizedBouquet>();
        public ICollection<CustomizedBouquetFlower> CustomizedBouquetFlowers { get; set; }
    = new List<CustomizedBouquetFlower>();
    }
}
