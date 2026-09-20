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

        // M : 1 Customer
        public int CustomerID { get; set; }

        public Customer Customer { get; set; } = null!;

        // M : 1 Occasion
        public int OccasionID { get; set; }

        public Occasion Occasion { get; set; } = null!;

        // M : 1 Admin
        public int? AdminID { get; set; }

        public Admin? Admin { get; set; }

        // M : N DecorationType
        public ICollection<EventRequestDecoration> EventRequestDecorations { get; set; }
            = new List<EventRequestDecoration>();
    }
}