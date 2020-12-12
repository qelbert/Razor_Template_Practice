using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodingEvents.Models
{
    public class EventTag
    {
        public string Name { get; set; }

        //public List<Event> Events { get; set; }
        public int Id { get; set; }

        public EventTag()
        {
        }

        public EventTag(string name)
        {
            Name = name;
        }
    }
}
