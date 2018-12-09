using System.ComponentModel.DataAnnotations;

namespace CalcWebApplication.Db
{
    public class MyUser
    {
        public int Id { get; set; }

        [MaxLength(30)]
        public string Login { get; set; }

        [MaxLength(100)]
        public string Password { get; set; }
    }
}
