using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Entities
{
    public class EventRequest
    {
        public int EventRequestID { get; set; }

        public string? LocationType { get; set; } 

        public int NumberOfGuests { get; set; }

        public DateTime EventDate { get; set; }

        public string? Theme { get; set; } 

        public decimal Budget { get; set; }

        public string? AdminResponse { get; set; } 
    }
}
