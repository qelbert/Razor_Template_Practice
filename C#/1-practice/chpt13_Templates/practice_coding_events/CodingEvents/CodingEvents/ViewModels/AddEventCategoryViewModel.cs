using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CodingEvents.ViewModels
{
    public class AddEventCategoryViewModel
    {
        [Required(ErrorMessage = "Event Name is Required")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Category name must be between 3 and 12 characters")]
        public string Name { get; set; }
    }
}
