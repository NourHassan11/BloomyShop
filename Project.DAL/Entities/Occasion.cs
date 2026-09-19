using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Entities
{
    public class Occasion
    {
        public int OccasionID { get; set; }

        public string? Name { get; set; }

        // 1 : M
        public ICollection<EventRequest> EventRequests { get; set; }
            = new List<EventRequest>();
    }
}