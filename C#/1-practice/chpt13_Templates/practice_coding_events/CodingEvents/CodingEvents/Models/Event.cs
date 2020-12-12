﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodingEvents.Models
{
    public class Event
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ContactEmail { get; set; }
        public EventCategory Category { get; set; }
        public int CategoryId { get; set; }
        public int Id { get; set; }

        //public EventType Type { get; set; }

        //public int Id { get;}
        //private static int nextId = 1;
        

        public Event()
        {
            //Id = nextId;
            //nextId++;
        }
        //public Event (string name, string description, string contactEmail) : this()
        public Event(string name, string description, string contactEmail)
        {
            Name = name;
            Description = description;
            ContactEmail = contactEmail;
        }


        public override string ToString()
        {
            return Name;
        }

        public override bool Equals(object obj)
        {
            return obj is Event @event &&
                   Id == @event.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }
}
