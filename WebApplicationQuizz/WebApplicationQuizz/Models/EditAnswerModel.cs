using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using DA = System.ComponentModel.DataAnnotations;

namespace WebApplicationQuizz.Models
{
    public class EditAnswerModel
    {
		[HiddenInput(DisplayValue =false)]
		public int Id { get; set; }
		[HiddenInput(DisplayValue = false)]
		public int QuizzId { get; set; }
		[HiddenInput(DisplayValue = false)]
		public int QuestionId { get; set; }
		
		[
            Required(ErrorMessage = "Текст ответа не может быть пустым"),
            Display(Name = "Текст ответа"),
            StringLength(50)
        ]
        public string Text { get; set; }

        [Display(Name = "Комментарий"), StringLength(50)]
        public string Comment { get; set; }

		[Display(Name = "Правильный ответ")]
        public bool Correct { get; set; }
    }
}
