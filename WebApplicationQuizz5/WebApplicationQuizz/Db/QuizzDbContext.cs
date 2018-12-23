using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplicationQuizz.Db
{
    public class QuizzDbContext:DbContext
    {
        public QuizzDbContext(): base("name=QuizzConnStr")
        {

        }
        public virtual DbSet<QuizzDbUser> QuizzUsers { get; set; }
        public virtual DbSet<QuizzDbHistory> QuizzUsersHistory { get; set; }
    }
}