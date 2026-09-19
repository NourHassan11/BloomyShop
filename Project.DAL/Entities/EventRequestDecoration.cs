using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Entities
{
    public class EventRequestDecoration
    {
        public int EventRequestId { get; set; }
        public EventRequest EventRequest { get; set; }


        public int DecorationTypeId { get; set; }
        public DecorationType DecorationType { get; set; }
    }
}
