using System.ComponentModel.DataAnnotations;

namespace AuthDemo.EF
{
    public class User
    {
        public int Id { get; set; }

        [Required, MaxLength(30)]
        public string Login { get; set; }

        [Required, MaxLength(40)]
        public string PasswordHash { get; set; }

        [Required, MaxLength(16)]
        public string Salt { get; set; }
    }
}
