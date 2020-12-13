using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodingEvents.Data;
using CodingEvents.Models;
using CodingEvents.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        public IActionResult Add(AddTagViewModel addTagViewModel)
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

        public IActionResult AddEvent(int id)
        {
            Event theEvent = context.Events.Find(id);
            List<EventTag> possibleTags = context.EventTags.ToList();

            AddEventTagViewModel viewModel = new AddEventTagViewModel(theEvent, possibleTags);
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult AddEvent(AddEventTagViewModel viewModel)
        {
           if (ModelState.IsValid)
            {
               int eventId = viewModel.EventId;
                int tagId = viewModel.TagId;

                List<EventTagJoin> existingItems = context.EventTagsJoined
                    .Where(evt => evt.EventId == eventId)
                    .Where(evt => evt.TagId == tagId)
                    .ToList();

                if (existingItems.Count == 0)
                {
                    EventTagJoin eventTag = new EventTagJoin
                    {
                        EventId = eventId,
                        TagId = tagId
                    };

                    context.EventTagsJoined.Add(eventTag);
                    context.SaveChanges();
                }

                return Redirect("/Events/Detail/" + eventId);
    
            }
           
            return View(viewModel);
        }

        public IActionResult Detail(int id)
        {
            List<EventTagJoin> eventTags = context.EventTagsJoined
                .Where(evt => evt.TagId == id)
                .Include(evt => evt.Event)
                .Include(evt => evt.Tag)
                .ToList();

            return View(eventTags);
        }

    }
}
