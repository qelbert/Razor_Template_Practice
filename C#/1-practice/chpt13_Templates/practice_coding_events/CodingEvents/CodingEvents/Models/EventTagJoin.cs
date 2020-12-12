using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodingEvents.Models
{
    public class EventTagJoin
    {
        public int EventId { get; set; }
        public Event Event { get; set; }
        public int TagId { get; set; }
        public EventTag Tag { get; set; }


        public EventTagJoin()
        {

        }
    }
}
