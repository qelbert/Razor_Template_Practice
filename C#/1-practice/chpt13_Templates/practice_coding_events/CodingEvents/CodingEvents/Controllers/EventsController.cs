using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CodingEvents.Models;
using CodingEvents.Data;

namespace CodingEvents.Controllers
{
    public class EventsController : Controller
    {
        //static private List<Event> Events = new List<Event>();


        [HttpGet]
        public IActionResult Index()
        {
            //Events.Add("Party in my Living Room");
            //Events.Add("Party in my Kitchen");
            //Events.Add("Party in my Garden Room");
            ViewBag.events = EventData.GetAll();
            return View();
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [Route("/Events/Add")]
        //public IActionResult NewEvent(string name, string desc)
        public IActionResult NewEvent(Event newEvent)
        {
            //Events.Add(new Event(name, desc));
            EventData.Add(newEvent);

            return Redirect("/Events");
        }

        public IActionResult Delete()
        {
            ViewBag.events = EventData.GetAll();
            return View();
        }

        [HttpPost]
        public IActionResult Delete(int[] eventIds)
        {
            foreach(int eventId in eventIds)
            {
                EventData.Remove(eventId);
            }

            return Redirect("/Events");
        }
    }
}
