using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Entities
{
    public class CustomizedBouquetFlower
    {
        public int CustomizationID { get; set; }

        public CustomizedBouquet CustomizedBouquet { get; set; } = null!;

        public int FlowerID { get; set; }

        public Flower Flower { get; set; } = null!;

        public int Quantity { get; set; }
    }
}
