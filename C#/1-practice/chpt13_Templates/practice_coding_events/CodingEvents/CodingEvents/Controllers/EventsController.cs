using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CodingEvents.Models;
using CodingEvents.Data;
using CodingEvents.ViewModels;

namespace CodingEvents.Controllers
{
    public class EventsController : Controller
    {
        //static private List<Event> Events = new List<Event>();


        private EventDbContext context;

        public EventsController(EventDbContext dbContext)
        {
            context = dbContext;
        }
        //[HttpGet]
        public IActionResult Index()
        {
            //Part1 -------------
            //Events.Add("Party in my Living Room");
            //Events.Add("Party in my Kitchen");
            //Events.Add("Party in my Garden Room");

            //Part2 -------------
            //ViewBag.events = EventData.GetAll();
            //return View();

            //Part3 -------------
            //List<Event> events = new List<Event>(EventData.GetAll());

            //Part4 -------------
            List<Event> events = context.Events.ToList();
            return View(events);

        }

        public IActionResult Add()
        {
            AddEventViewModel addEventViewModel = new AddEventViewModel();
            return View(addEventViewModel);
        }

        //Part2 ---------------

        //[HttpPost]
        //[Route("/Events/Add")]
        ////public IActionResult NewEvent(string name, string desc)
        //public IActionResult NewEvent(Event newEvent)
        //{
        //    //Events.Add(new Event(name, desc));
        //    EventData.Add(newEvent);

        //    return Redirect("/Events");
        //}

        //Part3a ----------------

        //[HttpPost]
        //public IActionResult Add(Event newEvent)
        //{
        //    //Events.Add(new Event(name, desc));
        //    EventData.Add(newEvent);

        //    return Redirect("/Events");
        //}

        //Part3b ----------------

        [HttpPost]
        public IActionResult Add(AddEventViewModel addEventViewModel)
        {
            if(ModelState.IsValid)
            {
                Event newEvent = new Event
                {
                    Name = addEventViewModel.Name,
                    Description = addEventViewModel.Description,
                    ContactEmail = addEventViewModel.ContactEmail,
                    Type = addEventViewModel.Type
                };

                //EventData.Add(newEvent);
                context.Events.Add(newEvent);
                context.SaveChanges();

                return Redirect("/Events");
            }

            return View(addEventViewModel);
        }

        public IActionResult Delete()
        {
            //ViewBag.events = EventData.GetAll();
            ViewBag.events = context.Events.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Delete(int[] eventIds)
        {
            foreach(int eventId in eventIds)
            {
                //EventData.Remove(eventId);
                Event theEvent = context.Events.Find(eventId);
                context.Events.Remove(theEvent);
            }

            context.SaveChanges();

            return Redirect("/Events");
        }
    }
}
