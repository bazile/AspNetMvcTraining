namespace WebApplicationQuizz.Models
{
    public class EditQuestionModel
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public EditAnswerModel[] Answers { get; set; }
    }
}
