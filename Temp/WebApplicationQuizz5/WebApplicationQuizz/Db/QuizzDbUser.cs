using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplicationQuizz.Db
{
    public class QuizzDbUser
    {
        public QuizzDbUser()
        {
            QuizzTaken = new HashSet<QuizzDbHistory>();
        }

        public int Id { get; set; }

        [Required, MaxLength(30)]
        public string Login { get; set; }

        //[Required, MaxLength(50)]
        //public string Password { get; set; }

        [Required, MaxLength(20)]
        public string PasswordSalt { get; set; }

        [Required, MaxLength(100)]
        public string PasswordHash { get; set; }

        public virtual ICollection<QuizzDbHistory> QuizzTaken { get; set; }
    }
}