using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Entities
{
    public class BouquetSize
    {
        public int BouquetSizeID { get; set; }

        public string Name { get; set; } = string.Empty;

        public decimal AdditionalPrice { get; set; }
    }
}
