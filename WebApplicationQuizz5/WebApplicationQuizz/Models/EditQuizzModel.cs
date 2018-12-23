using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplicationQuizz.Models
{
    public class EditQuizzModel
    {
        public int Id { get; set; }
        public string OriginalName { get; set; }
        public string CurrentName { get; set; }
    }
}