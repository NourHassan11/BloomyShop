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
    }
}
