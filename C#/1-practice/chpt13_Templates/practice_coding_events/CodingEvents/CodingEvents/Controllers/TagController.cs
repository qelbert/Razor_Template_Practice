using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodingEvents.Data;
using CodingEvents.Models;
using CodingEvents.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CodingEvents.Controllers
{
    public class TagController : Controller
    {

        private EventDbContext context;

        public TagController (EventDbContext dbContext)
        {
            context = dbContext;
        }
        public IActionResult Index()
        {
            List<EventTag> eventTags = context.EventTags.ToList();
            //List<EventCategory> eventTags = context.EventTags.ToList();
            return View(eventTags);
        }

        [HttpGet]
        public IActionResult Create()
        {
            AddTagViewModel addTagViewModel = new AddTagViewModel();
            return View(addTagViewModel);
        }

        [HttpPost]
        //[Route("/ProcessCategory")]
        public IActionResult ProcessCreateTagForm(AddTagViewModel addTagViewModel)
        {
            if (ModelState.IsValid)
            {
                EventTag newTag = new EventTag
                {
                    Name = addTagViewModel.Name
                };

                context.EventTags.Add(newTag);
                context.SaveChanges();

                return Redirect ("Index");
            }

            return View("Create", addTagViewModel);
        }

    }
}
