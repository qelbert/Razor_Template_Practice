﻿using CodingEvents.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodingEvents.ViewModels
{
    public class AddEventDetailViewModel
    {
        public int EventId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ContactEmail { get; set; }
        public string CategoryName { get; set; }
        public string TagText { get; set; }
        
        public AddEventDetailViewModel(Event theEvent, List<EventTagJoin> eventTags)
        {
            EventId = theEvent.Id;
            Name = theEvent.Name;
            Description = theEvent.Description;
            ContactEmail = theEvent.ContactEmail;
            CategoryName = theEvent.Category.Name;

            TagText = "";

            for (var i=0; i<eventTags.Count; i++)
            {
                TagText += "#" + eventTags[i].Tag.Name;

                if (i <eventTags.Count - 1)
                {
                    TagText += ", ";
                }
            }
        }

    }
}
