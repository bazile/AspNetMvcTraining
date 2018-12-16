using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplicationQuizz.Db
{
    public class QuizzDbHistory
    {
        public int Id { get; set; }

        //[MaxLength(30)]
        //public string Login { get; set; }

        public QuizzDbUser User { get; set; }

        [MaxLength(200)]
        public string QuizzName { get; set; }

        [MaxLength(100)]
        public string QuizzResult { get; set; }

        public DateTime QuizzDate { get; set; }
    }
}