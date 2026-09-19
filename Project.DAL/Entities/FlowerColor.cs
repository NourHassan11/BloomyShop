using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Entities
{
    public class FlowerColor
    {
        public int FlowerColorID { get; set; }

        public string Color { get; set; } = null!;

        // FK
        public int FlowerID { get; set; }

        public Flower Flower { get; set; } = null!;

        public ICollection<CustomizedBouquet> CustomizedBouquets { get; set; }
            = new List<CustomizedBouquet>();
    }

}
