using CodingEvents.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CodingEvents.ViewModels
{
    public class AddEventViewModel
    {
        [Required (ErrorMessage = "Event Name is Required")]
        [StringLength(12, MinimumLength =3, ErrorMessage = "Username must be between 3 and 12 characters")]
        public string Name { get; set; }
        [Required (ErrorMessage = "Event Description is Required")]
        [StringLength(250, ErrorMessage = "Description is too long!")]
        public string Description { get; set; }
        [EmailAddress]
        public string ContactEmail { get; set; }
        [Required(ErrorMessage = "Please select a category")]
        public int CategoryId { get; set; }

        public List<SelectListItem> Categories { get; set; }

        public AddEventViewModel(List<EventCategory> categories)
        {
            Categories = new List<SelectListItem>();

            foreach (var category in categories)
            {
                Categories.Add
                (
                    new SelectListItem
                    {
                        Value = category.Id.ToString(),
                        Text = category.Name
                    }
                ); ;
            }
        }

        public AddEventViewModel()
        {
        }

        // Part 1 ---------------------------

        //public EventType Type { get; set; }

        //public List<SelectListItem> EventTypes { get; set; } = new List<SelectListItem>
        //{
        //    new SelectListItem(EventType.Conference.ToString(), ((int)EventType.Conference).ToString()),
        //    new SelectListItem(EventType.Meetup.ToString(), ((int)EventType.Meetup).ToString()),
        //    new SelectListItem(EventType.Workshop.ToString(), ((int)EventType.Workshop).ToString()),
        //    new SelectListItem(EventType.Social.ToString(), ((int)EventType.Social).ToString())
        //};
    }
}
