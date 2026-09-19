using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Entities
{
    public class CustomizedBouquetAddOn
    {
        public int CustomizationID { get; set; }

        public CustomizedBouquet CustomizedBouquet { get; set; } = null!;

        public int AddOnID { get; set; }

        public AddOn AddOn { get; set; } = null!;
    }
}
