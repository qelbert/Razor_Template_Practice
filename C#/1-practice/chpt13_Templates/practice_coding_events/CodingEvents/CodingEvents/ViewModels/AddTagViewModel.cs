using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CodingEvents.ViewModels
{
    public class AddTagViewModel
    {
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Tag name must be between 3 and 20 characters")]
        public string Name { get; set; }
    }
}
