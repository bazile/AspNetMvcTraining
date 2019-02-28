using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lesson06.Models
{
    public class WebAddressModel
    {
        [Required]
        public string Address { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
