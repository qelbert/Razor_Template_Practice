using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CodingEvents.Controllers
{
    public class EventsController : Controller
    {
        static private List<string> Events = new List<string>();

        [HttpGet]
        public IActionResult Index()
        {
            //Events.Add("Party in my Living Room");
            //Events.Add("Party in my Kitchen");
            //Events.Add("Party in my Garden Room");
            ViewBag.events = Events;
            return View();
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [Route("/Events/Add")]
        public IActionResult NewEvent(string name)
        {
            Events.Add(name);
            return Redirect("/Events");
        }
    }
}
