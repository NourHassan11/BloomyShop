using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Entities
{
    public class BouquetFlower
    {
        public int ProductID { get; set; }

        public Bouquet Bouquet { get; set; } = null!;

        public int FlowerID { get; set; }

        public Flower Flower { get; set; } = null!;
    }
}
