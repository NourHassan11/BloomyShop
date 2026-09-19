using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Entities
{
    public class CustomerBouquet
    {
        public int CustomerID { get; set; }

        public Customer Customer { get; set; } = null!;

        public int ProductID { get; set; }

        public Bouquet Bouquet { get; set; } = null!;
    }
}
