using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Entities
{
    public class BouquetSize
    {
        public int SizeID { get; set; }

        public string size { get; set; } = null!;

        public decimal BasePrice { get; set; }

        public ICollection<Bouquet> Bouquets { get; set; }
            = new List<Bouquet>();

        public ICollection<CustomizedBouquet> CustomizedBouquets { get; set; }
            = new List<CustomizedBouquet>();
    }
}
