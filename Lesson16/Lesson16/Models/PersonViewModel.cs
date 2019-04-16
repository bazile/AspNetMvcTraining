using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lesson16.Models
{
    public class PersonViewModel
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        [Display(Name="Имя")]
        public string Name { get; set; }
        [Display(Name = "Дата рождения")]
        public DateTime BirthDate { get; set; }
    }
}
