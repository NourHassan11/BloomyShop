using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Entities
{
    public class EventRequestDecoration
    {
        public int EventRequestID { get; set; }
        public EventRequest EventRequest { get; set; } = null!;

        public int DecorationTypeID { get; set; }
        public DecorationType DecorationType { get; set; } = null!;
    }
}
