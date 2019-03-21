using System.ComponentModel.DataAnnotations;

namespace AuthDemo.EF
{
    public class User
    {
        public int Id { get; set; }

        [Required, MaxLength(30)]
        public string Login { get; set; }

        [Required, MaxLength(100)]
        public string PasswordHash { get; set; }
    }
}
