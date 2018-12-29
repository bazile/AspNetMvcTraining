using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace WebApplicationQuizz.Models
{
    public class RegisterUserModel
    {
        [
            Display(Name = "Имя пользователя"),
            Required,
            StringLength(30),
            Remote("CheckUserName", "AuthReg", HttpMethod = "post", ErrorMessage = "Имя уже используется")
        ]
        public string User { get; set; }

        [
            Display(Name = "Пароль"),
            Required,
            StringLength(100, MinimumLength = 6),
            DataType(DataType.Password)
        ]
        public string Pass { get; set; }
    }
}
