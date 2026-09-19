using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Entities
{
    public class DecorationType
    {
        public int DecorationTypeID { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }


        // M : N
        public ICollection<EventRequestDecoration> EventRequestDecorations { get; set; }
            = new List<EventRequestDecoration>();
    }
}