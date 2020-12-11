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
    public class EventCategoryController : Controller
    {

        private EventDbContext context;

        public EventCategoryController (EventDbContext dbContext)
        {
            context = dbContext;
        }
        public IActionResult Index()
        {
            List<EventCategory> eventCategories = context.EventCategories.ToList();
            return View(eventCategories);
        }

        [HttpGet]
        public IActionResult Create()
        {
            AddEventCategoryViewModel addEventCategoryViewModel = new AddEventCategoryViewModel();
            return View(addEventCategoryViewModel);
        }

        [HttpPost]
        //[Route("/ProcessCategory")]
        public IActionResult ProcessCreateEventCategoryForm(AddEventCategoryViewModel addEventCategory)
        {
            if (ModelState.IsValid)
            {
                EventCategory newCategory = new EventCategory
                {
                    Name = addEventCategory.Name
                };

                context.EventCategories.Add(newCategory);
                context.SaveChanges();

                return Redirect ("Index");
            }

            return View("Create", addEventCategory);
        }

    }
}
